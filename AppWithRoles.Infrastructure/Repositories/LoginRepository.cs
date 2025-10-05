using AppWithRoles.Application.Interfaces.Repositories;
using AppWithRoles.Domain.Entities;
using AppWithRoles.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
namespace AppWithRoles.Infrastructure.Repositories;

public class LoginRepository : ILoginRepository
{
    private readonly AppDbContext _context;

    public LoginRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Login?> GetByUserNameAsync(string userName)
    {
        return await _context.Logins.FirstOrDefaultAsync(u => u.UserName == userName);
    }


    
}