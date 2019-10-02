using System.ComponentModel.DataAnnotations;
using CustomFramework.WebApiUtils.Contracts;

namespace MySuperStats.Contracts.Requests
{
    public class Login
    {
        [Required(ErrorMessage = ErrorMessages.Required)]
        [Display(Name = nameof(ClientApplicationCode))]
        public string ClientApplicationCode { get; set; }

        [Required(ErrorMessage = ErrorMessages.Required)]
        [DataType(DataType.Password)]
        [Display(Name = nameof(ClientApplicationPassword))]
        public string ClientApplicationPassword { get; set; }

        [Required(ErrorMessage = ErrorMessages.Required)]
        [Display(Name = nameof(UserName))]
        public string UserName { get; set; }

        [Required(ErrorMessage = ErrorMessages.Required)]
        [DataType(DataType.Password)]
        [Display(Name = nameof(Password))]
        public string Password { get; set; }
    }
}