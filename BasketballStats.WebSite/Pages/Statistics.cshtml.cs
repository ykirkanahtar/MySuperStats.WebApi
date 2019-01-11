using BasketballStats.Contracts.Responses;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using BasketballStats.WebSite.Business;

namespace BasketballStats.WebSite.Pages
{
    public class StatisticModel : PageModel
    {
        private readonly IStat _stat;
        public StatisticTable StatisticTable { get; set; }

        public StatisticModel(IStat stat)
        {
            _stat = stat;
            StatisticTable = new StatisticTable();
        }

        public async Task OnGet()
        {
            StatisticTable = await _stat.GetTopStats();
            //var players = await _player.GetAll();

            //foreach (var player in players)
            //{
            //    try
            //    {
            //        var playerStats = await _stat.GetStatsByPlayerId(player.Id);
            //        var statisticDetail = new StatisticDetail();

            //        var totalStats = _stat.GetTotalStats(playerStats);

            //        var matchCount = _stat.GetMatchCount(playerStats);
            //        var twoPointMatchCount = _stat.GetMatchCountByTwoPointStat(playerStats);

            //        var perMatchStats = _stat.GetPerMatchStats(totalStats, playerStats);

            //        statisticDetail.Player = player;
            //        statisticDetail.MatchCount = matchCount;
            //        statisticDetail.TwoPointMatchCount = twoPointMatchCount;
            //        statisticDetail.TotalStatDetail = totalStats;
            //        statisticDetail.PerMatchStatDetail = perMatchStats;

            //        statisticDetail.MatchForms = _stat.GetMatchFormsByPlayerId(matchStats, player.Id);

            //        statisticDetail.WinRatio = _stat.GetWinRatioByMatchForms(statisticDetail.MatchForms);

            //        statisticDetail.LooseRatio = _stat.GetLooseRatioByMatchForms(statisticDetail.MatchForms);

            //        statisticDetail.OnePointRatio = _stat.GetPointRatio(totalStats.OnePoint, totalStats.MissingOnePoint);
            //        statisticDetail.TwoPointRatio = _stat.GetPointRatio(totalStats.TwoPoint, totalStats.MissingTwoPoint);

            //        statisticDetail.TotalPoint = _stat.GetTotalPoint(totalStats.OnePoint, totalStats.TwoPoint);
            //        statisticDetail.PerMatchTotalPoint = _stat.GetPerMatchTotalPoint(statisticDetail.TotalPoint, matchCount);

            //        StatisticDetailInfo.Add(statisticDetail);
            //    }
            //    catch (Exception)//Oyuncuya ait istatistik yoksa
            //    {

            //    }
            //}

            //StatisticInfo = new Statistic(StatisticDetailInfo);
        }
    }
}
