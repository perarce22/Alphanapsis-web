using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace USD.Alphanapsis.Entidades
{

    [Table("MSSolExaLabDet")]
    public class MSSolExaLabDet : EntidadBase
    {
        public int MSSolExaLabDetiD { get; set; }
        public int MSSolExaLabId { get; set; }
        public int? OrdenId { get; set; }
        public int? OrdenPaqueteId { get; set; }
        public int EstadoProcesoId { get; set; }
        public string CodigoOA { get; set; }
        public string IdOrdenAtencion { get; set; }
        public string IndRevertido { get; set; }
        public string Linea { get; set; }
        public DateTime FechaEmision { get; set; }
        public string Componente { get; set; }
        public string ComponenteNombre { get; set; }
        public string CantidadSolicitada { get; set; }
        public string EstadoDocumento { get; set; }
       

    }
}
