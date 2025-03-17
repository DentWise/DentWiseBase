using System;
using System.Collections.Generic;

namespace DotNetBase.EFCore.Entities;

public partial class ProductUnit
{
    public int Id { get; set; }

    public string UnitName { get; set; } = null!;

    public string? Description { get; set; }

    public bool? IsDefault { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
