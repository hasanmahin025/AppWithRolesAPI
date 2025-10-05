using AppWithRoles.Application.Dtos;
using AppWithRoles.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

[Route("api/userroles")]
[ApiController]
public class UserRoleController : ControllerBase
{
    private readonly IUserRoleService _userRoleService;
    public UserRoleController(IUserRoleService userRoleService) => _userRoleService = userRoleService;

    [HttpPost("assign")]
    public async Task<IActionResult> AssignRole(UserRoleRequestDto dto)
    {
        await _userRoleService.AssignRoleAsync(dto);
        return Ok("Role assigned successfully");
    }

    [HttpGet("{username}")]
    public async Task<IActionResult> GetRoles(string username)
    {
        var roles = await _userRoleService.GetRolesByUserNameAsync(username);
        return Ok(roles);
    }
}