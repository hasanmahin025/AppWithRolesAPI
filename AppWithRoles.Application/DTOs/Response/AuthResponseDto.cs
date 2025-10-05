namespace AppWithRoles.Application.Dtos;

public class AuthResponseDto
{
    public string UserName { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
}