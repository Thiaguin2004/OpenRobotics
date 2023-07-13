using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenRobotics.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Endereco { get; set; }
        [Required]
        public string? Celular { get; set; }
        [Required]
        public int CPF { get; set; }
        [Required]
        [ForeignKey(nameof(Perfil))]
        public int IdPerfil { get; set; }
        public virtual Perfil? Perfil { get; set; }
    }
}
