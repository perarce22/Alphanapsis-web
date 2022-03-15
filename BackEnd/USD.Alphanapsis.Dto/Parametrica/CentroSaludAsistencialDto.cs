using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD.Alphanapsis.Dto
{
    public class CentroSaludAsistencialDto : EntidadBaseDto
    {
        public int CentroSaludAsistencialId { get; set; }

        public int CentroSaludOrigenId { get; set; }
        public CentroSaludOrigenDto CentroSaludOrigen { get; set; }

        [MaxLength(500)]
        
        public string Nombre { get; set; }

        [MaxLength(10)]
        
        public string CodigoInterno { get; set; }
    }
}
