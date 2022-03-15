using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD.Alphanapsis.Entidades
{
    [Table("GalenoSolExaLab")]
    public class GalenoSolExaLab : EntidadBase
    {
        public int GalenoSolExaLabId { get; set; }
        public int SGSSSolExaLabId { get; set; }
        [ForeignKey("SGSSSolExaLabId")]
        public SGSSSolExaLab SGSSSolExaLab { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public int NumMovimiento { get; set; }
        public int NumCuenta { get; set; }
        public int FinanciamientoId { get; set; }
        public string Financiamiento { get; set; }
        public int NumOrden { get; set; }
        public int? TipoId { get; set; }
        public string Tipo { get; set; }
        public string ServicioId { get; set; }
        public string Servicio { get; set; }
        public string Ubigeo { get; set; }
        public string NumHistoriaPac { get; set; }
        public string NumDocumentoPac { get; set; }
        public string ApePatPac { get; set; }
        public string ApeMatPac { get; set; }
        public string NombresPac { get; set; }
        public DateTime? FecNacimientoPac { get; set; }
        public string SexoPac { get; set; }
        public string CMPMedico { get; set; }
        public string ApePatMedico { get; set; }
        public string ApeMatMedico { get; set; }
        public string NombresMedico { get; set; }
        public int? OrdenId { get; set; }
        [ForeignKey("OrdenId")]
        public Orden Orden { get; set; }
        public int EstadoProcesoId { get; set; }
       
    }
}
