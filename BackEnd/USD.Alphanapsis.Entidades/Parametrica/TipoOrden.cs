using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD.Alphanapsis.Entidades
{
    [Table("TipoOrden")]
    public class TipoOrden : EntidadBase
    {
        public int TipoOrdenId { get; set; }

        [Required]
        [MaxLength(50)]
        [Column(TypeName = "NVARCHAR")]
        public string Nombre { get; set; }
    }
}
