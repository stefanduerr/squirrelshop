using Squirrels.Data;
using squirrels.Models;
using Microsoft.EntityFrameworkCore;

namespace squirrels.Services
{
    public class UserService
    {
        private readonly AppDbContext _appDbContext;

        public UserService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _appDbContext.Users.ToListAsync();
        }

        public async Task<User> AddUser(User newUser)
        {
            _appDbContext.Users.Add(newUser);
            await _appDbContext.SaveChangesAsync();
            return newUser;
        }
    }
}
