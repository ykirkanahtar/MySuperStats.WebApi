﻿using System.Collections.Generic;
using MySuperStats.WebApi.Models;
using CustomFramework.Data.ModelConfiguration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MySuperStats.WebApi.Data.ModelConfiguration
{
    public class MatchModelConfiguration<T> : BaseModelConfiguration<T, int> where T : Match
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.MatchDate)
                .IsRequired();

            builder.Property(p => p.Order)
                .IsRequired();

            builder.Property(p => p.DurationInMinutes)
                .IsRequired();

            builder.Property(p => p.HomeTeamId)
                .IsRequired();

            builder.Property(p => p.AwayTeamId)
                .IsRequired();

            builder.Property(p => p.HomeTeamScore);

            builder.Property(p => p.AwayTeamScore);

            builder.Property(p => p.VideoLink)
                .HasMaxLength(100);

            builder
                .HasOne(r => r.HomeTeam)
                .WithMany(c => (IEnumerable<T>)c.HomeMatches)
                .HasForeignKey(r => r.HomeTeamId)
                .HasPrincipalKey(c => c.Id)
                .IsRequired();

            builder
                .HasOne(r => r.AwayTeam)
                .WithMany(c => (IEnumerable<T>)c.AwayMatches)
                .HasForeignKey(r => r.AwayTeamId)
                .HasPrincipalKey(c => c.Id)
                .IsRequired();

            builder.HasIndex(p => new { p.MatchDate, p.Order })
                .IsUnique();
        }
    }
}
