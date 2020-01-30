using System.ComponentModel.DataAnnotations;
using CustomFramework.BaseWebApi.Contracts.Constants;

namespace MySuperStats.Contracts.Requests
{
    public class MatchGroupPlayerRequest
    {
        [Range(1, int.MaxValue, ErrorMessage = ErrorMessages.Required)]
        [Display(Name = "MatchGroup")]
        public int MatchGroupId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = ErrorMessages.Required)]
        [Display(Name = "Player")]
        public int PlayerId { get; set; }        

        [Range(1, int.MaxValue, ErrorMessage = ErrorMessages.Required)]
        [Display(Name = "Role")]
        public int RoleId { get; set; }
    }     
}