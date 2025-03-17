namespace DotNetBase.Entities.Dto.RequestModels
{
    public class CompanyAddressCreateDto
    {
        public int CompanyId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
    public class CompanyAddressUpdateDto
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}
