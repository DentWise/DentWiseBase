namespace DotNetBase.Entities.Dto.RequestModel
{
    public class CreateProduct
    {
        public string ProductName { get; set; } = null!;
        public string? ProductDescription { get; set; }
        public string? ProductCode { get; set; }
        public int? ProductCategoryId { get; set; }
        public int? ProductUnitId { get; set; }
        public int? ProductBrandId { get; set; }
        public decimal? PurchasePrice { get; set; }
        public decimal? SalePrice { get; set; }
        public CreateProductImage ProductImage { get; set; }
    }

    public class UpdateProduct
    {
        public string ProductName { get; set; } = null!;
        public string? ProductDescription { get; set; }
        public string? ProductCode { get; set; }
        public int? ProductUnitId { get; set; }
        public decimal? PurchasePrice { get; set; }
        public decimal? SalePrice { get; set; }
    }

    public class CreateProductImage
    {
        public string ImagePath { get; set; } = null!;
        public string? Description { get; set; }
        public bool? IsDefault { get; set; }
    }
}
