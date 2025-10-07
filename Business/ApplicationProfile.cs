using AutoMapper;
using Business.Requests;
using Business.Responses;
using Entity.Entities;

namespace Business
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
          
            //CreateMap<Application, UpdatedApplicationResponse>();
            CreateMap<Application, CreatedApplicationResponse>()
                .ForMember(dest => dest.ApplicantName, opt => opt.MapFrom(src => src.Applicant.FirstName + " " + src.Applicant.LastName))
                .ForMember(dest => dest.BootcampName, opt => opt.MapFrom(src => src.Bootcamp.Name));
            CreateMap<CreateApplicationRequest, Application>();
            //CreateMap<UpdateApplicationRequest, Application>();
        }
    }

}
