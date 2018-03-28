using BasketballStats.WebApi.Authorization.Models;
using BasketballStats.WebApi.Data.ModelConfiguration;
using BasketballStats.WebApi.Data.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BasketballStats.WebApi.Authorization.ModelConfigurations
{
    public class UserModelConfiguration<T> : BaseModelConfiguration<T, int> where T : User
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.ToTable(SnakeCaseNamingForDbObject.GetSqlTableName<T>());

            builder.Property(p => p.Id)
                .IsRequired()
                .HasColumnName(SnakeCaseNamingForDbObject.GetSqlColumnName<T>(p => p.Id));

            builder.Property(p => p.UserName)
                .IsRequired()
                .HasColumnName(SnakeCaseNamingForDbObject.GetSqlColumnName<T>(p => p.UserName))
                .HasMaxLength(25);

            builder.Property(p => p.Password)
                .IsRequired()
                .HasColumnName(SnakeCaseNamingForDbObject.GetSqlColumnName<T>(p => p.Password))
                .HasMaxLength(256);

            builder.Property(p => p.Email)
                .IsRequired()
                .HasColumnName(SnakeCaseNamingForDbObject.GetSqlColumnName<T>(p => p.Email))
                .HasMaxLength(100);

            builder.Property(p => p.EmailConfirmed)
                .IsRequired()
                .HasColumnName(SnakeCaseNamingForDbObject.GetSqlColumnName<T>(p => p.EmailConfirmed));

            builder.Property(p => p.EmailConfirmCode)
                .IsRequired()
                .HasColumnName(SnakeCaseNamingForDbObject.GetSqlColumnName<T>(p => p.EmailConfirmCode))
                .HasMaxLength(6)
                .HasDefaultValue(new Random().Next(100000, 999999));

            builder.Property(p => p.AccessFailedCount)
                .IsRequired()
                .HasColumnName(SnakeCaseNamingForDbObject.GetSqlColumnName<T>(p => p.AccessFailedCount))
                .HasDefaultValue(0);

            builder.Property(p => p.Lockout)
                .IsRequired()
                .HasColumnName(SnakeCaseNamingForDbObject.GetSqlColumnName<T>(p => p.Lockout));

            builder.Property(p => p.LockoutEndDateTime)
                .IsRequired(false)
                .HasColumnName(SnakeCaseNamingForDbObject.GetSqlColumnName<T>(p => p.LockoutEndDateTime))
                .HasMaxLength(256);
        }
    }
}
