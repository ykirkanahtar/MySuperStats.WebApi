using System.Collections.Generic;

namespace MySuperStats.Contracts.Requests
{
    public class TeamRequest
    {
        public string Name { get; set; }
        public string Color { get; set; }

        public virtual ICollection<BasketballStatRequest> BasketballStats { get; set; }
    }
}
