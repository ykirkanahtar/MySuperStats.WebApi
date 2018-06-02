using System.Threading.Tasks;
using BasketballStats.WebApi.Models;
using CustomFramework.Data;
using CustomFramework.Data.Contracts;

namespace BasketballStats.WebApi.Data.Repositories
{
    public interface IPlayerRepository : IRepository<Player, int>
    {
        Task<ICustomList<Player>> GetAllAsync();
    }
}