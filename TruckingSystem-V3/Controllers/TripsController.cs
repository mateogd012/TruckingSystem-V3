using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TruckingSystem_V3.Models;
using TruckingSystem_V3.Services;

namespace TruckingSystem_V3.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/truckers/{idTrucker}/trips")]
    public class TripsController : ControllerBase
    {
        private readonly IInfoTruckersRepository _repository;
        private readonly IMapper _mapper;

        public TripsController(IInfoTruckersRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TripDto>> GetTrips(int idTrucker)
        {
            var nameAndLastNameTrucker = User.Claims.FirstOrDefault(c => c.Type == "trucker")?.Value;

            if (!_repository.NameAndLastNameAgreesWithIdTrucker(nameAndLastNameTrucker, idTrucker))
                return Forbid();

            if (!_repository.ExistsTrucker(idTrucker))
                return NotFound();

            return Ok(_mapper.Map<IEnumerable<TripDto>>(_repository.GetTrips(idTrucker)));
        }

        [HttpGet("{idTrip}", Name = "GetTrip")]
        public ActionResult<TripDto> GetTrip(int idTrucker, int idTrip)
        {
            if (!_repository.ExistsTrucker(idTrucker))
                return NotFound();

            var trip = _repository.GetTrip(idTrucker, idTrip); 

            if (trip == null)
                return NotFound();

            return Ok(_mapper.Map<TripDto>(trip));
        }

        [HttpPost]
        public ActionResult<TripDto> AddTrip(int idTrucker, TripToCreateDto trip)
        {
            if (!_repository.ExistsTrucker(idTrucker))
            {
                return NotFound();
            }

            var newTrip = _mapper.Map<Entities.Trip>(trip);

            _repository.AddTrip(idTrucker, newTrip);
            _repository.SaveChange();

            var tripToReturn = _mapper.Map<TripDto>(newTrip);

            return CreatedAtRoute(//CreatedAtRoute es para q devuelva 201, el 200 de post.
                "GetTrip", //El primer parámetro es el Name del endpoint que hace el Get
                new //El segundo los parametros q necesita ese endpoint
                {
                    idTrucker,
                    idTrip = tripToReturn.Id
                },
                tripToReturn);//El tercero es el objeto creado. 
        }

        [HttpPut("{idTrip}")]
        public ActionResult UpdateTrip(int idTrucker, int idTrip, TripToUpdateDto trip)
        {
            if (!_repository.ExistsTrucker(idTrucker))
                return NotFound();

            var tripInTheBase = _repository.GetTrip(idTrucker, idTrip);
            if (tripInTheBase == null)
                return NotFound();

            _mapper.Map(trip, tripInTheBase);

            _repository.SaveChange();

            return NoContent();
        }


        [HttpDelete("{idTrip}")]
        public ActionResult DeleteTrip(int idTrucker, int idTrip)
        {
            if (!_repository.ExistsTrucker(idTrucker))
                return NotFound();

            var tripToDelete = _repository.GetTrip(idTrucker, idTrip);
            if (tripToDelete is null)
                return NotFound();

            _repository.DeleteTrip(tripToDelete);
            _repository.SaveChange();

            return NoContent();
        }
    }
}
