using System;
using System.Collections.Generic;

namespace DotNetBase.EFCore.Entities;

public partial class CompanyNote
{
    public int Id { get; set; }

    public int CompanyId { get; set; }

    public string NoteText { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public int? CreatedByUserId { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual User? CreatedByUser { get; set; }
}
