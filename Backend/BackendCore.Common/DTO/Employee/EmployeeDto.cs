using BackendCore.Common.Core;
using BackendCore.Common.DTO.Region;

namespace BackendCore.Common.DTO.Employee
{
    public class EmployeeDto : IEntityDto<int?>
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public RegionDto Region { get; set; }
    }
}
