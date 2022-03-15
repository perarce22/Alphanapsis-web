using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using USD.Alphanapsis.Entidades.Custom;

namespace USD.Alphanapsis.Dto
{
    public class ServicioAgrupamientoDto : EntidadBaseDto
    {

        public int ServicioAgrupamientoId { get; set; }

        public int? AgrupamientoId { get; set; }

        public virtual AgrupamientoDto Agrupamiento { get; set; }


        public int ServicioId { get; set; }

        public virtual ServicioDto Servicio { get; set; }




    }
}
