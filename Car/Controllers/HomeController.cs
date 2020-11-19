using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Car.DbContext;
using Car.Models;
using Microsoft.Ajax.Utilities;

namespace Car.Controllers
{
    public class HomeController : Controller
    {
        CarContext db = new CarContext();
        public async Task<ActionResult> Index()
        {
            SelectList caList=new SelectList(db.Cars,"Model","Name");
            IEnumerable<Models.Car> cars = await db.Cars.ToListAsync();
            ViewBag.Cars = cars;
            ViewBag.CarList = caList;
            return View();
        }

        public ActionResult List()
        {
            IEnumerable<Models.Car> car = db.Cars.ToList();
            return View(car);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public   ActionResult Buy(int?id)
        {
            ViewBag.CarId =   id;
            return  View();
        }

        [HttpPost]
        public string Buy(Purchase purchase)
        {
            purchase.Date=DateTime.Now;
            db.Purchases.Add(purchase);
            db.SaveChanges();
            return "Thanks"+purchase.Person+"for buy";
        }

        public ActionResult Partial()
        {
            ViewBag.Message = "This is Partial view";
            return PartialView();
        }

        [HttpGet]
        public ActionResult EditCar(int? Id)
        {
            if (!Id.HasValue)
            {
                return HttpNotFound();
            }

            Models.Car car = db.Cars.Find(Id);
            if (car != null)
            {
                return View(car);
            }

            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult EditCar(Models.Car car)
        {
            db.Entry(car).State = EntityState.Modified;
            db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Models.Car car)
        {
            db.Cars.Add(car);
            db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? Id)
        {
            Models.Car car = db.Cars.Find(Id);
            if (car==null)
            {
                return HttpNotFound();
            }

            return View(car);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? Id)
        {
            Models.Car car = db.Cars.Find(Id);
            if (car == null)
            {
                return HttpNotFound();
            }

            db.Cars.Remove(car);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}