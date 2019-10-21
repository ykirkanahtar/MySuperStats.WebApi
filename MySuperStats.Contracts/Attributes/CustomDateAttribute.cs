using System;
using System.ComponentModel.DataAnnotations;

namespace MySuperStats.Contracts.Attributes
{
    public class MaxBirthDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)// Return a boolean value: true == IsValid, false != IsValid
        {
            var d = Convert.ToDateTime(value);
            return d < DateTime.Now; 
        }
    }
}