using AutoMapper;
using BusinessLogicLayer.DTOs;
using HRMagnement.Models;

namespace HRManagement.BussinessLogic.Mapping;

public sealed class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        // Entity -> DTO
        CreateMap<EmployeeContact, EmployeeContactDto>();
        CreateMap<Employee, EmployeeDto>()
            .ForMember(d => d.Contact, o => o.MapFrom(s => s.EmployeeContact));

        // Create request -> Entity
        CreateMap<CreateEmployeeContactRequest, EmployeeContact>();
        CreateMap<CreateEmployeeRequest, Employee>()
            .ForMember(d => d.Id, o => o.Ignore())
            .ForMember(d => d.IsActive, o => o.MapFrom(_ => true))
            .ForMember(d => d.EmployeeContact, o => o.MapFrom(s => s.Contact));

        // Update request -> Entity (used with Map(source, destination))
        CreateMap<UpdateEmployeeContactRequest, EmployeeContact>();
        CreateMap<UpdateEmployeeRequest, Employee>()
            .ForMember(d => d.EmployeeContact, o => o.MapFrom(s => s.Contact));
    }
}