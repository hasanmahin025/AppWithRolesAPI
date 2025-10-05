namespace AppWithRoles.Application.Dtos;

public class UserRoleRequestDto
{
    public string UserName { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
}