using System;
using System.ComponentModel.DataAnnotations;

namespace MySuperStats.Contracts.Requests
{
    public class MatchRequest
    {
        public int MatchGroupId { get; set; }
        public DateTime MatchDate { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Değer sıfır ya da sıfırdan küçük olamaz")]
        public int Order { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Değer sıfır ya da sıfırdan küçük olamaz")]
        public int DurationInMinutes { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }

        [Required(ErrorMessage = "Video Bağlantısı alanı zorunludur")]
        public string VideoLink { get; set; }

        public virtual TeamRequest HomeTeam { get; set; }
        public virtual TeamRequest AwayTeam { get; set; }
    }
}
