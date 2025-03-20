using DotNetBase.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace DotNetBase.EFCore.Entities;

public partial class CompanyStatusHistory : BaseEntity
{

    public int? CompanyId { get; set; }

    public int? Status { get; set; }

    public DateTime? StatusDate { get; set; }

    public string? Notes { get; set; }

    public virtual Company? Company { get; set; }

    public virtual CompanyStatus? StatusNavigation { get; set; }
}
