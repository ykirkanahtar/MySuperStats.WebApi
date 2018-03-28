using BasketballStats.WebApi.Authorization.Models;
using BasketballStats.WebApi.Data.ModelConfiguration;
using BasketballStats.WebApi.Data.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BasketballStats.WebApi.Authorization.ModelConfigurations
{
    public class ClientApplicationModelConfiguration<T> : BaseModelConfiguration<T, int> where T : ClientApplication
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.ToTable(SnakeCaseNamingForDbObject.GetSqlTableName<T>());

            builder.Property(u => u.Id)
                .IsRequired()
                .HasColumnName(SnakeCaseNamingForDbObject.GetSqlColumnName<T>(p => p.Id));

            builder.Property(u => u.ClientApplicationName)
                .IsRequired()
                .HasColumnName(SnakeCaseNamingForDbObject.GetSqlColumnName<T>(p => p.ClientApplicationName))
                .HasMaxLength(20);

            builder.Property(u => u.ClientApplicationCode)
                .IsRequired()
                .HasColumnName(SnakeCaseNamingForDbObject.GetSqlColumnName<T>(p => p.ClientApplicationCode))
                .HasMaxLength(6);
            
            builder.Property(u => u.ClientApplicationPassword)
                .IsRequired()
                .HasColumnName(SnakeCaseNamingForDbObject.GetSqlColumnName<T>(p => p.ClientApplicationPassword))
                .HasMaxLength(50);
        }
    }
}