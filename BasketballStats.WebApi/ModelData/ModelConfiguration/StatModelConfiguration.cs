using BasketballStats.WebApi.Data.ModelConfiguration;
using BasketballStats.WebApi.Data.Utils;
using BasketballStats.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BasketballStats.WebApi.ModelData.ModelConfiguration
{
    public class StatModelConfiguration<T> : BaseModelConfiguration<T, int> where T : Stat
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.ToTable(SnakeCaseNamingForDbObject.GetSqlTableName<T>());

            builder.Property(p => p.Id)
                .IsRequired()
                .HasColumnName(SnakeCaseNamingForDbObject.GetSqlColumnName<T>(p => p.Id));

            builder.Property(p => p.MatchId)
                .IsRequired()
                .HasColumnName(SnakeCaseNamingForDbObject.GetSqlColumnName<T>(p => p.MatchId));

            builder.Property(p => p.TeamId)
                .IsRequired()
                .HasColumnName(SnakeCaseNamingForDbObject.GetSqlColumnName<T>(p => p.TeamId));

            builder.Property(p => p.PlayerId)
                .IsRequired()
                .HasColumnName(SnakeCaseNamingForDbObject.GetSqlColumnName<T>(p => p.PlayerId));

            builder.Property(p => p.OnePoint)
                .IsRequired()
                .HasColumnName(SnakeCaseNamingForDbObject.GetSqlColumnName<T>(p => p.OnePoint));

            builder.Property(p => p.TwoPoint)
                .IsRequired()
                .HasColumnName(SnakeCaseNamingForDbObject.GetSqlColumnName<T>(p => p.TwoPoint));

            builder.Property(p => p.MissingOnePoint)
                .IsRequired()
                .HasColumnName(SnakeCaseNamingForDbObject.GetSqlColumnName<T>(p => p.MissingOnePoint));

            builder.Property(p => p.MissingTwoPoint)
                .IsRequired()
                .HasColumnName(SnakeCaseNamingForDbObject.GetSqlColumnName<T>(p => p.MissingTwoPoint));

            builder.Property(p => p.Rebound)
                .IsRequired()
                .HasColumnName(SnakeCaseNamingForDbObject.GetSqlColumnName<T>(p => p.Rebound));

            builder.Property(p => p.StealBall)
                .IsRequired()
                .HasColumnName(SnakeCaseNamingForDbObject.GetSqlColumnName<T>(p => p.StealBall));

            builder.Property(p => p.LooseBall)
                .IsRequired()
                .HasColumnName(SnakeCaseNamingForDbObject.GetSqlColumnName<T>(p => p.LooseBall));

            builder.Property(p => p.Assist)
                .IsRequired()
                .HasColumnName(SnakeCaseNamingForDbObject.GetSqlColumnName<T>(p => p.Assist));

            builder.Property(p => p.Interrupt)
                .IsRequired()
                .HasColumnName(SnakeCaseNamingForDbObject.GetSqlColumnName<T>(p => p.Interrupt));

            builder.HasIndex(p => new { p.MatchId, p.PlayerId, p.TeamId }).IsUnique();
        }
    }
}
