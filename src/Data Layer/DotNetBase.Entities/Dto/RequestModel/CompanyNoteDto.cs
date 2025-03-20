using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBase.Entities.Dto.RequestModel
{
    public class CreateCompanyNote
    {
        public int CompanyId { get; set; }
        public string NoteText { get; set; } = null!;
        public int? CreatedByUserId { get; set; }
    }

    public class UpdateCompanyNote
    {
        public string NoteText { get; set; } = null!;
    }
}
