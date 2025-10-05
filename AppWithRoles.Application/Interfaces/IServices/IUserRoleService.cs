using AppWithRoles.Application.Dtos;

namespace AppWithRoles.Application.Interfaces.Services;

public interface IUserRoleService
{
    Task AssignRoleAsync(UserRoleRequestDto dto);
    
    Task<List<string>> GetRolesByUserNameAsync(string userName);
}