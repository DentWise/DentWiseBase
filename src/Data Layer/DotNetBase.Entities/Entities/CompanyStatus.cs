using DotNetBase.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace DotNetBase.EFCore.Entities;

public partial class CompanyStatus : BaseEntity, ISoftDeletable
{
    public string? Name { get; set; }
    public int? StatusLeg { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<Company> Companies { get; set; } = new List<Company>();

    public virtual ICollection<CompanyStatusHistory> CompanyStatusHistories { get; set; } = new List<CompanyStatusHistory>();
}
