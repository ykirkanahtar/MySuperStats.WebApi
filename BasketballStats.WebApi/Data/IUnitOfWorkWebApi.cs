using BasketballStats.WebApi.Data.Repositories;
using CustomFramework.WebApiUtils.Authorization.Data;

namespace BasketballStats.WebApi.Data
{
    public interface IUnitOfWorkWebApi : IUnitOfWorkAuthorization
    {
        /*************Repositories************/
        IMatchRepository Matches { get; }
        ITeamRepository Teams { get; }
        IPlayerRepository Players { get; }
        IStatRepository Stats { get; }
        /*********End of Repositories*********/
    }
}