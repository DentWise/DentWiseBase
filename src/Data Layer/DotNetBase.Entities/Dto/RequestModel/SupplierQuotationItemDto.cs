using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBase.Entities.Dto.RequestModel
{
    public class CreateSupplierQuotationItem
    {
        public int? SupplierQuotationId { get; set; }
        public int? RequestForQuotationItemId { get; set; }
        public string? SupplierProductCode { get; set; }
        public int OfferedQuantity { get; set; }
        public decimal? OfferedPrice { get; set; }
        public string? LeadTime { get; set; }
        public string? Notes { get; set; }
        public bool? IsOffered { get; set; }
    }

    public class UpdateSupplierQuotationItem
    {
        public string? SupplierProductCode { get; set; }
        public int OfferedQuantity { get; set; }
        public decimal? OfferedPrice { get; set; }
        public string? LeadTime { get; set; }
        public string? Notes { get; set; }
        public bool? IsOffered { get; set; }
    }
}
