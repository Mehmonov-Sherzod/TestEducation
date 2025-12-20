namespace TestEducation.Aplication.Service
{
    public interface IPermissionService
    {
        Task<bool> HasPermissionAsync(Guid userId, string permissionName);
    }
}
