﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasketballStats.WebApi.Authorization.ModelConfigurations;
using BasketballStats.WebApi.Authorization.Models;
using Microsoft.EntityFrameworkCore;

namespace BasketballStats.WebApi.Authorization.Data
{
    public class AuthorizationContext : DbContext
    {
        public AuthorizationContext(DbContextOptions options)
            : base(options)
        {

        }

        public virtual DbSet<ClientApplication> ClientApplications { get; set; }
        public virtual DbSet<ClientApplicationUtil> ClientApplicationUtils { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Claim> Claims { get; set; }
        public virtual DbSet<RoleClaim> RoleClaims { get; set; }
        public virtual DbSet<UserClaim> UserClaims { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<UserUtil> UserUtils { get; set; }
        public virtual DbSet<RoleEntityClaim> RoleEntityClaims { get; set; }
        public virtual DbSet<UserEntityClaim> UserEntityClaims { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ClientApplicationModelConfiguration<ClientApplication>());
            modelBuilder.ApplyConfiguration(new ClientApplicationUtilModelConfiguration<ClientApplicationUtil>());
            modelBuilder.ApplyConfiguration(new UserModelConfiguration<User>());
            modelBuilder.ApplyConfiguration(new RoleModelConfiguration<Role>());
            modelBuilder.ApplyConfiguration(new ClaimModelConfiguration<Claim>());
            modelBuilder.ApplyConfiguration(new RoleClaimModelConfiguration<RoleClaim>());
            modelBuilder.ApplyConfiguration(new UserClaimModelConfiguration<UserClaim>());
            modelBuilder.ApplyConfiguration(new UserRoleModelConfiguration<UserRole>());
            modelBuilder.ApplyConfiguration(new UserUtilModelConfiguration<UserUtil>());
            modelBuilder.ApplyConfiguration(new RoleEntityClaimModelConfiguration<RoleEntityClaim>());
            modelBuilder.ApplyConfiguration(new UserEntityClaimModelConfiguration<UserEntityClaim>());

            modelBuilder.Entity<ClientApplicationUtil>()
                .HasOne(r => r.ClientApplication)
                .WithOne(c => c.ClientApplicationUtil)
                .HasForeignKey<ClientApplicationUtil>(r => r.ClientApplicationId);

            modelBuilder.Entity<RoleClaim>()
                .HasOne(r => r.Role)
                .WithMany(c => c.RoleClaims)
                .HasForeignKey(r => r.RoleId);

            modelBuilder.Entity<RoleClaim>()
                .HasOne(r => r.Claim)
                .WithMany(c => c.RoleClaims)
                .HasForeignKey(r => r.ClaimId);

            modelBuilder.Entity<RoleEntityClaim>()
                .HasOne(r => r.Role)
                .WithMany(c => c.RoleEntityClaims)
                .HasForeignKey(r => r.RoleId);

            modelBuilder.Entity<UserClaim>()
                .HasOne(r => r.User)
                .WithMany(c => c.UserClaims)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<UserClaim>()
                .HasOne(r => r.Claim)
                .WithMany(c => c.UserClaims)
                .HasForeignKey(r => r.ClaimId);

            modelBuilder.Entity<UserEntityClaim>()
                .HasOne(r => r.User)
                .WithMany(c => c.UserEntityClaims)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(r => r.User)
                .WithMany(c => c.UserRoles)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(r => r.Role)
                .WithMany(c => c.UserRoles)
                .HasForeignKey(r => r.RoleId);

            modelBuilder.Entity<UserUtil>()
                .HasOne(r => r.User)
                .WithOne(c => c.UserUtil)
                .HasForeignKey<UserUtil>(r => r.UserId);
        }
    }
}
