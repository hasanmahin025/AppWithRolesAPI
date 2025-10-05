using AppWithRoles.Application.Interfaces.Repositories;
using AppWithRoles.Domain.Entities;
using AppWithRoles.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
namespace AppWithRoles.Infrastructure.Repositories;

public class UserRoleRepository : IUserRoleRepository
{
    private readonly AppDbContext _dbContext;

    public UserRoleRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(UserRole userRole)
    {
        await _dbContext.UserRoles.AddAsync(userRole);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<UserRole>> GetByUserNameAsync(string userName)
    {
        return await _dbContext.UserRoles
            .Where(r => r.UserName == userName)
            .ToListAsync();
    }
    
    
}