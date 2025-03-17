﻿using System;
using System.Collections.Generic;

namespace DotNetBase.EFCore.Entities;

public partial class CompanyInteraction
{
    public int Id { get; set; }

    public int? CompanyId { get; set; }

    public int? ContactId { get; set; }

    public int? UserId { get; set; }

    public int? InteractionType { get; set; }

    public DateTime InteractionDate { get; set; }

    public string? Subject { get; set; }

    public string? Notes { get; set; }

    public int? ContactSentiment { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Company? Company { get; set; }

    public virtual Contact? Contact { get; set; }

    public virtual ContactSentiment? ContactSentimentNavigation { get; set; }

    public virtual ICollection<InteractionAttachment> InteractionAttachments { get; set; } = new List<InteractionAttachment>();

    public virtual InteractionType? InteractionTypeNavigation { get; set; }

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();

    public virtual User? User { get; set; }
}
