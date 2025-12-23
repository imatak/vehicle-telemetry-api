using System.ComponentModel.DataAnnotations;

namespace VehicleTelemetryApi.DTOs
{
    /// <summary>
    /// Data transfer object used to create a new telemetry record.
    /// </summary>
    public class TelemetryCreateDto
    {
        /// <summary>
        /// Unique identifier of the telemetry device installed in the vehicle.
        /// </summary>
        [Required]
        public Guid DeviceId { get; set; }

        /// <summary>
        /// Date and time when the telemetry data was recorded (UTC).
        /// </summary>
        [Required]
        public DateTimeOffset Timestamp { get; set; }

        /// <summary>
        /// Engine revolutions per minute (RPM).
        /// </summary>
        [Range(0, 10000)]
        public int EngineRPM { get; set; }

        /// <summary>
        /// Remaining fuel level expressed as a percentage (0–100).
        /// </summary>
        [Range(0, 100)]
        public decimal FuelLevelPercentage { get; set; }

        /// <summary>
        /// Vehicle latitude coordinate.
        /// </summary>
        [Range(-90, 90)]
        public decimal Latitude { get; set; }
        
        /// <summary>
        /// Vehicle longitude coordinate.
        /// </summary>
        [Range(-180, 180)]
        public decimal Longitude { get; set; }
    }
}
