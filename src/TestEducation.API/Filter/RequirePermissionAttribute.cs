using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TestEducation.Aplication.Service;
using TestEducation.Data;
using TestEducation.Domain.Enums;

namespace TestEducation.Filter
{
    public class RequirePermissionAttribute : Attribute, IAuthorizationFilter
    {
        private readonly PermissionEnum[] _permissions;

        public RequirePermissionAttribute(params PermissionEnum[] permissions)
        {
            _permissions = permissions;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // 1️ User claimdan ID olish
            var userIdClaim = context.HttpContext.User.Claims
                          .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var userId = int.Parse(userIdClaim.Value);

            // 2️ Servisdan foydalanuvchining ruxsatlarini olish
            var permissionService = context.HttpContext.RequestServices.GetRequiredService<IPermissionService>();

            // 3️ Har bir kerakli permissionni tekshirish
            foreach (var requiredPermission in _permissions)
            {
                bool hasPermission = permissionService.HasPermissionAsync(userId, requiredPermission.ToString()).Result;
                if (!hasPermission)
                {
                    context.Result = new ForbidResult();
                    return;
                }
            }
        }
    }
}
