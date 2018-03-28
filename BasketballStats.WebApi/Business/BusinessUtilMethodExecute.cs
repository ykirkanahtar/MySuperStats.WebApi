using System;
using System.Collections.Generic;
using System.Text;
using BasketballStats.WebApi.Enums;

namespace BasketballStats.WebApi.Business
{
    public static class BusinessUtilMethodExecute
    {
        public static void Execute<T>(BusinessUtilMethod businessUtilMethod, T result, string additionnalInfo, bool critical = false)
        {
            switch (businessUtilMethod)
            {
                case BusinessUtilMethod.UniqueGenericListChecker:
                    BusinessUtil.UniqueGenericListChecker(result, additionnalInfo, critical);
                    break;
                case BusinessUtilMethod.CheckDuplicatationForUniqueValue:
                    BusinessUtil.CheckDuplicatationForUniqueValue(result, additionnalInfo);
                    break;
                case BusinessUtilMethod.CheckRecordIsExist:
                    BusinessUtil.CheckRecordIsExist(result, additionnalInfo, critical);
                    break;
                case BusinessUtilMethod.CheckUniqueValue:
                    BusinessUtil.CheckUniqueValue(result, additionnalInfo);
                    break;
                case BusinessUtilMethod.CheckNothing:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

}
