using DotNetBase.Entities.Dto.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBase.Business.Identity.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto> GetUserByIdAsync(int id);
        Task<UserDto> CreateUserAsync(CreateUserDto createUserDto);
        Task UpdateUserAsync(int id, UpdateUserDto updateUserDto);
        Task DeleteUserAsync(int id);
        Task<UserDto> GetUserByEmailAsync(string email); // E-posta ile kullanıcı bulma
        Task<bool> CheckPasswordAsync(int userId, string password); // Şifre kontrolü
    }
}
