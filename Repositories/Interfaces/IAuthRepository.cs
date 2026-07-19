using RosterManagementSystem.Models;

namespace RosterManagementSystem.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        Task<User?> GetUserByUsernameAsync(string username);
    }
}