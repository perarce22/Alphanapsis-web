using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD.Alphanapsis.Entidades
{
    [Table("Idioma")]
    public class Idioma : EntidadBase
    {
        public int IdiomaId { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR")]
        [MaxLength(200)]
        public string Nombre { get; set; }


        [Required]
        [Column(TypeName = "NVARCHAR")]
        [MaxLength(10)]
        public string Prefijo { get; set; }

    }
}
