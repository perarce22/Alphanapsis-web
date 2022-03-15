using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD.Alphanapsis.Dto
{
    public class TipoDocumentoDto : EntidadBaseDto
    {
        public int TipoDocumentoId { get; set; }
        [Required]
        [MaxLength(50)]
       
        public string Nombre { get; set; }
        public int Longitud { get; set; }
        [MaxLength(3)]
        
        public string CodigoHIS { get; set; }
    }
}
