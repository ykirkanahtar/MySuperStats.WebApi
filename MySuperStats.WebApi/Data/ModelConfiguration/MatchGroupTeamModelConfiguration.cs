using System.Collections.Generic;
using CustomFramework.Data.ModelConfiguration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySuperStats.WebApi.Models;

namespace MySuperStats.WebApi.Data.ModelConfiguration
{
    public class MatchGroupTeamModelConfiguration<T> : BaseModelConfiguration<T, int> where T : MatchGroupTeam
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.HasKey(p => new { p.MatchGroupId, p.TeamId });

            builder.HasOne(p => p.MatchGroup)
                .WithMany(p => (IEnumerable<T>)p.MatchGroupTeams)
                .HasForeignKey(p => p.MatchGroupId)
                .IsRequired();

            builder.HasOne(p => p.Team)
                .WithMany(p => (IEnumerable<T>)p.MatchGroupTeams)
                .HasForeignKey(p => p.TeamId)
                .IsRequired();
        }
    }
}