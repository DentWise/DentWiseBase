namespace DotNetBase.Entities.Dto.RequestModel
{
    public class CreateUser
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public int? RoleId { get; set; }
        public int? CompanyId { get; set; }
        public int? ContactId { get; set; }
    }

    public class UpdateUser
    {
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public int? RoleId { get; set; }
    }
}
