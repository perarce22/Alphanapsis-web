using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace USD.Alphanapsis.Dto
{
    public class TrazabilidadAccesoDto : EntidadBaseDto
    {
        public int TrazabilidadAccesoId { get; set; }
        public int PacienteId { get; set; }
        public PacienteDto Paciente { get; set; }        
        public string Token { get; set; }
        public DateTime FechaIniVigencia { get; set; }
        public DateTime FechaFinVigencia { get; set; }
    }
}
