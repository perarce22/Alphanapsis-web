using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD.Alphanapsis.Dto
{
    public class ContenidoEstaticoDto : EntidadBaseDto
    {
        public int ContenidoEstaticoId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Campo { get; set; }


        [Required]
       
        [MaxLength(4000)]
        public string Descripcion { get; set; }

    }
}
