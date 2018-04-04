using BasketballStats.Contracts.Responses;
using BasketballStats.WebSite.Models;
using System.Collections.Generic;

namespace BasketballStats.WebSite.Business
{
    public interface ITeam
    {
        TeamDetail GetTeamDetailByTeamResponse(IStat stat, TeamResponse team, IList<StatResponse> matchStats);
    }
}
