using IntegracionesApi.Model;
using Microsoft.EntityFrameworkCore;

namespace IntegracionesApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }       
        public DbSet<Integracion> Integraciones { get; set; }

    }//
}
