using System.Collections.Generic;
using CustomFramework.BaseWebApi.Identity.Models;

namespace MySuperStats.WebApi.Models
{
    public class Role : CustomRole
    {
        public virtual ICollection<MatchGroupUser> MatchGroupUsers { get; set; }

    }
}