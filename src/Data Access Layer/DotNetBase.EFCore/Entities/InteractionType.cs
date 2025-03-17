using System;
using System.Collections.Generic;

namespace DotNetBase.EFCore.Entities;

public partial class InteractionType
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<CompanyInteraction> CompanyInteractions { get; set; } = new List<CompanyInteraction>();
}
