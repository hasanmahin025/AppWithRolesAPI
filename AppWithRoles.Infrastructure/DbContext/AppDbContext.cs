using AppWithRoles.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppWithRoles.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) :  base(options){}
    
    public DbSet<Login> Logins { get; set; }
    public DbSet<Register> Registers { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
}