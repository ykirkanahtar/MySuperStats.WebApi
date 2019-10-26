using System;
using CustomFramework.Data.Contracts;
using Microsoft.EntityFrameworkCore;
using MySuperStats.WebApi.Models;

namespace MySuperStats.WebApi.Data.ModelBuilderExtensions
{
    public static class BasketballStatData
    {
        public static ModelBuilder SeedBasketballData(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 1,
                    MatchId = 5,
                    TeamId = 2,
                    PlayerId = 4,
                    OnePoint = 17.00m,
                    TwoPoint = 1.00m,
                    MissingOnePoint = 23.00m,
                    MissingTwoPoint = 1.00m,
                    Rebound = 27.00m,
                    StealBall = 4.00m,
                    LooseBall = 6.00m,
                    Assist = 0.00m,
                    Interrupt = 1.00m,
                    CreateDateTime = new DateTime(2018, 4, 1),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 2,
                    MatchId = 5,
                    TeamId = 2,
                    PlayerId = 6,
                    OnePoint = 13.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 15.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 20.00m,
                    StealBall = 5.00m,
                    LooseBall = 9.00m,
                    Assist = 6.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 4, 1),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 3,
                    MatchId = 5,
                    TeamId = 2,
                    PlayerId = 11,
                    OnePoint = 7.00m,
                    TwoPoint = 4.00m,
                    MissingOnePoint = 20.00m,
                    MissingTwoPoint = 6.00m,
                    Rebound = 21.00m,
                    StealBall = 4.00m,
                    LooseBall = 8.00m,
                    Assist = 1.00m,
                    Interrupt = 1.00m,
                    CreateDateTime = new DateTime(2018, 4, 1),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 4,
                    MatchId = 5,
                    TeamId = 1,
                    PlayerId = 5,
                    OnePoint = 11.00m,
                    TwoPoint = 1.00m,
                    MissingOnePoint = 10.00m,
                    MissingTwoPoint = 6.00m,
                    Rebound = 20.00m,
                    StealBall = 5.00m,
                    LooseBall = 5.00m,
                    Assist = 4.00m,
                    Interrupt = 1.00m,
                    CreateDateTime = new DateTime(2018, 4, 1),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 5,
                    MatchId = 5,
                    TeamId = 1,
                    PlayerId = 3,
                    OnePoint = 15.00m,
                    TwoPoint = 1.00m,
                    MissingOnePoint = 20.00m,
                    MissingTwoPoint = 3.00m,
                    Rebound = 13.00m,
                    StealBall = 1.00m,
                    LooseBall = 3.00m,
                    Assist = 16.00m,
                    Interrupt = 1.00m,
                    CreateDateTime = new DateTime(2018, 4, 1),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 6,
                    MatchId = 5,
                    TeamId = 1,
                    PlayerId = 7,
                    OnePoint = 11.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 16.00m,
                    MissingTwoPoint = 4.00m,
                    Rebound = 13.00m,
                    StealBall = 5.00m,
                    LooseBall = 5.00m,
                    Assist = 5.00m,
                    Interrupt = 1.00m,
                    CreateDateTime = new DateTime(2018, 4, 1),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 7,
                    MatchId = 5,
                    TeamId = 1,
                    PlayerId = 1,
                    OnePoint = 15.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 18.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 14.00m,
                    StealBall = 2.00m,
                    LooseBall = 2.00m,
                    Assist = 4.00m,
                    Interrupt = 1.00m,
                    CreateDateTime = new DateTime(2018, 4, 1),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 8,
                    MatchId = 1,
                    TeamId = 2,
                    PlayerId = 4,
                    OnePoint = 9.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 15.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 19.00m,
                    StealBall = 4.00m,
                    LooseBall = 1.00m,
                    Assist = 3.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 3, 29),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 9,
                    MatchId = 1,
                    TeamId = 2,
                    PlayerId = 9,
                    OnePoint = 12.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 10.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 8.00m,
                    StealBall = 5.00m,
                    LooseBall = 6.00m,
                    Assist = 2.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 3, 29),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 10,
                    MatchId = 1,
                    TeamId = 2,
                    PlayerId = 1,
                    OnePoint = 17.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 25.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 24.00m,
                    StealBall = 4.00m,
                    LooseBall = 4.00m,
                    Assist = 2.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 3, 29),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 11,
                    MatchId = 1,
                    TeamId = 2,
                    PlayerId = 10,
                    OnePoint = 5.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 11.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 10.00m,
                    StealBall = 2.00m,
                    LooseBall = 2.00m,
                    Assist = 1.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 3, 29),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 12,
                    MatchId = 1,
                    TeamId = 1,
                    PlayerId = 5,
                    OnePoint = 7.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 12.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 17.00m,
                    StealBall = 4.00m,
                    LooseBall = 6.00m,
                    Assist = 2.00m,
                    Interrupt = 1.00m,
                    CreateDateTime = new DateTime(2018, 3, 29),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 13,
                    MatchId = 1,
                    TeamId = 1,
                    PlayerId = 7,
                    OnePoint = 11.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 22.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 6.00m,
                    StealBall = 4.00m,
                    LooseBall = 2.00m,
                    Assist = 1.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 3, 29),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 14,
                    MatchId = 1,
                    TeamId = 1,
                    PlayerId = 3,
                    OnePoint = 20.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 11.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 11.00m,
                    StealBall = 2.00m,
                    LooseBall = 2.00m,
                    Assist = 1.00m,
                    Interrupt = 1.00m,
                    CreateDateTime = new DateTime(2018, 3, 29),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 15,
                    MatchId = 2,
                    TeamId = 2,
                    PlayerId = 4,
                    OnePoint = 12.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 12.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 13.00m,
                    StealBall = 0.00m,
                    LooseBall = 1.00m,
                    Assist = 0.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 3, 29),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 16,
                    MatchId = 2,
                    TeamId = 2,
                    PlayerId = 9,
                    OnePoint = 2.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 13.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 15.00m,
                    StealBall = 3.00m,
                    LooseBall = 4.00m,
                    Assist = 1.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 3, 29),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 17,
                    MatchId = 2,
                    TeamId = 2,
                    PlayerId = 6,
                    OnePoint = 8.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 8.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 10.00m,
                    StealBall = 2.00m,
                    LooseBall = 12.00m,
                    Assist = 2.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 3, 29),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 18,
                    MatchId = 2,
                    TeamId = 2,
                    PlayerId = 8,
                    OnePoint = 14.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 12.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 10.00m,
                    StealBall = 3.00m,
                    LooseBall = 3.00m,
                    Assist = 2.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 3, 29),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 19,
                    MatchId = 2,
                    TeamId = 1,
                    PlayerId = 7,
                    OnePoint = 9.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 18.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 11.00m,
                    StealBall = 6.00m,
                    LooseBall = 3.00m,
                    Assist = 1.00m,
                    Interrupt = 1.00m,
                    CreateDateTime = new DateTime(2018, 3, 29),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 20,
                    MatchId = 2,
                    TeamId = 1,
                    PlayerId = 1,
                    OnePoint = 14.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 18.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 13.00m,
                    StealBall = 5.00m,
                    LooseBall = 1.00m,
                    Assist = 0.00m,
                    Interrupt = 1.00m,
                    CreateDateTime = new DateTime(2018, 3, 29),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 21,
                    MatchId = 2,
                    TeamId = 1,
                    PlayerId = 3,
                    OnePoint = 8.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 20.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 12.00m,
                    StealBall = 3.00m,
                    LooseBall = 5.00m,
                    Assist = 1.00m,
                    Interrupt = 1.00m,
                    CreateDateTime = new DateTime(2018, 3, 29),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 22,
                    MatchId = 2,
                    TeamId = 1,
                    PlayerId = 10,
                    OnePoint = 1.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 6.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 6.00m,
                    StealBall = 2.00m,
                    LooseBall = 1.00m,
                    Assist = 0.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 3, 29),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 23,
                    MatchId = 3,
                    TeamId = 1,
                    PlayerId = 4,
                    OnePoint = 13.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 22.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 23.00m,
                    StealBall = 2.00m,
                    LooseBall = 1.00m,
                    Assist = 4.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 3, 29),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 24,
                    MatchId = 3,
                    TeamId = 1,
                    PlayerId = 3,
                    OnePoint = 12.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 7.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 3.00m,
                    StealBall = 0.00m,
                    LooseBall = 3.00m,
                    Assist = 2.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 3, 29),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 25,
                    MatchId = 3,
                    TeamId = 1,
                    PlayerId = 7,
                    OnePoint = 11.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 21.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 14.00m,
                    StealBall = 6.00m,
                    LooseBall = 2.00m,
                    Assist = 0.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 3, 29),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 26,
                    MatchId = 3,
                    TeamId = 1,
                    PlayerId = 11,
                    OnePoint = 5.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 14.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 8.00m,
                    StealBall = 1.00m,
                    LooseBall = 2.00m,
                    Assist = 0.00m,
                    Interrupt = 1.00m,
                    CreateDateTime = new DateTime(2018, 3, 29),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 27,
                    MatchId = 3,
                    TeamId = 2,
                    PlayerId = 5,
                    OnePoint = 13.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 18.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 18.00m,
                    StealBall = 1.00m,
                    LooseBall = 1.00m,
                    Assist = 0.00m,
                    Interrupt = 1.00m,
                    CreateDateTime = new DateTime(2018, 3, 29),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 28,
                    MatchId = 3,
                    TeamId = 2,
                    PlayerId = 1,
                    OnePoint = 10.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 15.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 15.00m,
                    StealBall = 0.00m,
                    LooseBall = 1.00m,
                    Assist = 0.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 3, 29),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 29,
                    MatchId = 3,
                    TeamId = 2,
                    PlayerId = 10,
                    OnePoint = 5.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 7.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 9.00m,
                    StealBall = 1.00m,
                    LooseBall = 0.00m,
                    Assist = 0.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 3, 29),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 30,
                    MatchId = 3,
                    TeamId = 2,
                    PlayerId = 3,
                    OnePoint = 7.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 4.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 8.00m,
                    StealBall = 0.00m,
                    LooseBall = 3.00m,
                    Assist = 0.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 3, 29),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 31,
                    MatchId = 3,
                    TeamId = 1,
                    PlayerId = 10,
                    OnePoint = 1.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 1.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 0.00m,
                    StealBall = 0.00m,
                    LooseBall = 0.00m,
                    Assist = 0.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 3, 29),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 32,
                    MatchId = 4,
                    TeamId = 1,
                    PlayerId = 4,
                    OnePoint = 16.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 13.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 22.00m,
                    StealBall = 1.00m,
                    LooseBall = 2.00m,
                    Assist = 0.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 3, 29),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 33,
                    MatchId = 4,
                    TeamId = 1,
                    PlayerId = 6,
                    OnePoint = 6.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 8.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 7.00m,
                    StealBall = 3.00m,
                    LooseBall = 7.00m,
                    Assist = 6.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 3, 29),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 34,
                    MatchId = 4,
                    TeamId = 1,
                    PlayerId = 5,
                    OnePoint = 8.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 17.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 16.00m,
                    StealBall = 5.00m,
                    LooseBall = 3.00m,
                    Assist = 4.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 3, 29),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 35,
                    MatchId = 4,
                    TeamId = 1,
                    PlayerId = 11,
                    OnePoint = 6.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 24.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 12.00m,
                    StealBall = 3.00m,
                    LooseBall = 3.00m,
                    Assist = 2.00m,
                    Interrupt = 1.00m,
                    CreateDateTime = new DateTime(2018, 3, 29),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 36,
                    MatchId = 4,
                    TeamId = 2,
                    PlayerId = 7,
                    OnePoint = 11.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 21.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 7.00m,
                    StealBall = 6.00m,
                    LooseBall = 4.00m,
                    Assist = 0.00m,
                    Interrupt = 1.00m,
                    CreateDateTime = new DateTime(2018, 3, 29),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 37,
                    MatchId = 4,
                    TeamId = 2,
                    PlayerId = 3,
                    OnePoint = 6.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 12.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 9.00m,
                    StealBall = 0.00m,
                    LooseBall = 5.00m,
                    Assist = 5.00m,
                    Interrupt = 2.00m,
                    CreateDateTime = new DateTime(2018, 3, 29),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 38,
                    MatchId = 4,
                    TeamId = 2,
                    PlayerId = 1,
                    OnePoint = 6.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 9.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 15.00m,
                    StealBall = 0.00m,
                    LooseBall = 4.00m,
                    Assist = 3.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 3, 29),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 39,
                    MatchId = 4,
                    TeamId = 2,
                    PlayerId = 8,
                    OnePoint = 8.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 10.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 8.00m,
                    StealBall = 2.00m,
                    LooseBall = 2.00m,
                    Assist = 1.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 3, 29),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 40,
                    MatchId = 4,
                    TeamId = 2,
                    PlayerId = 10,
                    OnePoint = 1.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 6.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 6.00m,
                    StealBall = 2.00m,
                    LooseBall = 1.00m,
                    Assist = 0.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 3, 29),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 41,
                    MatchId = 6,
                    TeamId = 1,
                    PlayerId = 4,
                    OnePoint = 14.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 10.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 28.00m,
                    StealBall = 4.00m,
                    LooseBall = 2.00m,
                    Assist = 2.00m,
                    Interrupt = 1.00m,
                    CreateDateTime = new DateTime(2018, 4, 18),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 42,
                    MatchId = 6,
                    TeamId = 1,
                    PlayerId = 6,
                    OnePoint = 4.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 5.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 9.00m,
                    StealBall = 1.00m,
                    LooseBall = 8.00m,
                    Assist = 9.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 4, 18),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 43,
                    MatchId = 6,
                    TeamId = 1,
                    PlayerId = 3,
                    OnePoint = 8.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 10.00m,
                    MissingTwoPoint = 1.00m,
                    Rebound = 6.00m,
                    StealBall = 0.00m,
                    LooseBall = 6.00m,
                    Assist = 2.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 4, 18),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 44,
                    MatchId = 6,
                    TeamId = 1,
                    PlayerId = 9,
                    OnePoint = 5.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 16.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 4.00m,
                    StealBall = 5.00m,
                    LooseBall = 7.00m,
                    Assist = 4.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 4, 18),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 45,
                    MatchId = 6,
                    TeamId = 1,
                    PlayerId = 11,
                    OnePoint = 4.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 15.00m,
                    MissingTwoPoint = 1.00m,
                    Rebound = 19.00m,
                    StealBall = 1.00m,
                    LooseBall = 6.00m,
                    Assist = 0.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 4, 18),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 46,
                    MatchId = 6,
                    TeamId = 2,
                    PlayerId = 7,
                    OnePoint = 7.00m,
                    TwoPoint = 1.00m,
                    MissingOnePoint = 21.00m,
                    MissingTwoPoint = 6.00m,
                    Rebound = 20.00m,
                    StealBall = 4.00m,
                    LooseBall = 1.00m,
                    Assist = 2.00m,
                    Interrupt = 1.00m,
                    CreateDateTime = new DateTime(2018, 4, 18),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 47,
                    MatchId = 6,
                    TeamId = 2,
                    PlayerId = 1,
                    OnePoint = 7.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 15.00m,
                    MissingTwoPoint = 1.00m,
                    Rebound = 14.00m,
                    StealBall = 6.00m,
                    LooseBall = 6.00m,
                    Assist = 1.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 4, 18),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 48,
                    MatchId = 6,
                    TeamId = 2,
                    PlayerId = 5,
                    OnePoint = 5.00m,
                    TwoPoint = 1.00m,
                    MissingOnePoint = 9.00m,
                    MissingTwoPoint = 9.00m,
                    Rebound = 17.00m,
                    StealBall = 8.00m,
                    LooseBall = 2.00m,
                    Assist = 2.00m,
                    Interrupt = 1.00m,
                    CreateDateTime = new DateTime(2018, 4, 18),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 49,
                    MatchId = 6,
                    TeamId = 2,
                    PlayerId = 8,
                    OnePoint = 3.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 20.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 7.00m,
                    StealBall = 4.00m,
                    LooseBall = 5.00m,
                    Assist = 1.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 4, 18),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 50,
                    MatchId = 6,
                    TeamId = 2,
                    PlayerId = 10,
                    OnePoint = 4.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 10.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 9.00m,
                    StealBall = 2.00m,
                    LooseBall = 2.00m,
                    Assist = 2.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 4, 18),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 51,
                    MatchId = 7,
                    TeamId = 1,
                    PlayerId = 4,
                    OnePoint = 11.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 17.00m,
                    MissingTwoPoint = 1.00m,
                    Rebound = 40.00m,
                    StealBall = 1.00m,
                    LooseBall = 2.00m,
                    Assist = 2.00m,
                    Interrupt = 2.00m,
                    CreateDateTime = new DateTime(2018, 4, 20),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 52,
                    MatchId = 7,
                    TeamId = 1,
                    PlayerId = 8,
                    OnePoint = 14.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 23.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 13.00m,
                    StealBall = 1.00m,
                    LooseBall = 8.00m,
                    Assist = 1.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 4, 20),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 53,
                    MatchId = 7,
                    TeamId = 1,
                    PlayerId = 11,
                    OnePoint = 8.00m,
                    TwoPoint = 3.00m,
                    MissingOnePoint = 16.00m,
                    MissingTwoPoint = 15.00m,
                    Rebound = 17.00m,
                    StealBall = 4.00m,
                    LooseBall = 3.00m,
                    Assist = 1.00m,
                    Interrupt = 1.00m,
                    CreateDateTime = new DateTime(2018, 4, 20),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 54,
                    MatchId = 7,
                    TeamId = 1,
                    PlayerId = 10,
                    OnePoint = 8.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 10.00m,
                    MissingTwoPoint = 2.00m,
                    Rebound = 12.00m,
                    StealBall = 1.00m,
                    LooseBall = 7.00m,
                    Assist = 3.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 4, 20),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 55,
                    MatchId = 7,
                    TeamId = 2,
                    PlayerId = 7,
                    OnePoint = 8.00m,
                    TwoPoint = 3.00m,
                    MissingOnePoint = 36.00m,
                    MissingTwoPoint = 9.00m,
                    Rebound = 12.00m,
                    StealBall = 5.00m,
                    LooseBall = 3.00m,
                    Assist = 2.00m,
                    Interrupt = 1.00m,
                    CreateDateTime = new DateTime(2018, 4, 20),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 56,
                    MatchId = 7,
                    TeamId = 2,
                    PlayerId = 1,
                    OnePoint = 5.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 21.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 18.00m,
                    StealBall = 2.00m,
                    LooseBall = 2.00m,
                    Assist = 0.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 4, 20),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 57,
                    MatchId = 7,
                    TeamId = 2,
                    PlayerId = 5,
                    OnePoint = 19.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 16.00m,
                    MissingTwoPoint = 3.00m,
                    Rebound = 34.00m,
                    StealBall = 6.00m,
                    LooseBall = 2.00m,
                    Assist = 2.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 4, 20),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 58,
                    MatchId = 7,
                    TeamId = 2,
                    PlayerId = 9,
                    OnePoint = 5.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 15.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 10.00m,
                    StealBall = 1.00m,
                    LooseBall = 2.00m,
                    Assist = 2.00m,
                    Interrupt = 1.00m,
                    CreateDateTime = new DateTime(2018, 4, 20),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 59,
                    MatchId = 8,
                    TeamId = 1,
                    PlayerId = 8,
                    OnePoint = 12.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 31.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 14.00m,
                    StealBall = 3.00m,
                    LooseBall = 4.00m,
                    Assist = 2.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 4, 29),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 60,
                    MatchId = 8,
                    TeamId = 1,
                    PlayerId = 1,
                    OnePoint = 15.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 19.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 15.00m,
                    StealBall = 3.00m,
                    LooseBall = 3.00m,
                    Assist = 1.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 4, 29),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 61,
                    MatchId = 8,
                    TeamId = 1,
                    PlayerId = 6,
                    OnePoint = 4.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 8.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 18.00m,
                    StealBall = 2.00m,
                    LooseBall = 3.00m,
                    Assist = 2.00m,
                    Interrupt = 4.00m,
                    CreateDateTime = new DateTime(2018, 4, 29),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 62,
                    MatchId = 8,
                    TeamId = 1,
                    PlayerId = 10,
                    OnePoint = 7.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 9.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 13.00m,
                    StealBall = 4.00m,
                    LooseBall = 1.00m,
                    Assist = 2.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 4, 29),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 63,
                    MatchId = 8,
                    TeamId = 2,
                    PlayerId = 4,
                    OnePoint = 14.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 24.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 27.00m,
                    StealBall = 2.00m,
                    LooseBall = 5.00m,
                    Assist = 2.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 4, 29),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 64,
                    MatchId = 8,
                    TeamId = 2,
                    PlayerId = 3,
                    OnePoint = 8.00m,
                    TwoPoint = 1.00m,
                    MissingOnePoint = 19.00m,
                    MissingTwoPoint = 4.00m,
                    Rebound = 22.00m,
                    StealBall = 0.00m,
                    LooseBall = 7.00m,
                    Assist = 6.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 4, 29),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 65,
                    MatchId = 8,
                    TeamId = 2,
                    PlayerId = 7,
                    OnePoint = 13.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 25.00m,
                    MissingTwoPoint = 3.00m,
                    Rebound = 23.00m,
                    StealBall = 6.00m,
                    LooseBall = 8.00m,
                    Assist = 1.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 4, 29),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 66,
                    MatchId = 9,
                    TeamId = 1,
                    PlayerId = 3,
                    OnePoint = 8.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 11.00m,
                    MissingTwoPoint = 3.00m,
                    Rebound = 17.00m,
                    StealBall = 3.00m,
                    LooseBall = 3.00m,
                    Assist = 3.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 6, 27),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 67,
                    MatchId = 9,
                    TeamId = 1,
                    PlayerId = 5,
                    OnePoint = 7.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 6.00m,
                    MissingTwoPoint = 5.00m,
                    Rebound = 8.00m,
                    StealBall = 10.00m,
                    LooseBall = 2.00m,
                    Assist = 1.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 6, 27),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 68,
                    MatchId = 9,
                    TeamId = 1,
                    PlayerId = 8,
                    OnePoint = 2.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 16.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 8.00m,
                    StealBall = 3.00m,
                    LooseBall = 3.00m,
                    Assist = 2.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 6, 27),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 69,
                    MatchId = 9,
                    TeamId = 1,
                    PlayerId = 10,
                    OnePoint = 6.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 10.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 3.00m,
                    StealBall = 3.00m,
                    LooseBall = 3.00m,
                    Assist = 3.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 6, 27),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 70,
                    MatchId = 9,
                    TeamId = 2,
                    PlayerId = 4,
                    OnePoint = 9.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 7.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 23.00m,
                    StealBall = 3.00m,
                    LooseBall = 1.00m,
                    Assist = 4.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 6, 27),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 71,
                    MatchId = 9,
                    TeamId = 2,
                    PlayerId = 9,
                    OnePoint = 3.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 13.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 11.00m,
                    StealBall = 1.00m,
                    LooseBall = 5.00m,
                    Assist = 5.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 6, 27),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 72,
                    MatchId = 9,
                    TeamId = 2,
                    PlayerId = 6,
                    OnePoint = 3.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 7.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 9.00m,
                    StealBall = 1.00m,
                    LooseBall = 7.00m,
                    Assist = 4.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 6, 27),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 73,
                    MatchId = 9,
                    TeamId = 2,
                    PlayerId = 1,
                    OnePoint = 10.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 17.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 8.00m,
                    StealBall = 4.00m,
                    LooseBall = 9.00m,
                    Assist = 3.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 6, 27),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 74,
                    MatchId = 10,
                    TeamId = 1,
                    PlayerId = 5,
                    OnePoint = 4.00m,
                    TwoPoint = 8.00m,
                    MissingOnePoint = 4.00m,
                    MissingTwoPoint = 14.00m,
                    Rebound = 15.00m,
                    StealBall = 6.00m,
                    LooseBall = 8.00m,
                    Assist = 3.00m,
                    Interrupt = 1.00m,
                    CreateDateTime = new DateTime(2018, 7, 10),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 75,
                    MatchId = 10,
                    TeamId = 1,
                    PlayerId = 3,
                    OnePoint = 6.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 11.00m,
                    MissingTwoPoint = 4.00m,
                    Rebound = 9.00m,
                    StealBall = 2.00m,
                    LooseBall = 10.00m,
                    Assist = 5.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 7, 10),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 76,
                    MatchId = 10,
                    TeamId = 1,
                    PlayerId = 8,
                    OnePoint = 8.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 15.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 14.00m,
                    StealBall = 3.00m,
                    LooseBall = 2.00m,
                    Assist = 0.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 7, 10),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 77,
                    MatchId = 10,
                    TeamId = 1,
                    PlayerId = 10,
                    OnePoint = 5.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 4.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 9.00m,
                    StealBall = 1.00m,
                    LooseBall = 1.00m,
                    Assist = 1.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 7, 10),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 78,
                    MatchId = 10,
                    TeamId = 2,
                    PlayerId = 4,
                    OnePoint = 15.00m,
                    TwoPoint = 1.00m,
                    MissingOnePoint = 10.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 19.00m,
                    StealBall = 2.00m,
                    LooseBall = 3.00m,
                    Assist = 1.00m,
                    Interrupt = 1.00m,
                    CreateDateTime = new DateTime(2018, 7, 10),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 79,
                    MatchId = 10,
                    TeamId = 2,
                    PlayerId = 9,
                    OnePoint = 9.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 14.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 8.00m,
                    StealBall = 1.00m,
                    LooseBall = 6.00m,
                    Assist = 4.00m,
                    Interrupt = 2.00m,
                    CreateDateTime = new DateTime(2018, 7, 10),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 80,
                    MatchId = 10,
                    TeamId = 2,
                    PlayerId = 6,
                    OnePoint = 8.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 14.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 7.00m,
                    StealBall = 5.00m,
                    LooseBall = 7.00m,
                    Assist = 5.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 7, 10),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 81,
                    MatchId = 10,
                    TeamId = 2,
                    PlayerId = 12,
                    OnePoint = 10.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 11.00m,
                    MissingTwoPoint = 8.00m,
                    Rebound = 12.00m,
                    StealBall = 7.00m,
                    LooseBall = 5.00m,
                    Assist = 5.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 7, 10),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 82,
                    MatchId = 11,
                    TeamId = 1,
                    PlayerId = 6,
                    OnePoint = 6.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 7.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 7.00m,
                    StealBall = 0.00m,
                    LooseBall = 3.00m,
                    Assist = 5.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 11, 13),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 83,
                    MatchId = 11,
                    TeamId = 1,
                    PlayerId = 3,
                    OnePoint = 5.00m,
                    TwoPoint = 1.00m,
                    MissingOnePoint = 8.00m,
                    MissingTwoPoint = 2.00m,
                    Rebound = 4.00m,
                    StealBall = 0.00m,
                    LooseBall = 1.00m,
                    Assist = 1.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 11, 13),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 84,
                    MatchId = 11,
                    TeamId = 1,
                    PlayerId = 2,
                    OnePoint = 3.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 10.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 4.00m,
                    StealBall = 0.00m,
                    LooseBall = 3.00m,
                    Assist = 0.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 11, 13),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 85,
                    MatchId = 11,
                    TeamId = 2,
                    PlayerId = 4,
                    OnePoint = 7.00m,
                    TwoPoint = 1.00m,
                    MissingOnePoint = 6.00m,
                    MissingTwoPoint = 1.00m,
                    Rebound = 11.00m,
                    StealBall = 0.00m,
                    LooseBall = 2.00m,
                    Assist = 2.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 11, 13),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 86,
                    MatchId = 11,
                    TeamId = 2,
                    PlayerId = 13,
                    OnePoint = 4.00m,
                    TwoPoint = 5.00m,
                    MissingOnePoint = 5.00m,
                    MissingTwoPoint = 6.00m,
                    Rebound = 6.00m,
                    StealBall = 0.00m,
                    LooseBall = 9.00m,
                    Assist = 5.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 11, 13),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 87,
                    MatchId = 11,
                    TeamId = 2,
                    PlayerId = 10,
                    OnePoint = 2.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 3.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 6.00m,
                    StealBall = 0.00m,
                    LooseBall = 2.00m,
                    Assist = 3.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 11, 13),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 88,
                    MatchId = 12,
                    TeamId = 1,
                    PlayerId = 5,
                    OnePoint = 3.00m,
                    TwoPoint = 1.00m,
                    MissingOnePoint = 2.00m,
                    MissingTwoPoint = 4.00m,
                    Rebound = 7.00m,
                    StealBall = 0.00m,
                    LooseBall = 1.00m,
                    Assist = 2.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 11, 13),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 89,
                    MatchId = 12,
                    TeamId = 1,
                    PlayerId = 15,
                    OnePoint = 2.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 3.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 6.00m,
                    StealBall = 0.00m,
                    LooseBall = 1.00m,
                    Assist = 3.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 11, 13),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 90,
                    MatchId = 12,
                    TeamId = 1,
                    PlayerId = 14,
                    OnePoint = 2.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 11.00m,
                    MissingTwoPoint = 1.00m,
                    Rebound = 5.00m,
                    StealBall = 0.00m,
                    LooseBall = 0.00m,
                    Assist = 0.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 11, 13),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 91,
                    MatchId = 12,
                    TeamId = 2,
                    PlayerId = 4,
                    OnePoint = 1.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 5.00m,
                    MissingTwoPoint = 0.00m,
                    Rebound = 6.00m,
                    StealBall = 0.00m,
                    LooseBall = 0.00m,
                    Assist = 0.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 11, 13),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 92,
                    MatchId = 12,
                    TeamId = 2,
                    PlayerId = 13,
                    OnePoint = 1.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 5.00m,
                    MissingTwoPoint = 3.00m,
                    Rebound = 6.00m,
                    StealBall = 0.00m,
                    LooseBall = 3.00m,
                    Assist = 0.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 11, 13),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<BasketballStat>().HasData(
                new BasketballStat
                {
                    Id = 93,
                    MatchId = 12,
                    TeamId = 2,
                    PlayerId = 10,
                    OnePoint = 2.00m,
                    TwoPoint = 0.00m,
                    MissingOnePoint = 5.00m,
                    MissingTwoPoint = 3.00m,
                    Rebound = 3.00m,
                    StealBall = 0.00m,
                    LooseBall = 2.00m,
                    Assist = 0.00m,
                    Interrupt = 0.00m,
                    CreateDateTime = new DateTime(2018, 11, 13),
                    CreateUserId = 1,
                    Status = Status.Active
                }
            );

            return modelBuilder;
        }
    }
}