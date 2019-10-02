using System.ComponentModel.DataAnnotations;
using CustomFramework.WebApiUtils.Contracts;

namespace MySuperStats.Contracts.Requests
{
    public class MatchGroupTeamRequest
    {
        [Range(1, int.MaxValue, ErrorMessage = ErrorMessages.Required)]
        [DataType(DataType.Password)]
        [Display(Name = "MatchGroup")]
        public int MatchGroupId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = ErrorMessages.Required)]
        [Display(Name = "Team")]
        public int TeamId { get; set; }
    }
}