using DotNetBase.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace DotNetBase.Entities.Entities.Crm;

public partial class CompanySegment : BaseEntity, ISoftDeletable
{

    public string SegmentName { get; set; } = null!;
    public string? Description { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<CompanySegmentMember> CompanySegmentMembers { get; set; } = new List<CompanySegmentMember>();
}
