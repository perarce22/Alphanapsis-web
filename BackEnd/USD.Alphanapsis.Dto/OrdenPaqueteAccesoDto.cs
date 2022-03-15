using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD.Alphanapsis.Dto
{
    public class OrdenPaqueteAccesoDto : EntidadBaseDto
    {
        public int OrdenPaqueteAccesoId { get; set; }
        public int OrdenId { get; set; }
        public OrdenDto Orden { get; set; }
        public int OrdenPaqueteId { get; set; }
        public OrdenPaqueteDto OrdenPaquete { get; set; }
        public string Token { get; set; }
        public DateTime FechaIniVigencia { get; set; }
        public DateTime FechaFinVigencia { get; set; }
    }
}
