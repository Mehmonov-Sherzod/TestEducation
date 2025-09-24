using Microsoft.EntityFrameworkCore;
using TestEducation.Models;

namespace TestEducation.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<AnswerOption> Answers { get; set; }

        public DbSet<Permission> permissions { get; set; }

        public DbSet<Question> question { get; set; }   

        public DbSet<Role> roles { get; set; }  

        public DbSet<RolePermission> rolePermissions { get; set; }

        public DbSet<Test> tests { get; set; }  

        public DbSet<User> users { get; set; }  

        public DbSet<UserRole> userRoles { get; set; }  

        public DbSet<UserTest> userTests { get; set; }      
        

        public DbSet<Subject> subjects { get; set; }        



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = "Host=localhost;Username=postgres;Password=Sherzod3466;Database=TestEducation";

            optionsBuilder.UseNpgsql(path);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RolePermission>()
                .HasKey(rp => new { rp.RoleId, rp.PermissionId });

            modelBuilder.Entity<UserRole>()
               .HasKey(rp => new { rp.RoleId, rp.UserId });

            modelBuilder.Entity<UserTest>()
               .HasKey(rp => new { rp.TestId, rp.UserId });

            // deletebehavior  nimaar qiladi   
            // 1].cascade primary key ochkandan keyin primary key ochadi
            // 2].settnull primary key ochkandan keyin forenkey null boladi
            // 3].restrict forenkey bolsa primary key ochmaydi oldin forenkey ochish kere





        }

    }
}

