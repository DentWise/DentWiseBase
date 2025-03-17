using DotNetBase.Entities.Abstract;

namespace DotNetBase.Entities.Organization
{
    public class CompanyAddress : BaseEntity, ISoftDeletable
    {
        public int CompanyId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public bool IsDefault { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }

        public Company Company { get; set; }
    }
}
