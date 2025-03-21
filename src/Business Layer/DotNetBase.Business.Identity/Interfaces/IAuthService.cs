using DotNetBase.Entities.Dto.RequestModel;
using DotNetBase.Entities.Dto.ResponseModel;
using DotNetBase.Entities.Entities.Identity;

namespace DotNetBase.Business.Identity.Interfaces
{
    public interface IAuthService
    {
        Task<TokenResponseModel> Login(LoginRequestModel request);
        Task<bool> Logout(string token);
        Task<bool> ForgotPassword(ForgotPasswordRequestModel email);
        Task<TokenResponseModel> GenerateToken(User user);
        Task<TokenResponseModel> RefreshToken(string refreshToken);
    }
}
