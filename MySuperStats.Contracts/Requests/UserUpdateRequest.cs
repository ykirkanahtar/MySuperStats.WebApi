using System;
using System.ComponentModel.DataAnnotations;

namespace MySuperStats.Contracts.Requests
{
    public class UserUpdateRequest
    {
        [Required(ErrorMessage = "İsim alanı zorunludur")]
        [StringLength(30, ErrorMessage = "{0} alanı {1} karakterden fazla olamaz. ")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyisim alanı zorunludur")]
        [StringLength(30, ErrorMessage = "{0} alanı {1} karakterden fazla olamaz. ")]
        public string Surname { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

    }
}