using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBase.Entities.Dto.RequestModel
{
    public class CreateRequestForQuotationItem
    {
        public int? RequestForQuotationId { get; set; }
        public int? ConsolidatedRequisitionItemId { get; set; }
        public int Quantity { get; set; }
        public string? Description { get; set; }
    }
    public class UpdateRequestForQuotationItem
    {
        public int Quantity { get; set; }
        public string? Description { get; set; }
    }
}
