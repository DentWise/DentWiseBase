using DotNetBase.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBase.Entities.Dto.RequestModels
{
    public class CompanyCreateDto
    {
        public string Name { get; set; }
        public CompanyTypeEnum Type { get; set; }
        public string TaxOffice { get; set; }
        public string TaxNumber { get; set; }
        public CompanyStatusEnum Status { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }

    public class CompanyUpdateDto
    {
        public string? Name { get; set; }
        public CompanyTypeEnum? Type { get; set; }
        public string? TaxOffice { get; set; }
        public string? TaxNumber { get; set; }
        public CompanyStatusEnum? Status { get; set; }
    }
}
