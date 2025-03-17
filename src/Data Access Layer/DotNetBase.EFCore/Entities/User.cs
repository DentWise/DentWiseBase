using System;
using System.Collections.Generic;

namespace DotNetBase.EFCore.Entities;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? Email { get; set; }

    public DateTime? EmailVerifiedAt { get; set; }

    public bool? IsEmailVerified { get; set; }

    public string? PhoneNumber { get; set; }

    public DateTime? PhoneVerifiedAt { get; set; }

    public bool? IsPhoneVerified { get; set; }

    public bool IsActive { get; set; }

    public bool TwoFactorEnabled { get; set; }

    public string? TwoFactorSecret { get; set; }

    public DateTime CreatedAt { get; set; }

    public int? RoleId { get; set; }

    public int? CompanyId { get; set; }

    public int? ContactId { get; set; }

    public virtual Company? Company { get; set; }

    public virtual ICollection<CompanyInteraction> CompanyInteractions { get; set; } = new List<CompanyInteraction>();

    public virtual ICollection<CompanyNote> CompanyNotes { get; set; } = new List<CompanyNote>();

    public virtual ICollection<CompanySegmentMember> CompanySegmentMembers { get; set; } = new List<CompanySegmentMember>();

    public virtual Contact? Contact { get; set; }

    public virtual DoctorDetail? DoctorDetail { get; set; }

    public virtual ICollection<EmailThread> EmailThreads { get; set; } = new List<EmailThread>();

    public virtual ICollection<InteractionAttachment> InteractionAttachments { get; set; } = new List<InteractionAttachment>();

    public virtual ICollection<PurchaseRequisition> PurchaseRequisitions { get; set; } = new List<PurchaseRequisition>();

    public virtual Role? Role { get; set; }

    public virtual ICollection<SmsMessage> SmsMessages { get; set; } = new List<SmsMessage>();

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
