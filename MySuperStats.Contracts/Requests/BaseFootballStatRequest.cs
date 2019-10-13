using System.ComponentModel.DataAnnotations;
using CustomFramework.WebApiUtils.Contracts;

namespace MySuperStats.Contracts.Requests
{

    public class BaseFootballStatRequest
    {
        [Range(0, int.MaxValue, ErrorMessage = ErrorMessages.RangeWithMinValue)]
        [Display(Name = nameof(Goal))]
        public decimal Goal { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = ErrorMessages.RangeWithMinValue)]
        [Display(Name = nameof(OwnGoal))]
        public decimal? OwnGoal { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = ErrorMessages.RangeWithMinValue)]
        [Display(Name = nameof(PenaltyScore))]
        public decimal? PenaltyScore { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = ErrorMessages.RangeWithMinValue)]
        [Display(Name = nameof(MissedPenalty))]
        public decimal? MissedPenalty { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = ErrorMessages.RangeWithMinValue)]
        [Display(Name = nameof(Assist))]
        public decimal? Assist { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = ErrorMessages.RangeWithMinValue)]
        [Display(Name = nameof(SaveGoal))]
        public decimal? SaveGoal { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = ErrorMessages.RangeWithMinValue)]
        [Display(Name = nameof(ConcedeGoal))]
        public decimal? ConcedeGoal { get; set; }
    }
}