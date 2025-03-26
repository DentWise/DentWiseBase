namespace DotNetBase.Entities.Dto.RequestModel
{
    public class CreateProductUnit
    {
        public string UnitName { get; set; } = null!;
        public string? Description { get; set; }
        public bool? IsDefault { get; set; }
    }
    public class UpdateProductUnit
    {
        public string UnitName { get; set; } = null!;
        public string? Description { get; set; }
    }
}
