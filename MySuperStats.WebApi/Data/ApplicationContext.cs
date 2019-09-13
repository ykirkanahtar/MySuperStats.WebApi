using System.Linq;
using MySuperStats.WebApi.Data.ModelConfiguration;
using MySuperStats.WebApi.Models;
using CustomFramework.Data.Utils;
using Microsoft.EntityFrameworkCore;
using CustomFramework.WebApiUtils.Identity.Data;
using Microsoft.AspNetCore.Identity;
using MySuperStats.WebApi.Data.ModelBuilderExtensions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

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

            modelBuilder.Entity<User>().Property(p => p.FirstName).HasMaxLength(100);
            modelBuilder.Entity<User>().Property(p => p.Surname).HasMaxLength(100);
            modelBuilder.Entity<User>().Property(p => p.PhoneNumber).HasMaxLength(50);
            modelBuilder.Entity<User>().Property(p => p.ConcurrencyStamp).HasMaxLength(1000);
            modelBuilder.Entity<User>().Property(p => p.SecurityStamp).HasMaxLength(1000);
            modelBuilder.Entity<User>().Property(p => p.PasswordHash).HasMaxLength(1000);
            modelBuilder.Entity<User>().Property(p => p.NormalizedEmail).HasMaxLength(100);
            modelBuilder.Entity<User>().Property(p => p.Email).HasMaxLength(100);
            modelBuilder.Entity<User>().Property(p => p.NormalizedUserName).HasMaxLength(100);
            modelBuilder.Entity<User>().Property(p => p.UserName).HasMaxLength(100);

            modelBuilder.Entity<Role>().Property(p => p.Name).HasMaxLength(100);
            modelBuilder.Entity<Role>().Property(p => p.NormalizedName).HasMaxLength(100);
            modelBuilder.Entity<Role>().Property(p => p.ConcurrencyStamp).HasMaxLength(1000);

            modelBuilder.Entity<IdentityRoleClaim<int>>().Property(p => p.ClaimType).HasMaxLength(100);
            modelBuilder.Entity<IdentityRoleClaim<int>>().Property(p => p.ClaimValue).HasMaxLength(100);

            modelBuilder.Entity<IdentityUserClaim<int>>().Property(p => p.ClaimType).HasMaxLength(100);
            modelBuilder.Entity<IdentityUserClaim<int>>().Property(p => p.ClaimValue).HasMaxLength(100);

            modelBuilder.Entity<IdentityUserLogin<int>>().Property(p => p.LoginProvider).HasMaxLength(100);
            modelBuilder.Entity<IdentityUserLogin<int>>().Property(p => p.ProviderDisplayName).HasMaxLength(100);
            modelBuilder.Entity<IdentityUserLogin<int>>().Property(p => p.ProviderKey).HasMaxLength(100);

            modelBuilder.Entity<IdentityUserToken<int>>().Property(p => p.LoginProvider).HasMaxLength(100);
            modelBuilder.Entity<IdentityUserToken<int>>().Property(p => p.Name).HasMaxLength(100);
            modelBuilder.Entity<IdentityUserToken<int>>().Property(p => p.Value).HasMaxLength(100);

            modelBuilder.ApplyConfiguration(new MatchModelConfiguration());
            modelBuilder.ApplyConfiguration(new BasketballStatModelConfiguration());
            modelBuilder.ApplyConfiguration(new TeamModelConfiguration());
            modelBuilder.ApplyConfiguration(new MatchGroupModelConfiguration());
            modelBuilder.ApplyConfiguration(new MatchGroupUserModelConfiguration());
            modelBuilder.ApplyConfiguration(new MatchGroupTeamModelConfiguration());
            modelBuilder.ApplyConfiguration(new FootballStatModelConfiguration());

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(bool))
                    {
                        property.SetValueConverter(new BoolToIntConverter());
                    }
                }
            }


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

    public class BoolToIntConverter : ValueConverter<bool, int>
    {
        public BoolToIntConverter(ConverterMappingHints mappingHints = null)
            : base(
                  v => Convert.ToInt32(v),
                  v => Convert.ToBoolean(v),
                  mappingHints)
        {
        }

        public static ValueConverterInfo DefaultInfo { get; }
            = new ValueConverterInfo(typeof(bool), typeof(int), i => new BoolToIntConverter(i.MappingHints));
    }
}
