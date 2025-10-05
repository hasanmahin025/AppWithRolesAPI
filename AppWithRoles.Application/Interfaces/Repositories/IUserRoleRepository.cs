using AppWithRoles.Domain.Entities;

namespace AppWithRoles.Application.Interfaces.Repositories;

public interface IUserRoleRepository
{
    Task AddAsync(UserRole userRole);
    Task<List<UserRole>> GetByUserNameAsync(string userName);
}