using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBase.Entities.Dto.RequestModel
{
    public class CreateCompanySegmentMember
    {
        public int CompanyId { get; set; }
        public int CompanySegmentId { get; set; }
        public DateTime? AddedAt { get; set; }
        public int? UserId { get; set; }
    }

    public class UpdateCompanySegmentMember
    {
        public int CompanyId { get; set; }
        public int CompanySegmentId { get; set; }
    }
}
