namespace VehicleTelemetryApi.Models
{
    /// <summary>
    /// Represents a single telemetry data record received from a vehicle device.
    /// </summary>
    public class TelemetryRecord
    {
        /// <summary>
        /// Unique database identifier for the telemetry record.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Unique identifier of the telemetry device installed in the vehicle.
        /// </summary>
        public Guid DeviceId { get; set; }

        /// <summary>
        /// Date and time when the telemetry data was recorded (UTC).
        /// </summary>
        public DateTimeOffset Timestamp { get; set; }

        /// <summary>
        /// Engine revolutions per minute (RPM) at the time of recording.
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
