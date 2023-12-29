using DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace DB
{
    public class DbPPIContext: DbContext
    {
        public DbPPIContext(DbContextOptions<DbPPIContext> options):base(options) { }

        public DbSet<TipoActivo> TipoActivos { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Activo> Activos { get; set; }
        public DbSet<Orden> Ordenes { get; set; }
        public DbSet<User> Users { get; set; }
    }
}