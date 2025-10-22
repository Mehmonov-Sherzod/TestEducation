using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Filters;
using TestEducation.Data;
using TestEducation.Domain.Enums;

namespace TestEducation.Filter
{
    public class RequirePermissionAttribute : Attribute , IAuthorizationFilter 
    {
        private readonly PermissionEnum[] _permissionEnums;

        public RequirePermissionAttribute(params PermissionEnum [] permissions)
        {
            _permissionEnums  = permissions;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var userId = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            //var permissionService = context.HttpContext.RequestServices.GetRequiredService<IUserPermissionService>();
            //var userPermissions = permissionService.GetUserPermissions(userId);

            //bool hasPermission = _permissions.Any(p => userPermissions.Contains(p));

            //if (!hasPermission)
            //{
            //    context.Result = new ForbidResult();
            //    return;
            //}
        }
    }
}
