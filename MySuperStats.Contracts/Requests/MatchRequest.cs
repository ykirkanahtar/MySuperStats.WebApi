using System;
using System.ComponentModel.DataAnnotations;
using CustomFramework.WebApiUtils.Contracts;
using MySuperStats.Contracts.Utils;

namespace MySuperStats.Contracts.Requests
{

    public class MatchRequest
    {
        [Range(1, int.MaxValue, ErrorMessage = ErrorMessages.Required)]
        [Display(Name = "MatchGroup")]
        public int MatchGroupId { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = nameof(MatchDate))]
        public DateTime MatchDate { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = ErrorMessages.Required)]
        [Display(Name = nameof(Order))]
        public int Order { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = ErrorMessages.Required)]
        [Display(Name = nameof(DurationInMinutes))]
        public int DurationInMinutes { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = ErrorMessages.Required)]
        [Display(Name = "HomeTeam")]
        public int HomeTeamId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = ErrorMessages.Required)]
        [Display(Name = "AwayTeam")]
        public int AwayTeamId { get; set; }

        [Required(ErrorMessage = ErrorMessages.Required)]
        [StringLength(FieldLengths.MATCH_VIDEOLINK_MAX, MinimumLength = FieldLengths.MATCH_VIDEOLINK_MIN
        , ErrorMessage = ErrorMessages.StringLength)]
        [Display(Name = nameof(VideoLink))]
        public string VideoLink { get; set; }
    }
}
