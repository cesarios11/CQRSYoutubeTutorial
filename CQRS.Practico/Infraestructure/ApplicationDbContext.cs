using CQRS.Practico.Domain;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Practico.Infraestructure
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<TaskItem> TaskItems { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                
        }
    }
}
