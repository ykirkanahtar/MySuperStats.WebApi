using BasketballStats.WebSite.Enums;
using BasketballStats.WebSite.Utils;
using System.Collections.Generic;
using System.Linq;

namespace BasketballStats.WebSite.Models
{
    public class Statistic
    {
        private readonly IList<StatisticDetail> _statisticDetails;
        public Statistic(IList<StatisticDetail> statisticDetails)
        {
            _statisticDetails = statisticDetails;

            TotalPoints = new List<TopResult>();

            TotalOnePoints = new List<TopResult>();
            TotalTwoPoints = new List<TopResult>();
            TotalRebounds = new List<TopResult>();
            TotalStealBalls = new List<TopResult>();
            TotalLooseBalls = new List<TopResult>();
            TotalAsists = new List<TopResult>();
            TotalInterrupts = new List<TopResult>();

            PerMatchTotalPoints = new List<TopResult>();
            PerMatchOnePoints = new List<TopResult>();
            PerMatchTwoPoints = new List<TopResult>();
            PerMatchRebounds = new List<TopResult>();
            PerMatchStealBalls = new List<TopResult>();
            PerMatchLooseBalls = new List<TopResult>();
            PerMatchAsists = new List<TopResult>();
            PerMatchInterrupts = new List<TopResult>();

            OnePointRatio = new List<TopResult>();
            TwoPointRatio = new List<TopResult>();

            SetTotalPoints();

            SetTotalOnePoints();

            SetTotalTwoPoints();

            SetTotalRebounds();

            SetTotalStealBalls();

            SetTotalLooseBalls();

            SetTotalAsists();

            SetTotalInterrupts();

            SetTotalWin();

            SetTotalLoose();

            SetPerMatchTotalPoints();

            SetPerMatchOnePoints();

            SetPerMatchTwoPoints();

            SetPerMatchRebounds();

            SetPerMatchStealBalls();

            SetPerMatchLooseBalls();

            SetPerMatchAsists();

            SetPerMatchInterrupts();

            SetRatioWin();

            SetRatioLoose();

            SetOnePointRatio();

            SetTwoPointRatio();
        }

        public List<TopResult> TotalPoints { get; private set; }

        private void SetTotalPoints()
        {
            TotalPoints = (from p in _statisticDetails
                           orderby p.TotalPoint descending, p.MatchCount ascending, p.Player.Name ascending
                           select new TopResult
                           {
                               PlayerId = p.Player.Id,
                               Name = $"{p.Player.Name} {p.Player.Surname}",
                               Result = p.TotalPoint,
                               MatchCount = p.MatchCount,
                           }).Take(5).ToList();
        }

        public List<TopResult> TotalOnePoints { get; private set; }

        private void SetTotalOnePoints()
        {
            TotalOnePoints = (from p in _statisticDetails
                              orderby p.TotalStatDetail.OnePoint descending, p.MatchCount ascending, p.Player.Name ascending
                              select new TopResult
                              {
                                  PlayerId = p.Player.Id,
                                  Name = $"{p.Player.Name} {p.Player.Surname}",
                                  Result = p.TotalStatDetail.OnePoint,
                                  MatchCount = p.MatchCount,
                              }).Take(5).ToList();
        }

        public List<TopResult> TotalTwoPoints { get; private set; }

        private void SetTotalTwoPoints()
        {
            TotalTwoPoints = (from p in _statisticDetails
                              orderby p.TotalStatDetail.TwoPoint descending, p.TwoPointMatchCount ascending, p.Player.Name ascending
                              select new TopResult
                              {
                                  PlayerId = p.Player.Id,
                                  Name = $"{p.Player.Name} {p.Player.Surname}",
                                  Result = p.TotalStatDetail.TwoPoint,
                                  MatchCount = p.TwoPointMatchCount,
                              }).Take(5).ToList();
        }

        public List<TopResult> TotalRebounds { get; private set; }

        private void SetTotalRebounds()
        {
            TotalRebounds = (from p in _statisticDetails
                             orderby p.TotalStatDetail.Rebound descending, p.MatchCount ascending, p.Player.Name ascending
                             select new TopResult
                             {
                                 PlayerId = p.Player.Id,
                                 Name = $"{p.Player.Name} {p.Player.Surname}",
                                 Result = p.TotalStatDetail.Rebound,
                                 MatchCount = p.MatchCount,
                             }).Take(5).ToList();
        }

        public List<TopResult> TotalStealBalls { get; private set; }

        private void SetTotalStealBalls()
        {
            TotalStealBalls = (from p in _statisticDetails
                               orderby p.TotalStatDetail.StealBall descending, p.MatchCount ascending, p.Player.Name ascending
                               select new TopResult
                               {
                                   PlayerId = p.Player.Id,
                                   Name = $"{p.Player.Name} {p.Player.Surname}",
                                   Result = p.TotalStatDetail.StealBall,
                                   MatchCount = p.MatchCount,
                               }).Take(5).ToList();
        }

