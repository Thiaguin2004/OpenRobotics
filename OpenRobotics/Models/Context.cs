using Microsoft.EntityFrameworkCore;

namespace OpenRobotics.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<ContasPagar> ContasPagar { get; set; }

        //Funções para consultas em banco de dados
        public List<Cliente> GetCliente()
        {
            return Cliente.OrderBy(r => r.Nome).ToList();
        }
        public List<Cliente> GetClienteDesligado()
        {
            return Cliente.Where(r => r.Desligado == 1).OrderBy(r => r.Nome).ToList();
        }
        public Cliente GetCliente(int id)
        {
            return Cliente.Where(r => r.Id == id).FirstOrDefault();
        }
        public List<ContasPagar> GetContasPagar()
        {
            return ContasPagar.Include(r => r.Cliente).ToList();
        }
    }
}