﻿using MySuperStats.WebApi.Models;
using CustomFramework.Data.Contracts;
using CustomFramework.Data.Repositories;
using System.Threading.Tasks;

namespace MySuperStats.WebApi.Data.Repositories
{
    public interface IPlayerRepository : IRepository<Player, int>
    {
        Task<Player> GetByIdWithIncludeAsync(int playerId);
        Task<ICustomList<Player>> GetAllAsync();
    }
}