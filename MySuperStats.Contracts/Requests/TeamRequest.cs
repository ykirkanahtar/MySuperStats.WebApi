using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MySuperStats.Contracts.Utils;

namespace MySuperStats.Contracts.Requests
{
    public class TeamRequest
    {
        [Required(ErrorMessage = "<field>{0}</field> <message>RequiredError</message>")]
        [StringLength(FieldLengths.TEAM_TEAMNAME_MAX, ErrorMessage = "<field>{0}</field> <message>FieldLengthError</message> <const>{2} - {1}</const>", MinimumLength = FieldLengths.TEAM_TEAMNAME_MIN)]
        public string TeamName { get; set; }
        public string Color { get; set; }

        public virtual ICollection<BasketballStatRequest> BasketballStats { get; set; }
    }
}
