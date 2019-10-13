using System;
using AutoMapper;
using MySuperStats.Contracts.Requests;
using MySuperStats.Contracts.Responses;

namespace MySuperStats.WebUI.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<BasketballStatRequestForUI, BasketballStatResponse>();
            CreateMap<BaseBasketballStatRequest, BasketballStatResponse>();
            CreateMap<BasketballStatRequest, BasketballStatResponse>();
            CreateMap<MatchRequest, MatchResponse>();
            CreateMap<TeamRequest, TeamResponse>();
            CreateMap<TeamResponse, TeamRequest>();
            CreateMap<UpdatePlayerRequest, PlayerResponse>();
        }
    }
}