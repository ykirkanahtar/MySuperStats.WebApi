using BasketballStats.WebApi.Data.Contracts;
using BasketballStats.WebApi.Data.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BasketballStats.WebApi.Data.ModelConfiguration
{
    public class BaseModelConfiguration<TEntity, TKey> : IEntityTypeConfiguration<TEntity>
        where TEntity : class, IBaseModel<TKey> where TKey : struct
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(p => p.CreateDateTime).IsRequired().HasColumnName(SnakeCaseNamingForDbObject.GetSqlColumnName<TEntity>(p => p.CreateDateTime));
            builder.Property(p => p.UpdateDateTime).HasColumnName(SnakeCaseNamingForDbObject.GetSqlColumnName<TEntity>(p => p.UpdateDateTime));
            builder.Property(p => p.DeleteDateTime).HasColumnName(SnakeCaseNamingForDbObject.GetSqlColumnName<TEntity>(p => p.DeleteDateTime));
            builder.Property(p => p.Status).HasColumnName(SnakeCaseNamingForDbObject.GetSqlColumnName<TEntity>(p => p.Status));
        }
    }
}
