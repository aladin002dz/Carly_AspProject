using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Carly.Models;


namespace Carly.Dtos
{
    public class CarDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public byte ManufacturerId { get; set; }

        public int Year { get; set; }

        //[CarsNumberValidation]
        public int NumberAvailable { get; set; }
    }
}