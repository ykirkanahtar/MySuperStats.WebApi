using System.Collections.Generic;
using CustomFramework.WebApiUtils.Identity.Models;

namespace MySuperStats.WebApi.Models
{
    public class User : CustomUser
    {
        public virtual ICollection<BasketballStat> BasketballStats { get; set; }
        public virtual ICollection<FootballStat> FootballStats { get; set; }
        public virtual ICollection<MatchGroupUser> MatchGroupUsers { get; set; }
    }
}