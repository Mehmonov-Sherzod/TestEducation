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
        public DbSet<UserQuestion> UserQuestions { get; set; }
        public DbSet<UserQuestionAnswer> UserQuestionsAnswer { get; set; }
        public DbSet<TestProcess> TestProcesses { get; set; }
        public DbSet<UserOTPs> UserOTPs  { get; set; }
        public DbSet<SubjectTranslate> SubjectTranslates { get; set; }
        public DbSet<Topic> Topics { get; set; }    
        public DbSet<UserBalance> UserBalances { get; set; }
        public DbSet<SharedSource> SharedSources { get; set; }  
        public DbSet<BalanceTransaction> BalanceTransactions { get; set; }
        public DbSet<UserSharedSource> UserSharedSources   { get; set; }


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

