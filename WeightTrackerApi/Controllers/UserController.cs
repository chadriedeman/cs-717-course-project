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
        public Task<IActionResult> AddUser([FromBody] UserDto userToAdd)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{username}")]
        public Task<IActionResult> GetUser(string username)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public Task<IActionResult> GetUsers()
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public Task<IActionResult> UpdateUser([FromBody] UserDto updatedUser)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{username}")]
        public Task<IActionResult> DeleteUser(string username)
        {
            throw new NotImplementedException();
        }
    }
}
