using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestEducation.Data;

namespace TestEducation.Aplication.Service.Impl
{
    public class PermissionService : IPermissionService
    {
        private readonly AppDbContext _appDbContext;

        public PermissionService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<bool> HasPermissionAsync(int userId, string permissionName)
        {
            return await _appDbContext.UserRoles
                .Where(u => u.UserId == userId)
                .SelectMany(r => r.Role.RolePermissions)
                .AnyAsync(rp => rp.Permission.Name == permissionName);
        }
    }
}
