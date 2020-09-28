using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading.Tasks;
using WeightTrackerApi.Business.Services;
using WeightTrackerApi.DTOs;
using WeightTrackerApi.Mappers;
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
        public async Task<IActionResult> AddUserAsync([FromBody] UserDto userDto)
        {
            if (userDto == null)
                return BadRequest("User cannot be null");

            var userDtoValidator = new UserDtoValidator();

            var validationResult = userDtoValidator.Validate(userDto);

            if (!validationResult.IsValid)
            {
                var errorMessages = validationResult.Errors.Select(error => error.ErrorMessage);

                return BadRequest(JsonConvert.SerializeObject(errorMessages));
            }

            var user = UserMapper.MapUserDtoToUser(userDto);

            try
            {
                await _userService.AddUserAsync(user);
            } 
            catch (ArgumentException argumentException)
            {
                _logger.LogError(argumentException.Message, argumentException);

                return Conflict($"The user {user.Username} already exists.");
            }

            return Created("", ""); // TODO: Pass in appropriate params
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> GetUserAsync([FromRoute] string username)
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
        public async Task<IActionResult> UpdateUserAsync([FromBody] UserDto userDto)
        {
            if (userDto == null)
                return BadRequest("User cannot be null.");

            var userDtoValidator = new UserDtoValidator();

            var validationResult = userDtoValidator.Validate(userDto);

            if (!validationResult.IsValid)
            {
                var errorMessages = validationResult.Errors.Select(error => error.ErrorMessage);

                return BadRequest(JsonConvert.SerializeObject(errorMessages));
            }

            var user = UserMapper.MapUserDtoToUser(userDto);

            await _userService.UpdateUserAsync(user);

            return NoContent();
        }

        [HttpDelete("{username}")]
        public async Task<IActionResult> DeleteUserAsync([FromRoute] string username)
        {
            await _userService.DeleteUserAsync(username);

            return NoContent();
        }

        [HttpPost("{username}/weigh-in")]
        public async Task<IActionResult> AddUserWeighInAsync([FromRoute] string username, [FromBody] WeighInDto weighInDto)
        {
            throw new NotImplementedException(); // TODO
        }

        [HttpPut("{username}/weigh-in")]
        public async Task<IActionResult> UpdateUserWeighInAsync([FromRoute] string username, [FromBody] WeighInDto weighInDto)
        {
            throw new NotImplementedException(); // TODO
        }

        [HttpGet("{username}/weigh-in")]
        public async Task<IActionResult> UpdateUserWeighInAsync([FromRoute] string username, [FromBody] DateTime date)
        {
            throw new NotImplementedException(); // TODO
        }

        [HttpDelete("{username}/weigh-in")]
        public async Task<IActionResult> DeleteUserWeighInAsync([FromRoute] string username, [FromBody] DateTime date)
        {
            throw new NotImplementedException(); // TODO
        }
    }
}
