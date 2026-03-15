using Microsoft.EntityFrameworkCore;
using cinisatissitesi.Models;
namespace cinisatissitesi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cini> Ciniler { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }
    }
}