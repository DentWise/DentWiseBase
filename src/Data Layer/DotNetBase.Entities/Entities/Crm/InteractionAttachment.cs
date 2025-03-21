using DotNetBase.Entities.Abstract;
using DotNetBase.Entities.Entities.Identity;
using System;
using System.Collections.Generic;

namespace DotNetBase.Entities.Entities.Crm;

public partial class InteractionAttachment : BaseEntity, ISoftDeletable
{

    public int? CompanyInteractionId { get; set; }
    public string FileName { get; set; } = null!;
    public string FilePath { get; set; } = null!;
    public int? FileSize { get; set; }
    public DateTime? UploadDate { get; set; }
    public int? UserId { get; set; }
    public DateTime? DeletedAt { get; set; }
    public bool IsDeleted { get; set; } = false;

    public virtual CompanyInteraction? CompanyInteraction { get; set; }

    public virtual User? User { get; set; }
}
