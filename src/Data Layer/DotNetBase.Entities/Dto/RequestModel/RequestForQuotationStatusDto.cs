namespace DotNetBase.Entities.Dto.RequestModel
{
    public class CreateRequestForQuotationStatus
    {
        public string StatusName { get; set; } = null!;
        public string? Description { get; set; }
        public bool? IsDefault { get; set; }
    }

    public class UpdateRequestForQuotationStatus
    {
        public string StatusName { get; set; } = null!;
        public string? Description { get; set; }
        public bool? IsDefault { get; set; }
    }
}
