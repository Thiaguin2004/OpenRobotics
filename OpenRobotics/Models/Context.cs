using Microsoft.EntityFrameworkCore;

namespace OpenRobotics.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<ContasPagar> ContasPagar { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Parametros> Parametros { get; set; }

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
            return ContasPagar.Include(r => r.Cliente).Include(r => r.Categoria).ToList();
        }
        public ContasPagar GetContasPagar(int? id)
        {
            return ContasPagar.Include(r => r.Cliente).Include(r => r.Categoria).Where(r => r.IdContaPagar == id).FirstOrDefault();
        }
        public List<ContasPagar> GetContasPagar(DateTime periodo1, DateTime periodo2)
        {
            return ContasPagar.Include(r => r.Cliente).Include(r => r.Categoria).Where(r => r.Vencimento >= periodo1 && r.Vencimento <= periodo2).ToList();
        }
        public Parametros GetParametros()
        {
            return Parametros.Where(r => r.Cliente.Id == 1).FirstOrDefault();
        }
    }
}