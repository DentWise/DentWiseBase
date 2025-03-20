using DotNetBase.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace DotNetBase.EFCore.Entities;

public partial class ProductCategory : BaseEntity
{

    public string CategoryName { get; set; } = null!;

    public string? Description { get; set; }

    public int? ParentCategoryId { get; set; }

    public virtual ICollection<ProductCategory> InverseParentCategory { get; set; } = new List<ProductCategory>();

    public virtual ProductCategory? ParentCategory { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
