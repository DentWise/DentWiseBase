using DotNetBase.Entities.Abstract;
using DotNetBase.Entities.Entities.Crm;
using DotNetBase.Entities.Entities.Financial;
using DotNetBase.Entities.Entities.Identity;
using DotNetBase.Entities.Entities.Procurement;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Task = DotNetBase.Entities.Entities.Crm.Task;

namespace DotNetBase.EFCore.DBContext
{
    public class BaseDbContext : DbContext
    {
        public BaseDbContext(DbContextOptions<BaseDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<CompanyAddress> CompanyAddresses { get; set; }
        public DbSet<CompanyStatusHistory> CompanyStatusHistories { get; set; }
        public DbSet<CompanyNote> CompanyNotes { get; set; }
        public DbSet<InteractionAttachment> InteractionAttachments { get; set; }
        public DbSet<CompanyInteraction> CompanyInteractions { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<CompanySegment> CompanySegments { get; set; }
        public DbSet<CompanySegmentMember> CompanySegmentMembers { get; set; }
        public DbSet<EmailThread> EmailThreads { get; set; }
        public DbSet<SmsMessage> SmsMessages { get; set; }
        public DbSet<RequisitionStatus> RequisitionStatuses { get; set; }
        public DbSet<PurchaseRequisition> PurchaseRequisitions { get; set; }
        public DbSet<RequisitionItem> RequisitionItems { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductUnit> ProductUnits { get; set; }
        public DbSet<SupplierProduct> SupplierProducts { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<PurchaseRequestConsolidation> PurchaseRequestConsolidations { get; set; }
        public DbSet<ConsolidatedRequisitionItem> ConsolidatedRequisitionItems { get; set; }
        public DbSet<PurchaseRequisitionConsolidationItemsLink> PurchaseRequisitionConsolidationItemsLinks { get; set; }
        public DbSet<ConsolidationStatus> ConsolidationStatuses { get; set; }
        public DbSet<RequestForQuotation> RequestForQuotations { get; set; }
        public DbSet<RequestForQuotationStatus> RequestForQuotationStatuses { get; set; }
        public DbSet<RequestForQuotationItem> RequestForQuotationItems { get; set; }
        public DbSet<SupplierQuotation> SupplierQuotations { get; set; }
        public DbSet<SupplierQuotationItem> SupplierQuotationItems { get; set; }
        public DbSet<SupplierQuotationStatus> SupplierQuotationStatuses { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderStatus> PurchaseOrderStatus { get; set; }
        public DbSet<PurchaseOrderItem> PurchaseOrderItemStatus { get; set; }
        public DbSet<ShipmentTracking> ShipmentTrackings { get; set; }
        public DbSet<QuotationApprovalStatus> QuotationApprovalStatuses { get; set; }
        public DbSet<ClinicPayment> ClinicPayments { get; set; }
        public DbSet<PaymentStatus> PaymentStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // İlişkileri ve kısıtlamaları burada tanımlayabilirsiniz (Fluent API).
            // Örnek:
            modelBuilder.Entity<User>()
                 .HasOne(p => p.Role)
                 .WithMany(c => c.Users)
                 .HasForeignKey(p => p.RoleId)
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CompanyAddress>()
                 .HasOne(ca => ca.Company)
                 .WithMany()
                 .HasForeignKey(ca => ca.CompanyId)
                 .OnDelete(DeleteBehavior.Cascade);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(ISoftDeletable).IsAssignableFrom(entityType.ClrType))
                {
                    modelBuilder.Entity(entityType.ClrType).HasQueryFilter(GetSoftDeleteFilter(entityType.ClrType));
                }
            }

            base.OnModelCreating(modelBuilder);
        }
        public override int SaveChanges()
        {
            UpdateSoftDeleteStatuses();
            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateSoftDeleteStatuses();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateSoftDeleteStatuses()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        if (entry.Entity is BaseEntity addedEntity)
                        {
                            addedEntity.CreatedAt = DateTime.UtcNow;
                        }
                        break;

                    case EntityState.Deleted:
                        if (entry.Entity is ISoftDeletable deletableEntity)
                        {
                            entry.State = EntityState.Modified;
                            deletableEntity.DeletedAt = DateTime.UtcNow;
                            deletableEntity.IsDeleted = true;
                        }
                        break;
                    case EntityState.Modified:
                        if (entry.Entity is BaseEntity modifiedEntity)
                        {
                            modifiedEntity.UpdatedAt = DateTime.UtcNow;
                        }

                        break;
                    default:
                        break;
                }
            }
        }
        private LambdaExpression GetSoftDeleteFilter(Type type)
        {
            var param = Expression.Parameter(type, "e");
            var body = Expression.Equal(Expression.Property(param, nameof(ISoftDeletable.IsDeleted)), Expression.Constant(false));
            return Expression.Lambda(body, param);
        }
    }
}
