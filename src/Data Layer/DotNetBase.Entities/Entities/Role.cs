using DotNetBase.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace DotNetBase.EFCore.Entities;

public partial class Role : BaseEntity
{

    public string RoleName { get; set; } = null!;

    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
