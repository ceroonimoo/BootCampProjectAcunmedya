using AutoMapper;
using Business.Requests;
using Business.Responses;
using Entity.Entities;

namespace Business
{
    public class BlacklistProfile : Profile
    {
        public BlacklistProfile()
        {
            CreateMap<CreateBlacklistRequest, Blacklist>();
            CreateMap<UpdateBlacklistRequest, Blacklist>();
            CreateMap<Blacklist, BlacklistResponse>();
        }
    }

}
