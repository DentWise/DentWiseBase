using DotNetBase.EFCore.Repositories;
using DotNetBase.Entities.Entities.Crm;
using DotNetBase.Entities.Entities.Financial;
using DotNetBase.Entities.Entities.Identity;
using DotNetBase.Entities.Entities.Procurement;

namespace DotNetBase.EFCore.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> UserRepository { get; } // Örnek repository
        IRepository<Role> RoleRepository { get; } // Örnek repository
        IRepository<Contact> ContactRepository { get; }
        IRepository<ContactSentiment> ContactSentimentRepository { get; }
        IRepository<Company> CompanyRepository { get; }
        IRepository<CompanyType> CompanyTypeRepository { get; }
        IRepository<CompanyAddress> CompanyAddressRepository { get; }
        IRepository<CompanyNote> CompanyNoteRepository { get; }
        IRepository<CompanyStatus> CompanyStatusRepository { get; }
        IRepository<CompanyStatusHistory> CompanyStatusHistoryRepository { get; }
        IRepository<InteractionAttachment> InteractionAttachmentRepository { get; }
        IRepository<InteractionType> InteractionTypeRepository { get; }
        IRepository<CompanyInteraction> CompanyInteractionRepository { get; }
        IRepository<CompanySegment> CompanySegmentRepository { get; }
        IRepository<CompanySegmentMember> CompanySegmentMemberRepository { get; }
        IRepository<EmailThread> EmailThreadRepository { get; }
        IRepository<SmsMessage> SmsMessageRepository { get; }
        IRepository<RequisitionStatus> RequisitionStatusRepository { get; }
        IRepository<PurchaseRequisition> PurchaseRequisitionRepository { get; }
        IRepository<RequisitionItem> RequisitionItemRepository { get; }
        IRepository<ProductCategory> ProductCategoryRepository { get; }
        IRepository<Product> ProductRepository { get; }
        IRepository<ProductUnit> ProductUnitRepository { get; }
        IRepository<SupplierProduct> SupplierProductRepository { get; }
        IRepository<Currency> CurrencyRepository { get; }
        IRepository<PurchaseRequestConsolidation> PurchaseRequestConsolidationRepository { get; }
        IRepository<ConsolidatedRequisitionItem> ConsolidatedRequisitionItemRepository { get; }
        IRepository<PurchaseRequisitionConsolidationItemsLink> PurchaseRequisitionConsolidationItemsLinkRepository { get; }
        IRepository<ConsolidationStatus> ConsolidationStatusRepository { get; }
        IRepository<RequestForQuotation> RequestForQuotationRepository { get; }
        IRepository<RequestForQuotationStatus> RequestForQuotationStatusRepository { get; }
        IRepository<RequestForQuotationItem> RequestForQuotationItemRepository { get; }
        IRepository<SupplierQuotation> SupplierQuotationRepository { get; }
        IRepository<SupplierQuotationItem> SupplierQuotationItemRepository { get; }
        IRepository<SupplierQuotationStatus> SupplierQuotationStatusRepository { get; }
        IRepository<PurchaseOrder> PurchaseOrderRepository { get; }
        IRepository<PurchaseOrderStatus> PurchaseOrderStatusRepository { get; }
        IRepository<PurchaseOrderItem> PurchaseOrderItemRepository { get; }
        IRepository<ShipmentTracking> ShipmentTrackingRepository { get; }
        IRepository<QuotationApprovalStatus> QuotationApprovalStatusRepository { get; }
        IRepository<ClinicPayment> ClinicPaymentRepository { get; }
        IRepository<PaymentStatus> PaymentStatusRepository { get; }
        IRepository<Permission> PermissionRepository { get; }
        Task<int> CompleteAsync();
    }
}
