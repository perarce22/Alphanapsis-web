using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD.Alphanapsis.Dto
{
    public class PaqueteEquipoDto : EntidadBaseDto
    {
        public int PaqueteEquipoId { get; set; }
        public int EquipoId { get; set; }
        public virtual EquipoDto Equipo { get; set; }
        public int PaqueteId { get; set; }
        public virtual PaqueteDto Paquete { get; set; }
        
        public int MuestraAnalizadorId { get; set; }
    }
}
