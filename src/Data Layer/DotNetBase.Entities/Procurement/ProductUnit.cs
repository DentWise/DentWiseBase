using DotNetBase.Entities.Abstract;

namespace DotNetBase.Entities.Procurement
{
    public class ProductUnit : BaseEntity, ISoftDeletable
    {
        public string UnitName { get; set; }
        public string Description { get; set; }
        public bool IsDefault { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
