using System;
using System.Collections.Generic;

namespace DotNetBase.EFCore.Entities;

public partial class SmsMessage
{
    public int Id { get; set; }

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

    public DateTime? CreatedAt { get; set; }

    public virtual Company? Company { get; set; }

    public virtual Contact? Contact { get; set; }

    public virtual User? User { get; set; }
}
