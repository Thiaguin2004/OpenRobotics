using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OpenRobotics.Models
{
    public class Parametros
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int IdParametro { get; set; }
        [Required]
        public string? Parametro { get; set; }
        public virtual Cliente? Cliente { get; set; }
    }
}
