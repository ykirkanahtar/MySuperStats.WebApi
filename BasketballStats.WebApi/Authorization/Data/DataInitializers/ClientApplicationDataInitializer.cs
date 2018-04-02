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
    public class ClientApplicationDataInitializer : BaseDataInitializer
    {
        public ClientApplicationDataInitializer(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        public async Task Seed()
        {
            var roles = ConfigHelper.GetSection("ClientApplication");
            foreach (var section in roles.GetChildren())
            {
                var name = section.GetValue<string>("Name");
                var code = section.GetValue<string>("Code");
                var password = section.GetValue<string>("Password");

                if (GetClientApplicationsByNameAsync(name).Result.Count > 0) continue;

                var hashedPassword = password.HashPassword(out var salt);

                var clientApplication = new ClientApplication(name, code, hashedPassword);

                UnitOfWork.GetRepository<ClientApplication, int>().Add(clientApplication);

                await UnitOfWork.SaveChangesAsync();

                await CreateClientApplicationUtilAsync(clientApplication.Id, salt);
            }
        }

        private async Task<IList<ClientApplication>> GetClientApplicationsByNameAsync(string name)
        {
            return await UnitOfWork.GetRepository<ClientApplication, int>()
                .GetAll(predicate: p => p.ClientApplicationName == name).ToListAsync();
        }

        private async Task CreateClientApplicationUtilAsync(int clientApplicationId, string salt)
        {
            var clientApplicationUtil = new ClientApplicationUtil()
            {
                ClientApplicationId = clientApplicationId,
                SpecialValue = salt,
            };

            UnitOfWork.GetRepository<ClientApplicationUtil, int>().Add(clientApplicationUtil);
            await UnitOfWork.SaveChangesAsync();
        }
    }
}
