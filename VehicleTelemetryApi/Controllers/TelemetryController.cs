using Microsoft.AspNetCore.Mvc;
using VehicleTelemetryApi.DTOs;
using VehicleTelemetryApi.Models;
using VehicleTelemetryApi.Services;

namespace VehicleTelemetryApi.Controllers
{
    [ApiController]
    [Route("api/v1/telemetry")]
    public class TelemetryController : ControllerBase
    {
        private readonly ITelemetryService _telemetryService;

        public TelemetryController(ITelemetryService telemetryService)
        {
            _telemetryService = telemetryService;
        }

        /// <summary>
        /// Creates a new telemetry record.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] TelemetryCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var record = new TelemetryRecord
            {
                DeviceId = dto.DeviceId,
                Timestamp = dto.Timestamp,
                EngineRPM = dto.EngineRPM,
                FuelLevelPercentage = dto.FuelLevelPercentage,
                Latitude = dto.Latitude,
                Longitude = dto.Longitude
            };

            await _telemetryService.AddAsync(record);

            return CreatedAtAction(nameof(GetLatest), new { deviceId = dto.DeviceId }, null);
        }

        /// <summary>
        /// Retrieves the latest telemetry record for a device.
        /// </summary>
        [HttpGet("{deviceId}/latest")]
        public async Task<ActionResult<TelemetryResponseDto>> GetLatest(Guid deviceId)
        {
            var record = await _telemetryService.GetLatestAsync(deviceId);

            if (record == null)
                return NotFound();

            return Ok(new TelemetryResponseDto
            {
                DeviceId = record.DeviceId,
                Timestamp = record.Timestamp,
                EngineRPM = record.EngineRPM,
                FuelLevelPercentage = record.FuelLevelPercentage,
                Latitude = record.Latitude,
                Longitude = record.Longitude
            });
        }
    }
}
