namespace TestEducation.Domain.Enums
{
    public enum  PermissionEnum
    {
        // SuperAdmin permissions
        ManageUsers,
        ManageAdmins,
        SystemSettings,

        // Admin permissions
        ManageUsersStudent,
        ManageTests,
        ManageSubjects,
        ManageQuestions,
        ViewResults,

        // Student permissions
        TakeTest,
        ViewOwnResults,
        ViewAvailableTests
    }
}
