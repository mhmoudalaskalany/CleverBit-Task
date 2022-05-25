using System.ComponentModel.DataAnnotations;
using BackendCore.Common.Core;

namespace BackendCore.Common.DTO.Region
{
    public class AddRegionDto : IEntityDto<int>
    {
        public int Id { get; set; }
        [MaxLength(250)]
        public string Name { get; set; }
    }
}
