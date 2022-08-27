using AutoMapper;
using System.Reflection;

namespace TruckingSystem_V3.AutoMapper
{
    public class TruckerProfile : Profile
    {
        public TruckerProfile()
        {
            CreateMap<Entities.Trucker, Models.TruckerWithOutTripsDto>();
            CreateMap<Entities.Trucker, Models.TruckerDto>();
        }
    }
}
