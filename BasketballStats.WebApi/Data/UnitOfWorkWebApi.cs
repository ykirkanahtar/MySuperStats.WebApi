using BasketballStats.WebApi.Data.Repositories;
using CustomFramework.Data;

namespace BasketballStats.WebApi.Data
{
    public class UnitOfWorkWebApi : UnitOfWork<ApplicationContext>, IUnitOfWorkWebApi
    {
        public UnitOfWorkWebApi(ApplicationContext context) : base(context)
        {
            /*************Instances************/
            Matches = new MatchRepository(context);
            Teams = new TeamRepository(context);
            Players = new PlayerRepository(context);
            Stats = new StatRepository(context);
            /*********End of Instances*********/
        }

        /*************Repositories************/
        public IMatchRepository Matches { get; }
        public ITeamRepository Teams { get; }
        public IPlayerRepository Players { get; }
        public IStatRepository Stats { get; }
        /*********End of Repositories*********/
    }
}