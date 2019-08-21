using System;
using System.Collections.Generic;
using System.Linq;
using CustomFramework.Utils;

namespace MySuperStats.Contracts.Requests
{
    // public class TeamRequestForMultiStats : TeamRequest
    // {
    //     public TeamRequestForMultiStats()
    //     {
    //         BasketballStats = new List<BasketballStatRequest>();
    //     }
    //     public IList<BasketballStatRequest> BasketballStats { get; set; }

    //     // public decimal GetAgeRatio()
    //     // {
    //     //     var teamTotalAge = (from p in BasketballStats
    //     //                         select p.User).Sum(x => x.BirthDate.GetAge());

    //     //     return BasketballStats.Count > 0
    //     //         ? (Convert.ToDecimal(teamTotalAge) / Convert.ToDecimal(BasketballStats.Count)).RoundValue()
    //     //         : 0;
    //     // }

    //     public BasketballStatRequestForUIGrid GetTeamTotal()
    //     {
    //         var statResponses = (from p in BasketballStats
    //                              select p).ToArray();

    //         return new BasketballStatRequestForUIGrid
    //         {
    //             Assist = statResponses.Where(x => x.Assist != null).Sum(x => x.Assist) == null ? string.Empty : decimal.Truncate((decimal)(statResponses.Where(x => x.Assist != null).Sum(x => x.Assist))).ToString(),
    //             Interrupt = statResponses.Where(x => x.Interrupt != null).Sum(x => x.Interrupt) == null ? string.Empty : decimal.Truncate((decimal)(statResponses.Where(x => x.Interrupt != null).Sum(x => x.Interrupt))).ToString(),
    //             LooseBall = statResponses.Where(x => x.LooseBall != null).Sum(x => x.LooseBall) == null ? string.Empty : decimal.Truncate((decimal)(statResponses.Where(x => x.LooseBall != null).Sum(x => x.LooseBall))).ToString(),
    //             OnePoint = $"{((decimal)statResponses.Sum(x => x.OnePoint)).ToString()} / {((decimal)statResponses.Sum(x => x.OnePoint) + statResponses.Sum(x => x.MissingOnePoint) ?? 0).ToString()}",
    //             Rebound = statResponses.Where(x => x.Rebound != null).Sum(x => x.Rebound) == null ? string.Empty : decimal.Truncate((decimal)(statResponses.Where(x => x.Rebound != null).Sum(x => x.Rebound))).ToString(),
    //             StealBall = statResponses.Where(x => x.StealBall != null).Sum(x => x.StealBall) == null ? string.Empty : decimal.Truncate((decimal)(statResponses.Where(x => x.StealBall != null).Sum(x => x.StealBall))).ToString(),
    //             TwoPoint = statResponses.Sum(x => x.TwoPoint) == null ? string.Empty : $"{((decimal)statResponses.Where(x => x.TwoPoint != null).Sum(x => x.TwoPoint)).ToString()} / {(((decimal)statResponses.Where(x => x.TwoPoint != null).Sum(x => x.TwoPoint) + statResponses.Sum(x => x.MissingTwoPoint) ?? 0)).ToString()}",
    //             TotalPoint = (statResponses.Sum(x => x.OnePoint) + statResponses.Sum(x => x.TwoPoint) ?? 0 * 2).ToString()
    //         };
    //     }
    // }
}
