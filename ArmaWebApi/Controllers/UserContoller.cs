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
        public IActionResult GetUserById(int id)
        {
            try
            {
                var userInfo = _userService.GetUserPublicInformationById(id);

                return StatusCode(200, userInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("register")]
        public IActionResult RegisterUser(UserRegister userRegister)
        {
            try
            {
                var user = new User
                {
                    UserName = userRegister.UserName,
                    Email = userRegister.Email,
                    HashedPassword = HashPassword(userRegister.Password),
                    UserRole = 1,
                    CreationDate = DateTime.Today.Date.ToString()
                };

                _userService.AddNewUser(user);

                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("login")]
        public IActionResult Login(UserLogin userLogin)
        {
            try 
            { 
                var user = _userService.GetUserByEmail(userLogin.Email);

                if (user == null)
                {
                    return StatusCode(204, "User doesn't exist");
                }
                
                if (!String.Equals(HashPassword(userLogin.Password), user.HashedPassword))
                {
                    return StatusCode(401, "Incorrect password");
                }

                var token = _sessionService.GenerateNewSession(user.Id);

                return StatusCode(200, token);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("logout")]
        public IActionResult Logout(int id, string token)
        {
            try
            {
                var session = _sessionService.GetSessionByToken(token);

                if (session == null)
                {
                    return StatusCode(204, "No session was found");
                }

                _sessionService.CloseSession(session);

                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

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
