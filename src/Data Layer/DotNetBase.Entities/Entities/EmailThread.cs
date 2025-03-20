using DotNetBase.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace DotNetBase.EFCore.Entities;

public partial class EmailThread : BaseEntity
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

    public virtual Company? Company { get; set; }

    public virtual Contact? Contact { get; set; }

    public virtual EmailThread? InReplyToMessage { get; set; }

    public virtual ICollection<EmailThread> InverseInReplyToMessage { get; set; } = new List<EmailThread>();

    public virtual ICollection<EmailThread> InverseReferencesMessage { get; set; } = new List<EmailThread>();

    public virtual EmailThread? ReferencesMessage { get; set; }

    public virtual User? User { get; set; }
}
