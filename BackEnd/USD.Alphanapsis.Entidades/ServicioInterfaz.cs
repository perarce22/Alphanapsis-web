using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD.Alphanapsis.Entidades
{
    [Table("ServicioInterfaz")]
    public class ServicioInterfaz : EntidadBase
    {
        public int ServicioInterfazId { get; set; }
        public int ServicioId { get; set; }

        [ForeignKey("ServicioId")]
        public virtual Servicio Servicio { get; set; }
        public int EquipoId { get; set; }
        [ForeignKey("EquipoId")]
        public virtual Equipo Equipo { get; set; }
        [MaxLength(20)]
        [Column(TypeName = "NVARCHAR")]
        public string CodigoInterfaz { get; set; }
    }
}
