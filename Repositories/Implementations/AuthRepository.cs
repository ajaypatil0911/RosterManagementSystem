using Microsoft.EntityFrameworkCore;
using RosterManagementSystem.Data;
using RosterManagementSystem.Models;
using RosterManagementSystem.Repositories.Interfaces;

namespace RosterManagementSystem.Repositories.Implementations
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AppDbContext _context;

        public AuthRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}