namespace DotNetBase.Entities.Dto.RequestModel
{
    public class CreateProductCategory
    {
        public string CategoryName { get; set; } = null!;
        public string? Description { get; set; }
        public int? ParentCategoryId { get; set; }
    }
    
    public class UpdateProductCategory
    {
        public string CategoryName { get; set; } = null!;
        public string? Description { get; set; }
    }
}
