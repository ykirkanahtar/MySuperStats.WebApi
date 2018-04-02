using BasketballStats.Contracts.Responses;
using BasketballStats.WebSite.Utils;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BasketballStats.WebSite.Models;
using Microsoft.EntityFrameworkCore.Internal;

namespace BasketballStats.WebSite.Pages
{
    public class StatisticModel : PageModel
    {
        private readonly WebApiConnector _webApiConnector;

        public List<StatisticDetail> StatisticDetailInfo { get; set; }
        public Statistic StatisticInfo { get; set; }


        public StatisticModel(WebApiConnector webApiConnector)
        {
            _webApiConnector = webApiConnector;
            StatisticDetailInfo = new List<StatisticDetail>();
            StatisticInfo = new Statistic();
        }

        public async Task OnGet()
        {
            var teamForms = new List<TeamForm>();

            var matchResponse = await _webApiConnector.GetAsync($"{Constants.DefaultApiRoute}/match/getall");
            if (matchResponse.StatusCode == HttpStatusCode.OK)
            {
                var matches = JsonConvert.DeserializeObject<List<MatchResponse>>(matchResponse.Result.ToString());
                foreach (var match in matches)
                {
                    var matchStats = new List<StatResponse>();

                    var matchStatResponse = await _webApiConnector.GetAsync($"{Constants.DefaultApiRoute}/stat/getall/matchid/{match.Id}");
                    if (matchStatResponse.StatusCode == HttpStatusCode.OK)
                    {
                        matchStats = JsonConvert.DeserializeObject<List<StatResponse>>(matchStatResponse.Result.ToString());
                    }

                    var teamForm = new TeamForm()
                    {
                        Match = match,
                        HomeTeamId = match.HomeTeamId,
                        AwayTeamId = match.AwayTeamId,
                        HomeTeamScore = (from p in matchStats
                                         where p.TeamId == match.HomeTeamId
                                         select p.OnePoint + p.TwoPoint * 2).Sum(),
                        AwayTeamScore = (from p in matchStats
                                         where p.TeamId == match.AwayTeamId
                                         select p.OnePoint + p.TwoPoint * 2).Sum()
                    };

                    var matchPlayers = matchStats.Select(p => p.Player).Distinct();
                    foreach (var matchPlayer in matchPlayers)
                    {
                        if (matchStats.Where(p => p.TeamId == match.HomeTeamId && p.PlayerId == matchPlayer.Id).ToList().Count > 0) teamForm.HomeTeamPlayerIds.Add(matchPlayer.Id);
                        if (matchStats.Where(p => p.TeamId == match.AwayTeamId && p.PlayerId == matchPlayer.Id).ToList().Count > 0) teamForm.AwayTeamPlayerIds.Add(matchPlayer.Id);
                    }

                    teamForms.Add(teamForm);
                }
                var sortedTeamForms = teamForms.OrderBy(p => p.Match.MatchDate).ThenBy(p => p.Match.Order).ToList();
                teamForms = sortedTeamForms;
            }

            var playerResponse =
                await _webApiConnector.GetAsync($"{Constants.DefaultApiRoute}/player/getall");
            if (playerResponse.StatusCode == HttpStatusCode.OK)
            {
                var players = JsonConvert.DeserializeObject<List<PlayerResponse>>(playerResponse.Result.ToString());

                foreach (var player in players)
                {
                    var statResponse = await _webApiConnector.GetAsync($"{Constants.DefaultApiRoute}/stat/getall/playerid/{player.Id}");
                    if (statResponse.StatusCode == HttpStatusCode.OK)
                    {
                        var stats = JsonConvert.DeserializeObject<List<StatResponse>>(statResponse.Result.ToString());
                        var statisticDetail = new StatisticDetail();

                        var totalStats = new StatResponse
                        {
                            OnePoint = (from p in stats select p.OnePoint).Sum(),
                            MissingOnePoint = (from p in stats select p.MissingOnePoint).Sum(),
                            TwoPoint = (from p in stats select p.TwoPoint).Sum(),
                            MissingTwoPoint = (from p in stats select p.MissingTwoPoint).Sum(),
                            Rebound = (from p in stats select p.Rebound).Sum(),
                            StealBall = (from p in stats select p.StealBall).Sum(),
                            Assist = (from p in stats select p.Assist).Sum(),
                            LooseBall = (from p in stats select p.LooseBall).Sum(),
                            Interrupt = (from p in stats select p.Interrupt).Sum()
                        };

                        var matchCount = GetMatchCount.All(stats);
                        var twoPointMatchCount = GetMatchCount.GetByTwoPointStat(stats);

                        var ratioStats = new StatResponse
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

                        statisticDetail.Player = player;
                        statisticDetail.MatchCount = matchCount;
                        statisticDetail.TwoPointMatchCount = twoPointMatchCount;
                        statisticDetail.TotalStatDetail = totalStats;
                        statisticDetail.RatioStatDetail = ratioStats;

                        foreach (var teamForm in teamForms)
                        {
                            if (teamForm.HomeTeamPlayerIds.Contains(player.Id))
                            {
                                if (teamForm.HomeTeamScore > teamForm.AwayTeamScore)
                                    statisticDetail.MatchStatus.Add("W");
                                else if (teamForm.HomeTeamScore < teamForm.AwayTeamScore)
                                    statisticDetail.MatchStatus.Add("L");
                                else
                                    statisticDetail.MatchStatus.Add("D");
                            }

                            if (teamForm.AwayTeamPlayerIds.Contains(player.Id))
                            {
                                if (teamForm.AwayTeamScore > teamForm.HomeTeamScore)
                                    statisticDetail.MatchStatus.Add("W");
                                else if (teamForm.AwayTeamScore < teamForm.HomeTeamScore)
                                    statisticDetail.MatchStatus.Add("L");
                                else
                                    statisticDetail.MatchStatus.Add("D");
                            }
                        }

                        statisticDetail.WinRatio =
                            ((Convert.ToDecimal(statisticDetail.MatchStatus.Count(p => p.Contains("W")) * 100) / matchCount))
                            .RoundValue();

                        statisticDetail.LooseRatio =
                            ((Convert.ToDecimal(statisticDetail.MatchStatus.Count(p => p.Contains("L")) * 100) / matchCount))
                            .RoundValue();

                        statisticDetail.OnePointRatio = ((totalStats.OnePoint + totalStats.MissingOnePoint) > 0 ?
                            (totalStats.OnePoint * 100) / (totalStats.OnePoint + totalStats.MissingOnePoint) : 0).RoundValue();
                        statisticDetail.TwoPointRatio = ((totalStats.TwoPoint + totalStats.MissingTwoPoint) > 0 ?
                            (totalStats.TwoPoint * 100) / (totalStats.TwoPoint + totalStats.MissingTwoPoint) : 0).RoundValue();

                        statisticDetail.TotalPoint = totalStats.OnePoint + totalStats.TwoPoint * 2;
                        statisticDetail.RatioTotalPoint = ratioStats.OnePoint + ratioStats.TwoPoint;

                        StatisticDetailInfo.Add(statisticDetail);
                    }
                }

                StatisticInfo.TotalPoints = (from p in StatisticDetailInfo
                                             orderby p.TotalPoint descending
                                             select new TopResult
                                             {
                                                 PlayerId = p.Player.Id,
                                                 Name = $"{p.Player.Name} {p.Player.Surname}",
                                                 Result = p.TotalPoint,
                                                 MatchCount = p.MatchCount,
                                             }).Take(5).ToList();

                StatisticInfo.TotalOnePoints = (from p in StatisticDetailInfo
                                                orderby p.TotalStatDetail.OnePoint descending
                                                select new TopResult
                                                {
                                                    PlayerId = p.Player.Id,
                                                    Name = $"{p.Player.Name} {p.Player.Surname}",
                                                    Result = p.TotalStatDetail.OnePoint,
                                                    MatchCount = p.MatchCount,
                                                }).Take(5).ToList();

                StatisticInfo.TotalTwoPoints = (from p in StatisticDetailInfo
                                                orderby p.TotalStatDetail.TwoPoint descending
                                                select new TopResult
                                                {
                                                    PlayerId = p.Player.Id,
                                                    Name = $"{p.Player.Name} {p.Player.Surname}",
                                                    Result = p.TotalStatDetail.TwoPoint,
                                                    MatchCount = p.TwoPointMatchCount,
                                                }).Take(5).ToList();

                StatisticInfo.TotalRebounds = (from p in StatisticDetailInfo
                                               orderby p.TotalStatDetail.Rebound descending
                                               select new TopResult
                                               {
                                                   PlayerId = p.Player.Id,
                                                   Name = $"{p.Player.Name} {p.Player.Surname}",
                                                   Result = p.TotalStatDetail.Rebound,
                                                   MatchCount = p.MatchCount,
                                               }).Take(5).ToList();

                StatisticInfo.TotalStealBalls = (from p in StatisticDetailInfo
                                                 orderby p.TotalStatDetail.StealBall descending
                                                 select new TopResult
                                                 {
                                                     PlayerId = p.Player.Id,
                                                     Name = $"{p.Player.Name} {p.Player.Surname}",
                                                     Result = p.TotalStatDetail.StealBall,
                                                     MatchCount = p.MatchCount,
                                                 }).Take(5).ToList();

                StatisticInfo.TotalLooseBalls = (from p in StatisticDetailInfo
                                                 orderby p.TotalStatDetail.LooseBall descending
                                                 select new TopResult
                                                 {
                                                     PlayerId = p.Player.Id,
                                                     Name = $"{p.Player.Name} {p.Player.Surname}",
                                                     Result = p.TotalStatDetail.LooseBall,
                                                     MatchCount = p.MatchCount,
                                                 }).Take(5).ToList();

                StatisticInfo.TotalAsists = (from p in StatisticDetailInfo
                                             orderby p.TotalStatDetail.Assist descending
                                             select new TopResult
                                             {
                                                 PlayerId = p.Player.Id,
                                                 Name = $"{p.Player.Name} {p.Player.Surname}",
                                                 Result = p.TotalStatDetail.Assist,
                                                 MatchCount = p.MatchCount,
                                             }).Take(5).ToList();

                StatisticInfo.TotalInterrupts = (from p in StatisticDetailInfo
                                                 orderby p.TotalStatDetail.Interrupt descending
                                                 select new TopResult
                                                 {
                                                     PlayerId = p.Player.Id,
                                                     Name = $"{p.Player.Name} {p.Player.Surname}",
                                                     Result = p.TotalStatDetail.Interrupt,
                                                     MatchCount = p.MatchCount,
                                                 }).Take(5).ToList();

                StatisticInfo.TotalWins = (from p in StatisticDetailInfo
                                           orderby p.MatchStatus.Count(m => m.Contains("W")) descending
                                           select new TopResult
                                           {
                                               PlayerId = p.Player.Id,
                                               Name = $"{p.Player.Name} {p.Player.Surname}",
                                               Result = p.MatchStatus.Count(m => m.Contains("W")),
                                               MatchCount = p.MatchCount,
                                           }).Take(5).ToList();

                StatisticInfo.TotalLoose = (from p in StatisticDetailInfo
                                            orderby p.MatchStatus.Count(m => m.Contains("L")) descending
                                            select new TopResult
                                            {
                                                PlayerId = p.Player.Id,
                                                Name = $"{p.Player.Name} {p.Player.Surname}",
                                                Result = p.MatchStatus.Count(m => m.Contains("L")),
                                                MatchCount = p.MatchCount,
                                            }).Take(5).ToList();

                StatisticInfo.RatioTotalPoints = (from p in StatisticDetailInfo
                                                  orderby p.RatioTotalPoint descending
                                                  select new TopResult
                                                  {
                                                      PlayerId = p.Player.Id,
                                                      Name = $"{p.Player.Name} {p.Player.Surname}",
                                                      Result = p.RatioTotalPoint.RoundValue(),
                                                      MatchCount = p.MatchCount,
                                                  }).Take(5).ToList();

                StatisticInfo.RatioOnePoints = (from p in StatisticDetailInfo
                                                orderby p.RatioStatDetail.OnePoint descending
                                                select new TopResult
                                                {
                                                    PlayerId = p.Player.Id,
                                                    Name = $"{p.Player.Name} {p.Player.Surname}",
                                                    Result = p.RatioStatDetail.OnePoint.RoundValue(),
                                                    MatchCount = p.MatchCount,
                                                }).Take(5).ToList();

                StatisticInfo.RatioTwoPoints = (from p in StatisticDetailInfo
                                                orderby p.RatioStatDetail.TwoPoint descending
                                                select new TopResult
                                                {
                                                    PlayerId = p.Player.Id,
                                                    Name = $"{p.Player.Name} {p.Player.Surname}",
                                                    Result = p.RatioStatDetail.TwoPoint.RoundValue(),
                                                    MatchCount = p.TwoPointMatchCount,
                                                }).Take(5).ToList();

                StatisticInfo.RatioRebounds = (from p in StatisticDetailInfo
                                               orderby p.RatioStatDetail.Rebound descending
                                               select new TopResult
                                               {
                                                   PlayerId = p.Player.Id,
                                                   Name = $"{p.Player.Name} {p.Player.Surname}",
                                                   Result = p.RatioStatDetail.Rebound.RoundValue(),
                                                   MatchCount = p.MatchCount,
                                               }).Take(5).ToList();

                StatisticInfo.RatioStealBalls = (from p in StatisticDetailInfo
                                                 orderby p.RatioStatDetail.StealBall descending
                                                 select new TopResult
                                                 {
                                                     PlayerId = p.Player.Id,
                                                     Name = $"{p.Player.Name} {p.Player.Surname}",
                                                     Result = p.RatioStatDetail.StealBall.RoundValue(),
                                                     MatchCount = p.MatchCount,
                                                 }).Take(5).ToList();

                StatisticInfo.RatioLooseBalls = (from p in StatisticDetailInfo
                                                 orderby p.RatioStatDetail.LooseBall descending
                                                 select new TopResult
                                                 {
                                                     PlayerId = p.Player.Id,
                                                     Name = $"{p.Player.Name} {p.Player.Surname}",
                                                     Result = p.RatioStatDetail.LooseBall.RoundValue(),
                                                     MatchCount = p.MatchCount,
                                                 }).Take(5).ToList();

                StatisticInfo.RatioAsists = (from p in StatisticDetailInfo
                                             orderby p.RatioStatDetail.Assist descending
                                             select new TopResult
                                             {
                                                 PlayerId = p.Player.Id,
                                                 Name = $"{p.Player.Name} {p.Player.Surname}",
                                                 Result = p.RatioStatDetail.Assist.RoundValue(),
                                                 MatchCount = p.MatchCount,
                                             }).Take(5).ToList();

                StatisticInfo.RatioInterrupts = (from p in StatisticDetailInfo
                                                 orderby p.RatioStatDetail.Interrupt descending
                                                 select new TopResult
                                                 {
                                                     PlayerId = p.Player.Id,
                                                     Name = $"{p.Player.Name} {p.Player.Surname}",
                                                     Result = p.RatioStatDetail.Interrupt.RoundValue(),
                                                     MatchCount = p.MatchCount,
                                                 }).Take(5).ToList();

                StatisticInfo.RatioWins = (from p in StatisticDetailInfo
                                           orderby p.WinRatio descending
                                           select new TopResult
                                           {
                                               PlayerId = p.Player.Id,
                                               Name = $"{p.Player.Name} {p.Player.Surname}",
                                               Result = p.WinRatio.RoundValue(),
                                               MatchCount = p.MatchCount,
                                           }).Take(5).ToList();

                StatisticInfo.RatioLoose = (from p in StatisticDetailInfo
                                            orderby p.LooseRatio descending
                                            select new TopResult
                                            {
                                                PlayerId = p.Player.Id,
                                                Name = $"{p.Player.Name} {p.Player.Surname}",
                                                Result = p.LooseRatio.RoundValue(),
                                                MatchCount = p.MatchCount,
                                            }).Take(5).ToList();

                StatisticInfo.OnePointRatio = (from p in StatisticDetailInfo
                                               orderby p.OnePointRatio descending
                                               select new TopResult
                                               {
                                                   PlayerId = p.Player.Id,
                                                   Name = $"{p.Player.Name} {p.Player.Surname}",
                                                   Result = p.OnePointRatio.RoundValue(),
                                                   MatchCount = p.MatchCount,
                                               }).Take(5).ToList();

                StatisticInfo.TwoPointRatio = (from p in StatisticDetailInfo
                                               orderby p.TwoPointRatio descending
                                               select new TopResult
                                               {
                                                   PlayerId = p.Player.Id,
                                                   Name = $"{p.Player.Name} {p.Player.Surname}",
                                                   Result = p.TwoPointRatio.RoundValue(),
                                                   MatchCount = p.TwoPointMatchCount,
                                               }).Take(5).ToList();
            }
        }
    }
}
