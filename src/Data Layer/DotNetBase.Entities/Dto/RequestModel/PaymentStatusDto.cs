namespace DotNetBase.Entities.Dto.RequestModel
{
    public class CreatePaymentStatus
    {
        public string StatusName { get; set; } = null!;
        public string? Description { get; set; }
        public bool? IsDefault { get; set; }
    }
    public class UpdatePaymentStatus
    {
        public string StatusName { get; set; } = null!;
        public string? Description { get; set; }
        public bool? IsDefault { get; set; }
    }
}
