using System;
using System.Collections.Generic;

namespace DotNetBase.Entities.Entities.Procurement;

public partial class ProductImage
{
    public int Id { get; set; }

    public int? ProductId { get; set; }

    public string ImagePath { get; set; } = null!;

    public string? Description { get; set; }

    public bool? IsDefault { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Product? Product { get; set; }
}
