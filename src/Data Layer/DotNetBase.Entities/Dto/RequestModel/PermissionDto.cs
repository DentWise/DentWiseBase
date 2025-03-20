using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBase.Entities.Dto.RequestModel
{
    public class CreatePermission
    {
        public string PermissionName { get; set; } = null!;
        public string ControllerName { get; set; } = null!;
        public string ActionName { get; set; } = null!;
        public string? Description { get; set; }
    }
}
