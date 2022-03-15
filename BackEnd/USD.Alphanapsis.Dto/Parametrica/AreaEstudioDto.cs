using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace USD.Alphanapsis.Dto
{
    public class AreaEstudioDto : EntidadBaseDto
    {
        public int AreaEstudioId { get; set; }

        [Required]
        [MaxLength(50)]
        
        public string Nombre { get; set; }

        [MaxLength(20)]
        
        public string Sigla { get; set; }

        [MaxLength(10)]
        
        public string CodigoInterno { get; set; }

        [MaxLength(50)]
        
        public string Reporte { get; set; }

        [MaxLength(100)]
        
        public string Descripcion { get; set; }

    }
}
