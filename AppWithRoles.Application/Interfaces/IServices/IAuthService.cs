using AppWithRoles.Application.Dtos;

namespace AppWithRoles.Application.Interfaces.Services;

public interface IAuthService
{
    Task <AuthResponseDto> RegisterAsync(RegisterRequestDto registerRequestDto);
    Task<AuthResponseDto> LoginAsync(LoginRequestDto loginRequestDto);
}