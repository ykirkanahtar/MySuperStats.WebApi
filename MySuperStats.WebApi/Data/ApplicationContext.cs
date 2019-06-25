using System.Linq;
using MySuperStats.WebApi.Data.ModelConfiguration;
using MySuperStats.WebApi.Models;
using CustomFramework.Data.Utils;
using Microsoft.EntityFrameworkCore;
using CustomFramework.WebApiUtils.Identity.Data;
using CustomFramework.WebApiUtils.Identity.Models;

namespace MySuperStats.WebApi.Data
{
    public class ApplicationContext : IdentityContext<User, Role>
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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
