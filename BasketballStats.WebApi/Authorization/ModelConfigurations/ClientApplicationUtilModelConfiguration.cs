using BasketballStats.WebApi.Authorization.Models;
using BasketballStats.WebApi.Data.ModelConfiguration;
using BasketballStats.WebApi.Data.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BasketballStats.WebApi.Authorization.ModelConfigurations
{
    public class ClientApplicationUtilModelConfiguration<T> : BaseModelConfiguration<T, int> where T : ClientApplicationUtil
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.ToTable(SnakeCaseNamingForDbObject.GetSqlTableName<T>());

            builder.Property(u => u.Id).HasColumnName(SnakeCaseNamingForDbObject.GetSqlColumnName<T>(p => p.Id));
            builder.Property(u => u.SpecialValue).IsRequired().HasMaxLength(100).HasColumnName(SnakeCaseNamingForDbObject.GetSqlColumnName<T>(p => p.SpecialValue));
            builder.Property(u => u.ClientApplicationId).IsRequired().HasColumnName(SnakeCaseNamingForDbObject.GetSqlColumnName<T>(p => p.ClientApplicationId));
        }
    }
}