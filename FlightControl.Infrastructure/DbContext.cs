using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace FlightControl.Infrastructure.Context
{
    public class FlightControlDB : DbContext{
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<Stage> Stages { get; set; }
        public virtual DbSet<FlightHistory> FlightsHistory { get; set; }
        public FlightControlDB(DbContextOptions<FlightControlDB> options) : base(options) {
            try {
                var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if (databaseCreator == null) {
                    if (!databaseCreator.CanConnect()) databaseCreator.Create();
                    if (!databaseCreator.HasTables()) databaseCreator.CreateTables();
                }
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Stage>().HasData(
                StagesConfiguration.stagesConfig
            );
            base.OnModelCreating(modelBuilder);
        }  
    }
} 