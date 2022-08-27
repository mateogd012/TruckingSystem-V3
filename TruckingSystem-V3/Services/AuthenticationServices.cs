using TruckingSystem_V3.Data;
using TruckingSystem_V3.Entities;
using TruckingSystem_V3.Models;

namespace TruckingSystem_V3.Services
{
    public class AuthenticationServices : IAuthenticationServices
    {
        private readonly IUsersRepository _userRepository;

        public AuthenticationServices(IUsersRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User? ValidateUser(AuthenticationRequestBody authenticationRequest)
        {
            if (string.IsNullOrEmpty(authenticationRequest.UserName) || string.IsNullOrEmpty(authenticationRequest.Password))
                return null;

            return _userRepository.ValidateUser(authenticationRequest);
        }
    }
}