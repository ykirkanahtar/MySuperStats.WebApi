using System.ComponentModel.DataAnnotations;

namespace MySuperStats.Contracts.Requests
{
    public class MatchGroupTeamRequest
    {
        [Range(1, int.MaxValue, ErrorMessage = "<field>{0}</field> <message>RequiredError</message>")]
        public int MatchGroupId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "<field>{0}</field> <message>RequiredError</message>")]
        public int TeamId { get; set; }
    }
}