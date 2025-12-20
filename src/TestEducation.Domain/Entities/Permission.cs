namespace TestEducation.Models
{
    public class Permission
    {
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public List<RolePermission> RolePermissions { get; set; }
    }
}
