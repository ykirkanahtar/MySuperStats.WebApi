using BasketballStats.Contracts.Requests;
using BasketballStats.Contracts.Responses;
using BasketballStats.WebApi.Models;
using CustomFramework.WebApiUtils.Authorization.AutoMapper;

namespace BasketballStats.WebApi.AutoMapper
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
            
            CreateMap<Stat, StatResponse>();
            CreateMap<StatRequest, Stat>();

            CreateMap<Team, TeamResponse>();
            CreateMap<TeamRequest, Team>();

            CreateMap<Player, PlayerDetailResponse>();
        }
    }
}
