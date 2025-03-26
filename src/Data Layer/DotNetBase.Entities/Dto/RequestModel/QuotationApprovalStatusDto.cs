namespace DotNetBase.Entities.Dto.RequestModel
{
    public class CreateQuotationApprovalStatus
    {
        public string StatusName { get; set; } = null!;
        public string? Description { get; set; }
        public bool? IsDefault { get; set; }
    }

    public class UpdateQuotationApprovalStatus
    {
        public string StatusName { get; set; } = null!;
        public string? Description { get; set; }
        public bool? IsDefault { get; set; }
    }
}
