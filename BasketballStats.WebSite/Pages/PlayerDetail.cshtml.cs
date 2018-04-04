using BasketballStats.WebSite.Utils;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BasketballStats.Contracts.Responses;
using BasketballStats.WebSite.Models;
using BasketballStats.WebSite.Business;

namespace BasketballStats.WebSite.Pages
{
    public class PlayerDetailModel : PageModel
    {
        private readonly IPlayer _player;
        private readonly IStat _stat;
        private readonly IMatch _match;

        public PlayerDetail PlayerDetailInfo { get; set; }

        public PlayerDetailModel(IPlayer player, IMatch match, IStat stat)
        {
            _player = player;
            _stat = stat;
            _match = match;
            PlayerDetailInfo = new PlayerDetail();
        }

        public async Task OnGet(int id)
        {
            var playerId = id;

            var player = await _player.GetById(playerId);
            PlayerDetailInfo.Player = player;

            var playerStats = await _stat.GetStatsByPlayerId(playerId);
            playerStats = playerStats.OrderBy(p => p.Match.MatchDate).ThenBy(p => p.Match.Order).ThenBy(p => p.Team.Id).ToList();

            var totalStats = _stat.GetTotalStats(playerStats);

            var matchCount = _stat.GetMatchCount(playerStats);
            var twoPointMatchCount = _stat.GetMatchCountByTwoPointStat(playerStats);

            var perMatchStats = _stat.GetPerMatchStats(totalStats, playerStats);

            PlayerDetailInfo.OnePointRatio = _stat.GetPointRatio(totalStats.OnePoint, totalStats.MissingOnePoint);
            PlayerDetailInfo.TwoPointRatio = _stat.GetPointRatio(totalStats.TwoPoint, totalStats.MissingTwoPoint);

            PlayerDetailInfo.TotalStats = totalStats;
            PlayerDetailInfo.PerMatchStats = perMatchStats;

            var matches = await _match.GetAll();
            var allMatchStats = await _stat.GetAll();

            PlayerDetailInfo.MatchForms = _stat.GetMatchFormsByPlayerId(allMatchStats, playerId);
            PlayerDetailInfo.TotalWins = _stat.GetTotalWinsByMatchForms(PlayerDetailInfo.MatchForms);
            PlayerDetailInfo.TotalLooses = _stat.GetTotalLoosesByMatchForms(PlayerDetailInfo.MatchForms);
            PlayerDetailInfo.WinRatio = _stat.GetWinRatioByMatchForms(PlayerDetailInfo.MatchForms);
            PlayerDetailInfo.LooseRatio = _stat.GetLooseRatioByMatchForms(PlayerDetailInfo.MatchForms);

            foreach (var stat in playerStats)
            {
                var playerStatDetail = new PlayerStatDetail { PlayerStat = stat };

                playerStatDetail.MatchStats = await _stat.GetStatsByMatchId(stat.MatchId);

                playerStatDetail.HomeTeamScore = _stat.GetScoreByStatsAndTeamId(playerStatDetail.MatchStats, stat.Match.HomeTeamId);
                playerStatDetail.AwayTeamScore = _stat.GetScoreByStatsAndTeamId(playerStatDetail.MatchStats, stat.Match.AwayTeamId);

                PlayerDetailInfo.PlayerStats.Add(playerStatDetail);
            }
        }

    }
}
