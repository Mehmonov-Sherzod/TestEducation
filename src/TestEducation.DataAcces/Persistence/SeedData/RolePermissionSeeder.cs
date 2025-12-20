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

            var dbPermissions = _appDbContext.Permissions.ToList();

            foreach (var dbPerm in dbPermissions)
            {
                var result = permissions.Any(e => e.Name == dbPerm.Name);
                if (!result)
                {
                    _appDbContext.Permissions.Remove(dbPerm);
                }
            }

            foreach (var perm in permissions)
            {
                if (!_appDbContext.Permissions.Any(x => x.Name == perm.Name))
                    _appDbContext.Permissions.Add(perm);
            }

            _appDbContext.SaveChanges();

            List<Guid> role = _appDbContext.Roles.Select(x => x.Id).ToList();
            List<Guid> Permissions = _appDbContext.Permissions.Select(x => x.Id).ToList();
            HashSet<Guid> PermissionId1 = _appDbContext.RolePermissions.Where(x => x.RoleId == Guid.Parse("00000011-0000-0000-0000-000000000001")).Select(x => x.PermissionId).ToHashSet();
            HashSet<Guid> PermissionId2 = _appDbContext.RolePermissions.Where(x => x.RoleId == Guid.Parse("00000012-0000-0000-0000-000000000001")).Select(x => x.PermissionId).ToHashSet();

            foreach (var roles in role)
            {
                if (roles == Guid.Parse("00000011-0000-0000-0000-000000000001"))
                {
                    foreach (var permission in Permissions)
                    {
                        RolePermission rolePermission = new RolePermission
                        {
                            RoleId = roles,
                            PermissionId = permission,
                        };
                        if (!PermissionId1.Contains(permission))
                        {
                            _appDbContext.RolePermissions.Add(rolePermission);
                        }
                    }
                }

                if (roles == Guid.Parse("00000012-0000-0000-0000-000000000001"))
                {
                    var allPermissions = _appDbContext.Permissions.ToList();
                    foreach (var permission in allPermissions)
                    {
                        if (permission.Name == "ManageUsersStudent" ||
                            permission.Name == "ManageTests" ||
                            permission.Name == "ManageSubjects" ||
                            permission.Name == "ManageQuestions" ||
                            permission.Name == "ViewResults" ||
                            permission.Name == "TakeTest" ||
                            permission.Name == "ViewOwnResults" ||
                            permission.Name == "ViewAvailableTests" ||
                            permission.Name == "ManageTopics"
                            )
                        {
                            RolePermission rolePermission = new RolePermission
                            {
                                RoleId = roles,
                                PermissionId = permission.Id,
                            };
                            if (!PermissionId2.Contains(permission.Id))
                            {
                                _appDbContext.RolePermissions.Add(rolePermission);
                            }
                        }
                    }
                }
                _appDbContext.SaveChanges();
            }
        }
    }
}

