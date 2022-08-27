using AutoMapper;

namespace TruckingSystem_V3.AutoMapper
{
    public class TripProfile : Profile
    {
        public TripProfile()
        {
            CreateMap<Entities.Trip, Models.TripDto>();
            CreateMap<Models.TripToCreateDto, Entities.Trip>();
            CreateMap<Models.TripToUpdateDto, Entities.Trip>();
        }
    }
}
