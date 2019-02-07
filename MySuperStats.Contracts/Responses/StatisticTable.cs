using System.Collections.Generic;

namespace MySuperStats.Contracts.Responses
{
    public class StatisticTable
    {
        public StatisticTable()
        {
            Points = new List<StatisticDetail>();
            PointPerMatch = new List<StatisticDetail>();

            OnePoint = new List<StatisticDetail>();
            OnePointPerMatch = new List<StatisticDetail>();
            OnePointRatio = new List<StatisticDetail>();

            TwoPoint = new List<StatisticDetail>();
            TwoPointPerMatch = new List<StatisticDetail>();
            TwoPointRatio = new List<StatisticDetail>();

            Rebounds = new List<StatisticDetail>();
            ReboundPerMatch = new List<StatisticDetail>();

            Steals = new List<StatisticDetail>();
            StealsPerMatch = new List<StatisticDetail>();

            Turnovers = new List<StatisticDetail>();
            TurnoversPerMatch = new List<StatisticDetail>();

            Assist = new List<StatisticDetail>();
            AssistPerMatch = new List<StatisticDetail>();

            Interrupts = new List<StatisticDetail>();
            InterruptPerMatch = new List<StatisticDetail>();

            Wins = new List<StatisticDetail>();
            WinRatio = new List<StatisticDetail>();

            Looses = new List<StatisticDetail>();
            LooseRatio = new List<StatisticDetail>();
        }

        public List<StatisticDetail> Points { get; set; }
        public List<StatisticDetail> PointPerMatch { get; set; }

        public List<StatisticDetail> OnePoint { get; set; }
        public List<StatisticDetail> OnePointPerMatch { get; set; }
        public List<StatisticDetail> OnePointRatio { get; set; }

        public List<StatisticDetail> TwoPoint { get; set; }
        public List<StatisticDetail> TwoPointPerMatch { get; set; }
        public List<StatisticDetail> TwoPointRatio { get; set; }

        public List<StatisticDetail> Rebounds { get; set; }
        public List<StatisticDetail> ReboundPerMatch { get; set; }

        public List<StatisticDetail> Steals { get; set; }
        public List<StatisticDetail> StealsPerMatch { get; set; }

        public List<StatisticDetail> Turnovers { get; set; }
        public List<StatisticDetail> TurnoversPerMatch { get; set; }

        public List<StatisticDetail> Assist { get; set; }
        public List<StatisticDetail> AssistPerMatch { get; set; }

        public List<StatisticDetail> Interrupts { get; set; }
        public List<StatisticDetail> InterruptPerMatch { get; set; }

        public List<StatisticDetail> Wins { get; set; }
        public List<StatisticDetail> WinRatio { get; set; }

        public List<StatisticDetail> Looses { get; set; }
        public List<StatisticDetail> LooseRatio { get; set; }
    }
}