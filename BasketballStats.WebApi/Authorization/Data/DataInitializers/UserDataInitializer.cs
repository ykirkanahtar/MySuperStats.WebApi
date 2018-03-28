using BasketballStats.WebApi.Authorization.Models;
using BasketballStats.WebApi.Data.Contracts;
using BasketballStats.WebApi.Helper;
using BasketballStats.WebApi.Utils;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballStats.WebApi.Authorization.Data.DataInitializers
{
    public class UserDataInitializer : BaseDataInitializer
    {
        public UserDataInitializer(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task Seed()
        {
            var users = ConfigHelper.GetSection("Users");
            foreach (var section in users.GetChildren())
            {
                var userName = section.GetValue<string>("UserName");
                var email = section.GetValue<string>("Email");
                var password = section.GetValue<string>("Password");

                if (GetUsersByUserNameAsync(userName).Result.Count > 0) continue;

                var hashedPassword = password.HashPassword(out var salt);

                var user = new User(userName, email, hashedPassword);

                UnitOfWork.GetRepository<User, int>().Add(user);

                await UnitOfWork.SaveChangesAsync();

                await CreateUserUtilAsync(user.Id, salt);
            }
        }

        private async Task<IList<User>> GetUsersByUserNameAsync(string userName)
        {
            var predicate = PredicateBuilder.New<User>();
            predicate = predicate.And(p => p.UserName == userName);

            return await UnitOfWork.GetRepository<User, int>()
                .GetAll(0, ApiConstants.DefaultListCount, predicate, out var _).Select(p => p).ToListAsync();
        }

        private async Task CreateUserUtilAsync(int userId, string salt)
        {
            var userUtil = new UserUtil()
            {
                UserId = userId,
                SpecialValue = salt,
            };

            UnitOfWork.GetRepository<UserUtil, int>().Add(userUtil);

            await UnitOfWork.SaveChangesAsync();
        }

    }
}
