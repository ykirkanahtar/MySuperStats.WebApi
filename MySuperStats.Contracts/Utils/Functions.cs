using System;
using System.Collections.Generic;
using System.Linq;
using MySuperStats.Contracts.Enums;
using MySuperStats.Contracts.Responses;

namespace MySuperStats.Contracts.Utils
{
    public static class Functions
    {
        public static List<MatchResult> GetMatchResultByMatchAndPlayerId(this ICollection<StatResponse> playerStats)
        {
            var matchForms = new List<MatchResult>();
            var matches = (from p in playerStats orderby p.Match.MatchDate, p.Match.Order select p.Match).ToList().Distinct();
            //var mtches = playerStats.OrderBy(p => p.Match.MatchDate).ThenBy(p => p.Match.Order).Select(p => p.Match)
            //    .Distinct().ToList();
            var playerId = (from p in playerStats select p.PlayerId).FirstOrDefault();

            foreach (var match in matches)
            {
                var homeTeamScore = match.HomeTeamScore;
                var awayTeamScore = match.AwayTeamScore;

                if (playerStats.Where(p => p.MatchId == match.Id && p.TeamId == match.HomeTeamId && p.PlayerId == playerId).ToList().Count > 0)
                {
                    //iki takımda da oynadıysa
                    if (playerStats.Where(p => p.MatchId == match.Id && p.TeamId == match.AwayTeamId && p.PlayerId == playerId).ToList().Count > 0)
                    {
                        matchForms.Add(homeTeamScore == awayTeamScore ? MatchResult.Draw : MatchResult.BothOfTeam);
                    }
                    else
                    {
                        if (homeTeamScore > awayTeamScore) matchForms.Add(MatchResult.Win);
                        else matchForms.Add(homeTeamScore < awayTeamScore ? MatchResult.Loose : MatchResult.Draw);
                    }
                }
                else if (playerStats.Where(p => p.MatchId == match.Id && p.TeamId == match.AwayTeamId && p.PlayerId == playerId).ToList().Count > 0)
                {
                    //iki takımda da oynadıysa
                    if (playerStats.Where(p => p.MatchId == match.Id && p.TeamId == match.HomeTeamId && p.PlayerId == playerId).ToList().Count > 0)
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