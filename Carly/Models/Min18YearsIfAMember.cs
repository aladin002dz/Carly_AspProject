using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Carly.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId == MembershipType.PayAsYouGo || 
                customer.MembershipTypeId == MembershipType.Unknown)
                return ValidationResult.Success;
            if (customer.Birthday == null)
                return new ValidationResult("Birthdate is required.");
            var age = DateTime.Today.Year - customer.Birthday.Value.Year;
            return (age > 18) ?
                ValidationResult.Success
                : new ValidationResult("Customer should be at least 18 years olde to gi on a membership.");

        }
    }
}