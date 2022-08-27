using TruckingSystem_V3.Entities;
using TruckingSystem_V3.Models;

namespace TruckingSystem_V3.Data
{
    public interface IUsersRepository
    {
        public User? ValidateUser(AuthenticationRequestBody authRequestBody);
        public bool SaveChange();

    }
}
