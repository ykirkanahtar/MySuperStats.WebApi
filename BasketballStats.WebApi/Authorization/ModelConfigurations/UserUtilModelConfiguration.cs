using BasketballStats.WebApi.Authorization.Models;
using BasketballStats.WebApi.Data.ModelConfiguration;
using BasketballStats.WebApi.Data.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BasketballStats.WebApi.Authorization.ModelConfigurations
{
    public class UserUtilModelConfiguration<T> : BaseModelConfiguration<T, int> where T : UserUtil
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.ToTable(SnakeCaseNamingForDbObject.GetSqlTableName<T>());

            builder.Property(u => u.Id)
                .IsRequired()
                .HasColumnName(SnakeCaseNamingForDbObject.GetSqlColumnName<T>(p => p.Id));

            builder.Property(u => u.SpecialValue)
                .IsRequired()
                .HasColumnName(SnakeCaseNamingForDbObject.GetSqlColumnName<T>(p => p.SpecialValue))
                .HasMaxLength(100);

            builder.Property(u => u.UserId)
                .IsRequired()
                .HasColumnName(SnakeCaseNamingForDbObject.GetSqlColumnName<T>(p => p.UserId));
        }
    }
}