using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWithRoles.Domain.Entities;
[Table("Register" , Schema = "dbo")]
public class Register
{
     [Key]
     public Guid Id { get; set; }
     public string UserName { get; set; } = string.Empty;
     public string Email { get; set; } =  string.Empty;
     public string PasswordHash { get; set; } = String.Empty;

}