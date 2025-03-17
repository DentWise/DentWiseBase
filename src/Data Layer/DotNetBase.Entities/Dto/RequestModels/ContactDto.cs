namespace DotNetBase.Entities.Dto.RequestModels
{
    public class CreateContactDto
    {
        public int CompanyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
    public class UpdateContactDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Position { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
