using System.Linq;
using MySuperStats.WebApi.Data.ModelConfiguration;
using MySuperStats.WebApi.Models;
using CustomFramework.Data.Utils;
using Microsoft.EntityFrameworkCore;
using CustomFramework.WebApiUtils.Identity.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using CustomFramework.WebApiUtils.Identity.Data.ModelConfigurations;
using CustomFramework.WebApiUtils.Identity.Models;

namespace MySuperStats.WebApi.Data
{
    public class ApplicationContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public ApplicationContext(DbContextOptions options)
            : base(options)
        {

        }

        public virtual DbSet<Match> Matches { get; set; }
        public virtual DbSet<BasketballStat> BasketballStats { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<MatchGroup> MatchGroups { get; set; }
        public virtual DbSet<MatchGroupUser> MatchGroupUsers { get; set; }
        public virtual DbSet<MatchGroupTeam> MatchGroupTeams { get; set; }
        public virtual DbSet<FootballStat> FootballStats { get; set; }
        public virtual DbSet<ClientApplication> ClientApplications { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /* Identity */
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<Role>().ToTable("roles");
            modelBuilder.Entity<IdentityRoleClaim<int>>().ToTable("role_claims");
            modelBuilder.Entity<IdentityUserClaim<int>>().ToTable("user_claims");
            modelBuilder.Entity<IdentityUserLogin<int>>().ToTable("user_logins");
            modelBuilder.Entity<UserRole>().ToTable("user_roles");
            modelBuilder.Entity<IdentityUserToken<int>>().ToTable("user_tokens");

            modelBuilder.ApplyConfiguration(new ClientApplicationModelConfiguration<ClientApplication>());
            /* Identity */


            modelBuilder.ApplyConfiguration(new MatchModelConfiguration());
            modelBuilder.ApplyConfiguration(new BasketballStatModelConfiguration());
            modelBuilder.ApplyConfiguration(new TeamModelConfiguration());
            modelBuilder.ApplyConfiguration(new MatchGroupModelConfiguration());
            modelBuilder.ApplyConfiguration(new MatchGroupUserModelConfiguration());
            modelBuilder.ApplyConfiguration(new MatchGroupTeamModelConfiguration());
            modelBuilder.ApplyConfiguration(new FootballStatModelConfiguration());
            modelBuilder.Seed();

            //https://stackoverflow.com/questions/46526230/disable-cascade-delete-on-ef-core-2-globally
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.SetModelToSnakeCase();
        }
    }
}
