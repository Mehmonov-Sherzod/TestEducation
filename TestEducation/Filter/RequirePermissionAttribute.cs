using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Filters;
using TestEducation.Data;
using TestEducation.Models.Enum;

namespace TestEducation.Filter
{
    public class RequirePermissionAttribute : Attribute , IAuthorizationFilter 
    {
        private readonly PermissionEnum[] _permissionEnums;

        public RequirePermissionAttribute(params PermissionEnum [] permissions)
        {
            _permissionEnums  = permissions;
        }
        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            var userId = filterContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                filterContext.Result = new ForbidResult();
                return;
            }


            var dbContext = filterContext .HttpContext.RequestServices.GetService<AppDbContext>();
            var userPermissions = dbContext.permissions;

        }
    }
}
