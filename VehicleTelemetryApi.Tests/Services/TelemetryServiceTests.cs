using Microsoft.EntityFrameworkCore;
using VehicleTelemetryApi.Data;
using VehicleTelemetryApi.Models;
using VehicleTelemetryApi.Services;

namespace VehicleTelemetryApi.Tests.Services
{
    public class TelemetryServiceTests
    {
        [Fact]
        public async Task GetLatestAsync_ReturnsLatestRecord()
        {
            var options = new DbContextOptionsBuilder<TelemetryDbContext>()
                .UseInMemoryDatabase("TelemetryTestDb")
                .Options;

            using var context = new TelemetryDbContext(options);
            var service = new TelemetryService(context);

            var deviceId = Guid.NewGuid();

            await service.AddAsync(new TelemetryRecord
            {
                DeviceId = deviceId,
                Timestamp = DateTimeOffset.UtcNow.AddMinutes(-5),
                EngineRPM = 1000
            });

            await service.AddAsync(new TelemetryRecord
            {
                DeviceId = deviceId,
                Timestamp = DateTimeOffset.UtcNow,
                EngineRPM = 2000
            });

            var result = await service.GetLatestAsync(deviceId);

            Assert.NotNull(result);
            Assert.Equal(2000, result!.EngineRPM);
        }
    }
}
