using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBase.Entities.Dto.RequestModel
{
    public class CreateEmailThread
    {
        public int? CompanyId { get; set; }
        public int? ContactId { get; set; }
        public int? UserId { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
        public DateTime? SentDate { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public string? Direction { get; set; }
        public string? Status { get; set; }
        public string? MessageId { get; set; }
        public int? ReferencesMessageId { get; set; }
        public int? InReplyToMessageId { get; set; }
    }
}
