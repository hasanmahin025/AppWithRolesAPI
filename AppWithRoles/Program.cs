using Microsoft.EntityFrameworkCore;
using AppWithRoles.Infrastructure.Data;
using AppWithRoles.Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);


// Add infrastructure (DbContext, repos, services)
builder.Services.AddInfrastructure(builder.Configuration);

// Add controllers, swagger etc.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
