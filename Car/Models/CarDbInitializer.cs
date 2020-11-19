using System.Data.Entity;
using Car.DbContext;

namespace Car.Models
{
    public class CarDbInitializer:DropCreateDatabaseAlways<CarContext>
    {
        protected override void Seed(CarContext db)
        {
            db.Cars.Add(new Car{Name = "BMW",Model="i8",Price=22000000});
            db.Cars.Add(new Car {Name = "Audi", Model = "A8",Price=4000000});
            db.Cars.Add(new Car{Name = "Mersedes",Model = "S221",Price = 5000000});
            base.Seed(db);
        }
    }
}