using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OpenRobotics.Models
{
    public class ContasReceber
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int IdContaReceber { get; set; }
        [Required]
        public DateTime Vencimento { get; set; }
        [Required]
        public int Valor { get; set; }
        public DateTime DataEmissao { get; set; }
        public int NumeroDocumento { get; set; }
        public DateTime Competencia { get; set; }
        public string FormaPagamento { get; set; }
        public string Categoria { get; set; }
        public string Historico { get; set; }
        public string Tipo { get; set; }
        public string Situacao { get; set; }
        [Required]
        public int IdCliente { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
