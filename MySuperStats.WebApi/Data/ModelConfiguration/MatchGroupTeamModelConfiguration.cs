using System.Collections.Generic;
using CustomFramework.Data.ModelConfiguration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySuperStats.WebApi.Models;

namespace MySuperStats.WebApi.Data.ModelConfiguration
{
    public class MatchGroupTeamModelConfiguration : BaseModelConfiguration<MatchGroupTeam, int>
    {
        public override void Configure(EntityTypeBuilder<MatchGroupTeam> builder)
        {
            base.Configure(builder);

            builder.HasKey(p => new { p.MatchGroupId, p.TeamId });

            builder.HasOne(p => p.MatchGroup)
                .WithMany(p => p.MatchGroupTeams)
                .HasForeignKey(p => p.MatchGroupId)
                .IsRequired();

            builder.HasOne(p => p.Team)
                .WithMany(p => p.MatchGroupTeams)
                .HasForeignKey(p => p.TeamId)
                .IsRequired();
        }
    }
}