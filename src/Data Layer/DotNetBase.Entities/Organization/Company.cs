using DotNetBase.Entities.Abstract;
using DotNetBase.Entities.Enum;

namespace DotNetBase.Entities.Organization
{
    public class Company : BaseEntity, ISoftDeletable
    {
        public string Name { get; set; }
        public CompanyTypeEnum Type { get; set; }
        public string TaxOffice { get; set; }
        public string TaxNumber { get; set; }
        public CompanyStatusEnum Status { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
