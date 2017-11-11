using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Carly.Models
{
    public class CarsNumberValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var car = (Car)validationContext.ObjectInstance;
            if (car.NumberAvailable > 0 && car.NumberAvailable <21)
                return ValidationResult.Success;
            else
                return new ValidationResult("The field Number available must be between 1 and 20.");
        }
    }
}