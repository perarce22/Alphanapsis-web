using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD.Alphanapsis.Entidades
{
    [Table("TrazabilidadServicio")]
    public class TrazabilidadServicio : EntidadBase
    {
        public int TrazabilidadServicioId { get; set; }
        public int PacienteId { get; set; }
        [ForeignKey("PacienteId")]
        public Paciente Paciente { get; set; }
        public int ServicioId { get; set; }
        [ForeignKey("ServicioId")]
        public Servicio Servicio { get; set; }
        public int TrazabilidadAnno { get; set; }
        public int TrazabilidadMes { get; set; }
        [MaxLength(20)]
        [Column(TypeName = "NVARCHAR")]
        public string Valor { get; set; }
    }
}
