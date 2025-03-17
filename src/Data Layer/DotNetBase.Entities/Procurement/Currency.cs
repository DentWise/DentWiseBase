using DotNetBase.Entities.Abstract;

namespace DotNetBase.Entities.Procurement
{
    public class Currency : BaseEntity, ISoftDeletable
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public string Description { get; set; }
        public decimal ExchangeRate { get; set; }
        public int BaseCurrencyId { get; set; }
        public bool IsDefault { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
