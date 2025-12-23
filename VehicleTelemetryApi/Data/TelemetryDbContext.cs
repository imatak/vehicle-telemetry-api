using Microsoft.EntityFrameworkCore;
using VehicleTelemetryApi.Models;

namespace VehicleTelemetryApi.Data
{
    /// <summary>
    /// Entity Framework Core database context for vehicle telemetry data.
    /// </summary>
    public class TelemetryDbContext : DbContext
    {
        public TelemetryDbContext(DbContextOptions<TelemetryDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Telemetry records stored in the system.
        /// </summary>
        public DbSet<TelemetryRecord> TelemetryRecords => Set<TelemetryRecord>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TelemetryRecord>(entity =>
            {
                entity.HasKey(t => t.Id);

                entity.HasIndex(t => new { t.DeviceId, t.Timestamp });

                entity.Property(t => t.FuelLevelPercentage)
                      .HasPrecision(5, 2);

                entity.Property(t => t.Latitude)
                      .HasPrecision(9, 6);

                entity.Property(t => t.Longitude)
                      .HasPrecision(9, 6);
            });
        }
    }
}
