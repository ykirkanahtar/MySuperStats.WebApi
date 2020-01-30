using MySuperStats.WebApi.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CustomFramework.BaseWebApi.Data.ModelConfiguration;

namespace MySuperStats.WebApi.Data.ModelConfiguration
{
    public class TeamModelConfiguration : BaseModelConfiguration<Team, int>
    {
        public override void Configure(EntityTypeBuilder<Team> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.TeamName)
                .IsRequired()
                .HasMaxLength(25);

            builder.Property(p => p.Color)
                .IsRequired()
                .HasMaxLength(25);

            builder.HasIndex(p => p.TeamName);
        }
    }
}
