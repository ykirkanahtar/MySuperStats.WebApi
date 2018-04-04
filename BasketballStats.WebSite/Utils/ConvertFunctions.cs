using BasketballStats.WebSite.Enums;
using System;
using System.Collections.Generic;

namespace BasketballStats.WebSite.Utils
{
    public static class ConvertFunctions
    {
        public static decimal RoundValue(this decimal value)
        {
            return Math.Round(value, 2, MidpointRounding.ToEven);
        }

        public static int GetAge(this DateTime birthdate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthdate.Year;

            if (birthdate > today.AddYears(-age))
                age--;

            return age;
        }

        public static decimal GetTeamAgeRatio(int playerCount, decimal teamTotalAge)
        {
            return playerCount > 0
                ? (teamTotalAge / Convert.ToDecimal(playerCount)).RoundValue()
                : 0;
        }

        public static string GetFirstCharOfEnumValues(IList<MatchScore> matchScores)
        {
            var returnValue = string.Empty;

            foreach (var form in matchScores)
            {
                returnValue += $"{form.ToString().Substring(0, 1)}-";
            }
            return returnValue.Remove(returnValue.Length - 1);
        }
    }
}
