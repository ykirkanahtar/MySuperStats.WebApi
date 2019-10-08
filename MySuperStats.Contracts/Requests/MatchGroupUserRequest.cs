using System.ComponentModel.DataAnnotations;
using CustomFramework.WebApiUtils.Contracts;

namespace MySuperStats.Contracts.Requests
{
    public class MatchGroupUserRequest
    {
        [Range(1, int.MaxValue, ErrorMessage = ErrorMessages.Required)]
        [Display(Name = "MatchGroup")]
        public int MatchGroupId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = ErrorMessages.Required)]
        [Display(Name = "User")]
        public int UserId { get; set; }        

        [Range(1, int.MaxValue, ErrorMessage = ErrorMessages.Required)]
        [Display(Name = "Role")]
        public int RoleId { get; set; }
    }   
}