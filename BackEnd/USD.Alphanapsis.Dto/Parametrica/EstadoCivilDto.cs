using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD.Alphanapsis.Dto
{
    public class EstadoCivilDto : EntidadBaseDto
    {
        public int EstadoCivilId { get; set; }

        [Required]
        [MaxLength(50)]
        
        public string Nombre { get; set; }
    }
}
