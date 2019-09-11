using System;
using System.Collections.Generic;
using System.Linq;
using CustomFramework.Data.Enums;
using CustomFramework.WebApiUtils.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MySuperStats.Contracts.Enums;
using MySuperStats.WebApi.Enums;
using MySuperStats.WebApi.Models;

namespace MySuperStats.WebApi.Data
{
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    UserName = "yunusemre@gmail.com",
                    NormalizedUserName = "YUNUSEMRE@GMAIL.COM",
                    Email = "yunusemre@gmail.com",
                    NormalizedEmail = "YUNUSEMRE@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEF8ox4odFYBEgV+2mBcGv8jw4KXJKnjayRE9pJ91NG8Yp+9uSVMx6QU7TP2M9MOCGw==",
                    SecurityStamp = "ABQONVFKVTNPYSRLSGOFKH5KNSVIANUW",
                    ConcurrencyStamp = "ca40583b-394d-48a0-879e-c11a21da1aeb",
                    LockoutEnabled = true,
                    FirstName = "YUNUS EMRE",
                    Surname = "KIRKANAHTAR",
                    BirthDate = new DateTime(1982, 2, 14),
                    CreateDateTime = new DateTime(2019, 1, 1),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 2,
                    UserName = "y.unusemre@gmail.com",
                    NormalizedUserName = "Y.UNUSEMRE@GMAIL.COM",
                    Email = "y.unusemre@gmail.com",
                    NormalizedEmail = "Y.UNUSEMRE@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEF8ox4odFYBEgV+2mBcGv8jw4KXJKnjayRE9pJ91NG8Yp+9uSVMx6QU7TP2M9MOCGw==",
                    SecurityStamp = "ABQONVFKVTNPYSRLSGOFKH5KNSVIANUW",
                    ConcurrencyStamp = "ca40583b-394d-48a0-879e-c11a21da1aeb",
                    LockoutEnabled = true,
                    FirstName = "ALİ",
                    Surname = "YUNUSLAR",
                    BirthDate = new DateTime(1975, 9, 16),
                    CreateDateTime = new DateTime(2019, 1, 1),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 3,
                    UserName = "y..unusemre@gmail.com",
                    NormalizedUserName = "Y..UNUSEMRE@GMAIL.COM",
                    Email = "y..unusemre@gmail.com",
                    NormalizedEmail = "Y..UNUSEMRE@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEF8ox4odFYBEgV+2mBcGv8jw4KXJKnjayRE9pJ91NG8Yp+9uSVMx6QU7TP2M9MOCGw==",
                    SecurityStamp = "ABQONVFKVTNPYSRLSGOFKH5KNSVIANUW",
                    ConcurrencyStamp = "ca40583b-394d-48a0-879e-c11a21da1aeb",
                    LockoutEnabled = true,
                    FirstName = "ARBAK",
                    Surname = "DEMİRDAĞ",
                    BirthDate = new DateTime(1975, 2, 4),
                    CreateDateTime = new DateTime(2019, 1, 1),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 4,
                    UserName = "y...unusemre@gmail.com",
                    NormalizedUserName = "Y...UNUSEMRE@GMAIL.COM",
                    Email = "y...unusemre@gmail.com",
                    NormalizedEmail = "Y...UNUSEMRE@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEF8ox4odFYBEgV+2mBcGv8jw4KXJKnjayRE9pJ91NG8Yp+9uSVMx6QU7TP2M9MOCGw==",
                    SecurityStamp = "ABQONVFKVTNPYSRLSGOFKH5KNSVIANUW",
                    ConcurrencyStamp = "ca40583b-394d-48a0-879e-c11a21da1aeb",
                    LockoutEnabled = true,
                    FirstName = "FAHRİ",
                    Surname = "SÖYLEMEZGİLLER",
                    BirthDate = new DateTime(1970, 1, 27),
                    CreateDateTime = new DateTime(2019, 1, 1),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 5,
                    UserName = "yu.nusemre@gmail.com",
                    NormalizedUserName = "YU.NUSEMRE@GMAIL.COM",
                    Email = "yu.nusemre@gmail.com",
                    NormalizedEmail = "YU.NUSEMRE@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEF8ox4odFYBEgV+2mBcGv8jw4KXJKnjayRE9pJ91NG8Yp+9uSVMx6QU7TP2M9MOCGw==",
                    SecurityStamp = "ABQONVFKVTNPYSRLSGOFKH5KNSVIANUW",
                    ConcurrencyStamp = "ca40583b-394d-48a0-879e-c11a21da1aeb",
                    LockoutEnabled = true,
                    FirstName = "MAHMUT",
                    Surname = "BALCİ",
                    BirthDate = new DateTime(1982, 7, 20),
                    CreateDateTime = new DateTime(2019, 1, 1),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 6,
                    UserName = "yu..nusemre@gmail.com",
                    NormalizedUserName = "YU..NUSEMRE@GMAIL.COM",
                    Email = "yu..nusemre@gmail.com",
                    NormalizedEmail = "YU..NUSEMRE@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEF8ox4odFYBEgV+2mBcGv8jw4KXJKnjayRE9pJ91NG8Yp+9uSVMx6QU7TP2M9MOCGw==",
                    SecurityStamp = "ABQONVFKVTNPYSRLSGOFKH5KNSVIANUW",
                    ConcurrencyStamp = "ca40583b-394d-48a0-879e-c11a21da1aeb",
                    LockoutEnabled = true,
                    FirstName = "İLKER",
                    Surname = "OYMAN",
                    BirthDate = new DateTime(1971, 1, 21),
                    CreateDateTime = new DateTime(2019, 1, 1),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 7,
                    UserName = "yu...nusemre@gmail.com",
                    NormalizedUserName = "YU...NUSEMRE@GMAIL.COM",
                    Email = "yu...nusemre@gmail.com",
                    NormalizedEmail = "YU...NUSEMRE@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEF8ox4odFYBEgV+2mBcGv8jw4KXJKnjayRE9pJ91NG8Yp+9uSVMx6QU7TP2M9MOCGw==",
                    SecurityStamp = "ABQONVFKVTNPYSRLSGOFKH5KNSVIANUW",
                    ConcurrencyStamp = "ca40583b-394d-48a0-879e-c11a21da1aeb",
                    LockoutEnabled = true,
                    FirstName = "GÜRCAN",
                    Surname = "ATEŞ",
                    BirthDate = new DateTime(1984, 10, 17),
                    CreateDateTime = new DateTime(2019, 1, 1),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 8,
                    UserName = "yun.usemre@gmail.com",
                    NormalizedUserName = "YUN.USEMRE@GMAIL.COM",
                    Email = "yun.usemre@gmail.com",
                    NormalizedEmail = "YUN.USEMRE@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEF8ox4odFYBEgV+2mBcGv8jw4KXJKnjayRE9pJ91NG8Yp+9uSVMx6QU7TP2M9MOCGw==",
                    SecurityStamp = "ABQONVFKVTNPYSRLSGOFKH5KNSVIANUW",
                    ConcurrencyStamp = "ca40583b-394d-48a0-879e-c11a21da1aeb",
                    LockoutEnabled = true,
                    FirstName = "CEYHAN",
                    Surname = "GÖNEN",
                    BirthDate = new DateTime(1988, 1, 16),
                    CreateDateTime = new DateTime(2019, 1, 1),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 9,
                    UserName = "yun..usemre@gmail.com",
                    NormalizedUserName = "YUN..USEMRE@GMAIL.COM",
                    Email = "yun..usemre@gmail.com",
                    NormalizedEmail = "YUN..USEMRE@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEF8ox4odFYBEgV+2mBcGv8jw4KXJKnjayRE9pJ91NG8Yp+9uSVMx6QU7TP2M9MOCGw==",
                    SecurityStamp = "ABQONVFKVTNPYSRLSGOFKH5KNSVIANUW",
                    ConcurrencyStamp = "ca40583b-394d-48a0-879e-c11a21da1aeb",
                    LockoutEnabled = true,
                    FirstName = "AHMET",
                    Surname = "OKÇULAR",
                    BirthDate = new DateTime(1970, 3, 10),
                    CreateDateTime = new DateTime(2019, 1, 1),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 10,
                    UserName = "yun...usemre@gmail.com",
                    NormalizedUserName = "YUN...USEMRE@GMAIL.COM",
                    Email = "yun...usemre@gmail.com",
                    NormalizedEmail = "YUN...USEMRE@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEF8ox4odFYBEgV+2mBcGv8jw4KXJKnjayRE9pJ91NG8Yp+9uSVMx6QU7TP2M9MOCGw==",
                    SecurityStamp = "ABQONVFKVTNPYSRLSGOFKH5KNSVIANUW",
                    ConcurrencyStamp = "ca40583b-394d-48a0-879e-c11a21da1aeb",
                    LockoutEnabled = true,
                    FirstName = "MEHMET",
                    Surname = "AYGÜN",
                    BirthDate = new DateTime(1973, 7, 21),
                    CreateDateTime = new DateTime(2019, 1, 1),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 11,
                    UserName = "yunu.semre@gmail.com",
                    NormalizedUserName = "YUNU.SEMRE@GMAIL.COM",
                    Email = "yunu.semre@gmail.com",
                    NormalizedEmail = "YUNU.SEMRE@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEF8ox4odFYBEgV+2mBcGv8jw4KXJKnjayRE9pJ91NG8Yp+9uSVMx6QU7TP2M9MOCGw==",
                    SecurityStamp = "ABQONVFKVTNPYSRLSGOFKH5KNSVIANUW",
                    ConcurrencyStamp = "ca40583b-394d-48a0-879e-c11a21da1aeb",
                    LockoutEnabled = true,
                    FirstName = "FIRAT",
                    Surname = "TİMUR",
                    BirthDate = new DateTime(1987, 4, 2),
                    CreateDateTime = new DateTime(2019, 1, 1),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 12,
                    UserName = "yunus.emre@gmail.com",
                    NormalizedUserName = "YUNUS.EMRE@GMAIL.COM",
                    Email = "yunus.emre@gmail.com",
                    NormalizedEmail = "YUNUS.EMRE@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEF8ox4odFYBEgV+2mBcGv8jw4KXJKnjayRE9pJ91NG8Yp+9uSVMx6QU7TP2M9MOCGw==",
                    SecurityStamp = "ABQONVFKVTNPYSRLSGOFKH5KNSVIANUW",
                    ConcurrencyStamp = "ca40583b-394d-48a0-879e-c11a21da1aeb",
                    LockoutEnabled = true,
                    FirstName = "GÖKAY",
                    Surname = "PATAR",
                    BirthDate = new DateTime(1992, 9, 5),
                    CreateDateTime = new DateTime(2019, 1, 1),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 13,
                    UserName = "yunuse.mre@gmail.com",
                    NormalizedUserName = "YUNUSE.MRE@GMAIL.COM",
                    Email = "yunusemre@gmail.com",
                    NormalizedEmail = "YUNUSE.MRE@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEF8ox4odFYBEgV+2mBcGv8jw4KXJKnjayRE9pJ91NG8Yp+9uSVMx6QU7TP2M9MOCGw==",
                    SecurityStamp = "ABQONVFKVTNPYSRLSGOFKH5KNSVIANUW",
                    ConcurrencyStamp = "ca40583b-394d-48a0-879e-c11a21da1aeb",
                    LockoutEnabled = true,
                    FirstName = "ALTUĞ",
                    Surname = "DEMİRSEL",
                    BirthDate = new DateTime(1989, 9, 12),
                    CreateDateTime = new DateTime(2019, 1, 1),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 14,
                    UserName = "y.u.nusemre@gmail.com",
                    NormalizedUserName = "Y.U.NUSEMRE@GMAIL.COM",
                    Email = "y.u.nusemre@gmail.com",
                    NormalizedEmail = "Y.U.NUSEMRE@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEF8ox4odFYBEgV+2mBcGv8jw4KXJKnjayRE9pJ91NG8Yp+9uSVMx6QU7TP2M9MOCGw==",
                    SecurityStamp = "ABQONVFKVTNPYSRLSGOFKH5KNSVIANUW",
                    ConcurrencyStamp = "ca40583b-394d-48a0-879e-c11a21da1aeb",
                    LockoutEnabled = true,
                    FirstName = "ÖMER",
                    Surname = "SEFER",
                    BirthDate = new DateTime(2000, 7, 31),
                    CreateDateTime = new DateTime(2019, 1, 1),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 15,
                    UserName = "y.u.n.usemre@gmail.com",
                    NormalizedUserName = "Y.U.N.USEMRE@GMAIL.COM",
                    Email = "y.u.n.usemre@gmail.com",
                    NormalizedEmail = "Y.U.N.USEMRE@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEF8ox4odFYBEgV+2mBcGv8jw4KXJKnjayRE9pJ91NG8Yp+9uSVMx6QU7TP2M9MOCGw==",
                    SecurityStamp = "ABQONVFKVTNPYSRLSGOFKH5KNSVIANUW",
                    ConcurrencyStamp = "ca40583b-394d-48a0-879e-c11a21da1aeb",
                    LockoutEnabled = true,
                    FirstName = "CANER",
                    Surname = "PAZAR",
                    BirthDate = new DateTime(1987, 10, 25),
                    CreateDateTime = new DateTime(2019, 1, 1),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );

            modelBuilder.Entity<ClientApplication>().HasData(
                new ClientApplication
                {
                    Id = 1,
                    CreateDateTime = new DateTime(2019, 1, 1),
                    Status = Status.Active,
                    CreateUserId = 1,
                    ClientApplicationName = "web",
                    ClientApplicationCode = "web",
                    ClientApplicationPassword = "8ohVCPHTYZ3pYrhIBhLYSyiDkYbiKiA7AcRpvkuIOls=",
                    SecurityStamp = "nFOhCb4zVdFj8N/aJxnIVA==",

                }
            );

            var roleEnums = Enum.GetValues(typeof(RoleEnum)).Cast<RoleEnum>().ToList();

            foreach (var roleEnum in roleEnums)
            {
                modelBuilder.Entity<Role>().HasData(
                    new Role
                    {
                        Id = (int)roleEnum,
                        Name = roleEnum.ToString(),
                        NormalizedName = roleEnum.ToString().ToUpper(),
                        Status = Status.Active
                    }
                );
            }

            var permissionEnums = Enum.GetNames(typeof(PermissionEnum)).ToList();

            var roleClaimId = 1;
            modelBuilder.Entity<IdentityRoleClaim<int>>().HasData(
                    new IdentityRoleClaim<int>
                    {
                        Id = roleClaimId,
                        ClaimType = "OnlySystemAdmin",
                        ClaimValue = "true",
                        RoleId = 1,
                    }
                );

            roleClaimId++;

            foreach (var permissionEnum in permissionEnums)
            {
                modelBuilder.Entity<IdentityRoleClaim<int>>().HasData(
                    new IdentityRoleClaim<int>
                    {
                        Id = roleClaimId,
                        ClaimType = permissionEnum,
                        ClaimValue = "true",
                        RoleId = 1,
                    }
                );
                roleClaimId++;
            }

            var groupAdminPermissionEnums = new List<string>
            {
                PermissionEnum.CreateBasketballStat.ToString(),
                PermissionEnum.CreateFootballStat.ToString(),
                PermissionEnum.CreateMatch.ToString(),
                PermissionEnum.UpdateMatch.ToString(),
                PermissionEnum.CreateMatchGroupUser.ToString(),
                PermissionEnum.DeleteMatchGroupUser.ToString()
            };

            foreach (var permissionEnum in groupAdminPermissionEnums)
            {
                modelBuilder.Entity<IdentityRoleClaim<int>>().HasData(
                    new IdentityRoleClaim<int>
                    {
                        Id = roleClaimId,
                        ClaimType = permissionEnum,
                        ClaimValue = "true",
                        RoleId = 2,
                    }
                );
                roleClaimId++;
            }

            var editorPermissionEnums = new List<string>
            {
                PermissionEnum.CreateBasketballStat.ToString(),
                PermissionEnum.CreateFootballStat.ToString(),
                PermissionEnum.CreateMatch.ToString(),
                PermissionEnum.UpdateMatch.ToString(),
            };

            foreach (var permissionEnum in editorPermissionEnums)
            {
                modelBuilder.Entity<IdentityRoleClaim<int>>().HasData(
                    new IdentityRoleClaim<int>
                    {
                        Id = roleClaimId,
                        ClaimType = permissionEnum,
                        ClaimValue = "true",
                        RoleId = 3,
                    }
                );
                roleClaimId++;
            }

            modelBuilder.Entity<MatchGroup>().HasData(
                new MatchGroup
                {
                    Id = 1,
                    GroupName = "Provus Basketbol",
                    CreateDateTime = new DateTime(2019, 1, 1),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );

            for (var i = 1; i < 16; i++)
            {
                var matchGroupUser = new MatchGroupUser
                {
                    Id = i,
                    UserId = i,
                    MatchGroupId = 1,
                    CreateDateTime = new DateTime(2019, 1, 1),
                    CreateUserId = 1,
                    Status = Status.Active
                };

                if (i == 1) matchGroupUser.RoleId = (int)RoleEnum.Admin;
                else if (i == 4 || i == 5) matchGroupUser.RoleId = (int)RoleEnum.GroupAdmin;
                else matchGroupUser.RoleId = (int)RoleEnum.Player;

                modelBuilder.Entity<MatchGroupUser>().HasData(matchGroupUser);
            }

            return modelBuilder;
        }
    }
}