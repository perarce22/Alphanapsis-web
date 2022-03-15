using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD.Alphanapsis.Dto
{
    public class TrazabilidadServicioDto : EntidadBaseDto
    {
        public int TrazabilidadServicioId { get; set; }
        public int PacienteId { get; set; }
        public PacienteDto Paciente { get; set; }
        public int ServicioId { get; set; }
        public ServicioDto Servicio { get; set; }
        public int TrazabilidadAnno { get; set; }
        public int TrazabilidadMes { get; set; }
        [MaxLength(20)]
       
        public string Valor { get; set; }
    }
}
