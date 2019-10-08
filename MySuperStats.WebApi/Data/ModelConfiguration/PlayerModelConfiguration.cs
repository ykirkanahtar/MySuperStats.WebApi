using CustomFramework.Data.ModelConfiguration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySuperStats.Contracts.Utils;
using MySuperStats.WebApi.Models;

namespace MySuperStats.WebApi.Data.ModelConfiguration
{
    public class PlayerModelConfiguration : BaseModelConfiguration<Player, int>
    {
        public override void Configure(EntityTypeBuilder<Player> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.UserId);
            builder.Property(p => p.FirstName).HasMaxLength(FieldLengths.USER_FIRSTNAME_MAX);
            builder.Property(p => p.LastName).HasMaxLength(FieldLengths.USER_LASTNAME_MAX);
            builder.Property(p => p.BirthDate);
        }
    }
}