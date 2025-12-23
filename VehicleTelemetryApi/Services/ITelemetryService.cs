using VehicleTelemetryApi.Models;

namespace VehicleTelemetryApi.Services
{
    /// <summary>
    /// Provides operations for managing vehicle telemetry data.
    /// </summary>
    public interface ITelemetryService
    {
        /// <summary>
        /// Adds a new telemetry record to the system.
        /// </summary>
        /// <param name="record">Telemetry record to persist.</param>
        Task AddAsync(TelemetryRecord record);

        /// <summary>
        /// Retrieves the most recent telemetry record for a specific device.
        /// </summary>
        /// <param name="deviceId">Unique identifier of the telemetry device.</param>
        /// <returns>
        /// The latest <see cref="TelemetryRecord"/> if found; otherwise, <c>null</c>.
        /// </returns>
        Task<TelemetryRecord?> GetLatestAsync(Guid deviceId);
    }
}
