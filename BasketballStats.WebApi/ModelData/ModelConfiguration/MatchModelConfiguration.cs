using BasketballStats.WebApi.Data.ModelConfiguration;
using BasketballStats.WebApi.Data.Utils;
using BasketballStats.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BasketballStats.WebApi.ModelData.ModelConfiguration
{
    public class MatchModelConfiguration<T> : BaseModelConfiguration<T, int> where T : Match
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.ToTable(SnakeCaseNamingForDbObject.GetSqlTableName<T>());

            builder.Property(p => p.Id)
                .IsRequired()
                .HasColumnName(SnakeCaseNamingForDbObject.GetSqlColumnName<T>(p => p.Id));

            builder.Property(p => p.MatchDate)
                .IsRequired()
                .HasColumnName(SnakeCaseNamingForDbObject.GetSqlColumnName<T>(p => p.MatchDate));

            builder.Property(p => p.Order)
                .IsRequired()
                .HasColumnName(SnakeCaseNamingForDbObject.GetSqlColumnName<T>(p => p.Order));

            builder.Property(p => p.DurationInMinutes)
                .IsRequired()
                .HasColumnName(SnakeCaseNamingForDbObject.GetSqlColumnName<T>(p => p.DurationInMinutes));

            builder.Property(p => p.HomeTeamId)
                .IsRequired()
                .HasColumnName(SnakeCaseNamingForDbObject.GetSqlColumnName<T>(p => p.HomeTeamId));

            builder.Property(p => p.AwayTeamId)
                .IsRequired()
                .HasColumnName(SnakeCaseNamingForDbObject.GetSqlColumnName<T>(p => p.AwayTeamId));

            builder.Property(p => p.VideoLink)
                .HasColumnName(SnakeCaseNamingForDbObject.GetSqlColumnName<T>(p => p.VideoLink))
                .HasMaxLength(100);

            builder.HasIndex(p => new { p.MatchDate, p.Order })
                .IsUnique();
        }
    }
}
