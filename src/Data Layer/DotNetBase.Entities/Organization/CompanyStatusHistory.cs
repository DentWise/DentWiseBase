using DotNetBase.Entities.Abstract;
using DotNetBase.Entities.Enum;

namespace DotNetBase.Entities.Organization
{
    public class CompanyStatusHistory : BaseEntity, ISoftDeletable
    {
        public int CompanyId { get; set; }
        public CompanyStatusEnum Status { get; set; }
        public DateTime StatusDate { get; set; }
        public string Note { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