        public List<TopResult> TotalLooseBalls { get; private set; }

        private void SetTotalLooseBalls()
        {
            TotalLooseBalls = (from p in _statisticDetails
                               orderby p.TotalStatDetail.LooseBall descending, p.MatchCount ascending, p.Player.Name ascending
                               select new TopResult
                               {
                                   PlayerId = p.Player.Id,
                                   Name = $"{p.Player.Name} {p.Player.Surname}",
                                   Result = p.TotalStatDetail.LooseBall,
                                   MatchCount = p.MatchCount,
                               }).Take(5).ToList();
        }

        public List<TopResult> TotalAsists { get; private set; }

        private void SetTotalAsists()
        {
            TotalAsists = (from p in _statisticDetails
                           orderby p.TotalStatDetail.Assist descending, p.MatchCount ascending, p.Player.Name ascending
                           select new TopResult
                           {
                               PlayerId = p.Player.Id,
                               Name = $"{p.Player.Name} {p.Player.Surname}",
                               Result = p.TotalStatDetail.Assist,
                               MatchCount = p.MatchCount,
                           }).Take(5).ToList();
        }

        public List<TopResult> TotalInterrupts { get; private set; }

        private void SetTotalInterrupts()
        {
            TotalInterrupts = (from p in _statisticDetails
                               orderby p.TotalStatDetail.Interrupt descending, p.MatchCount ascending, p.Player.Name ascending
                               select new TopResult
                               {
                                   PlayerId = p.Player.Id,
                                   Name = $"{p.Player.Name} {p.Player.Surname}",
                                   Result = p.TotalStatDetail.Interrupt,
                                   MatchCount = p.MatchCount,
                               }).Take(5).ToList();
        }

        public List<TopResult> TotalWin { get; private set; }

        private void SetTotalWin()
        {
            TotalWin = (from p in _statisticDetails
                        orderby p.MatchForms.Count(m => m == (MatchScore.Win)) descending, p.MatchCount ascending, p.Player.Name ascending
                        select new TopResult
                        {
                            PlayerId = p.Player.Id,
                            Name = $"{p.Player.Name} {p.Player.Surname}",
                            Result = p.MatchForms.Count(m => m == (MatchScore.Win)),
                            MatchCount = p.MatchCount,
                        }).Take(5).ToList();
        }

        public List<TopResult> TotalLoose { get; private set; }

        private void SetTotalLoose()
        {
            TotalLoose = (from p in _statisticDetails
                          orderby p.MatchForms.Count(m => m == (MatchScore.Loose)) descending, p.MatchCount ascending, p.Player.Name ascending
                          select new TopResult
                          {
                              PlayerId = p.Player.Id,
                              Name = $"{p.Player.Name} {p.Player.Surname}",
                              Result = p.MatchForms.Count(m => m == (MatchScore.Loose)),
                              MatchCount = p.MatchCount,
                          }).Take(5).ToList();
        }

        public List<TopResult> PerMatchTotalPoints { get; private set; }

        private void SetPerMatchTotalPoints()
        {
            PerMatchTotalPoints = (from p in _statisticDetails
                                   orderby p.PerMatchTotalPoint descending, p.MatchCount ascending, p.Player.Name ascending
                                   select new TopResult
                                   {
                                       PlayerId = p.Player.Id,
                                       Name = $"{p.Player.Name} {p.Player.Surname}",
                                       Result = p.PerMatchTotalPoint.RoundValue(),
                                       MatchCount = p.MatchCount,
                                   }).Take(5).ToList();
        }

        public List<TopResult> PerMatchOnePoints { get; private set; }

        private void SetPerMatchOnePoints()
        {
            PerMatchOnePoints = (from p in _statisticDetails
                                 orderby p.PerMatchStatDetail.OnePoint descending, p.MatchCount ascending, p.Player.Name ascending
                                 select new TopResult
                                 {
                                     PlayerId = p.Player.Id,
                                     Name = $"{p.Player.Name} {p.Player.Surname}",
                                     Result = p.PerMatchStatDetail.OnePoint.RoundValue(),
                                     MatchCount = p.MatchCount,
                                 }).Take(5).ToList();
        }

        public List<TopResult> PerMatchTwoPoints { get; private set; }

        private void SetPerMatchTwoPoints()
        {
            PerMatchTwoPoints = (from p in _statisticDetails
                                 orderby p.PerMatchStatDetail.TwoPoint descending, p.TwoPointMatchCount ascending, p.Player.Name ascending
                                 select new TopResult
                                 {
                                     PlayerId = p.Player.Id,
                                     Name = $"{p.Player.Name} {p.Player.Surname}",
                                     Result = p.PerMatchStatDetail.TwoPoint.RoundValue(),
                                     MatchCount = p.TwoPointMatchCount,
                                 }).Take(5).ToList();
        }

        public List<TopResult> PerMatchRebounds { get; private set; }

