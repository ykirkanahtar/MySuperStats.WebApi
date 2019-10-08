using System.ComponentModel.DataAnnotations;
using CustomFramework.WebApiUtils.Contracts;

namespace MySuperStats.Contracts.Requests
{
    public class MatchGroupPlayerCreateRequest
    {
        [Range(1, int.MaxValue, ErrorMessage = ErrorMessages.Required)]
        [Display(Name = "MatchGroup")]
        public int MatchGroupId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = ErrorMessages.Required)]
        [Display(Name = "Player")]
        public int PlayerId { get; set; }
    }
}