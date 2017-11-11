using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Carly.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Car Name")]
        public string Name { get; set; }

        public Manufacturer Manufacturer { get; set; }

        [Display(Name = "Manufacturer")]
        public byte ManufacturerId { get; set; }

        [Display(Name = "Year of Fabrication")]
        public int Year { get; set; }

        [Display(Name = "Number Available")]
        [CarsNumberValidation]
        public int NumberAvailable { get; set; }
    }
}