using AppWithRoles.Application.Interfaces.Repositories;
using AppWithRoles.Domain.Entities;
using AppWithRoles.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AppWithRoles.Infrastructure.Repositories
{
    public class RegisterRepository : IRegisterRepository
    {
        private readonly AppDbContext _context;

        public RegisterRepository(AppDbContext context)
        {
            _context = context;
        }

        // Add new Register
        public async Task AddAsync(Register register)
        {
            await _context.Registers.AddAsync(register);
            await _context.SaveChangesAsync();
        }

        // Get Register by Username
        public async Task<Register?> GetByUserNameAsync(string userName)
        {
            return await _context.Registers
                .FirstOrDefaultAsync(u => u.UserName == userName);
        }
    }
}