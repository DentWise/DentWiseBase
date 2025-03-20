namespace DotNetBase.Entities.Dto.RequestModel
{
    public class CreateCurrency
    {
        public string CurrencyCode { get; set; } = null!;
        public string CurrencyName { get; set; } = null!;
        public string? CurrencySymbol { get; set; }
        public bool? IsDefault { get; set; }
    }

    public class UpdateCurrency
    {
        public bool IsDefault { get; set; }
    }
}
