using AppWithRoles.Application.Interfaces.Repositories;
using AppWithRoles.Application.Interfaces.Services;
using AppWithRoles.Application.Services;
using AppWithRoles.Infrastructure.Data;
using AppWithRoles.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppWithRoles.Infrastructure.DependencyInjection;

public  static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services , IConfiguration configuration)
    {
       
        // Register DbContext (Postgres)
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        
        
        // Repositories
        services.AddScoped<IRegisterRepository, RegisterRepository>();
        services.AddScoped<ILoginRepository, LoginRepository>(); 
        services.AddScoped<IUserRoleRepository, UserRoleRepository>();
        
        // Application services implementations that are in Application layer
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserRoleService, UserRoleService>();

        return services;
    }
}