using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace USD.Alphanapsis.Entidades
{
    [Table("TipoPaciente")]
    public class TipoPaciente : EntidadBase
    {
        public int TipoPacienteId { get; set; }
        [Required]
        [MaxLength(50)]
        [Column(TypeName = "NVARCHAR")]
        public string Nombre { get; set; }
        [MaxLength(3)]
        [Column(TypeName = "varchar")]
        public string CodigoHIS { get; set; }
    }
}
