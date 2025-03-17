using DotNetBase.Entities.Dto.RequestModels;

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
        Task SendVerificationCodeEmailAsync(string email);
        Task<bool> VerifyCodeAsync(int userId, string code);
    }
}
