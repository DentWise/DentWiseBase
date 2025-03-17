using DotNetBase.Entities.Abstract;

namespace DotNetBase.Entities.Organization
{
    public class CompanySegment : BaseEntity, ISoftDeletable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
