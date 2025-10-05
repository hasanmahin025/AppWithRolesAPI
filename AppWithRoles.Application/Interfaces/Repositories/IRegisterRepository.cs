using AppWithRoles.Domain.Entities;

namespace AppWithRoles.Application.Interfaces.Repositories;

public interface IRegisterRepository
{
    Task AddAsync(Register register);
    Task<Register?> GetByUserNameAsync(string userName);
}