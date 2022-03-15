using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace USD.Alphanapsis.Entidades
{
    [Table("AreaEstudio")]
    public class AreaEstudio : EntidadBase
    {
        public int AreaEstudioId { get; set; }

        [Required]
        [MaxLength(50)]
        [Column(TypeName = "varchar")]
        public string Nombre { get; set; }

        [MaxLength(20)]
        [Column(TypeName = "varchar")]
        public string Sigla { get; set; }

        [MaxLength(10)]
        [Column(TypeName = "varchar")]
        public string CodigoInterno { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "varchar")]
        public string Reporte { get; set; }

        [MaxLength(100)]
        [Column(TypeName = "varchar")]
        public string Descripcion { get; set; }

    }
}
