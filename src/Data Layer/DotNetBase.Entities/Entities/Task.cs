using System;
using System.Collections.Generic;

namespace DotNetBase.EFCore.Entities;

public partial class Task
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string TaskTitle { get; set; } = null!;

    public string? TaskDescription { get; set; }

    public DateTime? DueDate { get; set; }

    public bool? IsCompleted { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? ContactId { get; set; }

    public int? CompanyId { get; set; }

    public int? InteractionId { get; set; }

    public virtual Company? Company { get; set; }

    public virtual Contact? Contact { get; set; }

    public virtual CompanyInteraction? Interaction { get; set; }

    public virtual User? User { get; set; }
}
