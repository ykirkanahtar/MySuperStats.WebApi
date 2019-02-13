using CustomFramework.Data.ModelConfiguration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySuperStats.WebApi.Models;

namespace MySuperStats.WebApi.Data.ModelConfiguration
{
    public class MatchGroupModelConfiguration<T> : BaseModelConfiguration<T, int> where T : MatchGroup
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.GroupName).HasMaxLength(100).IsRequired();

            builder.HasIndex(p => p.GroupName);
        }
    }
}