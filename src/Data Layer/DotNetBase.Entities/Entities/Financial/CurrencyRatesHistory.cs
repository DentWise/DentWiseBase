using System;
using System.Collections.Generic;

namespace DotNetBase.Entities.Entities.Financial;

public partial class CurrencyRatesHistory
{
    public int Id { get; set; }

    public int? BaseCurrencyId { get; set; }

    public int? TargetCurrencyId { get; set; }

    public decimal Rate { get; set; }

    public DateTime EffectiveDate { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Currency? BaseCurrency { get; set; }

    public virtual Currency? TargetCurrency { get; set; }
}
