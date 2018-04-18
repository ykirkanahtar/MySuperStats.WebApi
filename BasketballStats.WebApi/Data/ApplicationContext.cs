using System.Linq;
using BasketballStats.WebApi.Data.ModelConfiguration;
using BasketballStats.WebApi.Models;
using CustomFramework.Data.Utils;
using CustomFramework.WebApiUtils.Authorization.Data;
using Microsoft.EntityFrameworkCore;

namespace BasketballStats.WebApi.Data
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

            //https://stackoverflow.com/questions/46526230/disable-cascade-delete-on-ef-core-2-globally
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            Startup.SeedAuthorizationData.SeedAll(modelBuilder);
            Startup.SeedWebApiData.SeedAll(modelBuilder);

            modelBuilder.SetModelToSnakeCase();
        }
    }
}
