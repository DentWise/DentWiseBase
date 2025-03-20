using System;
using System.Collections.Generic;

namespace DotNetBase.EFCore.Entities;

public partial class DoctorDetail
{
    public int UserId { get; set; }
    public string DiplomaNumber { get; set; } = null!;
    public string ChamberRegistrationNumber { get; set; } = null!;
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public virtual User User { get; set; } = null!;
}
