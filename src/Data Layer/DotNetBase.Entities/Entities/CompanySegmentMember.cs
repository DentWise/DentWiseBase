﻿using DotNetBase.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace DotNetBase.EFCore.Entities;

public partial class CompanySegmentMember : BaseEntity, ISoftDeletable
{
    public int CompanyId { get; set; }
    public int CompanySegmentId { get; set; }
    public DateTime? AddedAt { get; set; }
    public int? UserId { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedAt { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual CompanySegment CompanySegment { get; set; } = null!;

    public virtual User? User { get; set; }
}
