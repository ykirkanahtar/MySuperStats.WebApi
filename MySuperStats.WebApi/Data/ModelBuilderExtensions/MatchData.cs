using System;
using CustomFramework.Data.Contracts;
using Microsoft.EntityFrameworkCore;
using MySuperStats.WebApi.Models;

namespace MySuperStats.WebApi.Data.ModelBuilderExtensions
{
    public static class MatchData
    {
        public static ModelBuilder SeedMatchData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>().HasData(
                new Match
                {
                    Id = 1,
                    MatchGroupId = 1,
                    Order = 1,
                    DurationInMinutes = 60,
                    HomeTeamId = 1,
                    AwayTeamId = 2,
                    HomeTeamScore = 38.00m,
                    AwayTeamScore = 43.00m,
                    VideoLink = "https://www.youtube.com/watch?v=kE99vlYOB2Q",
                    MatchDate = new DateTime(2018, 2, 15),
                    CreateDateTime = new DateTime(2018, 3, 29),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );

            modelBuilder.Entity<Match>().HasData(
                new Match
                {
                    Id = 2,
                    MatchGroupId = 1,
                    Order = 1,
                    DurationInMinutes = 60,
                    HomeTeamId = 1,
                    AwayTeamId = 2,
                    HomeTeamScore = 32.00m,
                    AwayTeamScore = 36.00m,
                    VideoLink = "https://www.youtube.com/watch?v=wWCI6UwSglc",
                    MatchDate = new DateTime(2018, 2, 22),
                    CreateDateTime = new DateTime(2018, 3, 29),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );

            modelBuilder.Entity<Match>().HasData(
                new Match
                {
                    Id = 3,
                    MatchGroupId = 1,
                    Order = 1,
                    DurationInMinutes = 60,
                    HomeTeamId = 1,
                    AwayTeamId = 2,
                    HomeTeamScore = 42.00m,
                    AwayTeamScore = 35.00m,
                    VideoLink = "https://www.youtube.com/watch?v=egESDCEFAYI",
                    MatchDate = new DateTime(2018, 3, 22),
                    CreateDateTime = new DateTime(2018, 3, 29),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );

            modelBuilder.Entity<Match>().HasData(
                new Match
                {
                    Id = 4,
                    MatchGroupId = 1,
                    Order = 1,
                    DurationInMinutes = 60,
                    HomeTeamId = 1,
                    AwayTeamId = 2,
                    HomeTeamScore = 36.00m,
                    AwayTeamScore = 32.00m,
                    VideoLink = "https://www.youtube.com/watch?v=dVuBax06kpY",
                    MatchDate = new DateTime(2018, 3, 15),
                    CreateDateTime = new DateTime(2018, 3, 29),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );

            modelBuilder.Entity<Match>().HasData(
                new Match
                {
                    Id = 5,
                    MatchGroupId = 1,
                    Order = 1,
                    DurationInMinutes = 60,
                    HomeTeamId = 1,
                    AwayTeamId = 2,
                    HomeTeamScore = 56.00m,
                    AwayTeamScore = 47.00m,
                    VideoLink = "https://www.youtube.com/watch?v=NTWW2JwpOTE",
                    MatchDate = new DateTime(2018, 3, 29),
                    CreateDateTime = new DateTime(2018, 4, 1),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );

            modelBuilder.Entity<Match>().HasData(
                new Match
                {
                    Id = 6,
                    MatchGroupId = 1,
                    Order = 1,
                    DurationInMinutes = 60,
                    HomeTeamId = 1,
                    AwayTeamId = 2,
                    HomeTeamScore = 35.00m,
                    AwayTeamScore = 30.00m,
                    VideoLink = "https://www.youtube.com/watch?v=EIbnNsMsxQc",
                    MatchDate = new DateTime(2018, 4, 12),
                    CreateDateTime = new DateTime(2018, 4, 18),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );

            modelBuilder.Entity<Match>().HasData(
                new Match
                {
                    Id = 7,
                    MatchGroupId = 1,
                    Order = 1,
                    DurationInMinutes = 60,
                    HomeTeamId = 1,
                    AwayTeamId = 2,
                    HomeTeamScore = 47.00m,
                    AwayTeamScore = 43.00m,
                    VideoLink = "https://www.youtube.com/watch?v=3p7Z4LNknB8",
                    MatchDate = new DateTime(2018, 4, 19),
                    CreateDateTime = new DateTime(2018, 4, 20),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );

            modelBuilder.Entity<Match>().HasData(
                new Match
                {
                    Id = 8,
                    MatchGroupId = 1,
                    Order = 1,
                    DurationInMinutes = 60,
                    HomeTeamId = 1,
                    AwayTeamId = 2,
                    HomeTeamScore = 38.00m,
                    AwayTeamScore = 37.00m,
                    VideoLink = "https://www.youtube.com/watch?v=EVJvdvCDuMs",
                    MatchDate = new DateTime(2018, 4, 26),
                    CreateDateTime = new DateTime(2018, 4, 29),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );

            modelBuilder.Entity<Match>().HasData(
                new Match
                {
                    Id = 9,
                    MatchGroupId = 1,
                    Order = 1,
                    DurationInMinutes = 45,
                    HomeTeamId = 1,
                    AwayTeamId = 2,
                    HomeTeamScore = 23.00m,
                    AwayTeamScore = 25.00m,
                    VideoLink = "https://www.youtube.com/watch?v=Ueo_InIYTBk",
                    MatchDate = new DateTime(2018, 6, 21),
                    CreateDateTime = new DateTime(2018, 6, 27),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );

            modelBuilder.Entity<Match>().HasData(
                new Match
                {
                    Id = 10,
                    MatchGroupId = 1,
                    Order = 1,
                    DurationInMinutes = 60,
                    HomeTeamId = 1,
                    AwayTeamId = 2,
                    HomeTeamScore = 39.00m,
                    AwayTeamScore = 44.00m,
                    VideoLink = "https://www.youtube.com/watch?v=lplrXOBu3fs",
                    MatchDate = new DateTime(2018, 7, 5),
                    CreateDateTime = new DateTime(2018, 7, 10),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );

            modelBuilder.Entity<Match>().HasData(
                new Match
                {
                    Id = 11,
                    MatchGroupId = 1,
                    Order = 1,
                    DurationInMinutes = 30,
                    HomeTeamId = 1,
                    AwayTeamId = 2,
                    HomeTeamScore = 16.00m,
                    AwayTeamScore = 25.00m,
                    VideoLink = "https://www.youtube.com/watch?v=uVldmTIKMjo",
                    MatchDate = new DateTime(2018, 11, 8),
                    CreateDateTime = new DateTime(2018, 11, 13),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );

            modelBuilder.Entity<Match>().HasData(
                new Match
                {
                    Id = 12,
                    MatchGroupId = 1,
                    Order = 2,
                    DurationInMinutes = 30,
                    HomeTeamId = 1,
                    AwayTeamId = 2,
                    HomeTeamScore = 9.00m,
                    AwayTeamScore = 4.00m,
                    VideoLink = "https://www.youtube.com/watch?v=XaKCOZ5sKUE",
                    MatchDate = new DateTime(2018, 11, 8),
                    CreateDateTime = new DateTime(2018, 11, 13),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );

            return modelBuilder;
        }
    }
}