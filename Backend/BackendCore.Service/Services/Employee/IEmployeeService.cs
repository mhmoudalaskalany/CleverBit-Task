using System.Threading.Tasks;
using BackendCore.Common.Core;
using BackendCore.Common.DTO.Base;
using BackendCore.Common.DTO.Employee;
using BackendCore.Common.DTO.Employee.Parameters;
using BackendCore.Service.Services.Base;

namespace BackendCore.Service.Services.Employee
{
    public interface IEmployeeService : IBaseService<Entities.Entities.Employee, AddEmployeeDto, EmployeeDto, int, int?>
    {
        Task<IResponseResult> GetByRegionIdAsync(int regionId);
        Task<DataPaging> GetAllPagedAsync(BaseParam<EmployeeFilter> filter);
    }
}