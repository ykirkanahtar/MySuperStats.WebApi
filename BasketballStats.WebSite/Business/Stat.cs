using BasketballStats.Contracts.Responses;
using BasketballStats.WebSite.Enums;
using BasketballStats.WebSite.Models;
using BasketballStats.WebSite.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BasketballStats.WebSite.Business
{
    public class Stat : IStat
    {
        private readonly IWebApiConnector _webApiConnector;

        public Stat(IWebApiConnector webApiConnector)
        {
            _webApiConnector = webApiConnector;
        }

        public async Task<List<StatResponse>> GetStatsByMatchId(int matchId)
        {
            var getUrl = $"{Constants.DefaultApiRoute}/stat/getall/matchid/{matchId}";
            var response = await _webApiConnector.GetAsync(getUrl);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return
                    JsonConvert.DeserializeObject<List<StatResponse>>(response.Result.ToString());

            }
            else
                throw new Exception(response.Message);
        }

        public async Task<List<StatResponse>> GetStatsByPlayerId(int playerId)
        {
            var getUrl = $"{Constants.DefaultApiRoute}/stat/getall/playerid/{playerId}";
            var response = await _webApiConnector.GetAsync(getUrl);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return
                    JsonConvert.DeserializeObject<List<StatResponse>>(response.Result.ToString());

            }
            else
                throw new Exception(response.Message);
        }

        public async Task<List<StatResponse>> GetAll()
        {
            var getUrl = $"{Constants.DefaultApiRoute}/stat/getall";
            var response = await _webApiConnector.GetAsync(getUrl);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return
                    JsonConvert.DeserializeObject<List<StatResponse>>(response.Result.ToString());

            }
            else
                throw new Exception(response.Message);
        }


        public StatResponse AddPlayerStatToTeamStats(StatResponse teamStats, StatResponse playerStat)
        {
            teamStats.OnePoint += playerStat.OnePoint;
            teamStats.TwoPoint += playerStat.TwoPoint;
            teamStats.MissingOnePoint += playerStat.MissingOnePoint;
            teamStats.MissingTwoPoint += playerStat.MissingTwoPoint;
            teamStats.Rebound += playerStat.Rebound;
            teamStats.StealBall += playerStat.StealBall;
            teamStats.LooseBall += playerStat.LooseBall;
            teamStats.Assist += playerStat.Assist;
            teamStats.Interrupt += playerStat.Interrupt;

            return teamStats;
        }

        public StatResponse GetPlayerStatByMatchIdAndTeamId(int playerId, int teamId, IList<StatResponse> matchStats)
        {
            return matchStats.FirstOrDefault(p => p.TeamId == teamId && p.PlayerId == playerId);
        }

        public StatResponse GetTotalStats(IList<StatResponse> playerStats)
        {
            return new StatResponse
            {
                OnePoint = (from p in playerStats select p.OnePoint).Sum(),
                MissingOnePoint = (from p in playerStats select p.MissingOnePoint).Sum(),
                TwoPoint = (from p in playerStats select p.TwoPoint).Sum(),
                MissingTwoPoint = (from p in playerStats select p.MissingTwoPoint).Sum(),
                Rebound = (from p in playerStats select p.Rebound).Sum(),
                StealBall = (from p in playerStats select p.StealBall).Sum(),
                Assist = (from p in playerStats select p.Assist).Sum(),
                LooseBall = (from p in playerStats select p.LooseBall).Sum(),
                Interrupt = (from p in playerStats select p.Interrupt).Sum()
            };
        }

        public StatResponse GetPerMatchStats(StatResponse totalStats, List<StatResponse> playerStats)
        {
            var matchCount = GetMatchCount(playerStats);
            var twoPointMatchCount = GetMatchCountByTwoPointStat(playerStats);

            return new StatResponse
            {
                OnePoint = (totalStats.OnePoint / matchCount).RoundValue(),
                MissingOnePoint = (totalStats.MissingOnePoint / matchCount).RoundValue(),
                TwoPoint = twoPointMatchCount > 0 ? (totalStats.TwoPoint / twoPointMatchCount).RoundValue() : 0,
                MissingTwoPoint = twoPointMatchCount > 0 ? (totalStats.MissingTwoPoint / twoPointMatchCount).RoundValue() : 0,
                Rebound = (totalStats.Rebound / matchCount).RoundValue(),
                StealBall = (totalStats.StealBall / matchCount).RoundValue(),
                Assist = (totalStats.Assist / matchCount).RoundValue(),
                LooseBall = (totalStats.LooseBall / matchCount).RoundValue(),
                Interrupt = (totalStats.Interrupt / matchCount).RoundValue(),
            };
        }

        public IList<MatchScore> GetMatchFormsByPlayerId(IList<StatResponse> allMatchStats, int playerId)
        {
            var matchForms = new List<MatchScore>();

            var matches = allMatchStats.GroupBy(p => p.MatchId).Select(p => p.First().Match).OrderByDescending(p => p.MatchDate).OrderByDescending(p => p.Order).ToList();

            foreach (var match in matches)
            {
                var matchStats = allMatchStats.Where(p => p.MatchId == match.Id).ToList();
                var homeTeamScore = GetScoreByStatsAndTeamId(matchStats, match.HomeTeamId);
                var awayTeamScore = GetScoreByStatsAndTeamId(matchStats, match.AwayTeamId);

                if (matchStats.Where(p => p.TeamId == match.HomeTeamId && p.PlayerId == playerId).ToList().Count > 0)
                {
                    //iki takımda da oynadıysa
                    if (matchStats.Where(p => p.TeamId == match.AwayTeamId && p.PlayerId == playerId).ToList().Count > 0)
                    {
                        if (homeTeamScore == awayTeamScore) matchForms.Add(MatchScore.Draw);
                        else matchForms.Add(MatchScore.BothOfTeam);
                    }
                    else
                    {
                        if (homeTeamScore > awayTeamScore) matchForms.Add(MatchScore.Win);
                        else if (homeTeamScore < awayTeamScore) matchForms.Add(MatchScore.Loose);
                        else matchForms.Add(MatchScore.Draw);
                    }
                }
                else if (matchStats.Where(p => p.TeamId == match.AwayTeamId && p.PlayerId == playerId).ToList().Count > 0)
                {
                    if (homeTeamScore > awayTeamScore) matchForms.Add(MatchScore.Loose);
                    else if (homeTeamScore < awayTeamScore) matchForms.Add(MatchScore.Win);
                    else matchForms.Add(MatchScore.Draw);
                }
            }

            return matchForms;
        }

        public decimal GetScoreByStatsAndTeamId(IList<StatResponse> matchStats, int teamId)
        {
            return Decimal.Truncate((from p in matchStats
                                     where p.TeamId == teamId
                                     select p.OnePoint + (p.TwoPoint * 2)).Sum());
        }

        public int GetTotalWinsByMatchForms(IList<MatchScore> matchForms)
        {
            return matchForms.Count(p => p == MatchScore.Win);
        }

        public int GetTotalLoosesByMatchForms(IList<MatchScore> matchForms)
        {
            return matchForms.Count(p => p == MatchScore.Loose);
        }

        public int GetWinRatioByMatchForms(IList<MatchScore> matchForms)
        {
            var totalWins = GetTotalWinsByMatchForms(matchForms);
            var totalMatchCount = matchForms.Where(p => matchForms.Contains(MatchScore.Win) || matchForms.Contains(MatchScore.Loose) || matchForms.Contains(MatchScore.Draw)).Count();
            return totalMatchCount > 0 ? ((totalWins * 100) / totalMatchCount) : 0;
        }

        public int GetLooseRatioByMatchForms(IList<MatchScore> matchForms)
        {
            var totalLooses = GetTotalLoosesByMatchForms(matchForms);
            var totalMatchCount = matchForms.Where(p => matchForms.Contains(MatchScore.Win) || matchForms.Contains(MatchScore.Loose) || matchForms.Contains(MatchScore.Draw)).Count();
            return totalMatchCount > 0 ? ((totalLooses * 100) / totalMatchCount) : 0;
        }

        public int GetMatchCount(IList<StatResponse> stats)
        {
            return stats.Select(p => p.MatchId).Distinct().Count();
        }

        public int GetMatchCountByTwoPointStat(IList<StatResponse> stats)
        {
            return stats.Where(p => p.Match.MatchDate >= new DateTime(2018, 3, 29))
                .Select(p => p.MatchId).Distinct().Count();
        }

        public decimal GetTotalPoint(decimal onePoint, decimal twoPoint)
        {
            return onePoint + twoPoint * 2;
        }

        public decimal GetPerMatchTotalPoint(decimal totalPoint, int matchCount)
        {
            return matchCount > 0 ? totalPoint / matchCount : 0;
        }

        public decimal GetPointRatio(decimal point, decimal missing)
        {
            return ((point + missing) > 0 ?
                (point * 100) / (point + missing) : 0).RoundValue();
        }

    }
}
