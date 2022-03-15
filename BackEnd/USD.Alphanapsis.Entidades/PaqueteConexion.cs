using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD.Alphanapsis.Entidades
{
    [Table("PaqueteConexion")]
    public class PaqueteConexion : EntidadBase
    {
        public int PaqueteConexionId { get; set; }

        public int PaqueteId { get; set; }

        [ForeignKey("PaqueteId")]
        public virtual Paquete Paquete { get; set; }
        [MaxLength(20)]
        [Column(TypeName = "NVARCHAR")]
        public string CodigoConexion { get; set; }
    }
}
