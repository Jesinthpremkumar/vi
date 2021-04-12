using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace vi.Models
{
    public class Min18YearIfAMember:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer=(customer) validationContext.ObjectInstance;
            if (customer.MembershipTypeId==MembershipType.unkown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;
            if (customer.DateOfBirth == null && customer.MembershipTypeId==MembershipType.PayAsYouGo)
                return new ValidationResult("Birthdte is required");
            var age = DateTime.Now.Year-customer.DateOfBirth.Value.Year ;
            if (age < 18 && customer.MembershipTypeId != 1)
                return new ValidationResult("you must be above 18 years old to have membership");
            else
                return ValidationResult.Success;
        }   
    }
}