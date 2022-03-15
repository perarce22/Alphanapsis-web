using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD.Alphanapsis.Entidades
{
    [Table("PaqueteEquipo")]
    public class PaqueteEquipo : EntidadBase
    {
        public int PaqueteEquipoId { get; set; }
        public int EquipoId { get; set; }
        [ForeignKey("EquipoId")]
        public virtual Equipo Equipo { get; set; }
        public int PaqueteId { get; set; }
        [ForeignKey("PaqueteId")]
        public virtual Paquete Paquete { get; set; }
         
    }
}
