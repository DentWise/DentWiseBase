using DotNetBase.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace DotNetBase.Entities.Entities.Identity;

public partial class Permission : BaseEntity, ISoftDeletable
{
    public string PermissionName { get; set; } = null!;
    public string ControllerName { get; set; } = null!;
    public string ActionName { get; set; } = null!;
    public string? Description { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedAt { get; set; }
}
