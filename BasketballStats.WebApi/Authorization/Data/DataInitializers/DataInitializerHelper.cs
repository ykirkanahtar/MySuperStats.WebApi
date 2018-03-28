using BasketballStats.WebApi.Data.Utils;

namespace BasketballStats.WebApi.Authorization.Data.DataInitializers
{
    public static class DataInitializerHelper
    {
        public static string HashPassword(this string password, out string salt)
        {
            salt = HashString.GetSalt();
            return HashString.Hash(password, salt);
        }
    }
}