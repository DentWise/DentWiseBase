using DotNetBase.Entities.Abstract;

namespace DotNetBase.Entities.Communication
{
    public class EmailThread : BaseEntity, ISoftDeletable
    {
        public int CompanyId { get; set; }
        public int ContactId { get; set; }
        public int CreatorId { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime SendDate { get; set; }
        public DateTime ReceivedDate { get; set; }
        public string Direction { get; set; }
        public string Status { get; set; }
        public string MessageId { get; set; }
        public string ReferenceMessageId { get; set; }
        public string InReplyToMessageId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
