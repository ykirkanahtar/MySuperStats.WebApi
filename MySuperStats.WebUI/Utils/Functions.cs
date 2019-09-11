using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using MySuperStats.Contracts.Enums;
using Newtonsoft.Json;

namespace MySuperStats.WebUI.Utils
{
    public static class Functions
    {
        public static string GetFirstCharOfEnumValues(IList<MatchResult> matchScores)
        {
            var returnValue = matchScores.Aggregate(string.Empty, (current, form) => current + $"{form.ToString().Substring(0, 1)}-");

            return returnValue.Remove(returnValue.Length - 1);
        }

        public static void Put<T>(this ITempDataDictionary tempData, string key, T value) where T : class
        {
            tempData[key] = JsonConvert.SerializeObject(value);
        }

        public static T Get<T>(this ITempDataDictionary tempData, string key) where T : class
        {
            object o;
            tempData.TryGetValue(key, out o);
            return o == null ? null : JsonConvert.DeserializeObject<T>((string)o);
        }

        public static bool GetPermissionValue(Dictionary<string, bool> permissionDetail, string value)
        {
            bool response = false;
            if (permissionDetail.TryGetValue(value, out response))
            {
                return response;
            }
            else
            {
                return false;
            }
        }
    }
}