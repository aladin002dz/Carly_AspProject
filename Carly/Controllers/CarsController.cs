using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Carly.Models;
using Carly.ViewModels;


namespace Carly.Controllers
{
    public class CarsController : Controller
    {
        private ApplicationDbContext _context;
        public CarsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {

            var cars = _context.Cars.ToList();

            return View(cars);
        }

        public ActionResult New()
        {
            var manufacturers = _context.Manufacturers.ToList();
            var viewModel = new CarFormViewModel
            {
                Manufacturers = manufacturers
            };

            return View("CarForm", viewModel);
        }


        [HttpPost]
        public ActionResult Save(Car car)
        {
            if (car.Id == 0)
                _context.Cars.Add(car);
            else
            {
                var carInDb = _context.Cars.SingleOrDefault(c => c.Id == car.Id);
                carInDb.Name = car.Name;
                carInDb.Year = car.Year;
                carInDb.Manufacturer = car.Manufacturer;
                carInDb.NumberAvailable = car.NumberAvailable;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Cars");
        }

        public ActionResult Details(int id)
        {
            var car = _context.Cars.ToList().SingleOrDefault(c => c.Id == id);

            if (car == null)
                return HttpNotFound();

            return View(car);
        }


        public ActionResult Edit(int id)
        {
            var car = _context.Cars.SingleOrDefault(c => c.Id == id);
            var manufacturers = _context.Manufacturers.ToList();
            if (car == null)
                return HttpNotFound();

            var viewModel = new CarFormViewModel
            {
                Car = car,
                Manufacturers = manufacturers
            };

            return View("CarForm", viewModel);
        }

        [Route("cars/released/{year}/{month}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year+"/"+month);
        }
    }
}