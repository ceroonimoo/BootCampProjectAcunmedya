using AutoMapper;
using Business.Requests;
using Business.Responses;
using Entity.Entities;

namespace Business
{
    public class InstructorProfile : Profile
    {
        public InstructorProfile()
        {
            CreateMap<CreateInstructorRequest, Instructor>();
            CreateMap<UpdateInstructorRequest, Instructor>();
            CreateMap<Instructor, InstructorResponse>();
        }
    }
    }
