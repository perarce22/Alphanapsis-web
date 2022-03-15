using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace USD.Alphanapsis.Entidades
{
    [Table("ServicioSalud")]
    public class ServicioSalud : EntidadBase
    {
        public int ServicioSaludId { get; set; }
        [Required]
        [MaxLength(150)]
        [Column(TypeName = "varchar")]
        public string Nombre { get; set; }
        [MaxLength(3)]
        [Column(TypeName = "varchar")]
        public string CodigoHIS { get; set; }
    }
}
