using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDirectoryManagement.Application.DTOs;
using UserDirectoryManagement.Application.Interfaces;
using UserDirectoryManagement.Repository;
using System.Linq.Expressions;


namespace UserDirectoryManagement.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRespoitory;
        public UserService(IUserRepository userRespoitory)
        {
            this.userRespoitory = userRespoitory;
        }
        public async Task<IEnumerable<UserDto>> GetUserAsync()
        {
            var users = await userRespoitory.GetUsersAsync();

            return users.Select(u => new UserDto
            {
                Id = u.Id,
                Name = u.Name,
                Age = u.Age,
                City = u.City,
                State = u.State,
                Pincode = u.Pincode
            });
        }

        public async Task<int> CreateUserAsync(CreateUserDto dto)
        {
            var user = new Domain.Models.User
            {
                Name = dto.Name,
                Age = dto.Age,
                City = dto.City,
                State = dto.State,
                Pincode = dto.Pincode
            };
            // Save via repository
            int createdUserId = await userRespoitory.AddUserAsync(user);

            // Return the new user's ID
            return createdUserId;
        }
        public async Task DeleteUserAsync(int id)
        {
            // Delete via repository
            await userRespoitory.DeleteUserAsync(id);
        }
        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await userRespoitory.GetUserByIdAsync(id);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with id {id} not found.");
            }

            // Map domain model to DTO
            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Age = user.Age,
                City = user.City,
                State = user.State,
                Pincode = user.Pincode
            };
        }

        public async Task UpdateUserAsync(int id, UpdateUserDto dto)
        {
            var user = await userRespoitory.GetUserByIdAsync(id);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with id {id} not found.");
            }
            // Update fields
            user.Name = dto.Name;
            user.Age = dto.Age;
            user.City = dto.City;
            user.State = dto.State;
            user.Pincode = dto.Pincode;
            // Save changes
            await userRespoitory.UpdateUserAsync(user);
        }
    }
}
