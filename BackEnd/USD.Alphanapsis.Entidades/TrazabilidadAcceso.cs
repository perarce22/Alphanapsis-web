using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace USD.Alphanapsis.Entidades
{
    [Table("TrazabilidadAcceso")]
    public class TrazabilidadAcceso : EntidadBase
    {
        public int TrazabilidadAccesoId { get; set; }
        public int PacienteId { get; set; }
        [ForeignKey("PacienteId")]
        public Paciente Paciente { get; set; }        
        public string Token { get; set; }
        public DateTime FechaIniVigencia { get; set; }
        public DateTime FechaFinVigencia { get; set; }
    }
}
