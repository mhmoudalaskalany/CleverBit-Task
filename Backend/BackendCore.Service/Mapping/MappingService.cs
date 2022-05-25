using AutoMapper;

namespace BackendCore.Service.Mapping
{
    public partial class MappingService : Profile
    {
        public MappingService()
        {
           
            MapUser();
            MapEmployee();
            MapRegion();
        }
    }
}