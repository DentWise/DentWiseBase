namespace DotNetBase.Entities.Dto.RequestModel
{
    public class CreateContact
    {
        public int? CompanyId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Position { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
    }

    public class UpdateContact
    {
        public string? Position { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
