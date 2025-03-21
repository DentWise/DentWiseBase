using DotNetBase.Entities.Abstract;
using DotNetBase.Entities.Entities.Identity;
using System;
using System.Collections.Generic;

namespace DotNetBase.Entities.Entities.Crm;

public partial class CompanyNote : BaseEntity, ISoftDeletable
{
    public int CompanyId { get; set; }
    public string NoteText { get; set; } = null!;
    public int? CreatedByUserId { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedAt { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual User? CreatedByUser { get; set; }
}
