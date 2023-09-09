using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Aplicacion> Aplicaciones { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
    }
}
