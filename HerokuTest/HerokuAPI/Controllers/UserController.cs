using System.Text.Json;
using HerokuAPI.Models;
using HerokuAPI.Respositories;
using Microsoft.AspNetCore.Mvc;

namespace HerokuAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly UserRepository _userRepository;
    public UserController(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    [HttpGet]
    [Route("GetUser")]
    public JsonResult GetUser(JsonElement id)
    {
        return new JsonResult(_userRepository.GetUserByIdAsync(id.Deserialize<int>()));
    }
    
    [HttpPost]
    [Route("SetUser")]
    public async Task<JsonResult> SetUser(JsonElement userJson)
    {
        var user = JsonSerializer.Deserialize<User>(userJson.GetString() ?? string.Empty);
        await _userRepository.CreateUser(user);
        return new JsonResult(true);
    }
}