using Microsoft.AspNetCore.Mvc;
using Shoap.Api.Entities;
using Shoap.Api.Repositories.Contracts;
using Shoap.Models.Dtos;

namespace Shoap.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpPost]
    public async Task<ActionResult> InsertUser(UserDto userDto)
    {
        try
        {
            var existingUser = await _userRepository.GetUser(userDto.Login);
            if(existingUser != null)
            {
                return StatusCode(StatusCodes.Status409Conflict, "User with such login already exists");
            }
            User user = new()
            {
                Id = await _userRepository.GetNextId(),
                Login = userDto.Login,
                Password = userDto.Password,
                Money = 0,
            };
            await _userRepository.InsertUser(user);
            return Ok();
        }
        catch
        {
			return StatusCode(StatusCodes.Status500InternalServerError, "Error saving data to the server");
        }
    }

    [HttpGet]
    [Route("{login}")]
    public async Task<ActionResult<UserDto>> GetUser(string login)
    {
        try
        {
            var user = await _userRepository.GetUser(login);
            if(user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the server");
        }
    }

    [HttpPut]
    public async Task<ActionResult> UpdateMoney(UserDto user)
    {
        try
        {
            await _userRepository.UpdateMoney(user.Id, user.Money);
            return Ok();
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
        }
    }
}
