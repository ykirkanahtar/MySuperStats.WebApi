using System;
using System.ComponentModel.DataAnnotations;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Identity.Contracts.Utils;
using MySuperStats.Contracts.Utils;

namespace MySuperStats.Contracts.Requests
{
    public class UserRegisterRequest
    {
        [Required(ErrorMessage = ErrorMessages.Required)]
        [EmailAddress(ErrorMessage = ErrorMessages.EmailAddressNotValid)]
        [Display(Name = nameof(Email))]
        public string Email { get; set; }

        [Required(ErrorMessage = ErrorMessages.Required)]
        [StringLength(FieldLengths.USER_USERNAME_MAX, MinimumLength = FieldLengths.USER_USERNAME_MIN
        , ErrorMessage = ErrorMessages.StringLength)]
        [Display(Name = nameof(Username))]
        public string Username { get; set; }

        [Required(ErrorMessage = ErrorMessages.Required)]
        [StringLength(IdentityFieldLengths.PASSWORD_MAX, MinimumLength = IdentityFieldLengths.PASSWORD_MIN
        , ErrorMessage = ErrorMessages.StringLength)]
        [DataType(DataType.Password)]
        [Display(Name = nameof(Password))]
        public string Password { get; set; }

        [Required(ErrorMessage = ErrorMessages.Required)]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = ErrorMessages.Compare)]
        [Display(Name = nameof(ConfirmPassword))]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = ErrorMessages.Required)]
        [StringLength(FieldLengths.USER_FIRSTNAME_MAX, MinimumLength = FieldLengths.USER_FIRSTNAME_MIN
        , ErrorMessage = ErrorMessages.StringLength)]
        [Display(Name = nameof(FirstName))]
        public string FirstName { get; set; }

        [Required(ErrorMessage = ErrorMessages.Required)]
        [StringLength(FieldLengths.USER_SURNAME_MAX, MinimumLength = FieldLengths.USER_SURNAME_MIN
        , ErrorMessage = ErrorMessages.StringLength)]
        [Display(Name = nameof(Surname))]
        public string Surname { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = nameof(BirthDate))]
        public DateTime BirthDate { get; set; }

        public string CallBackUrl { get; set; }
    }
}