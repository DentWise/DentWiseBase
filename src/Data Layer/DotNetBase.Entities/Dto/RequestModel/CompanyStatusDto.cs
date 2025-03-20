using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBase.Entities.Dto.RequestModel
{
    public class CreateCompanyStatus
    {
        public string? Name { get; set; }
        public int? StatusLeg { get; set; }
    }
    public class UpdateCompanyStatus
    {
        public string? Name { get; set; }
    }
}
