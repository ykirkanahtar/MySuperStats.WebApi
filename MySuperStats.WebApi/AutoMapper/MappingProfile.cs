using CustomFramework.BaseWebApi.Identity.AutoMapper;
using MySuperStats.Contracts.Requests;
using MySuperStats.Contracts.Responses;
using MySuperStats.WebApi.Models;

namespace MySuperStats.WebApi.AutoMapper
{
    public class MappingProfile : IdentityMappingProfile
    {
        public MappingProfile()
        {
            Map();

            CreateMap<User, UserResponse>();
            CreateMap<UserRegisterRequest, User>();

            CreateMap<Role, RoleResponse>();
            CreateMap<RoleRequest, Role>();

            CreateMap<Match, MatchResponse>();
            CreateMap<Match, BaseMatchResponse>();
            CreateMap<MatchRequest, Match>();


            CreateMap<Player, PlayerResponse>();
            CreateMap<CreatePlayerRequest, Player>();
            CreateMap<UpdatePlayerRequest, Player>();

            CreateMap<BasketballStat, BasketballStatResponse>();
            CreateMap<BasketballStatRequestForMultiEntry, BasketballStat>()
                .ForMember(src => src.Player, act => act.Ignore())
                .ForMember(src => src.Team, act => act.Ignore())
                .ForMember(src => src.MatchId, act => act.Ignore());

            CreateMap<BasketballStatRequest, BasketballStat>()
                .ForMember(src => src.Player, act => act.Ignore())
                .ForMember(src => src.Team, act => act.Ignore());

            CreateMap<UserDetailWithBasketballStat, UserDetailWithBasketballStatResponse>();

            CreateMap<Team, TeamResponse>();
            CreateMap<Team, BaseTeamResponse>();
            CreateMap<TeamRequest, Team>();

            CreateMap<MatchGroup, MatchGroupResponse>();
            CreateMap<MatchGroupRequest, MatchGroup>();

            CreateMap<MatchGroupUser, MatchGroupUserResponse>();
            CreateMap<MatchGroupPlayerCreateRequest, MatchGroupPlayerRequest>();
            CreateMap<MatchGroupPlayerRequest, MatchGroupUser>();
            CreateMap<MatchGroupUserRequest, MatchGroupUser>();

            CreateMap<MatchGroupTeam, MatchGroupTeamResponse>();
            CreateMap<MatchGroupTeamRequest, MatchGroupTeam>();

            CreateMap<FootballStat, FootballStatResponse>();
            CreateMap<FootballStatRequestForMultiEntry, FootballStat>()
                .ForMember(src => src.Player, act => act.Ignore())
                .ForMember(src => src.Team, act => act.Ignore())
                .ForMember(src => src.MatchId, act => act.Ignore());

            CreateMap<FootballStatRequest, FootballStat>()
                .ForMember(src => src.Player, act => act.Ignore())
                .ForMember(src => src.Team, act => act.Ignore());      

            CreateMap<UserDetailWithFootballStat, UserDetailWithFootballStatResponse>();
        }
    }
}
