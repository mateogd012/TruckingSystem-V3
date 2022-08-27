using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TruckingSystem_V3.Models;
using TruckingSystem_V3.Services;

namespace TruckingSystem_V3.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/truckers")]
    public class TruckersController : ControllerBase
    {
        private readonly IInfoTruckersRepository _infoTruckersRepository;
        private readonly IMapper _mapper;

        public TruckersController(IInfoTruckersRepository infoTruckersRepository, IMapper mapper)
        {
            _infoTruckersRepository = infoTruckersRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TruckerWithOutTripsDto>> GetTruckers()
        {
            var truckers = _infoTruckersRepository.GetTruckers();

            return Ok(_mapper.Map<IEnumerable<TruckerWithOutTripsDto>>(truckers));
        }


        [HttpGet("{id}")]
        public IActionResult GetTrucker(int id, bool includeTrips = false)
        {
            var trucker = _infoTruckersRepository.GetTrucker(id, includeTrips);
            if (trucker == null)
                return NotFound();

            if (includeTrips)
                return Ok(_mapper.Map<TruckerDto>(trucker));

            return Ok(_mapper.Map<TruckerWithOutTripsDto>(trucker));
        }

    }
}
