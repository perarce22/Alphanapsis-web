using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace USD.Alphanapsis.Entidades
{
    [Table("HISEnvioExamen")]
    public class HISEnvioExamen : EntidadBase
    {
        public int HISEnvioExamenId { get; set; }

        public string HISNumero { get; set; }

        public DateTime FechaPrueba { get; set; }

        public string CodigoPrueba { get; set; }

        public string CodigoPerfilPrueba { get; set; }

        public string CodigoLab { get; set; }

        public string CodigoSec { get; set; }

        public string CodigoSede { get; set; }

        public string CodigoMedico { get; set; }

        public string NroAsegurado { get; set; }

        public string NroHistClinica { get; set; }

        public string Nombre { get; set; }

        public string Sexo { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string CodigoUbicacion { get; set; }

        public string CodigoDomicilio { get; set; }

        public string TipoDocumento { get; set; }

        public string NroDocumento { get; set; }

        public string NroTelefono { get; set; }

        public string NroActoMedico { get; set; }

        public int EstadoProcesoId { get; set; }

        public int OrdenId { get; set; }

        public int OrdenPaqueteId { get; set; }

        public int OrdenPaqueteDetalleId { get; set; }
    }
}
