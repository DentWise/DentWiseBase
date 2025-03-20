using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBase.Entities.Dto.RequestModel
{
    public class CreateCompanyType
    {
        public string? TypeName { get; set; }
    }

    public class UpdateCompanyType
    {
        public string? TypeName { get; set; }
    }
}
