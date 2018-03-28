using System;
using System.Linq.Expressions;
using System.Text;

namespace BasketballStats.WebApi.Data.Utils
{
    public static class SnakeCaseNamingForDbObject
    {
        public static string GetSqlColumnName<T>(Expression<Func<T, object>> expression)
        {
            return GetSqlColumnName<T>(StaticReflection.GetMemberName<T>(expression));
        }

        public static string GetSqlTableName<T>()
        {
            var tableName = typeof(T).Name;
            var psqlTableName = SqlNaming(tableName);
            if (psqlTableName.Substring(psqlTableName.Length - 1, 1) == "y"
                && psqlTableName.Substring(psqlTableName.Length - 2, 1) != "a"
                && psqlTableName.Substring(psqlTableName.Length - 2, 1) != "e"
                && psqlTableName.Substring(psqlTableName.Length - 2, 1) != "i"
                && psqlTableName.Substring(psqlTableName.Length - 2, 1) != "o"
                && psqlTableName.Substring(psqlTableName.Length - 2, 1) != "u"
            )
            {
                psqlTableName = psqlTableName.Remove(psqlTableName.Length - 1);
                psqlTableName = $"{psqlTableName}ie";
            }

            if (psqlTableName.Substring(psqlTableName.Length - 2, 2) == "ch"
                ||
                psqlTableName.Substring(psqlTableName.Length - 1, 1) == "s"
            )
            {
                psqlTableName = $"{psqlTableName}e";
            }

            psqlTableName = $"{psqlTableName}s";
            return psqlTableName;
        }

        public static string GetSqlJoinTable<T1, T2>()
        {
            var table1Name = typeof(T1).Name;

            var psqlTable1Name = SqlNaming(table1Name);
            var psqlTable2Name = GetSqlTableName<T2>();

            return $"{psqlTable1Name}_{psqlTable2Name}";
        }

        private static string GetSqlColumnName<T>(string memberName)
        {
            return memberName == "Id" ? $"{SqlNaming(typeof(T).Name)}_id" : SqlNaming(memberName);
        }

        private static string SqlNaming(string name)
        {
            var sb = new StringBuilder();
            foreach (var item in name.ToCharArray())
            {
                var val = item.ToString();

                if (char.IsUpper(item))
                {
                    if (string.IsNullOrEmpty(sb.ToString())) val = item.ToString().ToLower();
                    else val = "_" + item.ToString().ToLower();
                }
                sb.Append(val);
            }
            return sb.ToString().Replace("ı", "i");
        }
    }
}
