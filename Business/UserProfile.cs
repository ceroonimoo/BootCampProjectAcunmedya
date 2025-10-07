using AutoMapper;
using Business.Requests;
using Business.Responses;
using Entity.Entities;

namespace Business.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, RegisteredUserResponse>()
                .ForMember(dest => dest.FullName,
                    opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));

            CreateMap<RegisterUserRequest, User>();
        }
    }
}
