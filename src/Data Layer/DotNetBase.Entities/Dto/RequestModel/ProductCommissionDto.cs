namespace DotNetBase.Entities.Dto.RequestModel
{
    public class CreateProductCommission
    {
        public int? ProductId { get; set; }
        public decimal Rate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
    
    public class UpdateProductCommission
    {
        public decimal Rate { get; set; }
        public bool? IsActive { get; set; }
    }
}
