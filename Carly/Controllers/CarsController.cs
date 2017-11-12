using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Carly.Models;
using Carly.ViewModels;
using System.Data.Entity;


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
            if(User.IsInRole(RoleName.CanManageCars))
                return View("List");
            return View("ReadOnlyList");
        }

        [Authorize(Roles = RoleName.CanManageCars)]
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
        [ValidateAntiForgeryToken]
        public ActionResult Save(Car car)
        {
            ModelState["car.Id"].Errors.Clear();
            if (!ModelState.IsValid)
            {
                var viewModel = new CarFormViewModel
                {
                    Car = car,
                    Manufacturers = _context.Manufacturers.ToList()
                };
                return View("CarForm", viewModel);
                //var errors = ModelState.Values.SelectMany(v => v.Errors);
            }
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
            var car = _context.Cars.Include(c => c.Manufacturer).ToList().SingleOrDefault(c => c.Id == id);
            //var manufacturers = _context.Manufacturers.ToList();
            if (car == null)
                return HttpNotFound();

            var viewModel = new CarFormViewModel
            {
                Car = car,
                Manufacturers = _context.Manufacturers.ToList()
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