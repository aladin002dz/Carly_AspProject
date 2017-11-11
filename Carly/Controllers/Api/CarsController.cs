using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Carly.Models;
using Carly.Dtos;
using AutoMapper;

namespace Carly.Controllers.Api
{
    public class CarsController : ApiController
    {
        private ApplicationDbContext _context;

        public CarsController()
        {
            _context = new ApplicationDbContext();
        }

        //Get api/cars
        public IEnumerable<CarDto> GetCars()
        {
            return _context.Cars.ToList().Select(Mapper.Map<Car, CarDto>);
        }

        //Get api/cutomers/1
        public IHttpActionResult GetCar(int id)
        {
            var car = _context.Cars.FirstOrDefault(c => c.Id == id);
            if (car == null)
                return NotFound();
            return Ok(Mapper.Map<Car, CarDto>(car));
        }

        //Post api/Cars
        [HttpPost]
        public IHttpActionResult CreateCar(CarDto carDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var car = Mapper.Map<CarDto, Car>(carDto);

            _context.Cars.Add(car);
            _context.SaveChanges();

            carDto.Id = carDto.Id;

            return Created(new Uri(Request.RequestUri+"/"+car.Id), carDto);
        }

        //Put api/cars/1
        [HttpPut]
        public void UpdateCar(int id, CarDto carDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var carInDb = _context.Cars.FirstOrDefault(c => c.Id == id);
            if (carInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(carDto, carInDb);

            _context.SaveChanges();
        }

        //Delete api/cars/1
        [HttpDelete]
        public void DeleteCar(int id)
        {
            var carInDb = _context.Cars.FirstOrDefault(c => c.Id == id);
            if (carInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Cars.Remove(carInDb);

            _context.SaveChanges();
        }

    }
}
