using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BasketballStats.WebSite.ResponseModels;
using BasketballStats.WebSite.Utils;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace BasketballStats.WebSite.Pages
{
    public class StatisticModel : PageModel
    {
        private readonly WebApiConnector _webApiConnector;

        public List<StatisticDetail> StatisticDetails { get; set; }
        public Statistic Statistics { get; set; }


        public StatisticModel(WebApiConnector webApiConnector)
        {
            _webApiConnector = webApiConnector;
            StatisticDetails = new List<StatisticDetail>();
            Statistics = new Statistic();
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
                                         select p.OnePoint + p.TwoPoint).Sum(),
                        AwayTeamScore = (from p in matchStats
                                         where p.TeamId == match.AwayTeamId
                                         select p.OnePoint + p.TwoPoint).Sum()
                    };

                    var homeTeamPlayersResponse = await _webApiConnector.GetAsync($"{Constants.DefaultApiRoute}/stat/getallplayers/matchid/{match.Id}/teamid/{match.HomeTeamId}");
                    if (homeTeamPlayersResponse.StatusCode == HttpStatusCode.OK)
                    {
                        var homeTeamPlayers = JsonConvert.DeserializeObject<List<PlayerResponse>>(homeTeamPlayersResponse.Result.ToString());
                        foreach (var homeTeamPlayer in homeTeamPlayers)
                        {
                            teamForm.HomeTeamPlayerIds.Add(homeTeamPlayer.Id);
                        }
                    }

                    var awayTeamPlayersResponse = await _webApiConnector.GetAsync($"{Constants.DefaultApiRoute}/stat/getallplayers/matchid/{match.Id}/teamid/{match.AwayTeamId}");
                    if (awayTeamPlayersResponse.StatusCode == HttpStatusCode.OK)
                    {
                        var awayTeamPlayers = JsonConvert.DeserializeObject<List<PlayerResponse>>(awayTeamPlayersResponse.Result.ToString());
                        foreach (var awayTeamPlayer in awayTeamPlayers)
                        {
                            teamForm.AwayTeamPlayerIds.Add(awayTeamPlayer.Id);
                        }

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

                        var matchCount = stats.Select(p => p.MatchId).Distinct().Count();

                        var ratioStats = new StatResponse
                        {
                            OnePoint = (totalStats.OnePoint / matchCount).RoundValue(),
                            MissingOnePoint = (totalStats.MissingOnePoint / matchCount).RoundValue(),
                            TwoPoint = (totalStats.TwoPoint / matchCount).RoundValue(),
                            MissingTwoPoint = (totalStats.MissingTwoPoint / matchCount).RoundValue(),
                            Rebound = (totalStats.Rebound / matchCount).RoundValue(),
                            StealBall = (totalStats.StealBall / matchCount).RoundValue(),
                            Assist = (totalStats.Assist / matchCount).RoundValue(),
                            LooseBall = (totalStats.LooseBall / matchCount).RoundValue(),
                            Interrupt = (totalStats.Interrupt / matchCount).RoundValue(),
                        };

                        statisticDetail.Player = player;
                        statisticDetail.MatchCount = matchCount;
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

                        statisticDetail.TotalPoint = totalStats.OnePoint + totalStats.TwoPoint;
                        statisticDetail.RatioTotalPoint = ratioStats.OnePoint + ratioStats.TwoPoint;

                        StatisticDetails.Add(statisticDetail);
                    }
                }

                Statistics.TotalPoints = (from p in StatisticDetails
                                          orderby p.TotalPoint descending
                                          select new TopResult
                                          {
                                              PlayerId = p.Player.Id,
                                              Name = $"{p.Player.Name} {p.Player.Surname}",
                                              Result = p.TotalPoint,
                                              MatchCount = p.MatchCount,
                                          }).Take(5).ToList();

                Statistics.TotalOnePoints = (from p in StatisticDetails
                                             orderby p.TotalStatDetail.OnePoint descending
                                             select new TopResult
                                             {
                                                 PlayerId = p.Player.Id,
                                                 Name = $"{p.Player.Name} {p.Player.Surname}",
                                                 Result = p.TotalStatDetail.OnePoint,
                                                 MatchCount = p.MatchCount,
                                             }).Take(5).ToList();

                Statistics.TotalTwoPoints = (from p in StatisticDetails
                                             orderby p.TotalStatDetail.TwoPoint descending
                                             select new TopResult
                                             {
                                                 PlayerId = p.Player.Id,
                                                 Name = $"{p.Player.Name} {p.Player.Surname}",
                                                 Result = p.TotalStatDetail.TwoPoint,
                                                 MatchCount = p.MatchCount,
                                             }).Take(5).ToList();

                Statistics.TotalRebounds = (from p in StatisticDetails
                                            orderby p.TotalStatDetail.Rebound descending
                                            select new TopResult
                                            {
                                                PlayerId = p.Player.Id,
                                                Name = $"{p.Player.Name} {p.Player.Surname}",
                                                Result = p.TotalStatDetail.Rebound,
                                                MatchCount = p.MatchCount,
                                            }).Take(5).ToList();

                Statistics.TotalStealBalls = (from p in StatisticDetails
                                              orderby p.TotalStatDetail.StealBall descending
                                              select new TopResult
                                              {
                                                  PlayerId = p.Player.Id,
                                                  Name = $"{p.Player.Name} {p.Player.Surname}",
                                                  Result = p.TotalStatDetail.StealBall,
                                                  MatchCount = p.MatchCount,
                                              }).Take(5).ToList();

                Statistics.TotalLooseBalls = (from p in StatisticDetails
                                              orderby p.TotalStatDetail.LooseBall descending
                                              select new TopResult
                                              {
                                                  PlayerId = p.Player.Id,
                                                  Name = $"{p.Player.Name} {p.Player.Surname}",
                                                  Result = p.TotalStatDetail.LooseBall,
                                                  MatchCount = p.MatchCount,
                                              }).Take(5).ToList();

                Statistics.TotalAsists = (from p in StatisticDetails
                                          orderby p.TotalStatDetail.Assist descending
                                          select new TopResult
                                          {
                                              PlayerId = p.Player.Id,
                                              Name = $"{p.Player.Name} {p.Player.Surname}",
                                              Result = p.TotalStatDetail.Assist,
                                              MatchCount = p.MatchCount,
                                          }).Take(5).ToList();

                Statistics.TotalInterrupts = (from p in StatisticDetails
                                              orderby p.TotalStatDetail.Interrupt descending
                                              select new TopResult
                                              {
                                                  PlayerId = p.Player.Id,
                                                  Name = $"{p.Player.Name} {p.Player.Surname}",
                                                  Result = p.TotalStatDetail.Interrupt,
                                                  MatchCount = p.MatchCount,
                                              }).Take(5).ToList();

                Statistics.TotalWins = (from p in StatisticDetails
                                        orderby p.MatchStatus.Count(m => m.Contains("W")) descending
                                        select new TopResult
                                        {
                                            PlayerId = p.Player.Id,
                                            Name = $"{p.Player.Name} {p.Player.Surname}",
                                            Result = p.MatchStatus.Count(m => m.Contains("W")),
                                            MatchCount = p.MatchCount,
                                        }).Take(5).ToList();

                Statistics.TotalLoose = (from p in StatisticDetails
                                         orderby p.MatchStatus.Count(m => m.Contains("L")) descending
                                         select new TopResult
                                         {
                                             PlayerId = p.Player.Id,
                                             Name = $"{p.Player.Name} {p.Player.Surname}",
                                             Result = p.MatchStatus.Count(m => m.Contains("L")),
                                             MatchCount = p.MatchCount,
                                         }).Take(5).ToList();

                Statistics.RatioTotalPoints = (from p in StatisticDetails
                                               orderby p.RatioTotalPoint descending
                                               select new TopResult
                                               {
                                                   PlayerId = p.Player.Id,
                                                   Name = $"{p.Player.Name} {p.Player.Surname}",
                                                   Result = p.RatioTotalPoint.RoundValue(),
                                                   MatchCount = p.MatchCount,
                                               }).Take(5).ToList();

                Statistics.RatioOnePoints = (from p in StatisticDetails
                                             orderby p.RatioStatDetail.OnePoint descending
                                             select new TopResult
                                             {
                                                 PlayerId = p.Player.Id,
                                                 Name = $"{p.Player.Name} {p.Player.Surname}",
                                                 Result = p.RatioStatDetail.OnePoint.RoundValue(),
                                                 MatchCount = p.MatchCount,
                                             }).Take(5).ToList();

                Statistics.RatioTwoPoints = (from p in StatisticDetails
                                             orderby p.RatioStatDetail.TwoPoint descending
                                             select new TopResult
                                             {
                                                 PlayerId = p.Player.Id,
                                                 Name = $"{p.Player.Name} {p.Player.Surname}",
                                                 Result = p.RatioStatDetail.TwoPoint.RoundValue(),
                                                 MatchCount = p.MatchCount,
                                             }).Take(5).ToList();

                Statistics.RatioRebounds = (from p in StatisticDetails
                                            orderby p.RatioStatDetail.Rebound descending
                                            select new TopResult
                                            {
                                                PlayerId = p.Player.Id,
                                                Name = $"{p.Player.Name} {p.Player.Surname}",
                                                Result = p.RatioStatDetail.Rebound.RoundValue(),
                                                MatchCount = p.MatchCount,
                                            }).Take(5).ToList();

                Statistics.RatioStealBalls = (from p in StatisticDetails
                                              orderby p.RatioStatDetail.StealBall descending
                                              select new TopResult
                                              {
                                                  PlayerId = p.Player.Id,
                                                  Name = $"{p.Player.Name} {p.Player.Surname}",
                                                  Result = p.RatioStatDetail.StealBall.RoundValue(),
                                                  MatchCount = p.MatchCount,
                                              }).Take(5).ToList();

                Statistics.RatioLooseBalls = (from p in StatisticDetails
                                              orderby p.RatioStatDetail.LooseBall descending
                                              select new TopResult
                                              {
                                                  PlayerId = p.Player.Id,
                                                  Name = $"{p.Player.Name} {p.Player.Surname}",
                                                  Result = p.RatioStatDetail.LooseBall.RoundValue(),
                                                  MatchCount = p.MatchCount,
                                              }).Take(5).ToList();

                Statistics.RatioAsists = (from p in StatisticDetails
                                          orderby p.RatioStatDetail.Assist descending
                                          select new TopResult
                                          {
                                              PlayerId = p.Player.Id,
                                              Name = $"{p.Player.Name} {p.Player.Surname}",
                                              Result = p.RatioStatDetail.Assist.RoundValue(),
                                              MatchCount = p.MatchCount,
                                          }).Take(5).ToList();

                Statistics.RatioInterrupts = (from p in StatisticDetails
                                              orderby p.RatioStatDetail.Interrupt descending
                                              select new TopResult
                                              {
                                                  PlayerId = p.Player.Id,
                                                  Name = $"{p.Player.Name} {p.Player.Surname}",
                                                  Result = p.RatioStatDetail.Interrupt.RoundValue(),
                                                  MatchCount = p.MatchCount,
                                              }).Take(5).ToList();

                Statistics.RatioWins = (from p in StatisticDetails
                                        orderby p.WinRatio descending
                                        select new TopResult
                                        {
                                            PlayerId = p.Player.Id,
                                            Name = $"{p.Player.Name} {p.Player.Surname}",
                                            Result = p.WinRatio.RoundValue(),
                                            MatchCount = p.MatchCount,
                                        }).Take(5).ToList();

                Statistics.RatioLoose = (from p in StatisticDetails
                                         orderby p.LooseRatio descending
                                         select new TopResult
                                         {
                                             PlayerId = p.Player.Id,
                                             Name = $"{p.Player.Name} {p.Player.Surname}",
                                             Result = p.LooseRatio.RoundValue(),
                                             MatchCount = p.MatchCount,
                                         }).Take(5).ToList();

                Statistics.OnePointRatio = (from p in StatisticDetails
                                            orderby p.OnePointRatio descending
                                            select new TopResult
                                            {
                                                PlayerId = p.Player.Id,
                                                Name = $"{p.Player.Name} {p.Player.Surname}",
                                                Result = p.OnePointRatio.RoundValue(),
                                                MatchCount = p.MatchCount,
                                            }).Take(5).ToList();

                Statistics.TwoPointRatio = (from p in StatisticDetails
                                            orderby p.TwoPointRatio descending
                                            select new TopResult
                                            {
                                                PlayerId = p.Player.Id,
                                                Name = $"{p.Player.Name} {p.Player.Surname}",
                                                Result = p.TwoPointRatio.RoundValue(),
                                                MatchCount = p.MatchCount,
                                            }).Take(5).ToList();
            }
        }
    }

    public class Statistic
    {
        public Statistic()
        {
            TotalPoints = new List<TopResult>();

            TotalOnePoints = new List<TopResult>();
            TotalTwoPoints = new List<TopResult>();
            TotalRebounds = new List<TopResult>();
            TotalStealBalls = new List<TopResult>();
            TotalLooseBalls = new List<TopResult>();
            TotalAsists = new List<TopResult>();
            TotalInterrupts = new List<TopResult>();

            RatioTotalPoints = new List<TopResult>();
            RatioOnePoints = new List<TopResult>();
            RatioTwoPoints = new List<TopResult>();
            RatioRebounds = new List<TopResult>();
            RatioStealBalls = new List<TopResult>();
            RatioLooseBalls = new List<TopResult>();
            RatioAsists = new List<TopResult>();
            RatioInterrupts = new List<TopResult>();

            OnePointRatio = new List<TopResult>();
            TwoPointRatio = new List<TopResult>();
        }

        public List<TopResult> TotalPoints { get; set; }
        public List<TopResult> TotalOnePoints { get; set; }
        public List<TopResult> TotalTwoPoints { get; set; }
        public List<TopResult> TotalRebounds { get; set; }
        public List<TopResult> TotalStealBalls { get; set; }
        public List<TopResult> TotalLooseBalls { get; set; }
        public List<TopResult> TotalAsists { get; set; }
        public List<TopResult> TotalInterrupts { get; set; }
        public List<TopResult> TotalWins { get; set; }
        public List<TopResult> TotalLoose { get; set; }

        public List<TopResult> RatioTotalPoints { get; set; }
        public List<TopResult> RatioOnePoints { get; set; }
        public List<TopResult> RatioTwoPoints { get; set; }
        public List<TopResult> RatioRebounds { get; set; }
        public List<TopResult> RatioStealBalls { get; set; }
        public List<TopResult> RatioLooseBalls { get; set; }
        public List<TopResult> RatioAsists { get; set; }
        public List<TopResult> RatioInterrupts { get; set; }

        public List<TopResult> RatioWins { get; set; }
        public List<TopResult> RatioLoose { get; set; }


        public List<TopResult> OnePointRatio { get; set; }
        public List<TopResult> TwoPointRatio { get; set; }
    }

    public class TopResult
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public decimal Result { get; set; }
        public int MatchCount { get; set; }
    }

    public class StatisticDetail
    {
        public StatisticDetail()
        {
            MatchStatus = new List<string>();
        }

        public PlayerResponse Player { get; set; }
        public StatResponse TotalStatDetail { get; set; }
        public StatResponse RatioStatDetail { get; set; }
        public decimal TotalPoint { get; set; }
        public decimal RatioTotalPoint { get; set; }
        public decimal OnePointRatio { get; set; }
        public decimal TwoPointRatio { get; set; }
        public int MatchCount { get; set; }

        public List<string> MatchStatus { get; set; } //W:Win L:Loose D:Draw

        public decimal WinRatio { get; set; }
        public decimal LooseRatio { get; set; }
    }

    public class TeamForm
    {
        public TeamForm()
        {
            HomeTeamPlayerIds = new List<int>();
            AwayTeamPlayerIds = new List<int>();
        }

        public MatchResponse Match { get; set; }
        public int HomeTeamId { get; set; }
        public decimal HomeTeamScore { get; set; }
        public int AwayTeamId { get; set; }
        public decimal AwayTeamScore { get; set; }

        public List<int> HomeTeamPlayerIds { get; set; }
        public List<int> AwayTeamPlayerIds { get; set; }
    }
}
