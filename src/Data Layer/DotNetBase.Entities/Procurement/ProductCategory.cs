using DotNetBase.Entities.Abstract;

namespace DotNetBase.Entities.Procurement
{
    public class ProductCategory : BaseEntity, ISoftDeletable
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public int ParentCategoryId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
