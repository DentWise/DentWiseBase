using DotNetBase.Business.Identity.Interfaces;
using DotNetBase.EFCore.Entities;
using DotNetBase.EFCore.UnitOfWork;
using DotNetBase.Entities.Dto.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace DotNetBase.Business.Identity.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PermissionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Permission> CreatePermissionAsync(CreatePermission createPermission)
        {
            if (createPermission.ControllerName == null)
                throw new Exception("ControllerName can not be null!");

            var permission = new Permission
            {
                ControllerName = createPermission.ControllerName,
                ActionName = createPermission.ActionName,
                CreatedAt = DateTime.UtcNow,
                Description = createPermission.Description,
                PermissionName = createPermission.PermissionName
            };

            await _unitOfWork.PermissionRepository.AddAsync(permission);
            await _unitOfWork.CompleteAsync();

            return permission;
        }

        public async Task DeletePermissionAsync(int id)
        {
            var permission = await _unitOfWork.PermissionRepository.GetByIdAsync(id);
            if (permission == null)
                throw new Exception("Permission not found!");

            permission.IsDeleted = true;
            permission.DeletedAt = DateTime.UtcNow;

            _unitOfWork.PermissionRepository.Update(permission);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<Permission>> GetAllPermissionAsync()
        {
            var permission = await _unitOfWork.PermissionRepository.FindManyAsync(u => !u.IsDeleted);
            if (permission == null)
                throw new Exception("Permission does not have any object!");

            return permission;
        }

        public async Task<Permission> GetPermissionByIdAsync(int id)
        {
            var permission = await _unitOfWork.PermissionRepository.GetByIdAsync(id);
            if (permission == null || permission.IsDeleted)
                throw new Exception("Object not found!!");

            return permission;
        }
    }
}
