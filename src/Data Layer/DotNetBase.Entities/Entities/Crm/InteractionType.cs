using DotNetBase.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace DotNetBase.Entities.Entities.Crm;

public partial class InteractionType : BaseEntity, ISoftDeletable
{
    public string? Name { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<CompanyInteraction> CompanyInteractions { get; set; } = new List<CompanyInteraction>();
}
