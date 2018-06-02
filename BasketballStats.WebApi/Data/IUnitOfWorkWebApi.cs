using BasketballStats.WebApi.Data.Repositories;
using CustomFramework.Data;

namespace BasketballStats.WebApi.Data
{
    public interface IUnitOfWorkWebApi : IUnitOfWork
    {
        /*************Repositories************/
        IMatchRepository Matches { get; }
        ITeamRepository Teams { get; }
        IPlayerRepository Players { get; }
        IStatRepository Stats { get; }
        /*********End of Repositories*********/
    }
}