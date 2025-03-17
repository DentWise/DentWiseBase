//using DotNetBase.Business.Identity.Interfaces;
//using DotNetBase.Business.Identity.Services;
//using DotNetBase.EFCore.UnitOfWork;
//using DotNetBase.Entities.Dto.RequestModels;
//using DotNetBase.Entities.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Org.BouncyCastle.Asn1.Ocsp;

//namespace DotNetBase.Api.Controllers
//{
//    public class IdentityController(UserService userService, AuthService authService) : Controller
//    {
//        [HttpPost("SignUp")]
//        public async Task<IActionResult> SignUp(CreateUserDto user)
//        {
//            try
//            {
//                var result = await userService.CreateUserAsync(user);
//                return Ok(result);
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }

//        [HttpPost("Login")]
//        public async Task<IActionResult> Login(LoginDto request)
//        {
//            try
//            {
//                var result = await authService.Login(request);
//                return Ok(result);
//            }
//            catch (Exception)
//            {
//                throw new Exception("Password or Email incorrect.");
//            }
//        }

//        [HttpPost("email-veritification-send")]
//        public async Task<IActionResult> SendVerificationCodeEmailAsync(string email)
//        {
//            try
//            {
//                await userService.SendVerificationCodeEmailAsync(email);
//                return Ok();
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }

//        [HttpPost("email-veritification-confirm")]
//        public async Task<IActionResult> VerifyCodeAsync(int userId, string code)
//        {
//            try
//            {
//                await userService.VerifyCodeAsync(userId, code);
//                return Ok();
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }

//        [HttpPost("refresh-token")]
//        public async Task<IActionResult> RefreshToken(string refreshToken)
//        {
//            try
//            {
//                var result = await authService.RefreshToken(refreshToken);
//                return Ok(result);
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }
//    }
//}
