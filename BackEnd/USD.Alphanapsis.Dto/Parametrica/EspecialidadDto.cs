using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace USD.Alphanapsis.Dto
{
    public class EspecialidadDto : EntidadBaseDto
    {
        public int EspecialidadId { get; set; }

        [Required]
        [MaxLength(50)]
        
        public string Nombre { get; set; }
        
                

    }
}
