using TruckingSystem_V3.Entities;

namespace TruckingSystem_V3.Services
{
    public interface IInfoTruckersRepository
    {
        public IEnumerable<Trucker> GetTruckers();
        public Trucker? GetTrucker(int idTrucker, bool includeTrip);
        public IEnumerable<Trip> GetTrips(int idTrucker);
        public Trip? GetTrip(int idTrucker, int idTrip);
        public bool ExistsTrucker(int idTrucker);
        public void AddTrip(int idTrucker, Trip trip);
        void DeleteTrip(Trip trip);
        public bool SaveChange();
        bool NameAndLastNameAgreesWithIdTrucker(string? nameAndLastName, int idTrucker);
    }
}