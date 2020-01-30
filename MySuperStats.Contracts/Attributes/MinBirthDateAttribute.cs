using System;
using System.ComponentModel.DataAnnotations;

namespace MySuperStats.Contracts.Attributes
{
    public class MinBirthDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)// Return a boolean value: true == IsValid, false != IsValid
        {
            var d = Convert.ToDateTime(value);
            var retValue = d >= new DateTime(1900, 1, 1);
            return retValue;
        }
    }
}