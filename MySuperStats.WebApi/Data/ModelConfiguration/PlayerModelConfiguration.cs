using MySuperStats.WebApi.Models;
using CustomFramework.Data.ModelConfiguration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MySuperStats.WebApi.Data.ModelConfiguration
{
    public class PlayerModelConfiguration : BaseModelConfiguration<Player, int> 
    {
        public override void Configure(EntityTypeBuilder<Player> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(25);

            builder.Property(p => p.Surname)
                .IsRequired()
                .HasMaxLength(25);

            builder.Property(p => p.BirthDate)
                .IsRequired();
        }
    }
}
