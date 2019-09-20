using System.ComponentModel.DataAnnotations;

namespace MySuperStats.Contracts.Requests
{
    public class FootballStatRequest
    {
        [Range(1, int.MaxValue, ErrorMessage = "<field>{0}</field> <message>RequiredError</message>")]
        public int MatchId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "<field>{0}</field> <message>RequiredError</message>")]
        public int TeamId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "<field>{0}</field> <message>RequiredError</message>")]
        public int UserId { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "<field>{0}</field> <message>MinValueError</message> <const>{1}</const>")]
        public decimal Goal { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "<field>{0}</field> <message>MinValueError</message> <const>{1}</const>")]
        public decimal OwnGoal { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "<field>{0}</field> <message>MinValueError</message> <const>{1}</const>")]
        public decimal PenaltyScore { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "<field>{0}</field> <message>MinValueError</message> <const>{1}</const>")]
        public decimal MissedPenalty { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "<field>{0}</field> <message>MinValueError</message> <const>{1}</const>")]
        public decimal Assist { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "<field>{0}</field> <message>MinValueError</message> <const>{1}</const>")]
        public decimal SaveGoal { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "<field>{0}</field> <message>MinValueError</message> <const>{1}</const>")]
        public decimal ConcedeGoal { get; set; }

    }
}