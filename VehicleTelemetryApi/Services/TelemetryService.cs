using Microsoft.EntityFrameworkCore;
using VehicleTelemetryApi.Data;
using VehicleTelemetryApi.Models;

namespace VehicleTelemetryApi.Services
{
    /// <summary>
    /// Implements telemetry data persistence and retrieval operations.
    /// </summary>
    public class TelemetryService : ITelemetryService
    {
        private readonly TelemetryDbContext _context;

        public TelemetryService(TelemetryDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a new telemetry record to the database.
        /// </summary>
        public async Task AddAsync(TelemetryRecord record)
        {
            await _context.TelemetryRecords.AddAsync(record);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Retrieves the most recent telemetry record for a given device.
        /// </summary>
        public async Task<TelemetryRecord?> GetLatestAsync(Guid deviceId)
        {
            return await _context.TelemetryRecords
                .AsNoTracking()
                .Where(t => t.DeviceId == deviceId)
                .OrderByDescending(t => t.Timestamp)
                .FirstOrDefaultAsync();
        }
    }
}
