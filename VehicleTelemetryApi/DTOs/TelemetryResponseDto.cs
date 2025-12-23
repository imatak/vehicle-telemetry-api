namespace VehicleTelemetryApi.DTOs
{
    /// <summary>
    /// Data transfer object returned to clients when requesting telemetry data.
    /// </summary>
    public class TelemetryResponseDto
    {
        /// <summary>
        /// Unique identifier of the telemetry device.
        /// </summary>
        public Guid DeviceId { get; set; }

        /// <summary>
        /// Date and time when the telemetry data was recorded (UTC).
        /// </summary>
        public DateTimeOffset Timestamp { get; set; }

        /// <summary>
        /// Engine revolutions per minute (RPM).
        /// </summary>
        public int EngineRPM { get; set; }

        /// <summary>
        /// Remaining fuel level expressed as a percentage (0–100).
        /// </summary>
        public decimal FuelLevelPercentage { get; set; }

        /// <summary>
        /// Vehicle latitude coordinate.
        /// </summary>
        public decimal Latitude { get; set; }

        /// <summary>
        /// Vehicle longitude coordinate.
        /// </summary>
        public decimal Longitude { get; set; }
    }
}
