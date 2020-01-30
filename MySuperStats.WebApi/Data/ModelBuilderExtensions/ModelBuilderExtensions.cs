using System;
using System.Collections.Generic;
using System.Linq;
using CustomFramework.BaseWebApi.Contracts;
using CustomFramework.BaseWebApi.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MySuperStats.Contracts.Enums;
using MySuperStats.WebApi.Models;

namespace MySuperStats.WebApi.Data.ModelBuilderExtensions
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
                    CreateDateTime = new DateTime(2019, 1, 1),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );

            modelBuilder.Entity<Player>().HasData(
                new Player
                {
                    Id = 1,
                    UserId = 1,
                    FirstName = "Yunus Emre",
                    LastName = "Kırkanahtar",
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
                    CreateDateTime = new DateTime(2019, 1, 1),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );

            modelBuilder.Entity<Player>().HasData(
                new Player
                {
                    Id = 2,
                    UserId = 2,
                    FirstName = "Ali",
                    LastName = "Yunuslar",
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
                    CreateDateTime = new DateTime(2019, 1, 1),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );

            modelBuilder.Entity<Player>().HasData(
                new Player
                {
                    Id = 3,
                    UserId = 3,
                    FirstName = "Arbak",
                    LastName = "Demirdağ",
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
                    CreateDateTime = new DateTime(2019, 1, 1),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );

            modelBuilder.Entity<Player>().HasData(
                new Player
                {
                    Id = 4,
                    UserId = 4,
                    FirstName = "Fahri",
                    LastName = "Söylemezgiller",
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
                    CreateDateTime = new DateTime(2019, 1, 1),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );

            modelBuilder.Entity<Player>().HasData(
                new Player
                {
                    Id = 5,
                    UserId = 5,
                    FirstName = "Mahmut",
                    LastName = "Balci",
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
                    CreateDateTime = new DateTime(2019, 1, 1),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );

            modelBuilder.Entity<Player>().HasData(
                new Player
                {
                    Id = 6,
                    UserId = 6,
                    FirstName = "İlker",
                    LastName = "Oyman",
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
                    CreateDateTime = new DateTime(2019, 1, 1),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );

            modelBuilder.Entity<Player>().HasData(
                new Player
                {
                    Id = 7,
                    UserId = 7,
                    FirstName = "Gürcan",
                    LastName = "Ateş",
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
                    CreateDateTime = new DateTime(2019, 1, 1),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );

            modelBuilder.Entity<Player>().HasData(
                new Player
                {
                    Id = 8,
                    UserId = 8,
                    FirstName = "Ceyhan",
                    LastName = "Gönen",
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
                    CreateDateTime = new DateTime(2019, 1, 1),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );

            modelBuilder.Entity<Player>().HasData(
                new Player
                {
                    Id = 9,
                    UserId = 9,
                    FirstName = "Ahmet",
                    LastName = "Okçular",
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
                    CreateDateTime = new DateTime(2019, 1, 1),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );

            modelBuilder.Entity<Player>().HasData(
                 new Player
                 {
                     Id = 10,
                     UserId = 10,
                     FirstName = "Mehmet",
                     LastName = "Aygün",
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
                    CreateDateTime = new DateTime(2019, 1, 1),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );

            modelBuilder.Entity<Player>().HasData(
                 new Player
                 {
                     Id = 11,
                     UserId = 11,
                     FirstName = "Fırat",
                     LastName = "Timur",
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
                    CreateDateTime = new DateTime(2019, 1, 1),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );

            modelBuilder.Entity<Player>().HasData(
                 new Player
                 {
                     Id = 12,
                     UserId = 12,
                     FirstName = "Gökay",
                     LastName = "Patar",
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
                    CreateDateTime = new DateTime(2019, 1, 1),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );

            modelBuilder.Entity<Player>().HasData(
                 new Player
                 {
                     Id = 13,
                     UserId = 13,
                     FirstName = "Altuğ",
                     LastName = "Demirsel",
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
                    CreateDateTime = new DateTime(2019, 1, 1),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );

            modelBuilder.Entity<Player>().HasData(
                 new Player
                 {
                     Id = 14,
                     UserId = 14,
                     FirstName = "Ömer",
                     LastName = "Sefer",
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
                    CreateDateTime = new DateTime(2019, 1, 1),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );

            modelBuilder.Entity<Player>().HasData(
                 new Player
                 {
                     Id = 15,
                     UserId = 15,
                     FirstName = "Caner",
                     LastName = "Pazar",
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
                        NormalizedName = roleEnum.ToString().ToUpper().Replace('İ', 'I'),
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
                    MatchGroupType = MatchGroupType.Basketball,
                    CreateDateTime = new DateTime(2019, 1, 1),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );

            modelBuilder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int>
                {
                    RoleId = 1,
                    UserId = 1
                }
            );

            for (var i = 1; i < 16; i++)
            {
                var matchGroupUser = new MatchGroupUser
                {
                    Id = i,
                    UserId = i,
                    PlayerId = i,
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

            modelBuilder.Entity<Team>().HasData(
                new Team
                {
                    Id = 1,
                    TeamName = "Home",
                    Color = "Green",
                    CreateDateTime = new DateTime(2018, 3, 29),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );

            modelBuilder.Entity<Team>().HasData(
                new Team
                {
                    Id = 2,
                    TeamName = "Away",
                    Color = "White",
                    CreateDateTime = new DateTime(2018, 3, 29),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );

            modelBuilder = MatchData.SeedMatchData(modelBuilder);
            modelBuilder = BasketballStatData.SeedBasketballData(modelBuilder);


            return modelBuilder;
        }
    }
}