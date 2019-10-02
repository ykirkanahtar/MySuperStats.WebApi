using System.ComponentModel.DataAnnotations;
using CustomFramework.WebApiUtils.Contracts;

namespace MySuperStats.Contracts.Requests
{
    public class UserEmailUpdateRequest
    {
        [Required(ErrorMessage = ErrorMessages.Required)]
        [EmailAddress(ErrorMessage = ErrorMessages.EmailAddressNotValid)]
        [Display(Name = nameof(NewEmail))]
        public string NewEmail { get; set; }
    }
}