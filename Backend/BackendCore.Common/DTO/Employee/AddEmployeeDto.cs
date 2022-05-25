using System.ComponentModel.DataAnnotations;
using BackendCore.Common.Core;

namespace BackendCore.Common.DTO.Employee
{
    public class AddEmployeeDto : IEntityDto<int?>
    {
        public int? Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }
        [Required]
        public int RegionId { get; set; }
    }
}
