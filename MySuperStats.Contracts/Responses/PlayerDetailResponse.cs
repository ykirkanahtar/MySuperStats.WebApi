using System;
using System.Collections.Generic;
using System.Linq;
using MySuperStats.Contracts.Enums;
using MySuperStats.Contracts.Utils;

namespace MySuperStats.Contracts.Responses
{
    public class UserDetailResponse : UserResponse
    {
        public UserDetailResponse()
        {
            PerMatchStats = new BasketballStatResponse();
            TotalStats = new BasketballStatResponse();
            RatioTable = new BasketballRatioTable();
            MatchForms = new List<MatchResult>();
            WinLooseTable = new WinLooseTable();
            Matches = new List<MatchResponse>();
        }

        public BasketballStatResponse PerMatchStats { get; private set; }
        public BasketballStatResponse TotalStats { get; private set; }
        public BasketballRatioTable RatioTable { get; }
        public List<MatchResult> MatchForms { get; private set; }
        public WinLooseTable WinLooseTable { get; private set; }
        public List<MatchResponse> Matches { get; private set; }

        public void SetFields()
        {
            Matches = (from p in BasketballStats select p.Match).ToList();
            var matchCount = ((from p in Matches select p.Id).Distinct()).Count();

            var twoPointMatchCount = ((from p in Matches where p.MatchDate >= ReleaseDates.TwoPointReleasedate select p.Id).Distinct()).Count();

            TotalStats = new BasketballStatResponse
            {
                Assist = BasketballStats.Sum(x => x.Assist),
                Interrupt = BasketballStats.Sum(x => x.Interrupt),
                LooseBall = BasketballStats.Sum(x => x.LooseBall),
                MissingOnePoint = BasketballStats.Sum(x => x.MissingOnePoint),
                MissingTwoPoint = BasketballStats.Sum(x => x.MissingTwoPoint),
                OnePoint = BasketballStats.Sum(x => x.OnePoint),
                Rebound = BasketballStats.Sum(x => x.Rebound),
                StealBall = BasketballStats.Sum(x => x.StealBall),
                TwoPoint = BasketballStats.Sum(x => x.TwoPoint),
            };

            RatioTable.OnePointRatio = TotalStats.OnePoint + TotalStats.MissingOnePoint > 0 ? Math.Round(TotalStats.OnePoint / (TotalStats.OnePoint + TotalStats.MissingOnePoint) * 100, 2) : 0;
            RatioTable.TwoPointRatio = TotalStats.TwoPoint + TotalStats.MissingTwoPoint > 0 ? Math.Round(TotalStats.TwoPoint / (TotalStats.TwoPoint + TotalStats.MissingTwoPoint) * 100, 2) : 0;

            PerMatchStats = new BasketballStatResponse
            {
                Assist = Math.Round(BasketballStats.Sum(x => x.Assist) / matchCount, 2),
                Interrupt = Math.Round(BasketballStats.Sum(x => x.Interrupt) / matchCount, 2),
                LooseBall = Math.Round(BasketballStats.Sum(x => x.LooseBall) / matchCount, 2),
                MissingOnePoint = Math.Round(BasketballStats.Sum(x => x.MissingOnePoint) / matchCount, 2),

                MissingTwoPoint = Math.Round(BasketballStats.Sum(x => x.MissingTwoPoint) / twoPointMatchCount, 2),
                OnePoint = Math.Round(BasketballStats.Sum(x => x.OnePoint) / matchCount, 2),
                Rebound = Math.Round(BasketballStats.Sum(x => x.Rebound) / matchCount, 2),
                StealBall = Math.Round(BasketballStats.Sum(x => x.StealBall) / matchCount, 2),
                TwoPoint = Math.Round(BasketballStats.Sum(x => x.TwoPoint) / twoPointMatchCount, 2)
            };

            GetMatchFormsByUserId();
            WinLooseTable = new WinLooseTable
            {
                Win = MatchForms.Count(p => p == MatchResult.Win),
                Loose = MatchForms.Count(p => p == MatchResult.Loose),
            };

            WinLooseTable.WinRatio = matchCount > 0 ? Math.Round(((WinLooseTable.Win * 100) / matchCount), 2) : 0;
            WinLooseTable.LooseRatio = matchCount > 0 ? Math.Round(((WinLooseTable.Loose * 100) / matchCount), 2) : 0;
        }

        public void GetMatchFormsByUserId()
        {
            MatchForms = BasketballStats.GetMatchResultByMatchAndUserId();
        }
    }
}
