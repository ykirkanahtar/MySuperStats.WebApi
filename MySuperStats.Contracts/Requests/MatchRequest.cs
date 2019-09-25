using System;
using System.ComponentModel.DataAnnotations;
using MySuperStats.Contracts.Utils;

namespace MySuperStats.Contracts.Requests
{

    public class MatchRequest
    {
        [Range(1, int.MaxValue, ErrorMessage = "<field>{0}</field> <message>RequiredError</message>")]
        public int MatchGroupId { get; set; }

        [DataType(DataType.Date)]
        public DateTime MatchDate { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "<field>{0}</field> <message>RequiredError</message>")]
        public int Order { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "<field>{0}</field> <message>RequiredError</message>")]
        public int DurationInMinutes { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "<field>{0}</field> <message>RequiredError</message>")]
        public int HomeTeamId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "<field>{0}</field> <message>RequiredError</message>")]
        public int AwayTeamId { get; set; }

        [Required(ErrorMessage = "<field>{0}</field> <message>RequiredError</message>")]
        [StringLength(FieldLengths.MATCH_VIDEOLINK_MAX, ErrorMessage = "<field>{0}</field> <message>FieldLengthError</message> <const>{2} - {1}</const>", MinimumLength = FieldLengths.MATCH_VIDEOLINK_MIN)]
        public string VideoLink { get; set; }
    }
}
