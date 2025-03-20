using DotNetBase.Entities.Abstract;

namespace DotNetBase.EFCore.Entities;

public partial class PurchaseRequestConsolidation : BaseEntity
{

    public string ConsolidationNumber { get; set; } = null!;

    public DateTime ConsolidationDate { get; set; }

    public string? Description { get; set; }

    public int? ConsolidationStatusId { get; set; }

    public virtual ICollection<ClinicPayment> ClinicPayments { get; set; } = new List<ClinicPayment>();

    public virtual ICollection<ConsolidatedRequisitionItem> ConsolidatedRequisitionItems { get; set; } = new List<ConsolidatedRequisitionItem>();

    public virtual ConsolidationStatus? ConsolidationStatus { get; set; }

    public virtual ICollection<RequestForQuotation> RequestForQuotations { get; set; } = new List<RequestForQuotation>();
}
