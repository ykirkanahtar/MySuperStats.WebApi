using MySuperStats.WebApi.Models;
using CustomFramework.Data.ModelConfiguration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MySuperStats.WebApi.Data.ModelConfiguration
{
    public class TeamModelConfiguration : BaseModelConfiguration<Team, int>
    {
        public override void Configure(EntityTypeBuilder<Team> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(25);

            builder.Property(p => p.Color)
                .IsRequired()
                .HasMaxLength(25);

            builder.HasIndex(p => p.Name);
        }
    }
}
