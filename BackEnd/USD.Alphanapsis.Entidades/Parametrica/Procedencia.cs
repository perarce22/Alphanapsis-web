using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace USD.Alphanapsis.Entidades
{
    [Table("Procedencia")]
    public class Procedencia : EntidadBase
    {
        public int ProcedenciaId { get; set; }
        [Required]
        [MaxLength(150)]
        [Column(TypeName = "varchar")]
        public string Nombre { get; set; }
        [MaxLength(3)]
        [Column(TypeName = "varchar")]
        public string CodigoHIS { get; set; }
    }
}
