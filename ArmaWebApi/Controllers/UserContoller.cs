using Domain.Users;
using Microsoft.AspNetCore.Mvc;
using Services.Abstraction;
using System.Security.Cryptography;
using System.Text;

namespace ArmaWebApi.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserContoller : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ISessionService _sessionService;

        public UserContoller(IUserService userService, ISessionService sessionService)
        {
            _userService = userService;
            _sessionService = sessionService;
        }

        [HttpGet("getuser")]
        public UserPublicInformation GetUserById(int id)
        {
            return _userService.GetUserPublicInformationById(id);
        }

        [HttpPost("register")]
        public void RegisterUser(UserRegister userRegister)
        {
            var user = new User
            {
                UserName = userRegister.UserName,
                Email = userRegister.Email,
                HashedPassword = HashPassword(userRegister.Password),
                UserRole = 1,
                CreationDate = DateTime.Today.ToString()
            };

            _userService.AddNewUser(user);
        }

        [HttpPost("login")]
        public string Login(UserLogin userLogin)
        {
            var user = _userService.GetUserByEmail(userLogin.Email);
            // check if user exist in db
            if (String.Equals(HashPassword(userLogin.Password), user.HashedPassword))
            {
                var token = _sessionService.GenerateNewSession(user.Id);

                return token;
            }

            return null;
        }

        [HttpGet("logout")]
        public void Logout(int id, string token)
        {
            _sessionService.CloseSessionByToken(token);
        }

        //logout delete token from db

        private string HashPassword(string password)
        {
            using (SHA256 mySHA256 = SHA256.Create())
            {
                var hash = mySHA256.ComputeHash(Encoding.UTF8.GetBytes(password));
                var hashString = Encoding.UTF8.GetString(hash);

                return hashString;
            }
        }
    }
}
