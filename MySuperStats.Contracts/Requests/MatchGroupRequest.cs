using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MySuperStats.Contracts.Requests
{
    public class MatchGroupRequest
    {
        public MatchGroupRequest()
        {
            UserIds = new List<int>();
        }

        [Required(ErrorMessage = "Grup ismi zorunludur")]
        [MaxLength(40, ErrorMessage = "Grup ismi en fazla 40 karakter olmalıdır")]
        public string GroupName { get; set; }

        public List<int> UserIds { get; set; }
    }
}