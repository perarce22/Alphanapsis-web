using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD.Alphanapsis.Entidades
{
    [Table("Configuracion")]
    public class Configuracion : EntidadBase
    {
        public int ConfiguracionId { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR")]
        [MaxLength(50)]
        public string Parametro { get; set; }

        [Required]
        [MaxLength(100)]
        public string Valor { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR")]
        [MaxLength(250)]
        public string Descripcion { get; set; }

    }
}
