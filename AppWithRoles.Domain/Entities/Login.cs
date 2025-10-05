using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWithRoles.Domain.Entities;
[Table("Login" , Schema = "dbo")]
public class Login
{
    [Key]
    public Guid Id { get; set; }
    
    public string UserName { get; set; } = null!;
    
    public string PasswordHash { get; set; } = null!;
    
    
}