using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Car.Models;

namespace Car.DbContext
{
    public class CarContext : System.Data.Entity.DbContext
    {
        public CarContext() : base("name = test")
        {
        }

        public DbSet<Models.Car> Cars { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Test> Tests { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}