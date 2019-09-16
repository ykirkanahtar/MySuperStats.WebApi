using System.ComponentModel.DataAnnotations;

namespace MySuperStats.Contracts.Requests
{
    public class MatchGroupRequest
    {

        [Required(ErrorMessage = "Grup ismi zorunludur")]
        [MaxLength(40, ErrorMessage = "Grup ismi en fazla 40 karakter olmalıdır")]
        public string GroupName { get; set; }
    }
}