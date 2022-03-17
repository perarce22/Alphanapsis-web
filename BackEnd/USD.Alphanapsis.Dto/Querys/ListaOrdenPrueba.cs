using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD.Alphanapsis.Dto
{
    public class ListaOrdenPrueba
    {
        public int OrdenId { get; set; }
        public string Codigo { get; set; }
        public string CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public bool FlagActivo { get; set; }
        public bool FlagEliminado { get; set; }
        public int? MedicoId { get; set; }
        public string ModificadoPor { get; set; }
        public int TipoOrdenId { get; set; }
        public int OrdenPaqueteId { get; set; }
        public int EstadoOrdenPaqueteId { get; set; }
        public int? EquipoId { get; set; }
        public string NroOrden { get; set; }
        public string PaqueteNombre { get; set; }
        public int? TipoMuestraId { get; set; }
        public string Pruebas { get; set; }
        public string NroHistoriaClinica { get; set; }
        public int? Estado { get; set; }
        public int ClinicaVeterinariaSedeId { get; set; }
        public int AreaEstudioId { get; set; }
        public string AreaEstudio { get; set; }
        public string Sigla { get; set; }
        public string Reporte { get; set; }
        public string NombreEquipo { get; set; }
    }
}
