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
        // GET: Cars
        public ActionResult Random()
        {
            Car car = new Car() { Name = "Mustang"};

            var customers = new List<Customer>
            {
                new Customer { Name = "Customer1" },
                new Customer { Name = "Customer2" }
            };

            var viewModel = new RandomCarViewModel
            {
                Car = car,
                Customers = customers
            };

            return View(viewModel);
            //return Content("Hello World!");
        }

        public ActionResult Index()
        {

            var cars = GetCars();

            return View(cars);
        }

        private IEnumerable<Car> GetCars()
        {
            return new List<Car>
            {
                new Car { Id = 1, Name = "Mustang" },
                new Car { Id = 2, Name = "Kamaro" }
            };
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