// Infrastructure/UnitOfWork.cs
using DotNetBase.EFCore.DBContext;
using DotNetBase.EFCore.Repositories;
using DotNetBase.EFCore.UnitOfWork;
using DotNetBase.Entities.Entities.Crm;
using DotNetBase.Entities.Entities.Financial;
using DotNetBase.Entities.Entities.Identity;
using DotNetBase.Entities.Entities.Procurement;

public class UnitOfWork : IUnitOfWork
{
    private readonly BaseDbContext _context;
    private IRepository<User> _userRepository;
    private IRepository<Role> _roleRepository;
    private IRepository<Contact> _contactRepository;
    private IRepository<ContactSentiment> _contactSentimentRepository;
    private IRepository<Company> _companyRepository;
    private IRepository<CompanyType> _companyTypeRepository;
    private IRepository<CompanyAddress> _companyAddressRepository;
    private IRepository<CompanyNote> _companyNoteRepository;
    private IRepository<CompanyStatus> _companyStatusRepository;
    private IRepository<CompanyStatusHistory> _companyStatusHistoryRepository;
    private IRepository<InteractionAttachment> _interactionAttachmentRepository;
    private IRepository<InteractionType> _interactionTypeRepository;
    private IRepository<CompanyInteraction> _companyInteractionRepository;
    private IRepository<CompanySegment> _companySegmentRepository;
    private IRepository<CompanySegmentMember> _companySegmentMemberRepository;
    private IRepository<EmailThread> _emailThreadRepository;
    private IRepository<SmsMessage> _smsMessageRepository;
    private IRepository<RequisitionStatus> _requisitionStatusRepository;
    private IRepository<PurchaseRequisition> _purchaseRequisitionRepository;
    private IRepository<RequisitionItem> _requisitionItemRepository;
    private IRepository<ProductCategory> _productCategoryRepository;
    private IRepository<Product> _productRepository;
    private IRepository<ProductUnit> _productUnitRepository;
    private IRepository<SupplierProduct> _supplierProductRepository;
    private IRepository<Currency> _currencyRepository;
    private IRepository<PurchaseRequestConsolidation> _purchaseRequestConsolidationRepository;
    private IRepository<ConsolidatedRequisitionItem> _consolidatedRequisitionItemRepository;
    private IRepository<PurchaseRequisitionConsolidationItemsLink> _purchaseRequisitionConsolidationItemsLinkRepository;
    private IRepository<ConsolidationStatus> _consolidationStatusRepository;
    private IRepository<RequestForQuotation> _requestForQuotationRepository;
    private IRepository<RequestForQuotationStatus> _requestForQuotationStatusRepository;
    private IRepository<RequestForQuotationItem> _requestForQuotationItemRepository;
    private IRepository<SupplierQuotation> _supplierQuotationRepository;
    private IRepository<SupplierQuotationItem> _supplierQuotationItemRepository;
    private IRepository<SupplierQuotationStatus> _supplierQuotationStatusRepository;
    private IRepository<PurchaseOrder> _purchaseOrderRepository;
    private IRepository<PurchaseOrderStatus> _purchaseOrderStatusRepository;
    private IRepository<PurchaseOrderItem> _purchaseOrderItemRepository;
    private IRepository<ShipmentTracking> _shipmentTrackingRepository;
    private IRepository<QuotationApprovalStatus> _quotationApprovalStatusRepository;
    private IRepository<ClinicPayment> _clinicPaymentRepository;
    private IRepository<PaymentStatus> _paymentStatusRepository;
    private IRepository<Permission> _permissionRepository;
    public UnitOfWork(BaseDbContext context)
    {
        _context = context;
    }


