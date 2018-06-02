using System.Threading.Tasks;
using BasketballStats.WebApi.Models;
using CustomFramework.Data;
using CustomFramework.Data.Contracts;

namespace BasketballStats.WebApi.Data.Repositories
{
    public interface ITeamRepository : IRepository<Team, int>
    {
        Task<Team> GetByNameAsync(string name);
        Task<ICustomList<Team>> GetAllAsync();
    }
}