using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace USD.Alphanapsis.Entidades
{
    [Table("Metodo")]
    public class Metodo : EntidadBase
    {
        public int MetodoId { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR")]
        [MaxLength(150)]
        public string Nombre { get; set; }


    }
}
