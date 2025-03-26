using DotNetBase.Entities.Abstract;

namespace DotNetBase.EFCore.Entities;

public partial class Task : BaseEntity, ISoftDeletable
{
    public int? UserId { get; set; }
    public string TaskTitle { get; set; } = null!;
    public string? TaskDescription { get; set; }
    public DateTime? DueDate { get; set; }
    public bool? IsCompleted { get; set; } = false;
    public int? ContactId { get; set; }
    public int? CompanyId { get; set; }
    public int? InteractionId { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedAt { get; set; }

    public virtual Company? Company { get; set; }

    public virtual Contact? Contact { get; set; }

    public virtual CompanyInteraction? Interaction { get; set; }

    public virtual User? User { get; set; }
}
