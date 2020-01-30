using MySuperStats.WebApi.Data.Repositories;
using CustomFramework.BaseWebApi.Identity.Data;

namespace MySuperStats.WebApi.Data
{
    public interface IUnitOfWorkWebApi : IUnitOfWorkIdentity
    {
        /*************Repositories************/
        IMatchRepository Matches { get; }
        ITeamRepository Teams { get; }
        IBasketballStatRepository BasketballStats { get; }
        IMatchGroupRepository MatchGroups { get; }

        IMatchGroupUserRepository MatchGroupUsers { get; }
        IMatchGroupTeamRepository MatchGroupTeams { get; }
        IFootballStatRepository FootballStats { get; }
        IUserRepository Users { get; }
        IPlayerRepository Players { get; }
        /*********End of Repositories*********/
    }
}