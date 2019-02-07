using System.Collections.Generic;
using MySuperStats.WebApi.Models;
using CustomFramework.Data.ModelConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MySuperStats.WebApi.Data.ModelConfiguration
{
    public class BasketballStatModelConfiguration<T> : BaseModelConfiguration<T, int> where T : BasketballStat
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.MatchId)
                .IsRequired();

            builder.Property(p => p.TeamId)
                .IsRequired();

            builder.Property(p => p.PlayerId)
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
                .WithMany(c => (IEnumerable<T>)c.BasketballStats)
                .HasForeignKey(r => r.MatchId)
                .HasPrincipalKey(c => c.Id)
                .IsRequired();

            builder
                .HasOne(r => r.Team)
                .WithMany(c => (IEnumerable<T>)c.BasketballStats)
                .HasForeignKey(r => r.TeamId)
                .HasPrincipalKey(c => c.Id)
                .IsRequired();

            builder
                .HasOne(r => r.Player)
                .WithMany(c => (IEnumerable<T>)c.BasketballStats)
                .HasForeignKey(r => r.PlayerId)
                .HasPrincipalKey(c => c.Id)
                .IsRequired();


            builder.HasIndex(p => new { p.MatchId, p.PlayerId, p.TeamId }).IsUnique();
        }
    }
}
