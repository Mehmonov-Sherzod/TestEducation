namespace TestEducation.Aplication.Service
{
    public interface IPermissionService
    {
        Task<bool> HasPermissionAsync(int userId, string permissionName);
    }
}
