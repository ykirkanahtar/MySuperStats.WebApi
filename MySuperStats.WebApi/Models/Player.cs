using System;
using System.Collections.Generic;
using CustomFramework.Data.Models;

namespace MySuperStats.WebApi.Models
{
    public class Player : BaseModel<int>
    {
        public int? UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<BasketballStat> BasketballStats { get; set; }
        public virtual ICollection<FootballStat> FootballStats { get; set; }
        public virtual ICollection<MatchGroupUser> MatchGroupUsers { get; set; }
    }
}