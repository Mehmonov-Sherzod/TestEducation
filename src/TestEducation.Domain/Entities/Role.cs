namespace TestEducation.Models
{
    public class Role
    {
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public List<UserRole> UserRoles { get; set; }
        public List<RolePermission> RolePermissions { get; set; }
    }
}
