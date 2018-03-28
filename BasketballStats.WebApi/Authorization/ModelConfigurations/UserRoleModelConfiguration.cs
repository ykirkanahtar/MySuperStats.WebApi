using BasketballStats.WebApi.Authorization.Models;
using BasketballStats.WebApi.Data.ModelConfiguration;
using BasketballStats.WebApi.Data.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BasketballStats.WebApi.Authorization.ModelConfigurations
{
    public class UserRoleModelConfiguration<T> : BaseModelConfiguration<T, int> where T : UserRole
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.ToTable(SnakeCaseNamingForDbObject.GetSqlTableName<T>());

            builder.Property(p => p.Id)
                .IsRequired()
                .HasColumnName(SnakeCaseNamingForDbObject.GetSqlColumnName<T>(p => p.Id));

            builder.Property(p => p.UserId)
                .IsRequired()
                .HasColumnName(SnakeCaseNamingForDbObject.GetSqlColumnName<T>(p => p.UserId));

            builder.Property(p => p.RoleId)
                .IsRequired()
                .HasColumnName(SnakeCaseNamingForDbObject.GetSqlColumnName<T>(p => p.RoleId));

        }
    }
}