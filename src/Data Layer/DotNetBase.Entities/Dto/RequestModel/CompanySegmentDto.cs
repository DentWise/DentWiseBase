using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBase.Entities.Dto.RequestModel
{
    public class CreateCompanySegment
    {
        public string SegmentName { get; set; } = null!;
        public string? Description { get; set; }
    }

    public class UpdateCompanySegment
    {
        public string SegmentName { get; set; } = null!;
        public string? Description { get; set; }
    }
}
