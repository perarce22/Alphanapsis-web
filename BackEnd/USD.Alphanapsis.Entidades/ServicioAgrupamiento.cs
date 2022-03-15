using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using USD.Alphanapsis.Entidades.Custom;

namespace USD.Alphanapsis.Entidades
{
    [Table("ServicioAgrupamiento")]
    public class ServicioAgrupamiento : EntidadBase
    {

        public int ServicioAgrupamientoId { get; set; }

        public int? AgrupamientoId { get; set; }

        [ForeignKey("AgrupamientoId")]
        public virtual Agrupamiento Agrupamiento { get; set; }


        public int ServicioId { get; set; }

        [ForeignKey("ServicioId")]
        public virtual Servicio Servicio { get; set; }




    }
}
