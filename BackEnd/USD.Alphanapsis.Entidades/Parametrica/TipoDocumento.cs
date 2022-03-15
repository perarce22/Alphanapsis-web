using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD.Alphanapsis.Entidades
{
    [Table("TipoDocumento")]
    public class TipoDocumento : EntidadBase
    {
        public int TipoDocumentoId { get; set; }
        [Required]
        [MaxLength(50)]
        [Column(TypeName = "NVARCHAR")]
        public string Nombre { get; set; }
        public int Longitud { get; set; }
        [MaxLength(3)]
        [Column(TypeName = "varchar")]
        public string CodigoHIS { get; set; }
    }
}
