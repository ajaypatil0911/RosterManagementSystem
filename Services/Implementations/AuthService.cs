using RosterManagementSystem.DTOs.Auth;
using RosterManagementSystem.Repositories.Interfaces;
using RosterManagementSystem.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;


namespace RosterManagementSystem.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IConfiguration _configuration;

        public AuthService(IAuthRepository authRepository,IConfiguration configuration)
        {
            _authRepository = authRepository;
            _configuration = configuration;
        }

        public async Task<LoginResponseDto?> LoginAsync(LoginDto loginDto)
        {
            // Find user by username
            var user = await _authRepository.GetUserByUsernameAsync(loginDto.Username);

            // If user doesn't exist
            if (user == null)
            {
                return null;
            }

            if (!user.IsActive)
            {
                return null;
            }

            // Verify password
            if (user.PasswordHash != loginDto.Password)
            {
                return null;
            }

            var claims = new List<Claim>
           {
             new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
             new Claim(ClaimTypes.Name, user.Username),
             new Claim(ClaimTypes.Role, user.Role)
             };

            var key = new SymmetricSecurityKey(
             Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!)
             );
            var credentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256
            );

            var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(
            Convert.ToDouble(_configuration["Jwt:ExpiryInMinutes"])
             ),
             signingCredentials: credentials
             );


            var tokenHandler = new JwtSecurityTokenHandler();

            string jwtToken = tokenHandler.WriteToken(token);

            return new LoginResponseDto
            {
                Token = jwtToken,
                Username = user.Username,
                Role = user.Role
            };

        }
    }
}
