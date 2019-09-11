﻿using MySuperStats.Contracts.Requests;
using MySuperStats.Contracts.Responses;
using MySuperStats.WebApi.Models;
using CustomFramework.WebApiUtils.Identity.AutoMapper;

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
            CreateMap<MatchRequest, Match>();

            CreateMap<BasketballStat, BasketballStatResponse>();
            CreateMap<BasketballStatRequest, BasketballStat>()
                .ForMember(src => src.User, act => act.Ignore())
                .ForMember(src => src.Team, act => act.Ignore());

            CreateMap<Team, TeamResponse>();
            CreateMap<TeamRequest, Team>();

            CreateMap<User, UserDetailResponse>();

            CreateMap<MatchGroup, MatchGroupResponse>();
            CreateMap<MatchGroupRequest, MatchGroup>();

            CreateMap<MatchGroupUser, MatchGroupUserResponse>();
            CreateMap<MatchGroupUserCreateRequest, MatchGroupUserRequest>();
            CreateMap<MatchGroupUserRequest, MatchGroupUser>();

            CreateMap<MatchGroupTeam, MatchGroupTeamResponse>();
            CreateMap<MatchGroupTeamRequest, MatchGroupTeam>();

            CreateMap<FootballStat, FootballStatResponse>();
            CreateMap<FootballStatRequest, FootballStat>();

        }
    }
}
