using System;
using System.Collections.Generic;

namespace DotNetBase.EFCore.Entities;

public partial class ContactSentiment
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Feeling { get; set; }

    public virtual ICollection<CompanyInteraction> CompanyInteractions { get; set; } = new List<CompanyInteraction>();
}
