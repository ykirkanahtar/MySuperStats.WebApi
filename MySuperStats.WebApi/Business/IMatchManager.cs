using System.Threading.Tasks;
using MySuperStats.Contracts.Requests;
using MySuperStats.WebApi.Models;
using System.Collections.Generic;
using System;
using CustomFramework.BaseWebApi.Utils.Business;

namespace MySuperStats.WebApi.Business
{
    public interface IMatchManager : IBusinessManager<Match, MatchRequest, int>
    , IBusinessManagerUpdate<Match, MatchRequest, int>
    {
        Task<IList<Match>> GetAllByMatchGroupIdAsync(int matchGroupId);
        Task<IList<Match>> GetMatchForMainScreen(int matchGroupId);
        Task<Match> GetMatchDetailBasketballStats(int matchId);
        Task<Match> GetMatchDetailFootballStats(int matchId);
        Task<bool> MatchDateAndOrderAreUnique(int matchGroupId, DateTime matchDate, int order);
    }
}
