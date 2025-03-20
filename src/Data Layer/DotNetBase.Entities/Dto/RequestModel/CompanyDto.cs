using DotNetBase.EFCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBase.Entities.Dto.RequestModel
{
    public class CreateCompany
    {
        public string CompanyName { get; set; } = null!;
        public int? CompanyTypeId { get; set; }
        public string? TaxOffice { get; set; }
        public string? TaxNumber { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
        public string? LogoUrl { get; set; }
        public int? CompanyStatus { get; set; }
        public int? CompanyId { get; set; }
        public string? AddressLine { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public string? StatusNote { get; set; }
    }

    public class UpdateCompany
    {
        public string CompanyName { get; set; } = null!;
        public string? TaxOffice { get; set; }
        public string? TaxNumber { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
        public string? LogoUrl { get; set; }
        public int? CompanyStatus { get; set; }
        public string? CompanyStatusNote { get; set; }
    }
}
