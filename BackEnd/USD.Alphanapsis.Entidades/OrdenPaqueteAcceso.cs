using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD.Alphanapsis.Entidades
{
    [Table("OrdenPaqueteAcceso")]
    public class OrdenPaqueteAcceso : EntidadBase
    {
        public int OrdenPaqueteAccesoId { get; set; }
        public int OrdenId { get; set; }
        [ForeignKey("OrdenId")]
        public Orden Orden { get; set; }
        public int OrdenPaqueteId { get; set; }
        [ForeignKey("OrdenPaqueteId")]
        public OrdenPaquete OrdenPaquete { get; set; }
        public string Token { get; set; }
        public DateTime FechaIniVigencia { get; set; }
        public DateTime FechaFinVigencia { get; set; }
    }
}
