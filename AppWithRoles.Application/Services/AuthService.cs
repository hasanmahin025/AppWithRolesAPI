using AppWithRoles.Application.Dtos;
using AppWithRoles.Application.Interfaces.Repositories;
using AppWithRoles.Application.Interfaces.Services;
using AppWithRoles.Domain.Entities;

namespace AppWithRoles.Application.Services;

public class AuthService : IAuthService
{
   private readonly IRegisterRepository  _registerRepository;
   private readonly ILoginRepository _loginRepository;
   public AuthService(IRegisterRepository registerRepository)
   {
      _registerRepository = registerRepository;
      
   }

   #region IAuthService Members  

   
   public async Task<AuthResponseDto> RegisterAsync(RegisterRequestDto registerRequestDto)
   {
      var existing = await _registerRepository.GetByUserNameAsync(registerRequestDto.UserName);
      if (existing != null)
      {
         throw new Exception("User already exists");
      }
     //register New User
      var register = new Register
      {
         Id = new Guid(),
         UserName = registerRequestDto.UserName,
         Email = registerRequestDto.Email,
         PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerRequestDto.Password)

      };
      await _registerRepository.AddAsync(register);
      //Future Jwt Token from here
      return new AuthResponseDto { UserName = registerRequestDto.UserName, Token = string.Empty };
   }
   #endregion  IAuthService Members
   
   
   public async Task<AuthResponseDto> LoginAsync(LoginRequestDto loginRequestDto)
   {
      // Use register repository (we stored users there)
      var user =  await _registerRepository.GetByUserNameAsync(loginRequestDto.UserName);
      if (user == null)
      {
         throw new Exception("Invalid login request");
      }
      var isValid = BCrypt.Net.BCrypt.Verify(loginRequestDto.Password, user.PasswordHash);
      if (!isValid)
      {
         throw new Exception("Invalid login request");
      }
      //On sucess return for user
      return new AuthResponseDto { UserName = user.UserName, Token = string.Empty };
   }
   

   
}