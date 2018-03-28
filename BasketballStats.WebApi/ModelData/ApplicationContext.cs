using System.Linq;
using BasketballStats.WebApi.Authorization.Data;
using BasketballStats.WebApi.Authorization.ModelConfigurations;
using BasketballStats.WebApi.Authorization.Models;
using BasketballStats.WebApi.ModelData.ModelConfiguration;
using BasketballStats.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BasketballStats.WebApi.ModelData
{
    public class ApplicationContext : AuthorizationContext
    {
        public ApplicationContext(DbContextOptions options)
            : base(options)
        {

        }

        public virtual DbSet<Match> Matches { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Stat> Stats { get; set; }
        public virtual DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfiguration(new MatchModelConfiguration<Match>());
            modelBuilder.ApplyConfiguration(new PlayerModelConfiguration<Player>());
            modelBuilder.ApplyConfiguration(new StatModelConfiguration<Stat>());
            modelBuilder.ApplyConfiguration(new TeamModelConfiguration<Team>());

            modelBuilder.Entity<Match>()
                .HasOne(r => r.HomeTeam)
                .WithMany(c => c.HomeMatches)
                .HasForeignKey(r => r.HomeTeamId);

            modelBuilder.Entity<Match>()
                .HasOne(r => r.AwayTeam)
                .WithMany(c => c.AwayMatches)
                .HasForeignKey(r => r.AwayTeamId);

            modelBuilder.Entity<Stat>()
                .HasOne(r => r.Match)
                .WithMany(c => c.Stats)
                .HasForeignKey(r => r.MatchId);

            modelBuilder.Entity<Stat>()
                .HasOne(r => r.Team)
                .WithMany(c => c.Stats)
                .HasForeignKey(r => r.TeamId);

            modelBuilder.Entity<Stat>()
                .HasOne(r => r.Player)
                .WithMany(c => c.Stats)
                .HasForeignKey(r => r.PlayerId);

            //https://stackoverflow.com/questions/46526230/disable-cascade-delete-on-ef-core-2-globally
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}
