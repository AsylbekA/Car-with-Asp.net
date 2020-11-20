using OnlineStore.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace OnlineStore.DbContext
{
    public class CarContext : System.Data.Entity.DbContext
    {
        public CarContext() : base("name = test")
        {
        }

        public virtual DbSet<Carr> Cars { get; set; }
        public virtual DbSet<Purchase> Purchases { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Course> Courses { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}