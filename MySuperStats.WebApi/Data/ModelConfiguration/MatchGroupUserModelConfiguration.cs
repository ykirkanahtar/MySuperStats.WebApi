using CustomFramework.Data.ModelConfiguration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySuperStats.WebApi.Models;
using System.Collections.Generic;

namespace MySuperStats.WebApi.Data.ModelConfiguration
{
    public class MatchGroupUserModelConfiguration : BaseModelConfiguration<MatchGroupUser, int>
    {
        public override void Configure(EntityTypeBuilder<MatchGroupUser> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.MatchGroupId).IsRequired();
            builder.Property(p => p.RoleId).IsRequired();
            builder.Property(p => p.UserId).IsRequired();

            builder.HasIndex(p => new { p.MatchGroupId, p.UserId, p.RoleId }).IsUnique();

            builder.HasOne(p => p.MatchGroup)
                .WithMany(p => p.MatchGroupUsers)
                .HasForeignKey(p => p.MatchGroupId)
                .IsRequired();

            builder.HasOne(p => p.User)
                .WithMany(p => p.MatchGroupUsers)
                .HasForeignKey(p => p.UserId)
                .IsRequired();

            builder.HasOne(p => p.Role)
                .WithMany(p => p.MatchGroupUsers)
                .HasForeignKey(p => p.RoleId)
                .IsRequired();                
        }
    }
}