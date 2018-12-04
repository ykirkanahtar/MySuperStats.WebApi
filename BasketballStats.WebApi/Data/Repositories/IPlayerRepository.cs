using BasketballStats.WebApi.Models;
using CustomFramework.Data.Contracts;
using CustomFramework.Data.Repositories;
using System.Threading.Tasks;

namespace BasketballStats.WebApi.Data.Repositories
{
    public interface IPlayerRepository : IRepository<Player, int>
    {
        Task<ICustomList<Player>> GetAllAsync();
    }
}