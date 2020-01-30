using MySuperStats.WebApi.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using CustomFramework.BaseWebApi.Data.Repositories;

namespace MySuperStats.WebApi.Data.Repositories
{
    public interface ITeamRepository : IRepository<Team, int>
    {
        Task<Team> GetByNameAsync(string name);
        Task<IList<Team>> GetAllAsync();
    }
}