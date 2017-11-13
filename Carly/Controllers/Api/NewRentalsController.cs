using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Carly.Dtos;
using Carly.Models;
using System.Data.Entity;
using AutoMapper;

namespace Carly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }


        //Get api/rentals
        public IEnumerable<NewRentalDto> GetRentals()
        {
            return _context.Rentals
                .Select(Mapper.Map<Rental, NewRentalDto>);
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRentalDto)
        {
            var customer = _context.Customers.Single(c => c.Id == newRentalDto.CustomerId);

            var cars = _context.Cars.Where(c => newRentalDto.CarIds.Contains(c.Id));

            foreach (var car in cars)
            {
                if (car.NumberInStock == 0)
                    return BadRequest("Car is not available.");

                car.NumberInStock--;
                var rental = new Rental
                {
                    Customer = customer,
                    Car = car,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }

    }
}