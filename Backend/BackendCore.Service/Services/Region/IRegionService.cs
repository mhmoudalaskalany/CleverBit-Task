using BackendCore.Common.DTO.Region;
using BackendCore.Service.Services.Base;

namespace BackendCore.Service.Services.Region
{
    public interface IRegionService : IBaseService<Entities.Entities.Region, AddRegionDto, RegionDto, int, int>
    {
       
    }
}