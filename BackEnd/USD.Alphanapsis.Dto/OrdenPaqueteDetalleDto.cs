using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using USD.Alphanapsis.Utiles;

namespace USD.Alphanapsis.Dto
{
    public class OrdenPaqueteDetalleDto : EntidadBaseDto
    {
        public int OrdenPaqueteDetalleId { get; set; }

        public int OrdenPaqueteId { get; set; }
        public OrdenPaqueteDto OrdenPaquete { get; set; }
        public int? OrdenId { get; set; }
        public OrdenDto Orden { get; set; }
        public int ServicioId { get; set; }
        public ServicioDto Servicio { get; set; }
        public string ResultadoAutomatizado { get; set; }
        public int? EstadoServicioId { get; set; }
        
        public string EstadoServicioStr
        {
            get
            {
                return EstadoServicioId == null ? "" : Util.GetEnumDescription((EEstadoPrueba)(this.EstadoServicioId));
            }
        }
        public DateTime? FechaResultado { get; set; }        
        public string FechaResultadoStr
        {
            get
            {
                return FechaResultado == null ? "" : FechaResultado.Value.ToString("dd/MM/yyyy");
            }
        }
        public string CodigoUnico { get; set; }
        public int CodigoUnicoExamen { get; set; }
        [MaxLength(50)]
       
        public string Valor { get; set; }
        public string ValorReferencia { get; set; }
        public string EvaluacionPrueba { get; set; }
        public string FechaProcesaInterface { get; set; }
        public string Indicador { get; set; }
        public string ValorUnidad { get; set; }
        [MaxLength(50)]
       
        public string Observacion { get; set; }
        
        public string NombrePaquete { get; set; }
        
        public string CorreoElectronico { get; set; }
        
        public string NroOrden { get; set; }
        
        public int TipoAtencionId { get; set; }
        
        public int? TipoResultadoId { get; set; }

        public bool? FlagEnvioSE { get; set; }
        public bool? FlagResultadoEnvioSE { get; set; }
        
        public int? TipoDatoId { get; set; }
        
        public decimal? MultiplicarPor { get; set; }
    }


    public class ReportResultDto
    {
        public string NumOrden { get; set; }
        public string Area { get; set; }
        public string Paquete { get; set; }
        public string Prueba { get; set; }
        public Double Resultado { get; set; }
        public string ValorUnidad { get; set; }
        public string ValorReferencia { get; set; }
        public string EvaluacionPrueba { get; set; }
        public string Observacion { get; set; }
        public string Muestra { get; set; }
        public string Descripcion { get; set; }
        public string Metodo { get; set; }
        public int PaqueteId { get; set; }
        public int? MuestraAnalizadorId { get; set; }
    }
}
