using System.Collections.Generic;
using MySuperStats.WebApi.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CustomFramework.BaseWebApi.Data.ModelConfiguration;

namespace MySuperStats.WebApi.Data.ModelConfiguration
{
    public class MatchModelConfiguration : BaseModelConfiguration<Match, int>
    {
        public override void Configure(EntityTypeBuilder<Match> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.MatchGroupId);

            builder.Property(p => p.MatchDate)
                .IsRequired();

            builder.Property(p => p.Order)
                .IsRequired();

            builder.Property(p => p.DurationInMinutes)
                .IsRequired();

            builder.Property(p => p.HomeTeamId)
                .IsRequired();

            builder.Property(p => p.AwayTeamId)
                .IsRequired();

            builder.Property(p => p.HomeTeamScore)
                .HasColumnType("decimal(10,2)");

            builder.Property(p => p.AwayTeamScore)
                .HasColumnType("decimal(10,2)");

            builder.Property(p => p.VideoLink)
                .HasMaxLength(100);


            builder
                .HasOne(r => r.HomeTeam)
                .WithMany(c => c.HomeMatches)
                .HasForeignKey(r => r.HomeTeamId)
                .HasPrincipalKey(c => c.Id)
                .IsRequired();

            builder
                .HasOne(r => r.AwayTeam)
                .WithMany(c => c.AwayMatches)
                .HasForeignKey(r => r.AwayTeamId)
                .HasPrincipalKey(c => c.Id)
                .IsRequired();

            builder.HasIndex(p => new { p.MatchDate, p.Order });
            builder.HasIndex(p => p.MatchGroupId);
        }
    }
}
