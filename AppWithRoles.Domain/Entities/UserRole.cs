using System.ComponentModel.DataAnnotations.Schema;

namespace AppWithRoles.Domain.Entities;

[Table("UserRole" , Schema = "dbo")]
public class UserRole
{
    public Guid Id { get; set; }
    public string UserName { get; set; } = null!;
    public string Role { get; set; } = string.Empty;
}