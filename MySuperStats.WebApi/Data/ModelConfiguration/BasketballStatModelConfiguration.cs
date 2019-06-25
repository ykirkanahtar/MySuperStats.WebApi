using System.Collections.Generic;
using MySuperStats.WebApi.Models;
using CustomFramework.Data.ModelConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MySuperStats.WebApi.Data.ModelConfiguration
{
    public class BasketballStatModelConfiguration : BaseModelConfiguration<BasketballStat, int>
    {
        public override void Configure(EntityTypeBuilder<BasketballStat> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.MatchId)
                .IsRequired();

            builder.Property(p => p.TeamId)
                .IsRequired();

            builder.Property(p => p.UserId)
                .IsRequired();

            builder.Property(p => p.OnePoint)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.Property(p => p.TwoPoint)
                .HasColumnType("decimal(10,2)");

            builder.Property(p => p.MissingOnePoint)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.Property(p => p.MissingTwoPoint)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.Property(p => p.Rebound)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.Property(p => p.StealBall)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.Property(p => p.LooseBall)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.Property(p => p.Assist)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.Property(p => p.Interrupt)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder
                .HasOne(r => r.Match)
                .WithMany(c => c.BasketballStats)
                .HasForeignKey(r => r.MatchId)
                .HasPrincipalKey(c => c.Id)
                .IsRequired();

            builder
                .HasOne(r => r.Team)
                .WithMany(c => c.BasketballStats)
                .HasForeignKey(r => r.TeamId)
                .HasPrincipalKey(c => c.Id)
                .IsRequired();

            builder
                .HasOne(r => r.User)
                .WithMany(c => c.BasketballStats)
                .HasForeignKey(r => r.UserId)
                .HasPrincipalKey(c => c.Id)
                .IsRequired();


            builder.HasIndex(p => new { p.MatchId, p.UserId, p.TeamId });
        }
    }
}
