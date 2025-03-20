using System.Data.Entity;

namespace DotNetBase.EFCore.Entities;

public partial class DentWiseDbContext : DbContext
{
    public DentWiseDbContext()
    {
    }

    public DentWiseDbContext(DbContextOptions<DentWiseDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ClinicPayment> ClinicPayments { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<CompanyAddress> CompanyAddresses { get; set; }

    public virtual DbSet<CompanyInteraction> CompanyInteractions { get; set; }

    public virtual DbSet<CompanyNote> CompanyNotes { get; set; }

    public virtual DbSet<CompanySegment> CompanySegments { get; set; }

    public virtual DbSet<CompanySegmentMember> CompanySegmentMembers { get; set; }

    public virtual DbSet<CompanyStatus> CompanyStatuses { get; set; }

    public virtual DbSet<CompanyStatusHistory> CompanyStatusHistories { get; set; }

    public virtual DbSet<CompanyType> CompanyTypes { get; set; }

    public virtual DbSet<ConsolidatedRequisitionItem> ConsolidatedRequisitionItems { get; set; }

    public virtual DbSet<ConsolidationStatus> ConsolidationStatuses { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<ContactSentiment> ContactSentiments { get; set; }

    public virtual DbSet<Currency> Currencies { get; set; }

    public virtual DbSet<CurrencyRatesHistory> CurrencyRatesHistories { get; set; }

    public virtual DbSet<DoctorDetail> DoctorDetails { get; set; }

    public virtual DbSet<EmailThread> EmailThreads { get; set; }

    public virtual DbSet<InteractionAttachment> InteractionAttachments { get; set; }

    public virtual DbSet<InteractionType> InteractionTypes { get; set; }

    public virtual DbSet<PaymentStatus> PaymentStatuses { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<ProductCommission> ProductCommissions { get; set; }

    public virtual DbSet<ProductImage> ProductImages { get; set; }

    public virtual DbSet<ProductUnit> ProductUnits { get; set; }

    public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }

    public virtual DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; }

    public virtual DbSet<PurchaseOrderStatus> PurchaseOrderStatuses { get; set; }

    public virtual DbSet<PurchaseRequestConsolidation> PurchaseRequestConsolidations { get; set; }

    public virtual DbSet<PurchaseRequisition> PurchaseRequisitions { get; set; }

    public virtual DbSet<PurchaseRequisitionConsolidationItemsLink> PurchaseRequisitionConsolidationItemsLinks { get; set; }

    public virtual DbSet<QuotationApprovalStatus> QuotationApprovalStatuses { get; set; }

    public virtual DbSet<RequestForQuotation> RequestForQuotations { get; set; }

    public virtual DbSet<RequestForQuotationItem> RequestForQuotationItems { get; set; }

    public virtual DbSet<RequestForQuotationStatus> RequestForQuotationStatuses { get; set; }

    public virtual DbSet<RequisitionItem> RequisitionItems { get; set; }

    public virtual DbSet<RequisitionStatus> RequisitionStatuses { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RolePermission> RolePermissions { get; set; }

    public virtual DbSet<ShipmentTracking> ShipmentTrackings { get; set; }

    public virtual DbSet<SmsMessage> SmsMessages { get; set; }

    public virtual DbSet<SupplierProduct> SupplierProducts { get; set; }

    public virtual DbSet<SupplierQuotation> SupplierQuotations { get; set; }

    public virtual DbSet<SupplierQuotationItem> SupplierQuotationItems { get; set; }

    public virtual DbSet<SupplierQuotationStatus> SupplierQuotationStatuses { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=localhost;Port=3306;Database=DentWise_db;Uid=root;Pwd=952632;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ClinicPayment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.ClinicCompanyId, "ClinicCompanyId");

            entity.HasIndex(e => e.CurrencyId, "CurrencyId");

            entity.HasIndex(e => e.PrePaymentStatusId, "PrePaymentStatusId");

            entity.HasIndex(e => e.PurchaseRequestConsolidationId, "PurchaseRequestConsolidationId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.ClinicCompanyId).HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp");
            entity.Property(e => e.CurrencyId).HasColumnType("int(11)");
            entity.Property(e => e.Notes)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text");
            entity.Property(e => e.PaymentAmount).HasPrecision(10);
            entity.Property(e => e.PaymentDate)
                .HasDefaultValueSql("'current_timestamp()'")
                .HasColumnType("date");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.PrePaymentStatusId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.PurchaseRequestConsolidationId).HasColumnType("int(11)");
            entity.Property(e => e.ReferenceNumber)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp");

            entity.HasOne(d => d.ClinicCompany).WithMany(p => p.ClinicPayments)
                .HasForeignKey(d => d.ClinicCompanyId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("ClinicPayments_ibfk_1");

            entity.HasOne(d => d.Currency).WithMany(p => p.ClinicPayments)
                .HasForeignKey(d => d.CurrencyId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("ClinicPayments_ibfk_3");

            entity.HasOne(d => d.PrePaymentStatus).WithMany(p => p.ClinicPayments)
                .HasForeignKey(d => d.PrePaymentStatusId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("ClinicPayments_ibfk_4");

            entity.HasOne(d => d.PurchaseRequestConsolidation).WithMany(p => p.ClinicPayments)
                .HasForeignKey(d => d.PurchaseRequestConsolidationId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("ClinicPayments_ibfk_2");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.CompanyStatus, "CompanyStatus");

            entity.HasIndex(e => e.CompanyTypeId, "CompanyTypeId");

            entity.HasIndex(e => e.Email, "Email").IsUnique();

            entity.HasIndex(e => e.Phone, "Phone").IsUnique();

            entity.HasIndex(e => e.Website, "Website").IsUnique();

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CompanyName).HasMaxLength(255);
            entity.Property(e => e.CompanyStatus)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.CompanyTypeId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp");
            entity.Property(e => e.Email).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.LogoUrl)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Phone).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.TaxNumber)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.TaxOffice)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Website).HasDefaultValueSql("'NULL'");

            entity.HasOne(d => d.CompanyStatusNavigation).WithMany(p => p.Companies)
                .HasForeignKey(d => d.CompanyStatus)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Companies_ibfk_2");

            entity.HasOne(d => d.CompanyType).WithMany(p => p.Companies)
                .HasForeignKey(d => d.CompanyTypeId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Companies_ibfk_1");
        });

        modelBuilder.Entity<CompanyAddress>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.CompanyId, "CompanyId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.AddressLine)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.City)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.CompanyId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.Country)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp");
            entity.Property(e => e.IsDefault).HasDefaultValueSql("'0'");
            entity.Property(e => e.PostalCode)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'");

            entity.HasOne(d => d.Company).WithMany(p => p.CompanyAddresses)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("CompanyAddresses_ibfk_1");
        });

        modelBuilder.Entity<CompanyInteraction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.CompanyId, "CompanyId");

            entity.HasIndex(e => e.ContactId, "ContactId");

            entity.HasIndex(e => e.ContactSentiment, "ContactSentiment");

            entity.HasIndex(e => e.InteractionType, "InteractionType");

            entity.HasIndex(e => e.UserId, "UserId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CompanyId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.ContactId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.ContactSentiment)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp");
            entity.Property(e => e.InteractionDate)
                .HasDefaultValueSql("'current_timestamp()'")
                .HasColumnType("datetime");
            entity.Property(e => e.InteractionType)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.Notes)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text");
            entity.Property(e => e.Subject)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.UserId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");

            entity.HasOne(d => d.Company).WithMany(p => p.CompanyInteractions)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("CompanyInteractions_ibfk_1");

            entity.HasOne(d => d.Contact).WithMany(p => p.CompanyInteractions)
                .HasForeignKey(d => d.ContactId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("CompanyInteractions_ibfk_2");

            entity.HasOne(d => d.ContactSentimentNavigation).WithMany(p => p.CompanyInteractions)
                .HasForeignKey(d => d.ContactSentiment)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("CompanyInteractions_ibfk_5");

            entity.HasOne(d => d.InteractionTypeNavigation).WithMany(p => p.CompanyInteractions)
                .HasForeignKey(d => d.InteractionType)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("CompanyInteractions_ibfk_4");

            entity.HasOne(d => d.User).WithMany(p => p.CompanyInteractions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("CompanyInteractions_ibfk_3");
        });

        modelBuilder.Entity<CompanyNote>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.CompanyId, "CompanyId");

            entity.HasIndex(e => e.CreatedByUserId, "CreatedByUserId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CompanyId).HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp");
            entity.Property(e => e.CreatedByUserId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.NoteText).HasColumnType("text");

            entity.HasOne(d => d.Company).WithMany(p => p.CompanyNotes)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("CompanyNotes_ibfk_1");

            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.CompanyNotes)
                .HasForeignKey(d => d.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("CompanyNotes_ibfk_2");
        });

        modelBuilder.Entity<CompanySegment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.SegmentName, "SegmentName").IsUnique();

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'");
        });

        modelBuilder.Entity<CompanySegmentMember>(entity =>
        {
            entity.HasKey(e => new { e.CompanyId, e.CompanySegmentId }).HasName("PRIMARY");

            entity.HasIndex(e => e.CompanySegmentId, "CompanySegmentId");

            entity.HasIndex(e => e.UserId, "UserId");

            entity.Property(e => e.CompanyId).HasColumnType("int(11)");
            entity.Property(e => e.CompanySegmentId).HasColumnType("int(11)");
            entity.Property(e => e.AddedAt)
                .HasDefaultValueSql("'current_timestamp()'")
                .HasColumnType("timestamp");
            entity.Property(e => e.UserId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");

            entity.HasOne(d => d.Company).WithMany(p => p.CompanySegmentMembers)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("CompanySegmentMembers_ibfk_1");

            entity.HasOne(d => d.CompanySegment).WithMany(p => p.CompanySegmentMembers)
                .HasForeignKey(d => d.CompanySegmentId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("CompanySegmentMembers_ibfk_2");

            entity.HasOne(d => d.User).WithMany(p => p.CompanySegmentMembers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("CompanySegmentMembers_ibfk_3");
        });

        modelBuilder.Entity<CompanyStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.StatusLeg)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
        });

        modelBuilder.Entity<CompanyStatusHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("CompanyStatusHistory");

            entity.HasIndex(e => e.CompanyId, "CompanyId");

            entity.HasIndex(e => e.Status, "Status");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CompanyId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.Notes)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.StatusDate)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp");

            entity.HasOne(d => d.Company).WithMany(p => p.CompanyStatusHistories)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("CompanyStatusHistory_ibfk_1");

            entity.HasOne(d => d.StatusNavigation).WithMany(p => p.CompanyStatusHistories)
                .HasForeignKey(d => d.Status)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("CompanyStatusHistory_ibfk_2");
        });

        modelBuilder.Entity<CompanyType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.TypeName)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'");
        });

        modelBuilder.Entity<ConsolidatedRequisitionItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.ProductId, "ProductId");

            entity.HasIndex(e => e.PurchaseRequestConsolidationId, "PurchaseRequestConsolidationId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp");
            entity.Property(e => e.Description)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text");
            entity.Property(e => e.ProductId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.PurchaseRequestConsolidationId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.Quantity)
                .HasDefaultValueSql("'1'")
                .HasColumnType("int(11)");

            entity.HasOne(d => d.Product).WithMany(p => p.ConsolidatedRequisitionItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("ConsolidatedRequisitionItems_ibfk_2");

            entity.HasOne(d => d.PurchaseRequestConsolidation).WithMany(p => p.ConsolidatedRequisitionItems)
                .HasForeignKey(d => d.PurchaseRequestConsolidationId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("ConsolidatedRequisitionItems_ibfk_1");
        });

        modelBuilder.Entity<ConsolidationStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.StatusName, "StatusName").IsUnique();

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.IsDefault).HasDefaultValueSql("'0'");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.CompanyId, "CompanyId");

            entity.HasIndex(e => e.Email, "Email").IsUnique();

            entity.HasIndex(e => e.PhoneNumber, "PhoneNumber").IsUnique();

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CompanyId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp");
            entity.Property(e => e.Email).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.FirstName).HasMaxLength(255);
            entity.Property(e => e.LastName).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Position)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'");

            entity.HasOne(d => d.Company).WithMany(p => p.Contacts)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Contacts_ibfk_1");
        });

        modelBuilder.Entity<ContactSentiment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Feeling)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'");
        });

        modelBuilder.Entity<Currency>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.CurrencyCode, "CurrencyCode").IsUnique();

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp");
            entity.Property(e => e.CurrencyName).HasMaxLength(255);
            entity.Property(e => e.CurrencySymbol)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.IsDefault).HasDefaultValueSql("'0'");
        });

        modelBuilder.Entity<CurrencyRatesHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("CurrencyRatesHistory");

            entity.HasIndex(e => new { e.BaseCurrencyId, e.TargetCurrencyId, e.EffectiveDate }, "CurrencyRatesHistory_index_4").IsUnique();

            entity.HasIndex(e => e.TargetCurrencyId, "TargetCurrencyId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.BaseCurrencyId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp");
            entity.Property(e => e.EffectiveDate).HasColumnType("date");
            entity.Property(e => e.Rate).HasPrecision(10);
            entity.Property(e => e.TargetCurrencyId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp");

            entity.HasOne(d => d.BaseCurrency).WithMany(p => p.CurrencyRatesHistoryBaseCurrencies)
                .HasForeignKey(d => d.BaseCurrencyId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("CurrencyRatesHistory_ibfk_1");

            entity.HasOne(d => d.TargetCurrency).WithMany(p => p.CurrencyRatesHistoryTargetCurrencies)
                .HasForeignKey(d => d.TargetCurrencyId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("CurrencyRatesHistory_ibfk_2");
        });

        modelBuilder.Entity<DoctorDetail>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.HasIndex(e => e.ChamberRegistrationNumber, "ChamberRegistrationNumber").IsUnique();

            entity.HasIndex(e => e.DiplomaNumber, "DiplomaNumber").IsUnique();

            entity.Property(e => e.UserId).HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp");

            entity.HasOne(d => d.User).WithOne(p => p.DoctorDetail)
                .HasForeignKey<DoctorDetail>(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("DoctorDetails_ibfk_1");
        });

        modelBuilder.Entity<EmailThread>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.CompanyId, "CompanyId");

            entity.HasIndex(e => e.ContactId, "ContactId");

            entity.HasIndex(e => e.InReplyToMessageId, "InReplyToMessageId");

            entity.HasIndex(e => e.ReferencesMessageId, "ReferencesMessageId");

            entity.HasIndex(e => e.UserId, "UserId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Body)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text");
            entity.Property(e => e.CompanyId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.ContactId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp");
            entity.Property(e => e.Direction)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.InReplyToMessageId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.MessageId)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.ReceivedDate)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("datetime");
            entity.Property(e => e.ReferencesMessageId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.SentDate)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Subject)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.UserId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");

            entity.HasOne(d => d.Company).WithMany(p => p.EmailThreads)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("EmailThreads_ibfk_1");

            entity.HasOne(d => d.Contact).WithMany(p => p.EmailThreads)
                .HasForeignKey(d => d.ContactId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("EmailThreads_ibfk_2");

            entity.HasOne(d => d.InReplyToMessage).WithMany(p => p.InverseInReplyToMessage)
                .HasForeignKey(d => d.InReplyToMessageId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("EmailThreads_ibfk_5");

            entity.HasOne(d => d.ReferencesMessage).WithMany(p => p.InverseReferencesMessage)
                .HasForeignKey(d => d.ReferencesMessageId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("EmailThreads_ibfk_4");

            entity.HasOne(d => d.User).WithMany(p => p.EmailThreads)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("EmailThreads_ibfk_3");
        });

        modelBuilder.Entity<InteractionAttachment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.CompanyInteractionId, "CompanyInteractionId");

            entity.HasIndex(e => e.UserId, "UserId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CompanyInteractionId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp");
            entity.Property(e => e.FileName).HasMaxLength(255);
            entity.Property(e => e.FilePath).HasMaxLength(255);
            entity.Property(e => e.FileSize)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.UploadDate)
                .HasDefaultValueSql("'current_timestamp()'")
                .HasColumnType("timestamp");
            entity.Property(e => e.UserId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");

            entity.HasOne(d => d.CompanyInteraction).WithMany(p => p.InteractionAttachments)
                .HasForeignKey(d => d.CompanyInteractionId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("InteractionAttachments_ibfk_1");

            entity.HasOne(d => d.User).WithMany(p => p.InteractionAttachments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("InteractionAttachments_ibfk_2");
        });

        modelBuilder.Entity<InteractionType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'");
        });

        modelBuilder.Entity<PaymentStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.StatusName, "StatusName").IsUnique();

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.IsDefault).HasDefaultValueSql("'0'");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.PermissionName, "PermissionName").IsUnique();

            entity.HasIndex(e => new { e.ControllerName, e.ActionName }, "Permissions_index_1");

            entity.HasIndex(e => new { e.ControllerName, e.ActionName, e.PermissionName }, "Permissions_index_2").IsUnique();

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp");
            entity.Property(e => e.Description)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.ProductBrandId, "ProductBrandId");

            entity.HasIndex(e => e.ProductCategoryId, "ProductCategoryId");

            entity.HasIndex(e => e.ProductCode, "ProductCode").IsUnique();

            entity.HasIndex(e => e.ProductUnitId, "ProductUnitId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp");
            entity.Property(e => e.IsActive).HasDefaultValueSql("'1'");
            entity.Property(e => e.ProductBrandId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.ProductCategoryId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.ProductCode).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.ProductDescription)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text");
            entity.Property(e => e.ProductName).HasMaxLength(255);
            entity.Property(e => e.ProductUnitId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.PurchasePrice)
                .HasPrecision(10)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.SalePrice)
                .HasPrecision(10)
                .HasDefaultValueSql("'NULL'");

            entity.HasOne(d => d.ProductBrand).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductBrandId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Products_ibfk_3");

            entity.HasOne(d => d.ProductCategory).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductCategoryId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Products_ibfk_1");

            entity.HasOne(d => d.ProductUnit).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductUnitId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Products_ibfk_2");
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.CategoryName, "CategoryName").IsUnique();

            entity.HasIndex(e => e.ParentCategoryId, "ParentCategoryId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.ParentCategoryId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");

            entity.HasOne(d => d.ParentCategory).WithMany(p => p.InverseParentCategory)
                .HasForeignKey(d => d.ParentCategoryId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("ProductCategories_ibfk_1");
        });

        modelBuilder.Entity<ProductCommission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.ProductId, "ProductId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp");
            entity.Property(e => e.EndDate)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("date");
            entity.Property(e => e.IsActive).HasDefaultValueSql("'1'");
            entity.Property(e => e.ProductId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.Rate).HasPrecision(10);
            entity.Property(e => e.StartDate).HasColumnType("date");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductCommissions)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("ProductCommissions_ibfk_1");
        });

        modelBuilder.Entity<ProductImage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.ProductId, "ProductId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.ImagePath).HasMaxLength(255);
            entity.Property(e => e.IsDefault).HasDefaultValueSql("'0'");
            entity.Property(e => e.ProductId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductImages)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("ProductImages_ibfk_1");
        });

        modelBuilder.Entity<ProductUnit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.UnitName, "UnitName").IsUnique();

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.IsDefault).HasDefaultValueSql("'0'");
        });

        modelBuilder.Entity<PurchaseOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.CurrencyId, "CurrencyId");

            entity.HasIndex(e => e.PurchaseOrderNumber, "PurchaseOrderNumber").IsUnique();

            entity.HasIndex(e => e.PurchaseOrderStatusId, "PurchaseOrderStatusId");

            entity.HasIndex(e => e.RequestForQuotationId, "RequestForQuotationId");

            entity.HasIndex(e => e.SupplierCompanyId, "SupplierCompanyId");

            entity.HasIndex(e => e.SupplierQuotationId, "SupplierQuotationId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp");
            entity.Property(e => e.CurrencyId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.DeliveryTerms)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Description)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text");
            entity.Property(e => e.ExpectedDeliveryDate)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("date");
            entity.Property(e => e.OrderAmount)
                .HasPrecision(10)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.PaymentTerms)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.PurchaseOrderDate)
                .HasDefaultValueSql("'current_timestamp()'")
                .HasColumnType("date");
            entity.Property(e => e.PurchaseOrderStatusId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.RequestForQuotationId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.SupplierCompanyId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.SupplierQuotationId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp");

            entity.HasOne(d => d.Currency).WithMany(p => p.PurchaseOrders)
                .HasForeignKey(d => d.CurrencyId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("PurchaseOrders_ibfk_5");

            entity.HasOne(d => d.PurchaseOrderStatus).WithMany(p => p.PurchaseOrders)
                .HasForeignKey(d => d.PurchaseOrderStatusId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("PurchaseOrders_ibfk_4");

            entity.HasOne(d => d.RequestForQuotation).WithMany(p => p.PurchaseOrders)
                .HasForeignKey(d => d.RequestForQuotationId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("PurchaseOrders_ibfk_2");

            entity.HasOne(d => d.SupplierCompany).WithMany(p => p.PurchaseOrders)
                .HasForeignKey(d => d.SupplierCompanyId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("PurchaseOrders_ibfk_3");

            entity.HasOne(d => d.SupplierQuotation).WithMany(p => p.PurchaseOrders)
                .HasForeignKey(d => d.SupplierQuotationId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("PurchaseOrders_ibfk_1");
        });

        modelBuilder.Entity<PurchaseOrderItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.ProductId, "ProductId");

            entity.HasIndex(e => e.PurchaseOrderId, "PurchaseOrderId");

            entity.HasIndex(e => e.SupplierQuotationItemId, "SupplierQuotationItemId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp");
            entity.Property(e => e.Description)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text");
            entity.Property(e => e.LineAmount)
                .HasPrecision(10)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.OrderedQuantity).HasColumnType("int(11)");
            entity.Property(e => e.ProductId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.PurchaseOrderId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.SupplierQuotationItemId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.UnitPrice).HasPrecision(10);

            entity.HasOne(d => d.Product).WithMany(p => p.PurchaseOrderItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("PurchaseOrderItems_ibfk_3");

            entity.HasOne(d => d.PurchaseOrder).WithMany(p => p.PurchaseOrderItems)
                .HasForeignKey(d => d.PurchaseOrderId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("PurchaseOrderItems_ibfk_1");

            entity.HasOne(d => d.SupplierQuotationItem).WithMany(p => p.PurchaseOrderItems)
                .HasForeignKey(d => d.SupplierQuotationItemId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("PurchaseOrderItems_ibfk_2");
        });

        modelBuilder.Entity<PurchaseOrderStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.StatusName, "StatusName").IsUnique();

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.IsDefault).HasDefaultValueSql("'0'");
        });

        modelBuilder.Entity<PurchaseRequestConsolidation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.ConsolidationNumber, "ConsolidationNumber").IsUnique();

            entity.HasIndex(e => e.ConsolidationStatusId, "ConsolidationStatusId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.ConsolidationDate)
                .HasDefaultValueSql("'current_timestamp()'")
                .HasColumnType("date");
            entity.Property(e => e.ConsolidationStatusId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp");
            entity.Property(e => e.Description)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp");

            entity.HasOne(d => d.ConsolidationStatus).WithMany(p => p.PurchaseRequestConsolidations)
                .HasForeignKey(d => d.ConsolidationStatusId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("PurchaseRequestConsolidations_ibfk_1");
        });

        modelBuilder.Entity<PurchaseRequisition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.DeliveryCompanyAddressId, "DeliveryCompanyAddressId");

            entity.HasIndex(e => e.RequesterCompanyId, "RequesterCompanyId");

            entity.HasIndex(e => e.RequesterUserId, "RequesterUserId");

            entity.HasIndex(e => e.RequisitionNumber, "RequisitionNumber").IsUnique();

            entity.HasIndex(e => e.RequisitionStatusId, "RequisitionStatusId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.ApprovalNotes)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp");
            entity.Property(e => e.DeliveryCompanyAddressId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.Description)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text");
            entity.Property(e => e.RequesterCompanyId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.RequesterUserId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.RequisitionDate)
                .HasDefaultValueSql("'current_timestamp()'")
                .HasColumnType("date");
            entity.Property(e => e.RequisitionStatusId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp");

            entity.HasOne(d => d.DeliveryCompanyAddress).WithMany(p => p.PurchaseRequisitions)
                .HasForeignKey(d => d.DeliveryCompanyAddressId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("PurchaseRequisitions_ibfk_4");

            entity.HasOne(d => d.RequesterCompany).WithMany(p => p.PurchaseRequisitions)
                .HasForeignKey(d => d.RequesterCompanyId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("PurchaseRequisitions_ibfk_2");

            entity.HasOne(d => d.RequesterUser).WithMany(p => p.PurchaseRequisitions)
                .HasForeignKey(d => d.RequesterUserId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("PurchaseRequisitions_ibfk_1");

            entity.HasOne(d => d.RequisitionStatus).WithMany(p => p.PurchaseRequisitions)
                .HasForeignKey(d => d.RequisitionStatusId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("PurchaseRequisitions_ibfk_3");
        });

        modelBuilder.Entity<PurchaseRequisitionConsolidationItemsLink>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("PurchaseRequisitionConsolidationItemsLink");

            entity.HasIndex(e => e.ConsolidatedRequisitionItemId, "ConsolidatedRequisitionItemId");

            entity.HasIndex(e => new { e.RequisitionItemId, e.ConsolidatedRequisitionItemId }, "PurchaseRequisitionConsolidationItemsLink_index_5").IsUnique();

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.ConsolidatedRequisitionItemId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp");
            entity.Property(e => e.Quantity).HasColumnType("int(11)");
            entity.Property(e => e.RequisitionItemId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");

            entity.HasOne(d => d.ConsolidatedRequisitionItem).WithMany(p => p.PurchaseRequisitionConsolidationItemsLinks)
                .HasForeignKey(d => d.ConsolidatedRequisitionItemId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("PurchaseRequisitionConsolidationItemsLink_ibfk_2");

            entity.HasOne(d => d.RequisitionItem).WithMany(p => p.PurchaseRequisitionConsolidationItemsLinks)
                .HasForeignKey(d => d.RequisitionItemId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("PurchaseRequisitionConsolidationItemsLink_ibfk_1");
        });

        modelBuilder.Entity<QuotationApprovalStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.StatusName, "StatusName").IsUnique();

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.IsDefault).HasDefaultValueSql("'0'");
        });

        modelBuilder.Entity<RequestForQuotation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.Rfqnumber, "RFQNumber").IsUnique();

            entity.HasIndex(e => e.RfqstatusId, "RFQStatusId");

            entity.HasIndex(e => new { e.PurchaseRequestConsolidationId, e.SupplierCompanyId }, "RequestForQuotations_index_6").IsUnique();

            entity.HasIndex(e => e.SupplierCompanyId, "SupplierCompanyId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp");
            entity.Property(e => e.Description)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text");
            entity.Property(e => e.PurchaseRequestConsolidationId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.ResponseDueDate)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("date");
            entity.Property(e => e.Rfqdate)
                .HasDefaultValueSql("'current_timestamp()'")
                .HasColumnType("date")
                .HasColumnName("RFQDate");
            entity.Property(e => e.Rfqnumber).HasColumnName("RFQNumber");
            entity.Property(e => e.RfqstatusId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("RFQStatusId");
            entity.Property(e => e.SentDate)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp");
            entity.Property(e => e.SupplierCompanyId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp");

            entity.HasOne(d => d.PurchaseRequestConsolidation).WithMany(p => p.RequestForQuotations)
                .HasForeignKey(d => d.PurchaseRequestConsolidationId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("RequestForQuotations_ibfk_1");

            entity.HasOne(d => d.Rfqstatus).WithMany(p => p.RequestForQuotations)
                .HasForeignKey(d => d.RfqstatusId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("RequestForQuotations_ibfk_3");

            entity.HasOne(d => d.SupplierCompany).WithMany(p => p.RequestForQuotations)
                .HasForeignKey(d => d.SupplierCompanyId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("RequestForQuotations_ibfk_2");
        });

        modelBuilder.Entity<RequestForQuotationItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.ConsolidatedRequisitionItemId, "ConsolidatedRequisitionItemId");

            entity.HasIndex(e => e.RequestForQuotationId, "RequestForQuotationId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.ConsolidatedRequisitionItemId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp");
            entity.Property(e => e.Description)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text");
            entity.Property(e => e.Quantity).HasColumnType("int(11)");
            entity.Property(e => e.RequestForQuotationId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");

            entity.HasOne(d => d.ConsolidatedRequisitionItem).WithMany(p => p.RequestForQuotationItems)
                .HasForeignKey(d => d.ConsolidatedRequisitionItemId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("RequestForQuotationItems_ibfk_2");

            entity.HasOne(d => d.RequestForQuotation).WithMany(p => p.RequestForQuotationItems)
                .HasForeignKey(d => d.RequestForQuotationId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("RequestForQuotationItems_ibfk_1");
        });

        modelBuilder.Entity<RequestForQuotationStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.StatusName, "StatusName").IsUnique();

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.IsDefault).HasDefaultValueSql("'0'");
        });

        modelBuilder.Entity<RequisitionItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.ProductId, "ProductId");

            entity.HasIndex(e => e.PurchaseRequisitionId, "PurchaseRequisitionId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Description)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text");
            entity.Property(e => e.ProductId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.PurchaseRequisitionId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.Quantity)
                .HasDefaultValueSql("'1'")
                .HasColumnType("int(11)");

            entity.HasOne(d => d.Product).WithMany(p => p.RequisitionItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("RequisitionItems_ibfk_2");

            entity.HasOne(d => d.PurchaseRequisition).WithMany(p => p.RequisitionItems)
                .HasForeignKey(d => d.PurchaseRequisitionId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("RequisitionItems_ibfk_1");
        });

        modelBuilder.Entity<RequisitionStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.StatusName, "StatusName").IsUnique();

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.IsDefault).HasDefaultValueSql("'0'");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.RoleName, "RoleName").IsUnique();

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp");
            entity.Property(e => e.Description)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text");
            entity.Property(e => e.IsActive).HasDefaultValueSql("'1'");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp");
        });

        modelBuilder.Entity<RolePermission>(entity =>
        {
            entity.HasNoKey();

            entity.HasIndex(e => e.PermissionId, "PermissionId");

            entity.HasIndex(e => new { e.RoleId, e.PermissionId }, "RolePermissions_index_0").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp");
            entity.Property(e => e.PermissionId).HasColumnType("int(11)");
            entity.Property(e => e.RoleId).HasColumnType("int(11)");

            entity.HasOne(d => d.Permission).WithMany()
                .HasForeignKey(d => d.PermissionId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("RolePermissions_ibfk_2");

            entity.HasOne(d => d.Role).WithMany()
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("RolePermissions_ibfk_1");
        });

        modelBuilder.Entity<ShipmentTracking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("ShipmentTracking");

            entity.HasIndex(e => e.CarrierCompanyId, "CarrierCompanyId");

            entity.HasIndex(e => e.PurchaseOrderId, "PurchaseOrderId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CarrierCompanyId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp");
            entity.Property(e => e.EstimatedDeliveryDate)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("date");
            entity.Property(e => e.Notes)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text");
            entity.Property(e => e.PurchaseOrderId).HasColumnType("int(11)");
            entity.Property(e => e.ShipmentDate)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("date");
            entity.Property(e => e.TrackingNumber).HasMaxLength(255);
            entity.Property(e => e.TrackingUrl)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp");

            entity.HasOne(d => d.CarrierCompany).WithMany(p => p.ShipmentTrackings)
                .HasForeignKey(d => d.CarrierCompanyId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("ShipmentTracking_ibfk_2");

            entity.HasOne(d => d.PurchaseOrder).WithMany(p => p.ShipmentTrackings)
                .HasForeignKey(d => d.PurchaseOrderId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("ShipmentTracking_ibfk_1");
        });

        modelBuilder.Entity<SmsMessage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.CompanyId, "CompanyId");

            entity.HasIndex(e => e.ContactId, "ContactId");

            entity.HasIndex(e => e.UserId, "UserId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CompanyId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.ContactId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp");
            entity.Property(e => e.Direction)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.MessageText).HasColumnType("text");
            entity.Property(e => e.PhoneNumber).HasMaxLength(255);
            entity.Property(e => e.ProviderMessageId)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.ReceivedDate)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("datetime");
            entity.Property(e => e.SentDate)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.UserId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");

            entity.HasOne(d => d.Company).WithMany(p => p.SmsMessages)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("SmsMessages_ibfk_1");

            entity.HasOne(d => d.Contact).WithMany(p => p.SmsMessages)
                .HasForeignKey(d => d.ContactId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("SmsMessages_ibfk_2");

            entity.HasOne(d => d.User).WithMany(p => p.SmsMessages)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("SmsMessages_ibfk_3");
        });

        modelBuilder.Entity<SupplierProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.CurrencyId, "CurrencyId");

            entity.HasIndex(e => e.SupplierCompanyId, "SupplierCompanyId");

            entity.HasIndex(e => new { e.ProductId, e.SupplierCompanyId }, "SupplierProducts_index_3").IsUnique();

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp");
            entity.Property(e => e.CurrencyId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.DiscountRates)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text");
            entity.Property(e => e.IsActive).HasDefaultValueSql("'1'");
            entity.Property(e => e.LeadTime)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Moq)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("MOQ");
            entity.Property(e => e.Notes)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text");
            entity.Property(e => e.ProductId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.SupplierCompanyId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.SupplierPrice)
                .HasPrecision(10)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.SupplierProductCode)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'");

            entity.HasOne(d => d.Currency).WithMany(p => p.SupplierProducts)
                .HasForeignKey(d => d.CurrencyId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("SupplierProducts_ibfk_3");

            entity.HasOne(d => d.Product).WithMany(p => p.SupplierProducts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("SupplierProducts_ibfk_1");

            entity.HasOne(d => d.SupplierCompany).WithMany(p => p.SupplierProducts)
                .HasForeignKey(d => d.SupplierCompanyId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("SupplierProducts_ibfk_2");
        });

        modelBuilder.Entity<SupplierQuotation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.CurrencyId, "CurrencyId");

            entity.HasIndex(e => e.QuotationApprovalStatusId, "QuotationApprovalStatusId");

            entity.HasIndex(e => e.QuotationNumber, "QuotationNumber").IsUnique();

            entity.HasIndex(e => e.QuotationStatusId, "QuotationStatusId");

            entity.HasIndex(e => e.SupplierCompanyId, "SupplierCompanyId");

            entity.HasIndex(e => new { e.RequestForQuotationId, e.SupplierCompanyId }, "SupplierQuotations_index_7").IsUnique();

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp");
            entity.Property(e => e.CurrencyId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.DeliveryTerms)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.ExpirationDate)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("date");
            entity.Property(e => e.Notes)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text");
            entity.Property(e => e.PaymentTerms)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.QuotationApprovalStatusId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.QuotationDate)
                .HasDefaultValueSql("'current_timestamp()'")
                .HasColumnType("date");
            entity.Property(e => e.QuotationStatusId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.RequestForQuotationId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.SubmissionDate)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp");
            entity.Property(e => e.SupplierCompanyId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp");

            entity.HasOne(d => d.Currency).WithMany(p => p.SupplierQuotations)
                .HasForeignKey(d => d.CurrencyId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("SupplierQuotations_ibfk_5");

            entity.HasOne(d => d.QuotationApprovalStatus).WithMany(p => p.SupplierQuotations)
                .HasForeignKey(d => d.QuotationApprovalStatusId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("SupplierQuotations_ibfk_6");

            entity.HasOne(d => d.QuotationStatus).WithMany(p => p.SupplierQuotations)
                .HasForeignKey(d => d.QuotationStatusId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("SupplierQuotations_ibfk_4");

            entity.HasOne(d => d.RequestForQuotation).WithMany(p => p.SupplierQuotations)
                .HasForeignKey(d => d.RequestForQuotationId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("SupplierQuotations_ibfk_1");

            entity.HasOne(d => d.SupplierCompany).WithMany(p => p.SupplierQuotations)
                .HasForeignKey(d => d.SupplierCompanyId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("SupplierQuotations_ibfk_2");
        });

        modelBuilder.Entity<SupplierQuotationItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.RequestForQuotationItemId, "RequestForQuotationItemId");

            entity.HasIndex(e => e.SupplierQuotationId, "SupplierQuotationId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp");
            entity.Property(e => e.IsOffered)
                .IsRequired()
                .HasDefaultValueSql("'1'");
            entity.Property(e => e.LeadTime)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Notes)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text");
            entity.Property(e => e.OfferedPrice)
                .HasPrecision(10)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.OfferedQuantity).HasColumnType("int(11)");
            entity.Property(e => e.RequestForQuotationItemId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.SupplierProductCode)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.SupplierQuotationId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");

            entity.HasOne(d => d.RequestForQuotationItem).WithMany(p => p.SupplierQuotationItems)
                .HasForeignKey(d => d.RequestForQuotationItemId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("SupplierQuotationItems_ibfk_2");

            entity.HasOne(d => d.SupplierQuotation).WithMany(p => p.SupplierQuotationItems)
                .HasForeignKey(d => d.SupplierQuotationId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("SupplierQuotationItems_ibfk_1");
        });

        modelBuilder.Entity<SupplierQuotationStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.StatusName, "StatusName").IsUnique();

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.IsDefault).HasDefaultValueSql("'0'");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.CompanyId, "CompanyId");

            entity.HasIndex(e => e.ContactId, "ContactId");

            entity.HasIndex(e => e.InteractionId, "InteractionId");

            entity.HasIndex(e => e.UserId, "UserId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CompanyId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.ContactId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp");
            entity.Property(e => e.DueDate)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("datetime");
            entity.Property(e => e.InteractionId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.IsCompleted).HasDefaultValueSql("'0'");
            entity.Property(e => e.TaskDescription)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text");
            entity.Property(e => e.TaskTitle).HasMaxLength(255);
            entity.Property(e => e.UserId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");

            entity.HasOne(d => d.Company).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Tasks_ibfk_3");

            entity.HasOne(d => d.Contact).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.ContactId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Tasks_ibfk_2");

            entity.HasOne(d => d.Interaction).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.InteractionId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Tasks_ibfk_4");

            entity.HasOne(d => d.User).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Tasks_ibfk_1");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.CompanyId, "CompanyId");

            entity.HasIndex(e => e.ContactId, "ContactId").IsUnique();

            entity.HasIndex(e => e.Email, "Email").IsUnique();

            entity.HasIndex(e => e.PhoneNumber, "PhoneNumber").IsUnique();

            entity.HasIndex(e => e.RoleId, "RoleId");

            entity.HasIndex(e => e.Username, "Username").IsUnique();

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CompanyId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.ContactId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'current_timestamp()'")
                .HasColumnType("timestamp");
            entity.Property(e => e.Email).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.EmailVerifiedAt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp");
            entity.Property(e => e.IsEmailVerified).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.IsPhoneVerified).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.PhoneVerifiedAt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp");
            entity.Property(e => e.RoleId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.TwoFactorSecret)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'");

            entity.HasOne(d => d.Company).WithMany(p => p.Users)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Users_ibfk_2");

            entity.HasOne(d => d.Contact).WithOne(p => p.User)
                .HasForeignKey<User>(d => d.ContactId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Users_ibfk_3");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Users_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
