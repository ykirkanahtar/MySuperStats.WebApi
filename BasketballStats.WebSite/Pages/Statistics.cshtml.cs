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
using BasketballStats.WebSite.Business;

namespace BasketballStats.WebSite.Pages
{
    public class StatisticModel : PageModel
    {
        private readonly IMatch _match;
        private readonly IPlayer _player;
        private readonly IStat _stat;

        public List<StatisticDetail> StatisticDetailInfo { get; set; }
        public Statistic StatisticInfo { get; set; }


        public StatisticModel(IMatch match, IPlayer player, IStat stat)
        {
            _match = match;
            _player = player;
            _stat = stat;
            StatisticDetailInfo = new List<StatisticDetail>();
        }

        public async Task OnGet()
        {
            var matches = await _match.GetAll();
            var matchStats = await _stat.GetAll();

            var players = await _player.GetAll();

            foreach (var player in players)
            {
                try
                {
                    var playerStats = await _stat.GetStatsByPlayerId(player.Id);
                    var statisticDetail = new StatisticDetail();

                    var totalStats = _stat.GetTotalStats(playerStats);

                    var matchCount = _stat.GetMatchCount(playerStats);
                    var twoPointMatchCount = _stat.GetMatchCountByTwoPointStat(playerStats);

                    var perMatchStats = _stat.GetPerMatchStats(totalStats, playerStats);

                    statisticDetail.Player = player;
                    statisticDetail.MatchCount = matchCount;
                    statisticDetail.TwoPointMatchCount = twoPointMatchCount;
                    statisticDetail.TotalStatDetail = totalStats;
                    statisticDetail.PerMatchStatDetail = perMatchStats;

                    statisticDetail.MatchForms = _stat.GetMatchFormsByPlayerId(matchStats, player.Id);

                    statisticDetail.WinRatio = _stat.GetWinRatioByMatchForms(statisticDetail.MatchForms);

                    statisticDetail.LooseRatio = _stat.GetLooseRatioByMatchForms(statisticDetail.MatchForms);

                    statisticDetail.OnePointRatio = _stat.GetPointRatio(totalStats.OnePoint, totalStats.MissingOnePoint);
                    statisticDetail.TwoPointRatio = _stat.GetPointRatio(totalStats.TwoPoint, totalStats.MissingTwoPoint);

                    statisticDetail.TotalPoint = _stat.GetTotalPoint(totalStats.OnePoint, totalStats.TwoPoint);
                    statisticDetail.PerMatchTotalPoint = _stat.GetPerMatchTotalPoint(statisticDetail.TotalPoint, matchCount);

                    StatisticDetailInfo.Add(statisticDetail);
                }
                catch (Exception)//Oyuncuya ait istatistik yoksa
                {

                }
            }

            StatisticInfo = new Statistic(StatisticDetailInfo);
        }
    }
}
