using System.Collections.Generic;

namespace MySuperStats.Contracts.Responses
{
    public class FootballStatisticTable
    {
        public FootballStatisticTable()
        {
            Goals = new List<StatisticDetail>();
            GoalPerMatch = new List<StatisticDetail>();

            OwnGoals = new List<StatisticDetail>();
            OwnGoalPerMatch = new List<StatisticDetail>();

            PenaltyScores = new List<StatisticDetail>();
            PenaltyScorePerMatch = new List<StatisticDetail>();

            MissedPenalties = new List<StatisticDetail>();
            MissedPenaltyPerMatch = new List<StatisticDetail>();

            Assist = new List<StatisticDetail>();
            AssistPerMatch = new List<StatisticDetail>();

            SaveGoals = new List<StatisticDetail>();
            SaveGoalPerMatch = new List<StatisticDetail>();

            ConcedeGoals = new List<StatisticDetail>();
            ConcedeGoalPerMatch = new List<StatisticDetail>();

            Wins = new List<StatisticDetail>();
            WinRatio = new List<StatisticDetail>();

            Looses = new List<StatisticDetail>();
            LooseRatio = new List<StatisticDetail>();
        }

        public List<StatisticDetail> Goals { get; set; }
        public List<StatisticDetail> GoalPerMatch { get; set; }

        public List<StatisticDetail> OwnGoals { get; set; }
        public List<StatisticDetail> OwnGoalPerMatch { get; set; }

        public List<StatisticDetail> PenaltyScores { get; set; }
        public List<StatisticDetail> PenaltyScorePerMatch { get; set; }

        public List<StatisticDetail> MissedPenalties { get; set; }
        public List<StatisticDetail> MissedPenaltyPerMatch { get; set; }

        public List<StatisticDetail> Assist { get; set; }
        public List<StatisticDetail> AssistPerMatch { get; set; }

        public List<StatisticDetail> SaveGoals { get; set; }
        public List<StatisticDetail> SaveGoalPerMatch { get; set; }

        public List<StatisticDetail> ConcedeGoals { get; set; }
        public List<StatisticDetail> ConcedeGoalPerMatch { get; set; }

        public List<StatisticDetail> Wins { get; set; }
        public List<StatisticDetail> WinRatio { get; set; }

        public List<StatisticDetail> Looses { get; set; }
        public List<StatisticDetail> LooseRatio { get; set; }
    }    
}