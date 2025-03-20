using DotNetBase.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace DotNetBase.EFCore.Entities;

public partial class CompanyType : BaseEntity, ISoftDeletable
{
    public string? TypeName { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<Company> Companies { get; set; } = new List<Company>();
}
