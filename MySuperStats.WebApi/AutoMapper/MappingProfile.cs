using MySuperStats.Contracts.Requests;
using MySuperStats.Contracts.Responses;
using MySuperStats.WebApi.Models;
using CustomFramework.WebApiUtils.Authorization.AutoMapper;

namespace MySuperStats.WebApi.AutoMapper
{
    public class MappingProfile : AuthorizationMappingProfile
    {
        public MappingProfile()
        {
            Map();

            CreateMap<Match, MatchResponse>();
            CreateMap<MatchRequest, Match>();

            CreateMap<Player, PlayerResponse>();
            CreateMap<PlayerRequest, Player>();

            CreateMap<BasketballStat, BasketballStatResponse>();
            CreateMap<BasketballStatRequest, BasketballStat>();

            CreateMap<Team, TeamResponse>();
            CreateMap<TeamRequest, Team>();

            CreateMap<Player, PlayerDetailResponse>();

            CreateMap<MatchGroup, MatchGroupResponse>();
            CreateMap<MatchGroupRequest, MatchGroup>();

            CreateMap<MatchGroupPlayer, MatchGroupPlayerResponse>();
            CreateMap<MatchGroupPlayerRequest, MatchGroupPlayer>();

            CreateMap<MatchGroupTeam, MatchGroupTeamResponse>();
            CreateMap<MatchGroupTeamRequest, MatchGroupTeam>();
        }
    }
}
