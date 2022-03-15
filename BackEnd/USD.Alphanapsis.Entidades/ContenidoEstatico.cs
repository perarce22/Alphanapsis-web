using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD.Alphanapsis.Entidades
{
    [Table("ContenidoEstatico")]
    public class ContenidoEstatico : EntidadBase
    {
        public int ContenidoEstaticoId { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR")]
        [MaxLength(200)]
        public string Campo { get; set; }


        [Required]
        [Column(TypeName = "NVARCHAR")]
        [MaxLength(4000)]
        public string Descripcion { get; set; }

    }
}
