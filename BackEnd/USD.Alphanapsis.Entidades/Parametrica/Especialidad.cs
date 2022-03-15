using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace USD.Alphanapsis.Entidades
{
    [Table("Especialidad")]
    public class Especialidad : EntidadBase
    {
        public int EspecialidadId { get; set; }

        [Required]
        [MaxLength(50)]
        [Column(TypeName = "varchar")]
        public string Nombre { get; set; }
        
                

    }
}
