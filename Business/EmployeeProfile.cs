using AutoMapper;
using Business.Requests;
using Business.Responses;
using Entity.Entities;

namespace Business
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<CreateEmployeeRequest, Employee>();
            CreateMap<UpdateEmployeeRequest, Employee>();
            CreateMap<Employee, EmployeeResponse>();
        }
    }
}
