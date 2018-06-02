using BasketballStats.WebApi.Models;
using CustomFramework.Data.ModelConfiguration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BasketballStats.WebApi.Data.ModelConfiguration
{
    public class TeamModelConfiguration<T> : BaseModelConfiguration<T, int> where T : Team
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(25);

            builder.Property(p => p.Color)
                .IsRequired()
                .HasMaxLength(25);

            builder.HasIndex(p => p.Name).IsUnique();
        }
    }
}
