using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace USD.Alphanapsis.Entidades
{
    [Table("TipoMuestraAnalizador")]
    public class TipoMuestraAnalizador : EntidadBase
    {
        public int TipoMuestraAnalizadorId { get; set; }
        [Required]
        [MaxLength(50)]
        [Column(TypeName = "NVARCHAR")]
        public string Nombre { get; set; }
        [MaxLength(3)]
        [Column(TypeName = "varchar")]
        public string Codigo { get; set; }
    }
}
