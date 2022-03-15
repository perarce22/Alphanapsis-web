using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace USD.Alphanapsis.Dto
{
    public class ProcedenciaDto : EntidadBaseDto
    {
        public int ProcedenciaId { get; set; }
        [Required]
        [MaxLength(150)]
        
        public string Nombre { get; set; }
        [MaxLength(3)]
        
        public string CodigoHIS { get; set; }
    }
}
