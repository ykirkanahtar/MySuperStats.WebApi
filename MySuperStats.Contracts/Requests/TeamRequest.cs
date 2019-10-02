using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CustomFramework.WebApiUtils.Contracts;
using MySuperStats.Contracts.Utils;

namespace MySuperStats.Contracts.Requests
{
    public class TeamRequest
    {
        [Required(ErrorMessage = ErrorMessages.Required)]
        [StringLength(FieldLengths.TEAM_TEAMNAME_MAX, MinimumLength = FieldLengths.TEAM_TEAMNAME_MIN
        , ErrorMessage = ErrorMessages.StringLength)]
        [Display(Name = nameof(TeamName))]
        public string TeamName { get; set; }
        

        [Required(ErrorMessage = ErrorMessages.Required)]
        [StringLength(FieldLengths.TEAM_COLOR_MAX, MinimumLength = FieldLengths.TEAM_COLOR_MIN
        , ErrorMessage = ErrorMessages.StringLength)]
        [Display(Name = nameof(Color))]
        public string Color { get; set; }

        public virtual ICollection<BasketballStatRequest> BasketballStats { get; set; }
    }
}
