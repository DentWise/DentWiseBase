using System;
using System.Collections.Generic;

namespace DotNetBase.EFCore.Entities;

public partial class CompanyStatus
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? StatusLeg { get; set; }

    public virtual ICollection<Company> Companies { get; set; } = new List<Company>();

    public virtual ICollection<CompanyStatusHistory> CompanyStatusHistories { get; set; } = new List<CompanyStatusHistory>();
}
