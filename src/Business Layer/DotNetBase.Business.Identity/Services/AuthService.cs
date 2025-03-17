//using DotNetBase.Business.Identity.Interfaces;
//using DotNetBase.EFCore.UnitOfWork;
//using DotNetBase.Entities.Dto.RequestModels;
//using DotNetBase.Entities.Identity;
//using DotNetBase.Entities.Identity.Authentication;
//using DotNetBase.Infrastructure.Common.Helpers;
//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Security.Cryptography;
//using System.Text;

//namespace DotNetBase.Business.Identity.Services
//{
//    public class AuthService : IAuthService
//    {
//        private readonly IUnitOfWork _unitOfWork;
//        private readonly AuthenticationOptions _authOptions;

//        public AuthService(IUnitOfWork unitOfWork, AuthenticationOptions authOptions)
//        {
//            _unitOfWork = unitOfWork;
//            _authOptions = authOptions;
//        }

//        public async Task<User> Login(LoginDto request)
//        {
//            var user = await _unitOfWork.UserRepository.FindOneAsync(x => x.EMail == request.EMail);
//            if (user == null)
//                throw new UnauthorizedAccessException("Email is not correct.");

//            string hashedPassword = HashHelper.HashPassword(request.Password);
//            if (user.HashedPassword != hashedPassword)
//                throw new UnauthorizedAccessException("Password is not correct.");

//            var accessToken = GenerateToken(user);

//            return user;
//        }

//        public async Task<Token> GenerateToken(User user)
//        {
//            var now = DateTime.UtcNow;
//            var accessTokenExpiration = now.AddMinutes(_authOptions.AccessTokenExpiration);
//            var refreshTokenExpiration = now.AddMinutes(_authOptions.RefreshTokenExpiration);

//            var key = Encoding.ASCII.GetBytes(_authOptions.Secret);

//            var claims = await GetClaims(user);

//            var tokenDescriptor = new SecurityTokenDescriptor
//            {
//                Issuer = _authOptions.Issuer,
//                Expires = accessTokenExpiration,
//                NotBefore = now,
//                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
//                Subject = new ClaimsIdentity(claims),
//            };

//            var handler = new JwtSecurityTokenHandler();
//            var token = handler.CreateToken(tokenDescriptor);
//            var tokenString = handler.WriteToken(token);

//            var userToken = new Token()
//            {
//                AccessToken = tokenString,
//                AccessTokenExpiration = accessTokenExpiration,
//            };

//            var userRefreshToken = await _unitOfWork.UserRefreshTokenRepository.FindOneAsync(s => s.UserId.Equals(user.Id));
//            if (userRefreshToken != null)
//            {
//                userRefreshToken.Token = CreateRefreshToken();
//                userRefreshToken.Expiration = refreshTokenExpiration;
//                _unitOfWork.UserRefreshTokenRepository.Update(userRefreshToken);
//            }
//            else
//            {
//                userRefreshToken = new UserRefreshToken
//                {
//                    UserId = user.Id,
//                    Token = CreateRefreshToken(),
//                    Expiration = refreshTokenExpiration
//                };
//                await _unitOfWork.UserRefreshTokenRepository.AddAsync(userRefreshToken);
//            }
//            userToken.RefreshToken = userRefreshToken.Token;
//            userToken.RefreshTokenExpiration = userRefreshToken.Expiration;

//            return userToken;
//        }

//        public async Task<Token> RefreshToken(string refreshToken)
//        {
//            var savedRefreshToken = await _unitOfWork.UserRefreshTokenRepository.FindOneAsync(x => x.Token == refreshToken);
//            if (savedRefreshToken == null || savedRefreshToken.isUsed || savedRefreshToken.Expiration < DateTime.UtcNow)
//            {
//                throw new Exception("Invalid or expired refresh token");
//            }

//            var user = await _unitOfWork.UserRepository.GetByIdAsync(savedRefreshToken.UserId);
//            var newToken = await GenerateToken(user);

//            savedRefreshToken.isUsed = true;
//            _unitOfWork.UserRefreshTokenRepository.Update(savedRefreshToken);

//            var newRefreshToken = new UserRefreshToken
//            {
//                Token = Guid.NewGuid().ToString(),
//                Expiration = DateTime.UtcNow.AddDays(4),
//                UserId = user.Id
//            };

//            await _unitOfWork.UserRefreshTokenRepository.AddAsync(newRefreshToken);

//            return newToken;
//        }

//        private static string CreateRefreshToken()
//        {
//            var bytes = new byte[32];
//            using var rnd = RandomNumberGenerator.Create();
//            rnd.GetBytes(bytes);
//            return Convert.ToBase64String(bytes);
//        }

//        private async Task<IEnumerable<Claim>> GetClaims(User user)
//        {
//            var role = await _unitOfWork.RoleRepository.GetByIdAsync(user.RoleId);
//            var claims = new List<Claim>
//            {
//                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
//                new(ClaimTypes.Email, user.EMail!),
//                new(ClaimTypes.MobilePhone, user.PhoneNumber!),
//                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
//                new(ClaimTypes.Role, role.Name!)
//            };

//            claims.AddRange(_authOptions.Audiences.Select(s => new Claim(JwtRegisteredClaimNames.Aud, s)));
//            return claims;
//        }

//    }
//}
