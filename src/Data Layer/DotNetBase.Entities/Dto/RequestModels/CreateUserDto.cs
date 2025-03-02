namespace DotNetBase.Entities.Dto.RequestModels
{
    public class CreateUserDto
    {
        public required string EMail { get; set; }
        public required string Password { get; set; } // Şifre DTO'da düz metin olarak *gelmeli*.
        public int RoleId { get; set; }
    }
}
