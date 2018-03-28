using System;
using System.Threading.Tasks;
using BasketballStats.WebApi.Contracts;
using BasketballStats.WebApi.Helper;
using BasketballStats.WebApi.Models;
using BasketballStats.WebApi.RequestModels;

namespace BasketballStats.WebApi.Business.Contracts
{
    public interface IPlayerManager : IBusinessManager
    {
        Task<Player> CreateAsync(PlayerRequest request);
        Task<Player> UpdateAsync(int id, PlayerRequest request);
        Task DeleteAsync(int id);
        Task<Player> GetByIdAsync(int id);
        Task<CustomEntityList<Player>> GetAllByNameAsync(string name);
        Task<CustomEntityList<Player>> GetAllBySurnameAsync(string surname);
        Task<CustomEntityList<Player>> GetAllByNameAndSurnameAsync(string name, string surname);
        Task<CustomEntityList<Player>> GetAllAsync();

    }
}