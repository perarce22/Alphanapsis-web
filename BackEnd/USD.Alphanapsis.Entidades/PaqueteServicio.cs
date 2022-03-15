using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD.Alphanapsis.Entidades
{
    [Table("PaqueteServicio")]
    public class PaqueteServicio : EntidadBase
    {
        public int PaqueteServicioId { get; set; }

        public int ServicioId { get; set; }

        [ForeignKey("ServicioId")]
        public virtual Servicio Servicio { get; set; }

        public int PaqueteId { get; set; }

        [ForeignKey("PaqueteId")]
        public virtual Paquete Paquete { get; set; }
    }
}
