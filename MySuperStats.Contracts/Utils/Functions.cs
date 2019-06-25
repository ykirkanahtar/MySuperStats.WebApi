using System;
using System.Collections.Generic;
using System.Linq;
using MySuperStats.Contracts.Enums;
using MySuperStats.Contracts.Responses;

namespace MySuperStats.Contracts.Utils
{
    public static class Functions
    {
        public static List<MatchResult> GetMatchResultByMatchAndUserId(this ICollection<BasketballStatResponse> userStats)
        {
            var matchForms = new List<MatchResult>();
            var matches = (from p in userStats orderby p.Match.MatchDate, p.Match.Order select p.Match).ToList().Distinct();
            //var mtches = playerStats.OrderBy(p => p.Match.MatchDate).ThenBy(p => p.Match.Order).Select(p => p.Match)
            //    .Distinct().ToList();
            var userId = (from p in userStats select p.UserId).FirstOrDefault();

            foreach (var match in matches)
            {
                var homeTeamScore = match.HomeTeamScore;
                var awayTeamScore = match.AwayTeamScore;

                if (userStats.Where(p => p.MatchId == match.Id && p.TeamId == match.HomeTeamId && p.UserId == userId).ToList().Count > 0)
                {
                    //iki takımda da oynadıysa
                    if (userStats.Where(p => p.MatchId == match.Id && p.TeamId == match.AwayTeamId && p.UserId == userId).ToList().Count > 0)
                    {
                        matchForms.Add(homeTeamScore == awayTeamScore ? MatchResult.Draw : MatchResult.BothOfTeam);
                    }
                    else
                    {
                        if (homeTeamScore > awayTeamScore) matchForms.Add(MatchResult.Win);
                        else matchForms.Add(homeTeamScore < awayTeamScore ? MatchResult.Loose : MatchResult.Draw);
                    }
                }
                else if (userStats.Where(p => p.MatchId == match.Id && p.TeamId == match.AwayTeamId && p.UserId == userId).ToList().Count > 0)
                {
                    //iki takımda da oynadıysa
                    if (userStats.Where(p => p.MatchId == match.Id && p.TeamId == match.HomeTeamId && p.UserId == userId).ToList().Count > 0)
                    {
                        matchForms.Add(homeTeamScore == awayTeamScore ? MatchResult.Draw : MatchResult.BothOfTeam);
                    }
                    else
                    {
                        if (awayTeamScore > homeTeamScore) matchForms.Add(MatchResult.Win);
                        else matchForms.Add(awayTeamScore < homeTeamScore ? MatchResult.Loose : MatchResult.Draw);
                    }
                }
            }
            return matchForms;
        }
    }
}