using Microsoft.EntityFrameworkCore;
using VehicleTelemetryApi.Data;

namespace VehicleTelemetryApi.Background
{
    /// <summary>
    /// Background service responsible for periodically sending telemetry data to the cloud.
    /// </summary>
    public class TelemetryBackgroundService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<TelemetryBackgroundService> _logger;

        public TelemetryBackgroundService(
            IServiceScopeFactory scopeFactory,
            ILogger<TelemetryBackgroundService> logger)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using var scope = _scopeFactory.CreateScope();
                    var db = scope.ServiceProvider.GetRequiredService<TelemetryDbContext>();

                    var latestRecords = await db.TelemetryRecords
                        .AsNoTracking()
                        .OrderByDescending(t => t.Timestamp)
                        .Take(5)
                        .ToListAsync(stoppingToken);

                    foreach (var record in latestRecords)
                    {
                        _logger.LogInformation(
                            "Sending data to Cloud for Device {DeviceId}", record.DeviceId);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(
                        ex,
                        "Unhandled exception in TelemetryBackgroundService");
                }

                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }
    }
}
