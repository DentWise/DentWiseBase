using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBase.Entities.Dto.RequestModel
{
    public class CreateSupplierProduct
    {
        public int? ProductId { get; set; }
        public int? SupplierCompanyId { get; set; }
        public string? SupplierProductCode { get; set; }
        public decimal? SupplierPrice { get; set; }
        public int? CurrencyId { get; set; }
        public string? LeadTime { get; set; }
        public int? Moq { get; set; }
        public string? DiscountRates { get; set; }
        public string? Notes { get; set; }
    }

    public class UpdateSupplierProduct
    {
        public string? SupplierProductCode { get; set; }
        public decimal? SupplierPrice { get; set; }
        public string? LeadTime { get; set; }
        public int? Moq { get; set; }
        public string? DiscountRates { get; set; }
        public string? Notes { get; set; }
    }
}
