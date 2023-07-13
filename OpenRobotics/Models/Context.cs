using Microsoft.EntityFrameworkCore;

namespace OpenRobotics.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options):base(options){}

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Perfil> Perfil { get; set; }

        //Funções para consultas em banco de dados
        public List<Usuario> GetUsuario()
        {
            return Usuario.Include(tp => tp.Perfil).OrderBy(r => r.Nome).ToList();
        }
        public List<Perfil> GetPerfis()
        {
            return Perfil.OrderByDescending(r => r.IdPerfil).ToList();
        }
    }
}
