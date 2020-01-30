using System;
using System.ComponentModel.DataAnnotations;
using CustomFramework.BaseWebApi.Contracts.Constants;
using CustomFramework.BaseWebApi.Contracts.Utils;
using MySuperStats.Contracts.Attributes;
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
        [StringLength(15, MinimumLength = IdentityFieldLengths.PASSWORD_MIN
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
        [StringLength(FieldLengths.USER_LASTNAME_MAX, MinimumLength = FieldLengths.USER_LASTNAME_MIN
        , ErrorMessage = ErrorMessages.StringLength)]
        [Display(Name = nameof(LastName))]
        public string LastName { get; set; }

        [Required(ErrorMessage = ErrorMessages.Required)]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [MinBirthDate(ErrorMessage = ErrorMessages.InvalidDateOfBirth)]
        [MaxBirthDate(ErrorMessage = ErrorMessages.InvalidDateOfBirth)]        
        [Display(Name = nameof(BirthDate))]
        public DateTime BirthDate { get; set; }

        public string CallBackUrl { get; set; }
    }
}