using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD.Alphanapsis.Dto
{
    public class ListaOrden
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
        public string MedicoNombre { get; set; }
        public string MedicoAP { get; set; }
        public string MedicoAM { get; set; }
        public string ClienteNombre { get; set; }
        public string ClienteAP { get; set; }
        public string ClienteAM { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public int? TipoDocumentoId { get; set; }
        public string TipoDocumentoPac { get; set; }
        public string NumeroDocumento { get; set; }
        public string Celular { get; set; }
        public string NroHistoriaClinica { get; set; }
        public int? Edad { get; set; }
        public string MascotaNombre { get; set; }
        public DateTime? MascotaFecNac { get; set; }
        public string MascotaEspecie { get; set; }
        public int? Estado { get; set; }
        public int ClinicaVeterinariaSedeId { get; set; }
    }
}
