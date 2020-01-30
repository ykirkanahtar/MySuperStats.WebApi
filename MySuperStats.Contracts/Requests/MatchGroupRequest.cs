using System.ComponentModel.DataAnnotations;
using CustomFramework.BaseWebApi.Contracts.Constants;
using MySuperStats.Contracts.Enums;
using MySuperStats.Contracts.Utils;

namespace MySuperStats.Contracts.Requests
{
    public class MatchGroupRequest
    {

        [Required(ErrorMessage = ErrorMessages.Required)]
        [StringLength(FieldLengths.MATCHGROUP_GROUPNAME_MAX, MinimumLength = FieldLengths.MATCHGROUP_GROUPNAME_MIN
          , ErrorMessage = ErrorMessages.StringLength)]
        [Display(Name = nameof(GroupName))]
        public string GroupName { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = ErrorMessages.Required)]
        [Display(Name = nameof(MatchGroupType))]
        public MatchGroupType MatchGroupType { get; set; }
    }
}