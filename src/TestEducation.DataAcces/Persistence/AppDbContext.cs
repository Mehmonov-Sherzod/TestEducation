using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
        public DbSet<UserTestResult> UserTestResult { get; set; }

 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
       //     modelBuilder.Entity<Question>()
       //.HasMany(q => q.Answers)
       //.WithOne(a => a.Question)
       //.HasForeignKey(a => a.QuestionId)
       //.OnDelete(DeleteBehavior.Cascade);
       //     modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RolePermission>()
                .HasKey(rp => new { rp.RoleId, rp.PermissionId });

            modelBuilder.Entity<UserRole>()
               .HasKey(rp => new { rp.RoleId, rp.UserId });

            modelBuilder.Entity<UserQuestion>()
                .HasKey(rp => new { rp.UserId, rp.QuestionId });

            //bu qismida Question ochkandan keyin avtomadtik unga boglangan savollar ham ochadi
            //modelBuilder.Entity<Answer>()
            //   .HasOne(a => a.Question)
            //   .WithMany(q => q.AnswerOptions)
            //   .HasForeignKey(a => a.QuestionId)
            //   .OnDelete(DeleteBehavior.Cascade);


            // deletebehavior  nimaar qiladi   
            // 1].cascade primary key ochkandan keyin primary key ochadi
            // 2].settnull primary key ochkandan keyin forenkey null boladi
            // 3].restrict forenkey bolsa primary key ochmaydi oldin forenkey ochish kere


            modelBuilder.Entity<Question>()
          .Property(q => q.Level)
          .HasConversion<string>();

            modelBuilder.Entity<Role>()
                .HasData(
                new Role { Id = 1, Name = "Admin", Description = "Barcha tizimdi boshqaradiga admin rol" },
                new Role { Id = 2, Name = "Student", Description = "Test yechish va natija korish" }

                );

        }

    }
}

