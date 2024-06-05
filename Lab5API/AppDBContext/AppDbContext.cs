using Lab5API.Model;
using Microsoft.EntityFrameworkCore;

namespace Lab5API.AppDBContext
{
    public class AppDbContext: DbContext 
    {
        public AppDbContext()
        {
            
        }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<NhanVien> nhanViens { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = MSI\\SQLEXPRESS; Initial Catalog = Lab5; Trusted_Connection = True; Integrated Security = True; TrustServerCertificate = True");
        }
    }
}
