using AutoMapper;
using Business.Requests;
using Business.Responses;
using Entity.Entities;

namespace Business
{
    public class ApplicantProfile : Profile
    {
        public ApplicantProfile()
        {
            // Create
            CreateMap<CreateBlacklistRequest, Blacklist>();

            // Update
            CreateMap<UpdateBlacklistRequest, Blacklist>();

            // Response
            CreateMap<Blacklist, BlacklistResponse>();
        }
    }
}

