using AutoMapper;
using Business.Requests;
using Business.Responses;
using Entity.Entities;

namespace Business
{
    public class BootcampProfile : Profile
    {
        public BootcampProfile()
        {
            CreateMap<CreateBootcampRequest, Bootcamp>();
            CreateMap<UpdateBootcampRequest, Bootcamp>();
            CreateMap<Bootcamp, BootcampResponse>()
                .ForMember(dest => dest.InstructorFullName,
                           opt => opt.MapFrom(src => src.Instructor.FirstName + " " + src.Instructor.LastName))
                .ForMember(dest => dest.State,
                           opt => opt.MapFrom(src => src.BootcampState.ToString()));
        }
    }

}
