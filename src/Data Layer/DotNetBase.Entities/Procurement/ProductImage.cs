using DotNetBase.Entities.Abstract;

namespace DotNetBase.Entities.Procurement
{
    public class ProductImage : BaseEntity, ISoftDeletable
    {
        public int ProductId { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public bool IsDefault { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }

        public Product Product { get; set; }
    }
}
