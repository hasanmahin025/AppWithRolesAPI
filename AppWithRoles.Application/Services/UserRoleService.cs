using AppWithRoles.Application.Dtos;
using AppWithRoles.Application.Interfaces.Repositories;
using AppWithRoles.Application.Interfaces.Services;
using AppWithRoles.Domain.Entities;

namespace AppWithRoles.Application.Services;

public class UserRoleService : IUserRoleService
{
    private readonly IUserRoleRepository _userRoleRepository;

    public UserRoleService(IUserRoleRepository userRoleRepository)
    {
        _userRoleRepository = userRoleRepository;
    }

    // Fixed: add async
    public async Task AssignRoleAsync(UserRoleRequestDto dto)
    {
        var role = new UserRole
        {
            Id = Guid.NewGuid(),
            UserName = dto.UserName,
            Role = dto.Role
        };

        await _userRoleRepository.AddAsync(role);
    }

    // Move this outside AssignRoleAsync
    public async Task<List<string>> GetRolesByUserNameAsync(string userName)
    {
        var roles = await _userRoleRepository.GetByUserNameAsync(userName);
        return roles.Select(r => r.Role).ToList();
    }
}