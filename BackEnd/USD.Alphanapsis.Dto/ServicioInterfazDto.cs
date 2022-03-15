using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD.Alphanapsis.Dto
{
    public class ServicioInterfazDto : EntidadBaseDto
    {
        public int ServicioInterfazId { get; set; }
        public int ServicioId { get; set; }

        public virtual ServicioDto Servicio { get; set; }
        public int EquipoId { get; set; }
        public virtual EquipoDto Equipo { get; set; }
        [MaxLength(20)]
       
        public string CodigoInterfaz { get; set; }
    }
}
