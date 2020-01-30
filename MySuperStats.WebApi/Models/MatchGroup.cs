using System.Collections.Generic;
using CustomFramework.BaseWebApi.Data.Models;
using MySuperStats.Contracts.Enums;

namespace MySuperStats.WebApi.Models
{
    public class MatchGroup : BaseModel<int>
    {
        public string GroupName { get; set; }
        public MatchGroupType MatchGroupType { get; set; }

        public virtual ICollection<Match> Matches { get; set; }
        public virtual ICollection<MatchGroupUser> MatchGroupUsers { get; set; }
        public virtual ICollection<MatchGroupTeam> MatchGroupTeams { get; set; }

    }
}