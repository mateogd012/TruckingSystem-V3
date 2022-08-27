using TruckingSystem_V3.DBContexts;
using TruckingSystem_V3.Entities;
using Microsoft.EntityFrameworkCore;
using TruckingSystem_V3.Services;

namespace TruckingSystem.Services
{
    public class InfoTruckersRepository : IInfoTruckersRepository
    {
        private readonly Context _context;

        public InfoTruckersRepository(Context context)
        {
            _context = context;
        }
        public Trucker? GetTrucker(int idTrucker, bool includeTrips)
        {
            if (includeTrips)
                return _context.Truckers.Include(c => c.Trips)
                    .Where(c => c.Id == idTrucker).FirstOrDefault();

            return _context.Truckers.Where(c => c.Id == idTrucker).FirstOrDefault();
        }

        public IEnumerable<Trucker> GetTruckers()
        {
            return _context.Truckers.OrderBy(x => x.NameAndLastName).ToList();
        }

        public Trip? GetTrip(int idTrucker, int idTrip)
        {
            return _context.Trips.Where(p => p.TruckerId == idTrucker && p.Id == idTrip).FirstOrDefault();
        }

        public IEnumerable<Trip> GetTrips(int idTrucker)
        {
            return _context.Trips.Where(p => p.TruckerId == idTrucker).ToList();
        }

        public bool ExistsTrucker(int idTrucker)
        {
            return _context.Truckers.Any(c => c.Id == idTrucker);
        }

        public void AddTrip(int idTrucker, Trip trip)
        {
            var trucker = GetTrucker(idTrucker, false);
            if (trucker != null)
                trucker.Trips.Add(trip);
        }

        public bool SaveChange()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void DeleteTrip(Trip trip)
        {
            _context.Trips.Remove(trip);
        }

        public bool NameAndLastNameAgreesWithIdTrucker(string? nameAndLastNameTrucker, int idTrucker)
        {
            return _context.Truckers.Any(c => c.Id == idTrucker && c.NameAndLastName == nameAndLastNameTrucker);
        }

    }
}