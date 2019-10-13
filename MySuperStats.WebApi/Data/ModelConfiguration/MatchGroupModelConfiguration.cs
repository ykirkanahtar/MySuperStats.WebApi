using CustomFramework.Data.ModelConfiguration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySuperStats.WebApi.Models;

namespace MySuperStats.WebApi.Data.ModelConfiguration
{
    public class MatchGroupModelConfiguration : BaseModelConfiguration<MatchGroup, int>
    {
        public override void Configure(EntityTypeBuilder<MatchGroup> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.GroupName).HasMaxLength(100).IsRequired();
            builder.Property(p => p.MatchGroupType).IsRequired();

            builder.HasIndex(p => p.GroupName);
        }
    }
}