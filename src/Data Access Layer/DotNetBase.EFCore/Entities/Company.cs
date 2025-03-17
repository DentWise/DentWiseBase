using System;
using System.Collections.Generic;

namespace DotNetBase.EFCore.Entities;

public partial class Company
{
    public int Id { get; set; }

    public string CompanyName { get; set; } = null!;

    public int? CompanyTypeId { get; set; }

    public string? TaxOffice { get; set; }

    public string? TaxNumber { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Website { get; set; }

    public string? LogoUrl { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CompanyStatus { get; set; }

    public virtual ICollection<ClinicPayment> ClinicPayments { get; set; } = new List<ClinicPayment>();

    public virtual ICollection<CompanyAddress> CompanyAddresses { get; set; } = new List<CompanyAddress>();

    public virtual ICollection<CompanyInteraction> CompanyInteractions { get; set; } = new List<CompanyInteraction>();

    public virtual ICollection<CompanyNote> CompanyNotes { get; set; } = new List<CompanyNote>();

    public virtual ICollection<CompanySegmentMember> CompanySegmentMembers { get; set; } = new List<CompanySegmentMember>();

    public virtual ICollection<CompanyStatusHistory> CompanyStatusHistories { get; set; } = new List<CompanyStatusHistory>();

    public virtual CompanyStatus? CompanyStatusNavigation { get; set; }

    public virtual CompanyType? CompanyType { get; set; }

    public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();

    public virtual ICollection<EmailThread> EmailThreads { get; set; } = new List<EmailThread>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; } = new List<PurchaseOrder>();

    public virtual ICollection<PurchaseRequisition> PurchaseRequisitions { get; set; } = new List<PurchaseRequisition>();

    public virtual ICollection<RequestForQuotation> RequestForQuotations { get; set; } = new List<RequestForQuotation>();

    public virtual ICollection<ShipmentTracking> ShipmentTrackings { get; set; } = new List<ShipmentTracking>();

    public virtual ICollection<SmsMessage> SmsMessages { get; set; } = new List<SmsMessage>();

    public virtual ICollection<SupplierProduct> SupplierProducts { get; set; } = new List<SupplierProduct>();

    public virtual ICollection<SupplierQuotation> SupplierQuotations { get; set; } = new List<SupplierQuotation>();

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
