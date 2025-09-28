using Backer.Application.Features.Users.Dtos;
using Backer.Core.Entities;
using Backer.Core.Interfaces;
using Backer.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Backer.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IRepository<User> _userRepository;
        private readonly IConfiguration _configuration;
        private readonly IMemoryCache _cache;


        public AuthController(ITokenService tokenService, IRepository<User> userRepository, IMemoryCache cache, IConfiguration configuration)
        {
            _tokenService = tokenService;
            _userRepository = userRepository;
            _cache = cache;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestModel model)
        {
            try
            {
                // Retrieve the user by username from the database.
                var users = await _userRepository.FindAsync(u => u.Username == model.Username);
                var user = users.FirstOrDefault();

                if (user == null)
                {
                    // Return a NotFound or custom message indicating that the user does not exist.
                    return Ok(ResponseProvider.GetRespone(ResponseState.Failed, "نام کاربری وارد شده نامعتبر می باشد"));
                }

                if (!_tokenService.VerifyPassword(model.Password, user.Password))
                {
                    // Invalid credentials; return an Unauthorized result.
                    return Ok(ResponseProvider.GetRespone(ResponseState.Failed, "رمز عبور وارد شده نامعتبر می باشد"));
                }

                // At this point, the user exists and the credentials are correct.
                var token = _tokenService.GenerateToken(user.Username);
                _cache.Set("fullname", user.Fullname, TimeSpan.FromMinutes(Convert.ToDouble(_configuration["Jwt:TokenValidityInMinutes"])));
                _cache.Set("username", user.Username, TimeSpan.FromMinutes(Convert.ToDouble(_configuration["Jwt:TokenValidityInMinutes"])));

                return Ok(new { success = true, token });
            }
            catch (Exception)
            {
                 return Ok(ResponseProvider.GetRespone(ResponseState.Failed));

            }
        }
    }

    
}
