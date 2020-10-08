using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Linq;
using WeightTrackerApi.Business.Services;
using WeightTrackerApi.DTOs;
using WeightTrackerApi.Mappers;
using WeightTrackerApi.Validators;

namespace WeightTrackerApi.Controllers
{
    [Route("api/users")]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] UserDto userDto)
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
                _userService.AddUser(user);
            } 
            catch (ArgumentException argumentException)
            {
                _logger.LogError(argumentException.Message, argumentException);

                return Conflict($"The user {user.Username} already exists.");
            }

            var apiBasePath = GetBasePath(Request);

            return Created(apiBasePath, string.Empty);
        }

        [HttpGet("{username}")]
        public  IActionResult GetUser([FromRoute] string username)
        {
            try
            {
                var user = _userService.GetUser(username);

                return Ok(user);
            }
            catch (ArgumentException argumentException)
            {
                _logger.LogError(argumentException.Message, argumentException);

                return BadRequest(argumentException);
            }
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _userService.GetUsers();

            return Ok(users);
        }

        [HttpPut]
        public IActionResult UpdateUser([FromBody] UserDto userDto)
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

            _userService.UpdateUser(user);

            return NoContent();
        }

        [HttpDelete("{username}")]
        public IActionResult DeleteUser([FromRoute] string username)
        {
            _userService.DeleteUser(username);

            return NoContent();
        }

        [HttpPost("{username}/weigh-in")]
        public IActionResult AddUserWeighIn([FromRoute] string username, [FromBody] WeighInDto weighInDto)
        {

            if (string.IsNullOrWhiteSpace(username))
                return BadRequest("Username cannot be null");

            if (weighInDto == null)
                return BadRequest("Weigh-in cannot be null");

            var weighInDtoValidator = new WeighInDtoValidator();

            var validationResult = weighInDtoValidator.Validate(weighInDto);

            if (!validationResult.IsValid)
            {
                var errorMessages = validationResult.Errors.Select(error => error.ErrorMessage);

                return BadRequest(JsonConvert.SerializeObject(errorMessages));
            }

            var weighIn = WeighInMapper.MapWeighInDtoToWeighIn(weighInDto);

            try
            {
                _userService.AddUserWeighIn(username, weighIn);
            }
            catch (ArgumentException argumentException)
            {
                _logger.LogError(argumentException.Message, argumentException);

                return Conflict($"A weigh-in already exists for {username} on {weighInDto.Date.ToShortDateString()}.");
            }

            var apiBasePath = GetBasePath(Request);

            return Created(apiBasePath, string.Empty);
        }

        [HttpPut("{username}/weigh-in")]
        public IActionResult UpdateUserWeighIn([FromRoute] string username, [FromBody] WeighInDto weighInDto)
        {
            if (string.IsNullOrWhiteSpace(username))
                return BadRequest("Username cannot be null.");

            if (weighInDto == null)
                return BadRequest("Weigh-in cannot be null.");

            var weighInDtoValidator = new WeighInDtoValidator();

            var validationResult = weighInDtoValidator.Validate(weighInDto);

            if (!validationResult.IsValid)
            {
                var errorMessages = validationResult.Errors.Select(error => error.ErrorMessage);

                return BadRequest(JsonConvert.SerializeObject(errorMessages));
            }

            var weighIn = WeighInMapper.MapWeighInDtoToWeighIn(weighInDto);

            _userService.UpdateUserWeighIn(username, weighIn);

            return NoContent();
        }

        [HttpGet("{username}/weigh-in")]
        public IActionResult GetUserWeighIn([FromRoute] string username, [FromBody] DateTime date)
        {
            try
            {
                var weighIn = _userService.GetUserWeighIn(username, date);

                return Ok(weighIn);
            }
            catch (ArgumentException argumentException)
            {
                _logger.LogError(argumentException.Message, argumentException);

                return BadRequest(argumentException);
            }
        }

        [HttpDelete("{username}/weigh-in")]
        public IActionResult DeleteUserWeighIn([FromRoute] string username, [FromBody] DateTime date)
        {
            _userService.DeleteUserWeighIn(username, date);

            return NoContent();
        }

        [HttpGet("{username}/weigh-in")]
        public IActionResult GetUserWeighIns([FromRoute] DateTime beginDate, [FromBody] DateTime endDate)
        {
            throw new NotImplementedException(); // TODO
        }
    }
}
