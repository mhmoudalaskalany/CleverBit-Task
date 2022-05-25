using BackendCore.Common.DTO.Region;
using BackendCore.Service.Services.Base;

namespace BackendCore.Service.Services.Region
{
    public class RegionService : BaseService<Entities.Entities.Region, AddRegionDto, RegionDto, int, int>, IRegionService
    {
        #region Properties
        #endregion

        #region Constructors
        public RegionService(IServiceBaseParameter<Entities.Entities.Region> parameters) : base(parameters)
        {

        }
        #endregion


        #region Public Methods
        

        #endregion


        #region Private Methods
       
        #endregion

    }
}
