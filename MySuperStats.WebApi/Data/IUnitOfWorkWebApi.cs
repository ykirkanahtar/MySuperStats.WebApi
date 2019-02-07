using MySuperStats.WebApi.Data.Repositories;
using CustomFramework.WebApiUtils.Authorization.Data;

namespace MySuperStats.WebApi.Data
{
    public interface IUnitOfWorkWebApi : IUnitOfWorkAuthorization
    {
        /*************Repositories************/
        IMatchRepository Matches { get; }
        ITeamRepository Teams { get; }
        IPlayerRepository Players { get; }
        IBasketballStatRepository Stats { get; }
        /*********End of Repositories*********/
    }
}