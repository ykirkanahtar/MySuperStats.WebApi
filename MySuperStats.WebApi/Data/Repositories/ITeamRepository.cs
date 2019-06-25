using MySuperStats.WebApi.Models;
using CustomFramework.Data.Contracts;
using CustomFramework.Data.Repositories;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MySuperStats.WebApi.Data.Repositories
{
    public interface ITeamRepository : IRepository<Team, int>
    {
        Task<Team> GetByNameAsync(string name);
        Task<IList<Team>> GetAllAsync();
    }
}