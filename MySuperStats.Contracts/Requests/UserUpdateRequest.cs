using System;
using System.ComponentModel.DataAnnotations;
using CustomFramework.WebApiUtils.Contracts;
using MySuperStats.Contracts.Utils;

namespace MySuperStats.Contracts.Requests
{
    public class UserUpdateRequest
    {
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

    }
}