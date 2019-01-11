using System;
using System.Collections.Generic;
using System.Linq;
using BasketballStats.Contracts.Enums;
using BasketballStats.Contracts.Utils;

namespace BasketballStats.Contracts.Responses
{
    public class PlayerDetailResponse : PlayerResponse
    {
        public PlayerDetailResponse()
        {
            PerMatchStats = new StatResponse();
            TotalStats = new StatResponse();
            RatioTable = new RatioTable();
            MatchForms = new List<MatchResult>();
            WinLooseTable = new WinLooseTable();
            Matches = new List<MatchResponse>();
        }

        public StatResponse PerMatchStats { get; private set; }
        public StatResponse TotalStats { get; private set; }
        public RatioTable RatioTable { get; }
        public List<MatchResult> MatchForms { get; private set; }
        public WinLooseTable WinLooseTable { get; private set; }
        public List<MatchResponse> Matches { get; private set; }

        public void SetFields()
        {
            Matches = (from p in Stats select p.Match).ToList();
            var matchCount = ((from p in Matches select p.Id).Distinct()).Count();

            var twoPointMatchCount = ((from p in Matches where p.MatchDate >= ReleaseDates.TwoPointReleasedate select p.Id).Distinct()).Count();

            TotalStats = new StatResponse
            {
                Assist = Stats.Sum(x => x.Assist),
                Interrupt = Stats.Sum(x => x.Interrupt),
                LooseBall = Stats.Sum(x => x.LooseBall),
                MissingOnePoint = Stats.Sum(x => x.MissingOnePoint),
                MissingTwoPoint = Stats.Sum(x => x.MissingTwoPoint),
                OnePoint = Stats.Sum(x => x.OnePoint),
                Rebound = Stats.Sum(x => x.Rebound),
                StealBall = Stats.Sum(x => x.StealBall),
                TwoPoint = Stats.Sum(x => x.TwoPoint),
            };

            RatioTable.OnePointRatio = TotalStats.OnePoint + TotalStats.MissingOnePoint > 0 ? Math.Round(TotalStats.OnePoint / (TotalStats.OnePoint + TotalStats.MissingOnePoint) * 100, 2) : 0;
            RatioTable.TwoPointRatio = TotalStats.TwoPoint + TotalStats.MissingTwoPoint > 0 ? Math.Round(TotalStats.TwoPoint / (TotalStats.TwoPoint + TotalStats.MissingTwoPoint) * 100, 2) : 0;

            PerMatchStats = new StatResponse
            {
                Assist = Math.Round(Stats.Sum(x => x.Assist) / matchCount, 2),
                Interrupt = Math.Round(Stats.Sum(x => x.Interrupt) / matchCount, 2),
                LooseBall = Math.Round(Stats.Sum(x => x.LooseBall) / matchCount, 2),
                MissingOnePoint = Math.Round(Stats.Sum(x => x.MissingOnePoint) / matchCount, 2),

                MissingTwoPoint = Math.Round(Stats.Sum(x => x.MissingTwoPoint) / twoPointMatchCount, 2),
                OnePoint = Math.Round(Stats.Sum(x => x.OnePoint) / matchCount, 2),
                Rebound = Math.Round(Stats.Sum(x => x.Rebound) / matchCount, 2),
                StealBall = Math.Round(Stats.Sum(x => x.StealBall) / matchCount, 2),
                TwoPoint = Math.Round(Stats.Sum(x => x.TwoPoint) / twoPointMatchCount, 2)
            };

            GetMatchFormsByPlayerId();
            WinLooseTable = new WinLooseTable
            {
                Win = MatchForms.Count(p => p == MatchResult.Win),
                Loose = MatchForms.Count(p => p == MatchResult.Loose),
            };

            WinLooseTable.WinRatio = matchCount > 0 ? Math.Round(((WinLooseTable.Win * 100) / matchCount), 2) : 0;
            WinLooseTable.LooseRatio = matchCount > 0 ? Math.Round(((WinLooseTable.Loose * 100) / matchCount), 2) : 0;
        }

        public void GetMatchFormsByPlayerId()
        {
            MatchForms = Stats.GetMatchResultByMatchAndPlayerId();
        }
    }
}
