using Microsoft.EntityFrameworkCore;
using TestEducation.Domain.Entities;
using TestEducation.Models;

namespace TestEducation.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<UserQuestion> UserQuestions { get; set; }
        public DbSet<UserQuestionAnswer> UserQuestionsAnswer { get; set; }
        public DbSet<TestProcess> testProcesses { get; set; }
        public DbSet<UserOTPs> userOTPs  { get; set; }
        public DbSet<SubjectTranslate> subjectTranslates { get; set; }
        public DbSet<QuestionTranslation> questionTranslations { get; set; }
        public DbSet<Topic> topics { get; set; }    

        public DbSet<SharedSource> sharedSources { get; set; }  


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            modelBuilder.Entity<RolePermission>()
                .HasKey(rp => new { rp.RoleId, rp.PermissionId });

            modelBuilder.Entity<UserRole>()
               .HasKey(rp => new { rp.RoleId, rp.UserId });

            modelBuilder.Entity<UserQuestion>()
                .HasKey(rp => new { rp.UserId, rp.QuestionId });
        }
    }
}

