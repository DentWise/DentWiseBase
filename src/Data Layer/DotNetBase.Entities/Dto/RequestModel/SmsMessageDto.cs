using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBase.Entities.Dto.RequestModel
{
    public class CreateSmsMessage
    {
        public int? CompanyId { get; set; }
        public int? ContactId { get; set; }
        public int? UserId { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string MessageText { get; set; } = null!;
        public DateTime? SentDate { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public string? Direction { get; set; }
        public string? Status { get; set; }
        public string? ProviderMessageId { get; set; }
    }
}
