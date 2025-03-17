using DotNetBase.Entities.Identity;

namespace DotNetBase.Entities.Dto.RequestModels
{
    public class CreateUserDto
    {
        public required string EMail { get; set; }
        public required string Password { get; set; } // Şifre DTO'da düz metin olarak *gelmeli*.
        public int RoleId { get; set; }
        public int CompanyId { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
