using System.Collections.Generic;
using System.Linq;
using MySuperStats.Contracts.Enums;

namespace MySuperStats.WebUI.Utils
{
    public static class ConvertFunctions
    {
        public static string GetFirstCharOfEnumValues(IList<MatchResult> matchScores)
        {
            var returnValue = matchScores.Aggregate(string.Empty, (current, form) => current + $"{form.ToString().Substring(0, 1)}-");

            return returnValue.Remove(returnValue.Length - 1);
        }
    }
}