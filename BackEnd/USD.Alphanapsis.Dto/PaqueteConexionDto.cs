using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD.Alphanapsis.Dto
{
    public class PaqueteConexionDto : EntidadBaseDto
    {
        public int PaqueteConexionId { get; set; }

        public int PaqueteId { get; set; }

        public virtual PaqueteDto Paquete { get; set; }
        [MaxLength(20)]
       
        public string CodigoConexion { get; set; }
    }
}
