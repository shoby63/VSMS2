using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api.Data;
using api.models;

namespace api.Services
{
    public class UserService
    {
        private readonly PrimeAutomobilesDbContext _context;

        public UserService(PrimeAutomobilesDbContext context)
        {
            _context = context;
        }

        public async Task<User> ValidateUserCredentials(string username, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username && u.PasswordHash == password);
        }
    }
}
