using DotNetBase.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace DotNetBase.EFCore.Entities;

public partial class ProductImage : BaseEntity, ISoftDeletable
{
    public int? ProductId { get; set; }
    public string ImagePath { get; set; } = null!;
    public string? Description { get; set; }
    public bool? IsDefault { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedAt { get; set; }

    public virtual Product? Product { get; set; }
}
