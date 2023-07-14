using Microsoft.EntityFrameworkCore;

namespace OpenRobotics.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Cliente> Cliente { get; set; }

        //Funções para consultas em banco de dados
        public List<Cliente> GetCliente()
        {
            return Cliente.OrderBy(r => r.Nome).ToList();
        }
        public Cliente GetCliente(int id)
        {
            return Cliente.Where(r => r.Id == id).FirstOrDefault();
        }
    }
}