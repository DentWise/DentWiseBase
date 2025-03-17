using DotNetBase.Entities.Abstract;

namespace DotNetBase.Entities.Communication
{
    public class SmsMessage : BaseEntity, ISoftDeletable
    {
        public int CompanyId { get; set; }
        public int ContactId { get; set; }
        public int CreatorId { get; set; }
        public string PhoneNumber { get; set; }
        public string MessageText { get; set; }
        public DateTime SendDate { get; set; }
        public DateTime ReceivedDate { get; set; }
        public string Direction { get; set; }
        public string Status { get; set; }
        public string ProviderMessageId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
