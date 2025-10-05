using AppWithRoles.Domain.Entities;

namespace AppWithRoles.Application.Interfaces.Repositories;

public interface ILoginRepository
{
    Task<Login?> GetByUserNameAsync(string userName);
}