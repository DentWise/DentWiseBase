using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBase.Entities.Dto.RequestModel
{
    public class CreateRequisitionStatus
    {
        public string StatusName { get; set; } = null!;
        public string? Description { get; set; }
        public bool? IsDefault { get; set; }
    }
    public class UpdateRequisitionStatus
    {
        public string StatusName { get; set; } = null!;
        public string? Description { get; set; }
        public bool? IsDefault { get; set; }
    }
}
