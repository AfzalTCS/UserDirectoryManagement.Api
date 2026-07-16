using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDirectoryManagement.Repository;
using Microsoft.EntityFrameworkCore;
using UserDirectoryManagement.Domain.Models;

namespace UserDirectoryManagement.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public UserRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }
        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user == null) throw new KeyNotFoundException($"User with id {id} not found.");
            return user;
        }
        public async Task<int> AddUserAsync(User user)
        {
            _dbContext.Users.Add(user);
            return await _dbContext.SaveChangesAsync(); // returns number of rows written
        }
        public async Task UpdateUserAsync(User user)
        {
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteUserAsync(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user != null)
            {
                _dbContext.Users.Remove(user);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