    // Lazy loading ile repository'leri oluşturuyoruz.
    public IRepository<User> UserRepository => _userRepository ??= new Repository<User>(_context);
    public IRepository<Role> RoleRepository => _roleRepository ??= new Repository<Role>(_context);
    public IRepository<Contact> ContactRepository => _contactRepository ??= new Repository<Contact>(_context);
    public IRepository<ContactSentiment> ContactSentimentRepository => _contactSentimentRepository ??= new Repository<ContactSentiment>(_context);
    public IRepository<Company> CompanyRepository => _companyRepository ??= new Repository<Company>(_context);
    public IRepository<CompanyType> CompanyTypeRepository => _companyTypeRepository ??= new Repository<CompanyType>(_context);
    public IRepository<CompanyAddress> CompanyAddressRepository => _companyAddressRepository ??= new Repository<CompanyAddress>(_context);
    public IRepository<CompanyNote> CompanyNoteRepository => _companyNoteRepository ??= new Repository<CompanyNote>(_context);
    public IRepository<CompanyStatus> CompanyStatusRepository => _companyStatusRepository ??= new Repository<CompanyStatus>(_context);
    public IRepository<CompanyStatusHistory> CompanyStatusHistoryRepository => _companyStatusHistoryRepository ??= new Repository<CompanyStatusHistory>(_context);
    public IRepository<InteractionAttachment> InteractionAttachmentRepository => _interactionAttachmentRepository ??= new Repository<InteractionAttachment>(_context);
    public IRepository<InteractionType> InteractionTypeRepository => _interactionTypeRepository ??= new Repository<InteractionType>(_context);
    public IRepository<CompanyInteraction> CompanyInteractionRepository => _companyInteractionRepository ??= new Repository<CompanyInteraction>(_context);
    public IRepository<CompanySegment> CompanySegmentRepository => _companySegmentRepository ??= new Repository<CompanySegment>(_context);
    public IRepository<CompanySegmentMember> CompanySegmentMemberRepository => _companySegmentMemberRepository ??= new Repository<CompanySegmentMember>(_context);
    public IRepository<EmailThread> EmailThreadRepository => _emailThreadRepository ??= new Repository<EmailThread>(_context);
    public IRepository<SmsMessage> SmsMessageRepository => _smsMessageRepository ??= new Repository<SmsMessage>(_context);
    public IRepository<RequisitionStatus> RequisitionStatusRepository => _requisitionStatusRepository ??= new Repository<RequisitionStatus>(_context);
    public IRepository<PurchaseRequisition> PurchaseRequisitionRepository => _purchaseRequisitionRepository ??= new Repository<PurchaseRequisition>(_context);
    public IRepository<RequisitionItem> RequisitionItemRepository => _requisitionItemRepository ??= new Repository<RequisitionItem>(_context);
    public IRepository<ProductCategory> ProductCategoryRepository => _productCategoryRepository ??= new Repository<ProductCategory>(_context);
    public IRepository<Product> ProductRepository => _productRepository ??= new Repository<Product>(_context);
    public IRepository<ProductUnit> ProductUnitRepository => _productUnitRepository ??= new Repository<ProductUnit>(_context);
    public IRepository<SupplierProduct> SupplierProductRepository => _supplierProductRepository ??= new Repository<SupplierProduct>(_context);
    public IRepository<Currency> CurrencyRepository => _currencyRepository ??= new Repository<Currency>(_context);
    public IRepository<PurchaseRequestConsolidation> PurchaseRequestConsolidationRepository => _purchaseRequestConsolidationRepository ??= new Repository<PurchaseRequestConsolidation>(_context);
    public IRepository<ConsolidatedRequisitionItem> ConsolidatedRequisitionItemRepository => _consolidatedRequisitionItemRepository ??= new Repository<ConsolidatedRequisitionItem>(_context);
    public IRepository<PurchaseRequisitionConsolidationItemsLink> PurchaseRequisitionConsolidationItemsLinkRepository => _purchaseRequisitionConsolidationItemsLinkRepository ??= new Repository<PurchaseRequisitionConsolidationItemsLink>(_context);
    public IRepository<ConsolidationStatus> ConsolidationStatusRepository => _consolidationStatusRepository ??= new Repository<ConsolidationStatus>(_context);
    public IRepository<RequestForQuotation> RequestForQuotationRepository => _requestForQuotationRepository ??= new Repository<RequestForQuotation>(_context);
    public IRepository<RequestForQuotationStatus> RequestForQuotationStatusRepository => _requestForQuotationStatusRepository ??= new Repository<RequestForQuotationStatus>(_context);
    public IRepository<RequestForQuotationItem> RequestForQuotationItemRepository => _requestForQuotationItemRepository ??= new Repository<RequestForQuotationItem>(_context);
    public IRepository<SupplierQuotation> SupplierQuotationRepository => _supplierQuotationRepository ??= new Repository<SupplierQuotation>(_context);
    public IRepository<SupplierQuotationItem> SupplierQuotationItemRepository => _supplierQuotationItemRepository ??= new Repository<SupplierQuotationItem>(_context);
    public IRepository<SupplierQuotationStatus> SupplierQuotationStatusRepository => _supplierQuotationStatusRepository ??= new Repository<SupplierQuotationStatus>(_context);
    public IRepository<PurchaseOrder> PurchaseOrderRepository => _purchaseOrderRepository ??= new Repository<PurchaseOrder>(_context);
    public IRepository<PurchaseOrderStatus> PurchaseOrderStatusRepository => _purchaseOrderStatusRepository ??= new Repository<PurchaseOrderStatus>(_context);
    public IRepository<PurchaseOrderItem> PurchaseOrderItemRepository => _purchaseOrderItemRepository ??= new Repository<PurchaseOrderItem>(_context);
    public IRepository<ShipmentTracking> ShipmentTrackingRepository => _shipmentTrackingRepository ??= new Repository<ShipmentTracking>(_context);
    public IRepository<QuotationApprovalStatus> QuotationApprovalStatusRepository => _quotationApprovalStatusRepository ??= new Repository<QuotationApprovalStatus>(_context);
    public IRepository<ClinicPayment> ClinicPaymentRepository => _clinicPaymentRepository ??= new Repository<ClinicPayment>(_context);
    public IRepository<PaymentStatus> PaymentStatusRepository => _paymentStatusRepository ??= new Repository<PaymentStatus>(_context);
    public IRepository<Permission> PermissionRepository => _permissionRepository ??= new Repository<Permission>(_context);

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose(); // DbContext'i dispose ediyoruz.
        GC.SuppressFinalize(this);
    }
}