using CustomFramework.Data;
using CustomFramework.WebApiUtils.Identity.Data.Repositories;
using MySuperStats.WebApi.Data.Repositories;

namespace MySuperStats.WebApi.Data
{
    public class UnitOfWorkWebApi : UnitOfWork<ApplicationContext>, IUnitOfWorkWebApi
    {
        public UnitOfWorkWebApi(ApplicationContext context) : base(context)
        {
            /*************Authorization************/
            ClientApplications = new ClientApplicationRepository(context);
            Users = new UserRepository(context);
            /*************Authorization************/

            /*************Instances************/
            Matches = new MatchRepository(context);
            Teams = new TeamRepository(context);
            BasketballStats = new BasketballStatRepository(context);
            MatchGroups = new MatchGroupRepository(context);
            MatchGroupUsers = new MatchGroupUserRepository(context);
            MatchGroupTeams = new MatchGroupTeamRepository(context);
            FootballStats = new FootballStatRepository(context);
            /*********End of Instances*********/
        }

        /*************Authorization************/
        public IClientApplicationRepository ClientApplications { get; }
        public IUserRepository Users { get; }
        /*************Authorization************/

        /*************Repositories************/
        public IMatchRepository Matches { get; }
        public ITeamRepository Teams { get; }
        public IBasketballStatRepository BasketballStats { get; }
        public IMatchGroupRepository MatchGroups { get; }
        public IMatchGroupUserRepository MatchGroupUsers { get; }
        public IMatchGroupTeamRepository MatchGroupTeams { get; }
        public IFootballStatRepository FootballStats { get; }
        /*********End of Repositories*********/
    }
}