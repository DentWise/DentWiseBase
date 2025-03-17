using System;
using System.Collections.Generic;

namespace DotNetBase.EFCore.Entities;

public partial class InteractionAttachment
{
    public int Id { get; set; }

    public int? CompanyInteractionId { get; set; }

    public string FileName { get; set; } = null!;

    public string FilePath { get; set; } = null!;

    public int? FileSize { get; set; }

    public DateTime? UploadDate { get; set; }

    public int? UserId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual CompanyInteraction? CompanyInteraction { get; set; }

    public virtual User? User { get; set; }
}
