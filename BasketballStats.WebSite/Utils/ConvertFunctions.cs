using System;

namespace BasketballStats.WebSite.Utils
{
    public static class ConvertFunctions
    {
        public static decimal RoundValue(this decimal value)
        {
            return Math.Round(value, 2, MidpointRounding.AwayFromZero);
        }

        public static int GetAge(this DateTime birthdate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthdate.Year;

            if (birthdate > today.AddYears(-age))
                age--;

            return age;
        }
    }
}
