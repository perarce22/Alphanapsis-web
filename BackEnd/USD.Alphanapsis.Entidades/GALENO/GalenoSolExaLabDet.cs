using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD.Alphanapsis.Entidades
{
    [Table("GalenoSolExaLabDet")]
    public class GalenoSolExaLabDet : EntidadBase
    {
        public int GalenoSolExaLabDetId { get; set; }
        public int GalenoSolExaLabId { get; set; }
        [ForeignKey("GalenoSolExaLabId")]
        public GalenoSolExaLab GalenoSolExaLab { get; set; }
        public int NumMovimiento { get; set; }
        public int NumCuenta { get; set; }
        public int FinanciamientoId { get; set; }
        public int NumOrden { get; set; }
        public string CodigoCPT { get; set; }
        public string DescripcionCPT { get; set; }
        public DateTime FechaProgramada { get; set; }
        public int EstadoProcesoId { get; set; }
    }
}
