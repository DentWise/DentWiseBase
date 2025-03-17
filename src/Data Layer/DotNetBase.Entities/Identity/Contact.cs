using DotNetBase.Entities.Abstract;
using DotNetBase.Entities.Organization;

namespace DotNetBase.Entities.Identity
{
    public class Contact : BaseEntity, ISoftDeletable
    {
        public int CompanyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }

        public Company Company { get; set; }
    }
}
