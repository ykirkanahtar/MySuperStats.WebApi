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

            var missingOnePointMatchCount = (from p in BasketballStats where p.MissingOnePoint != null select p.MatchId).Distinct().Count();
            var twoPointMatchCount = (from p in BasketballStats where p.TwoPoint != null select p.MatchId).Distinct().Count();
            var missingTwoPointMatchCount = (from p in BasketballStats where p.MissingTwoPoint != null select p.MatchId).Distinct().Count();
            var assistMatchCount = (from p in BasketballStats where p.Assist != null select p.MatchId).Distinct().Count();
            var interruptMatchCount = (from p in BasketballStats where p.Interrupt != null select p.MatchId).Distinct().Count();
            var looseBallMatchCount = (from p in BasketballStats where p.LooseBall != null select p.MatchId).Distinct().Count();
            var reboundMatchCount = (from p in BasketballStats where p.Rebound != null select p.MatchId).Distinct().Count();
            var stealBallMatchCount = (from p in BasketballStats where p.StealBall != null select p.MatchId).Distinct().Count();

            //var twoPointMatchCount = ((from p in Matches where p.MatchDate >= ReleaseDates.TwoPointReleasedate select p.Id).Distinct()).Count();

            TotalStats = new BasketballStatResponse
            {
                Assist = BasketballStats.Where(x => x.Assist != null).Sum(x => x.Assist),
                Interrupt = BasketballStats.Where(x => x.Interrupt != null).Sum(x => x.Interrupt),
                LooseBall = BasketballStats.Where(x => x.LooseBall != null).Sum(x => x.LooseBall),
                MissingOnePoint = BasketballStats.Where(x => x.MissingOnePoint != null).Sum(x => x.MissingOnePoint),
                MissingTwoPoint = BasketballStats.Where(x => x.MissingTwoPoint != null).Sum(x => x.MissingTwoPoint),
                OnePoint = BasketballStats.Sum(x => x.OnePoint),
                Rebound = BasketballStats.Where(x => x.Rebound != null).Sum(x => x.Rebound),
                StealBall = BasketballStats.Where(x => x.StealBall != null).Sum(x => x.StealBall),
                TwoPoint = BasketballStats.Where(x => x.TwoPoint != null).Sum(x => x.TwoPoint),
            };

            RatioTable.OnePointRatio = TotalStats.OnePoint + (TotalStats.MissingOnePoint ?? 0) > 0 ? Math.Round(TotalStats.OnePoint / (TotalStats.OnePoint + TotalStats.MissingOnePoint ?? 0) * 100, 2) : 0;
            RatioTable.TwoPointRatio = (TotalStats.TwoPoint ?? 0) + (TotalStats.MissingTwoPoint ?? 0) > 0 ? Math.Round((TotalStats.TwoPoint ?? 0) / ((TotalStats.TwoPoint ?? 0) + (TotalStats.MissingTwoPoint) ?? 0) * 100, 2) : 0;

            PerMatchStats = new BasketballStatResponse
            {
                Assist = Math.Round(BasketballStats.Where(x => x.Assist != null).Sum(x => x.Assist) ?? 0 / assistMatchCount, 2),
                Interrupt = Math.Round(BasketballStats.Where(x => x.Interrupt != null).Sum(x => x.Interrupt) ?? 0 / interruptMatchCount, 2),
                LooseBall = Math.Round(BasketballStats.Where(x => x.LooseBall != null).Sum(x => x.LooseBall) ?? 0 / looseBallMatchCount, 2),
                MissingOnePoint = Math.Round(BasketballStats.Where(x => x.MissingOnePoint != null).Sum(x => x.MissingOnePoint) ?? 0 / missingOnePointMatchCount, 2),

                MissingTwoPoint = Math.Round(BasketballStats.Where(x => x.MissingTwoPoint != null).Sum(x => x.MissingTwoPoint) ?? 0 / twoPointMatchCount, 2),
                OnePoint = Math.Round(BasketballStats.Sum(x => x.OnePoint) / matchCount, 2),
                Rebound = Math.Round(BasketballStats.Where(x => x.Rebound != null).Sum(x => x.Rebound) ?? 0 / reboundMatchCount, 2),
                StealBall = Math.Round(BasketballStats.Where(x => x.StealBall != null).Sum(x => x.StealBall) ?? 0 / stealBallMatchCount, 2),
                TwoPoint = Math.Round(BasketballStats.Where(x => x.TwoPoint != null).Sum(x => x.TwoPoint) ?? 0 / twoPointMatchCount, 2)
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
