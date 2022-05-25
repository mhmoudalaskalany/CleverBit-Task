using BackendCore.Common.DTO.Region;
using BackendCore.Entities.Entities;

// ReSharper disable once CheckNamespace
namespace BackendCore.Service.Mapping
{
    public partial class MappingService
    {
        public void MapRegion()
        {
            CreateMap<Region, RegionDto>()
                .ReverseMap();

            CreateMap<Region, AddRegionDto>()
                .ReverseMap();
        }
    }
}