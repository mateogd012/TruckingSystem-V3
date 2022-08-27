using TruckingSystem_V3.DBContexts;
using TruckingSystem_V3.Entities;
using TruckingSystem_V3.Models;

namespace TruckingSystem_V3.Data
{
    public class UsersRepository : IUsersRepository
    {
        internal readonly Context _context;

        public UsersRepository(Context context)
        {
            this._context = context;
        }

        public User? ValidateUser(AuthenticationRequestBody authRequestBody)
        {
            return _context.Users.FirstOrDefault(p => p.UserName == authRequestBody.UserName && p.Password == authRequestBody.Password);
        }
        public bool SaveChange()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