        private void SetPerMatchRebounds()
        {
            PerMatchRebounds = (from p in _statisticDetails
                                orderby p.PerMatchStatDetail.Rebound descending, p.MatchCount ascending, p.Player.Name ascending
                                select new TopResult
                                {
                                    PlayerId = p.Player.Id,
                                    Name = $"{p.Player.Name} {p.Player.Surname}",
                                    Result = p.PerMatchStatDetail.Rebound.RoundValue(),
                                    MatchCount = p.MatchCount,
                                }).Take(5).ToList();
        }

        public List<TopResult> PerMatchStealBalls { get; private set; }

        private void SetPerMatchStealBalls()
        {
            PerMatchStealBalls = (from p in _statisticDetails
                                  orderby p.PerMatchStatDetail.StealBall descending, p.MatchCount ascending, p.Player.Name ascending
                                  select new TopResult
                                  {
                                      PlayerId = p.Player.Id,
                                      Name = $"{p.Player.Name} {p.Player.Surname}",
                                      Result = p.PerMatchStatDetail.StealBall.RoundValue(),
                                      MatchCount = p.MatchCount,
                                  }).Take(5).ToList();
        }

        public List<TopResult> PerMatchLooseBalls { get; private set; }

        private void SetPerMatchLooseBalls()
        {
            PerMatchLooseBalls = (from p in _statisticDetails
                                  orderby p.PerMatchStatDetail.LooseBall descending, p.MatchCount ascending, p.Player.Name ascending
                                  select new TopResult
                                  {
                                      PlayerId = p.Player.Id,
                                      Name = $"{p.Player.Name} {p.Player.Surname}",
                                      Result = p.PerMatchStatDetail.LooseBall.RoundValue(),
                                      MatchCount = p.MatchCount,
                                  }).Take(5).ToList();
        }

        public List<TopResult> PerMatchAsists { get; private set; }

        private void SetPerMatchAsists()
        {
            PerMatchAsists = (from p in _statisticDetails
                              orderby p.PerMatchStatDetail.Assist descending, p.MatchCount ascending, p.Player.Name ascending
                              select new TopResult
                              {
                                  PlayerId = p.Player.Id,
                                  Name = $"{p.Player.Name} {p.Player.Surname}",
                                  Result = p.PerMatchStatDetail.Assist.RoundValue(),
                                  MatchCount = p.MatchCount,
                              }).Take(5).ToList();
        }

        public List<TopResult> PerMatchInterrupts { get; private set; }

        private void SetPerMatchInterrupts()
        {
            PerMatchInterrupts = (from p in _statisticDetails
                                  orderby p.PerMatchStatDetail.Interrupt descending, p.MatchCount ascending, p.Player.Name ascending
                                  select new TopResult
                                  {
                                      PlayerId = p.Player.Id,
                                      Name = $"{p.Player.Name} {p.Player.Surname}",
                                      Result = p.PerMatchStatDetail.Interrupt.RoundValue(),
                                      MatchCount = p.MatchCount,
                                  }).Take(5).ToList();
        }


        public List<TopResult> RatioWin { get; private set; }

        private void SetRatioWin()
        {
            RatioWin = (from p in _statisticDetails
                        orderby p.WinRatio descending, p.MatchCount ascending, p.Player.Name ascending
                        select new TopResult
                        {
                            PlayerId = p.Player.Id,
                            Name = $"{p.Player.Name} {p.Player.Surname}",
                            Result = p.WinRatio.RoundValue(),
                            MatchCount = p.MatchCount,
                        }).Take(5).ToList();
        }

        public List<TopResult> RatioLoose { get; private set; }

        private void SetRatioLoose()
        {
            RatioLoose = (from p in _statisticDetails
                          orderby p.LooseRatio descending, p.MatchCount ascending, p.Player.Name ascending
                          select new TopResult
                          {
                              PlayerId = p.Player.Id,
                              Name = $"{p.Player.Name} {p.Player.Surname}",
                              Result = p.LooseRatio.RoundValue(),
                              MatchCount = p.MatchCount,
                          }).Take(5).ToList();
        }

        public List<TopResult> OnePointRatio { get; private set; }

        private void SetOnePointRatio()
        {
            OnePointRatio = (from p in _statisticDetails
                             orderby p.OnePointRatio descending, p.MatchCount ascending, p.Player.Name ascending
                             select new TopResult
                             {
                                 PlayerId = p.Player.Id,
                                 Name = $"{p.Player.Name} {p.Player.Surname}",
                                 Result = p.OnePointRatio.RoundValue(),
                                 MatchCount = p.MatchCount,
                             }).Take(5).ToList();
        }

        public List<TopResult> TwoPointRatio { get; private set; }

        private void SetTwoPointRatio()
        {
            TwoPointRatio = (from p in _statisticDetails
                             orderby p.TwoPointRatio descending, p.MatchCount ascending, p.Player.Name ascending
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
