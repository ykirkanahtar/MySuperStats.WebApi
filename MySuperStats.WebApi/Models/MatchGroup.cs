using System.Collections.Generic;
using CustomFramework.Data.Models;

namespace MySuperStats.WebApi.Models
{
    public class MatchGroup : BaseModel<int>
    {
        public string GroupName { get; set; }

        public virtual ICollection<MatchGroupUser> MatchGroupUsers { get; set; }
        public virtual ICollection<MatchGroupTeam> MatchGroupTeams { get; set; }
    }
}