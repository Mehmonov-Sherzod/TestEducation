
using TestEducation.Data;
using TestEducation.Domain.Enums;
using TestEducation.Models;

namespace TestEducation.Aplication.Helpers.SeedData
{
    public class RolePermissionSeeder
    {
        private readonly AppDbContext _appDbContext;

        public RolePermissionSeeder(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public void SeedMapping()
        {

            var permissions = Enum.GetValues(typeof(PermissionEnum))
                 .Cast<PermissionEnum>()
                 .Select(p => new Permission
                 {
                     Name = p.ToString(),
                     Description = p + " permission"
                 }).ToList();

            foreach (var perm in permissions)
            {
                if (!_appDbContext.Permissions.Any(x => x.Name == perm.Name))
                    _appDbContext.Permissions.Add(perm);
            }

            _appDbContext.SaveChanges();

            List<int> role = _appDbContext.Roles.Select(x => x.Id).ToList();
            List<int> Permissions = _appDbContext.Permissions.Select(x => x.Id).ToList();
            HashSet<int> RolePermission = _appDbContext.RolePermissions.Select(x => x.RoleId).ToHashSet();

            foreach (var roles in role)
            {
                if (!RolePermission.Contains(roles))
                {
                    if (roles == 1)
                    {
                        foreach (var permission in Permissions)
                        {
                            RolePermission rolePermission = new RolePermission
                            {
                                RoleId = roles,
                                PermissionId = permission,
                            };
                            _appDbContext.RolePermissions.Add(rolePermission);
                        }
                    }

                    if (roles == 2)
                    {
                        foreach (var permission in Permissions)
                        {
                            if (permission >= 6 && permission <= 9)
                            {
                                RolePermission rolePermission = new RolePermission
                                {
                                    RoleId = roles,
                                    PermissionId = permission,
                                };

                                _appDbContext.RolePermissions.Add(rolePermission);
                            }
                        }
                    }
                }
            }
        }
    }
}
