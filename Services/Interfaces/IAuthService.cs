using RosterManagementSystem.DTOs.Auth;

namespace RosterManagementSystem.Services.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponseDto?> LoginAsync(LoginDto loginDto);
    }
}