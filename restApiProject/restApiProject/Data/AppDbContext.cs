using ClassLibraryModels;
using Microsoft.EntityFrameworkCore;


namespace restApiProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee_Project>().HasKey(am => new
            {
                am.EmployeeId,
                am.ProjectId
            });

            CreatePasswordHash2("admin123", out byte[] passwordHash, out byte[] passwordSalt);
            modelBuilder.Entity<User>().HasData(
                new User { Id = 2, Name = "name", Lastname = "lastname", Username = "administrator", EmailAddress = "null", Role = "Administrator", PasswordHash = passwordHash, PasswordSalt = passwordSalt }
                );
        }



        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Taskk> Tasks { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Employee_Project> Employee_Projects { get; set; }


        private void CreatePasswordHash2(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }


    }
}
