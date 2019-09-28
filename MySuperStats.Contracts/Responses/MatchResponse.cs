using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MySuperStats.Contracts.Responses
{
    public class MatchResponse : BaseMatchResponse
    {
        public MatchResponse()
        {
            HomeTeam = new TeamResponse();
            AwayTeam = new TeamResponse();
            BasketballStats = new Collection<BasketballStatResponse>();
            FootballStats = new Collection<FootballStatResponse>();
        }

        public virtual MatchGroupResponse MatchGroup { get; set; }
        public virtual TeamResponse HomeTeam { get; set; }
        public virtual TeamResponse AwayTeam { get; set; }
        public virtual ICollection<BasketballStatResponse> BasketballStats { get; set; }
        public virtual ICollection<FootballStatResponse> FootballStats { get; set; }
    }
}

