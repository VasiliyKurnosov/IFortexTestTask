using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Enums;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext applicationDbContext;

        public UserService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<User> GetUser()
        {
            return await applicationDbContext.Users.OrderByDescending(user => user.Orders.Count).FirstOrDefaultAsync();
        }

        public async Task<List<User>> GetUsers()
        {
            return await applicationDbContext.Users.Where(user => user.Status == UserStatus.Inactive).ToListAsync();
        }
    }
}
