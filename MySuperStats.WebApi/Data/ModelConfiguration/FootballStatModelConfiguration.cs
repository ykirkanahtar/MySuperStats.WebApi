using CustomFramework.BaseWebApi.Data.ModelConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySuperStats.WebApi.Models;

namespace MySuperStats.WebApi.Data.ModelConfiguration
{
    public class FootballStatModelConfiguration : BaseModelConfiguration<FootballStat, int>
    {
        public override void Configure(EntityTypeBuilder<FootballStat> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.MatchId)
                .IsRequired();

            builder.Property(p => p.TeamId)
                .IsRequired();

            builder.Property(p => p.PlayerId)
                .IsRequired();

            builder.Property(p => p.Goal)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.Property(p => p.OwnGoal)
                .HasColumnType("decimal(10,2)");

            builder.Property(p => p.PenaltyScore)
                .HasColumnType("decimal(10,2)");

            builder.Property(p => p.MissedPenalty)
                .HasColumnType("decimal(10,2)");

            builder.Property(p => p.Assist)
                .HasColumnType("decimal(10,2)");

            builder.Property(p => p.SaveGoal)
                .HasColumnType("decimal(10,2)");

            builder.Property(p => p.ConcedeGoal)
                .HasColumnType("decimal(10,2)");

            builder
                .HasOne(r => r.Match)
                .WithMany(c => c.FootballStats)
                .HasForeignKey(r => r.MatchId)
                .HasPrincipalKey(c => c.Id)
                .IsRequired();

            builder
                .HasOne(r => r.Team)
                .WithMany(c => c.FootballStats)
                .HasForeignKey(r => r.TeamId)
                .HasPrincipalKey(c => c.Id)
                .IsRequired();

            builder
                .HasOne(r => r.Player)
                .WithMany(c => c.FootballStats)
                .HasForeignKey(r => r.PlayerId)
                .HasPrincipalKey(c => c.Id)
                .IsRequired();


            builder.HasIndex(p => new { p.MatchId, p.PlayerId, p.TeamId });

        }
    }
}