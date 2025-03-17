using System;
using System.Collections.Generic;

namespace DotNetBase.EFCore.Entities;

public partial class CompanyType
{
    public int Id { get; set; }

    public string? TypeName { get; set; }

    public virtual ICollection<Company> Companies { get; set; } = new List<Company>();
}
