using DotNetBase.Entities.Entities.Procurement;
using System;
using System.Collections.Generic;

namespace DotNetBase.Entities.Entities.Financial;

public partial class ProductCommission
{
    public int Id { get; set; }

    public int? ProductId { get; set; }

    public decimal Rate { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Product? Product { get; set; }
}
