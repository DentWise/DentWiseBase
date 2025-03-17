
using DotNetBase.Entities.Abstract;

namespace DotNetBase.Entities.Organization
{
    public class CompanySegmentMember : BaseEntity, ISoftDeletable
    {
        public int CompanyId { get; set; }
        public int CompanySegmentId { get; set; }
        public DateTime AddedAt { get; set; }
        public int CreatorId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
