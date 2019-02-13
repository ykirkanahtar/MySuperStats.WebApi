using CustomFramework.Data.ModelConfiguration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySuperStats.WebApi.Models;
using System.Collections.Generic;

namespace MySuperStats.WebApi.Data.ModelConfiguration
{
    public class MatchGroupPlayerModelConfiguration<T> : BaseModelConfiguration<T, int> where T : MatchGroupPlayer
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.HasKey(p => new { p.MatchGroupId, p.PlayerId });

            builder.HasOne(p => p.MatchGroup)
                .WithMany(p => (IEnumerable<T>)p.MatchGroupPlayers)
                .HasForeignKey(p => p.MatchGroupId)
                .IsRequired();

            builder.HasOne(p => p.Player)
                .WithMany(p => (IEnumerable<T>)p.MatchGroupPlayers)
                .HasForeignKey(p => p.PlayerId)
                .IsRequired();
        }
    }
}