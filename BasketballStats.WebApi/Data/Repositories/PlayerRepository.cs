﻿using BasketballStats.WebApi.Models;
using CustomFramework.Data.Contracts;
using CustomFramework.Data.Repositories;
using CustomFramework.Data.Utils;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BasketballStats.WebApi.Data.Repositories
{
    public class PlayerRepository : BaseRepository<Player, int>, IPlayerRepository
    {
        public PlayerRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<ICustomList<Player>> GetAllAsync()
        {
            return await GetAll().IncludeMultiple(p => p.Stats).ToCustomList();
        }
    }
}