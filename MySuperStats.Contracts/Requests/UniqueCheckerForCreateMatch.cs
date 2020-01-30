using System;
using System.ComponentModel.DataAnnotations;
using CustomFramework.BaseWebApi.Contracts.Constants;

namespace MySuperStats.Contracts.Requests
{
    public class UniqueCheckerForCreateMatch
    {
        [Range(1, int.MaxValue, ErrorMessage = ErrorMessages.Required)]
        [Display(Name = "MatchGroup")]
        public int MatchGroupId { get; set; }

        [Required(ErrorMessage = ErrorMessages.Required)]
        [Display(Name = nameof(MatchDate))]
        public string MatchDateString { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = nameof(MatchDate))]
        public DateTime MatchDate { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = ErrorMessages.Required)]
        [Display(Name = nameof(Order))]
        public int Order { get; set; }
    }
}
