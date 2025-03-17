using DotNetBase.Entities.Abstract;

namespace DotNetBase.Entities.Procurement
{
    public class RequestForQuotationStatus : BaseEntity, ISoftDeletable
    {
        public string StatusName { get; set; }
        public string Description { get; set; }
        public bool IsDefault { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
