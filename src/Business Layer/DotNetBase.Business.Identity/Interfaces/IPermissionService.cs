using DotNetBase.EFCore.Entities;
using DotNetBase.Entities.Dto.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace DotNetBase.Business.Identity.Interfaces
{
    public interface IPermissionService
    {
        Task<IEnumerable<Permission>> GetAllPermissionAsync();
        Task<Permission> GetPermissionByIdAsync(int id);
        Task<Permission> CreatePermissionAsync(CreatePermission createPermission);
        Task DeletePermissionAsync(int id);
    }
}
