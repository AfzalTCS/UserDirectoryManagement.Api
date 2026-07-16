using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDirectoryManagement.Application.DTOs;

namespace UserDirectoryManagement.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetUserAsync();
        Task<UserDto> GetUserByIdAsync(int id);
        Task<int> CreateUserAsync(CreateUserDto dto);
        Task UpdateUserAsync(int id, UpdateUserDto dto);
        Task DeleteUserAsync(int id);

    }
}
