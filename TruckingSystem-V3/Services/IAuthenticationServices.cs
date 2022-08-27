using TruckingSystem_V3.Entities;
using TruckingSystem_V3.Models;

namespace TruckingSystem_V3.Services
{
    public interface IAuthenticationServices
    {
        User? ValidateUser(AuthenticationRequestBody authenticationRequestBody);
    }
}