using DotNetBase.Entities.Abstract;
using DotNetBase.Entities.Enum;

namespace DotNetBase.Entities.Organization
{
    public class CompanyInteraction : BaseEntity, ISoftDeletable
    {
        public int CompanyId { get; set; }
        public int ContactId { get; set; }
        public int CreatorId { get; set; }
        public InteractionTypeEnum InteractionType { get; set; }
        public DateTime InteractionDate { get; set; }
        public string Subject { get; set; }
        public string Note { get; set; }
        public ContactSentimentEnum ContactSentiment { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
