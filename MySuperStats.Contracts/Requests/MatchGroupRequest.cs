using System.ComponentModel.DataAnnotations;
using MySuperStats.Contracts.Utils;

namespace MySuperStats.Contracts.Requests
{
    public class MatchGroupRequest
    {

        [Required(ErrorMessage = "<field>{0}</field> <message>RequiredError</message>")]
        [StringLength(FieldLengths.MATCHGROUP_GROUPNAME_MAX, ErrorMessage = "<field>{0}</field> <message>FieldLengthError</message> <const>{2} - {1}</const>", MinimumLength = FieldLengths.MATCHGROUP_GROUPNAME_MIN)]
        public string GroupName { get; set; }
    }
}