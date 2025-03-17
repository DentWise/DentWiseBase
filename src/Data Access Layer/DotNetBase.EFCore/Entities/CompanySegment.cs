using System;
using System.Collections.Generic;

namespace DotNetBase.EFCore.Entities;

public partial class CompanySegment
{
    public int Id { get; set; }

    public string SegmentName { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<CompanySegmentMember> CompanySegmentMembers { get; set; } = new List<CompanySegmentMember>();
}
