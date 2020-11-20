using OnlineStore.DbContext;
using System.Data.Entity;

namespace OnlineStore.Models
{
    public class CarDbInitializer : DropCreateDatabaseAlways<CarContext>
    {
        protected override void Seed(CarContext db)
        {
            db.Cars.Add(new Carr { Name = "BMW", Model = "i8", Price = 22000000 });
            db.Cars.Add(new Carr { Name = "Audi", Model = "A8", Price = 4000000 });
            db.Cars.Add(new Carr { Name = "Mersedes", Model = "S221", Price = 5000000 });
            base.Seed(db);
        }
    }
}