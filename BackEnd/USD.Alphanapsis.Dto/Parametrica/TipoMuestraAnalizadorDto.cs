using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace USD.Alphanapsis.Dto
{
    public class TipoMuestraAnalizadorDto : EntidadBaseDto
    {
        public int TipoMuestraAnalizadorId { get; set; }
        [Required]
        [MaxLength(50)]
       
        public string Nombre { get; set; }
        [MaxLength(3)]
        
        public string Codigo { get; set; }
    }
}
