using System;
using System.Collections.Generic;

namespace MySuperStats.Contracts.Responses
{
    public class PlayerResponse
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public virtual UserResponse User { get; set; }
        public virtual ICollection<BasketballStatResponse> BasketballStats { get; set; }
        public virtual ICollection<FootballStatResponse> FootballStats { get; set; }

    }
}

