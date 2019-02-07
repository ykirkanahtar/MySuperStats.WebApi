using MySuperStats.WebApi.Data.Repositories;
using CustomFramework.Data;
using CustomFramework.WebApiUtils.Authorization.Data.Repositories;

namespace MySuperStats.WebApi.Data
{
    public class UnitOfWorkWebApi : UnitOfWork<ApplicationContext>, IUnitOfWorkWebApi
    {
        public UnitOfWorkWebApi(ApplicationContext context) : base(context)
        {
            /*************Authorization************/
            Claims = new ClaimRepository(context);
            ClientApplications = new ClientApplicationRepository(context);
            ClientApplicationUtils = new ClientApplicationUtilRepository(context);
            RoleClaims = new RoleClaimRepository(context);
            RoleEntityClaims = new RoleEntityClaimRepository(context);
            Roles = new RoleRepository(context);
            UserClaims = new UserClaimRepository(context);
            UserEntityClaims = new UserEntityClaimRepository(context);
            Users = new UserRepository(context);
            UserRoles = new UserRoleRepository(context);
            UserUtils = new UserUtilRepository(context);
            Applications = new ApplicationRepository(context);
            ApplicationUsers = new ApplicationUserRepository(context);
            /*************Authorization************/

            /*************Instances************/
            Matches = new MatchRepository(context);
            Teams = new TeamRepository(context);
            Players = new PlayerRepository(context);
            Stats = new StatRepository(context);
            /*********End of Instances*********/
        }

        /*************Authorization************/
        public IApplicationUserRepository ApplicationUsers { get; }
        public IClaimRepository Claims { get; }
        public IClientApplicationRepository ClientApplications { get; }
        public IClientApplicationUtilRepository ClientApplicationUtils { get; }
        public IRoleClaimRepository RoleClaims { get; }
        public IRoleEntityClaimRepository RoleEntityClaims { get; }
        public IRoleRepository Roles { get; }
        public IUserClaimRepository UserClaims { get; }
        public IUserEntityClaimRepository UserEntityClaims { get; }
        public IUserRepository Users { get; }
        public IUserRoleRepository UserRoles { get; }
        public IUserUtilRepository UserUtils { get; }
        public IApplicationRepository Applications { get; }
        /*************Authorization************/

        /*************Repositories************/
        public IMatchRepository Matches { get; }
        public ITeamRepository Teams { get; }
        public IPlayerRepository Players { get; }
        public IStatRepository Stats { get; }
        /*********End of Repositories*********/
    }
}