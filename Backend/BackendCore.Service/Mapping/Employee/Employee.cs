using BackendCore.Common.DTO.Employee;
using BackendCore.Entities.Entities;

// ReSharper disable once CheckNamespace
namespace BackendCore.Service.Mapping
{
    public partial class MappingService
    {
        public void MapEmployee()
        {
            CreateMap<Employee, EmployeeDto>()
                .ReverseMap();

            CreateMap<Employee, AddEmployeeDto>()
                .ReverseMap();
        }
    }
}