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

        public ActionResult Details(int id)
        {
            var car = _context.Cars.ToList().SingleOrDefault(c => c.Id == id);

            if (car == null)
                return HttpNotFound();

            return View(car);
        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        [Route("cars/released/{year}/{month}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year+"/"+month);
        }
    }
}