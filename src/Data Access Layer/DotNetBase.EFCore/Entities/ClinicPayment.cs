using System;
using System.Collections.Generic;

namespace DotNetBase.EFCore.Entities;

public partial class ClinicPayment
{
    public int Id { get; set; }

    public int ClinicCompanyId { get; set; }

    public int PurchaseRequestConsolidationId { get; set; }

    public DateTime PaymentDate { get; set; }

    public decimal PaymentAmount { get; set; }

    public int CurrencyId { get; set; }

    public string? PaymentMethod { get; set; }

    public string? ReferenceNumber { get; set; }

    public string? Notes { get; set; }

    public int? PrePaymentStatusId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Company ClinicCompany { get; set; } = null!;

    public virtual Currency Currency { get; set; } = null!;

    public virtual PaymentStatus? PrePaymentStatus { get; set; }

    public virtual PurchaseRequestConsolidation PurchaseRequestConsolidation { get; set; } = null!;
}
