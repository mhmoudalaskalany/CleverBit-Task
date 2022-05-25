using BackendCore.Common.Core;

namespace BackendCore.Common.DTO.Region
{
    public class RegionDto : IEntityDto<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}