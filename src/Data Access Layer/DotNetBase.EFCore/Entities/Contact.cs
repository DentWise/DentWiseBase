using System;
using System.Collections.Generic;

namespace DotNetBase.EFCore.Entities;

public partial class Contact
{
    public int Id { get; set; }

    public int? CompanyId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Position { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Company? Company { get; set; }

    public virtual ICollection<CompanyInteraction> CompanyInteractions { get; set; } = new List<CompanyInteraction>();

    public virtual ICollection<EmailThread> EmailThreads { get; set; } = new List<EmailThread>();

    public virtual ICollection<SmsMessage> SmsMessages { get; set; } = new List<SmsMessage>();

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();

    public virtual User? User { get; set; }
}
