using BasketballStats.WebApi.Authorization.AutoMapper;
using BasketballStats.WebApi.Models;
using BasketballStats.WebApi.RequestModels;
using BasketballStats.WebApi.ResponseModels;

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
        }
    }
}
