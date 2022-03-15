using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD.Alphanapsis.Dto
{
    public class PaqueteServicioDto : EntidadBaseDto
    {
        public int PaqueteServicioId { get; set; }

        public int ServicioId { get; set; }

        public virtual ServicioDto Servicio { get; set; }

        public int PaqueteId { get; set; }

        public virtual PaqueteDto Paquete { get; set; }
    }
}
