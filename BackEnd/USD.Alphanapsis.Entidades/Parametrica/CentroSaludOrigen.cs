using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD.Alphanapsis.Entidades
{
    [Table("CentroSaludOrigen")]
    public class CentroSaludOrigen : EntidadBase
    {
        public int CentroSaludOrigenId { get; set; }

        [MaxLength(500)]
        [Column(TypeName = "varchar")]
        public string Nombre { get; set; }

        [MaxLength(10)]
        [Column(TypeName = "varchar")]
        public string CodigoInterno { get; set; }

        [MaxLength(20)]
        [Column(TypeName = "varchar")]
        public string CodigoExterno { get; set; }
    }
}
