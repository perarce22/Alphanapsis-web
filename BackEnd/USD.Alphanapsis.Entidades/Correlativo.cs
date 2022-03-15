using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD.Alphanapsis.Entidades
{
    [Table("Correlativo")]
    public class Correlativo : EntidadBase
    {
        public int CorrelativoId { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(10)]
        public string Prefijo { get; set; }

        [Required]
        [Column(TypeName = "INT")]
        public int TipoCorrelativo { get; set; }

        [Required]
        [Column(TypeName = "INT")]
        public int Valor { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(100)]
        public string Ceros { get; set; }

        public DateTime FechaEmision { get; set; }

        

    }
}
