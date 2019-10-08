using System.Collections.Generic;
using CustomFramework.WebApiUtils.Identity.Models;

namespace MySuperStats.WebApi.Models
{
    public class User : CustomUser
    {
        public virtual Player Player { get; set; }
        public virtual ICollection<MatchGroupUser> MatchGroupUsers { get; set; }

    }
}