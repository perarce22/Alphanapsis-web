using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD.Alphanapsis.Entidades
{
    [Table("ContenidoEstaticoIdioma")]
    public class ContenidoEstaticoIdioma : EntidadBase
    {
        public int ContenidoEstaticoIdiomaId { get; set; }

        public int IdiomaId { get; set; }
        [ForeignKey("IdiomaId")]
        public virtual Idioma Idioma { get; set; }


        public int ContenidoEstaticoId { get; set; }
        [ForeignKey("ContenidoEstaticoId")]
        public virtual ContenidoEstatico ContenidoEstatico { get; set; }


        [Required]
        [Column(TypeName = "NVARCHAR")]
        [MaxLength(4000)]
        public string Valor { get; set; }

    }
}
