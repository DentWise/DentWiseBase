using DotNetBase.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace DotNetBase.EFCore.Entities;

public partial class ProductCommission : BaseEntity
{
    public int? ProductId { get; set; }
    public decimal Rate { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public bool? IsActive { get; set; } = true;


    public virtual Product? Product { get; set; }
}
