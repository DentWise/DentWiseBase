using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBase.Entities.Dto.RequestModel
{
    public class CreateRequisitionItem
    {
        public int? PurchaseRequisitionId { get; set; }
        public int? ProductId { get; set; }
        public int Quantity { get; set; }
        public string? Description { get; set; }
    }
    public class UpdateRequisitionItem
    {
        public int Quantity { get; set; }
        public string? Description { get; set; }
    }
}
