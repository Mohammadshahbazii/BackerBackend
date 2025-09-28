using Backer.Core.Entities;
using Backer.Core.Interfaces;
using Backer.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace Backer.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMemoryCache _cache;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<JobsAccess> _jobsAccessRepository;

        public UsersController(IRepository<User> userRepository, IRepository<JobsAccess> jobsAccessRepository, IMemoryCache cache)
        {
            _cache = cache;
            _userRepository = userRepository;
            _jobsAccessRepository = jobsAccessRepository;
        }

        [HttpGet("GetUsername")]
        public async Task<IActionResult> GetUsername()
        {
            _cache.TryGetValue("username", out string? username);
            return Ok(ResponseProvider.GetRespone(ResponseState.Success, username));
        }

        [HttpGet("GetFullname")]
        public async Task<IActionResult> GetFullname()
        {
            _cache.TryGetValue("fullname", out string? fullname);
            return Ok(ResponseProvider.GetRespone(ResponseState.Success, fullname));
        }

        [HttpGet("GetUserAccess")]
        public async Task<IActionResult> GetUserAccess()
        {
            _cache.TryGetValue("username", out string? username);

            var user = await _userRepository.FindAsync(u => u.Username == username);
            var userEntity = user.FirstOrDefault(); // Assuming the username is unique

            if (userEntity == null)
            {
                return Ok(new Respone() { State = ResponseState.Error, Message = "مدت زمان معتبر برای استفاده از نرم افزار به اتمام رسیده است" });
            }

            var jobsAccess = await _jobsAccessRepository.FindAsync(ja => ja.JobTitleID == userEntity.JobId, ja => ja.AccessGroup);

            if (jobsAccess == null || !jobsAccess.Any())
            {
                return Ok(new Respone() { State = ResponseState.Error, Message = "دسترسی یافت نشد" });
            }

            // 3. Include AccessGroup in the result
            var accessGroupTitles = jobsAccess
                .Where(ja => ja.AccessGroup != null) // Filter out null AccessGroups
                .Select(ja => ja.AccessGroup) // AccessGroup Title
                .ToList();

            return Ok(ResponseProvider.GetRespone(ResponseState.Success, accessGroupTitles));
        }
    }
}
