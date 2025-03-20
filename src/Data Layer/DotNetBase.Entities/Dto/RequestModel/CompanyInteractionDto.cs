using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBase.Entities.Dto.RequestModel
{
    public class CreateCompanyInteraction
    {
        public int? CompanyId { get; set; }
        public int? ContactId { get; set; }
        public int? UserId { get; set; }
        public int? InteractionType { get; set; }
        public DateTime InteractionDate { get; set; }
        public string? Subject { get; set; }
        public string? Notes { get; set; }
        public int? ContactSentiment { get; set; }
    }

    public class UpdateCompanyInteraction
    {
        public int? InteractionType { get; set; }
        public string? Subject { get; set; }
        public string? Notes { get; set; }
    }
}
