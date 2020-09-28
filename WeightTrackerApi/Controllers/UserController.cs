using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WeightTrackerApi.Business.Services;
using WeightTrackerApi.DTOs;

namespace WeightTrackerApi.Controllers
{
    [Route("api/users")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost]
        public Task<IActionResult> AddUserAsync([FromBody] UserDto userToAdd)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> GetUserAsync(string username)
        {
            try
            {
                var user = await _userService.GetUserAsync(username);

                return Ok(user);
            }
            catch (ArgumentException argumentException)
            {
                return BadRequest(argumentException);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetUsersAsync()
        {
            var users = await _userService.GetUsersAsync();

            return Ok(users);
        }

        [HttpPut]
        public Task<IActionResult> UpdateUserAsync([FromBody] UserDto updatedUser)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{username}")]
        public Task<IActionResult> DeleteUserAsync(string username)
        {
            throw new NotImplementedException();
        }
    }
}
