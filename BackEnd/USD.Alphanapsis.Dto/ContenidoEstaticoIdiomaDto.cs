using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD.Alphanapsis.Dto
{
    public class ContenidoEstaticoIdiomaDto : EntidadBaseDto
    {
        public int ContenidoEstaticoIdiomaId { get; set; }

        public int IdiomaId { get; set; }
        public virtual IdiomaDto Idioma { get; set; }


        public int ContenidoEstaticoId { get; set; }
        public virtual ContenidoEstaticoDto ContenidoEstatico { get; set; }


        [Required]
       
        [MaxLength(4000)]
        public string Valor { get; set; }

    }
}
