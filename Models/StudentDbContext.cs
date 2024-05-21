using Microsoft.EntityFrameworkCore;

namespace StudentRegisterFormAPI.Models
{
    public class StudentDbContext : DbContext
    {

        public StudentDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=.; initial Catalog=lbs; User Id=sa; password=123; TrustServerCertificate= True");
        //}
    }
}
