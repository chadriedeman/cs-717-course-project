using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading.Tasks;
using WeightTrackerApi.Business.Services;
using WeightTrackerApi.DTOs;
using WeightTrackerApi.Validators;

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
        public async Task<IActionResult> AddUserAsync([FromBody] UserDto userToAdd)
        {
            if (userToAdd == null)
                return BadRequest("User cannot be null");

            var userDtoValidator = new UserDtoValidator();

            var validationResult = userDtoValidator.Validate(userToAdd);

            if (!validationResult.IsValid)
            {
                var errorMessages = validationResult.Errors.Select(error => error.ErrorMessage);

                return BadRequest(JsonConvert.SerializeObject(errorMessages));
            }

            // TODO: Map

            // TODO

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
                _logger.LogError(argumentException.Message, argumentException);

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
        public async Task<IActionResult> UpdateUserAsync([FromBody] UserDto updatedUser)
        {
            // TODO

            return NoContent();
        }

        [HttpDelete("{username}")]
        public async Task<IActionResult> DeleteUserAsync(string username)
        {
            // TODO

            return NoContent();
        }
    }
}
