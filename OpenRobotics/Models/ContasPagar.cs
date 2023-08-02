using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OpenRobotics.Models
{
    public class ContasPagar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int IdContaPagar { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Vencimento { get; set; }
        [Required]
        public string Valor { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataEmissao { get; set; }
        public int NumeroDocumento { get; set; }
        [DataType(DataType.Date)]
        public DateTime Competencia { get; set; }
        public string FormaPagamento { get; set; }
        public string Historico { get; set; }
        public string Tipo { get; set; }
        [Required]
        public int IdCliente { get; set; }
        public virtual Cliente? Cliente { get; set; }
        [Required]
        public int IdCategoria { get; set; }
        public virtual Categoria? Categoria { get; set;}
    }
}
