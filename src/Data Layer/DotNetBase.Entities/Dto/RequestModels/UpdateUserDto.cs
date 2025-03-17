namespace DotNetBase.Entities.Dto.RequestModels
{
    public class UpdateUserDto
    {
        public string? EMail { get; set; }  // Optional, null ise değiştirilmez.
        public string? Password { get; set; } // Optional, null ise değiştirilmez. Yeni şifre.
        public bool? IsMailConfirmed { get; set; } // Optional
        public int? RoleId { get; set; }  // Optional
        public string? PhoneNumber { get; set; }
    }
}
