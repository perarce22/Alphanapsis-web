using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace USD.Alphanapsis.Entidades
{
    [Table("OrdenPaqueteDetalle")]
    public class OrdenPaqueteDetalle : EntidadBase
    {
        public int OrdenPaqueteDetalleId { get; set; }

        public int OrdenPaqueteId { get; set; }
        [ForeignKey("OrdenPaqueteId")]
        public OrdenPaquete OrdenPaquete { get; set; }
        public int? OrdenId { get; set; }
        [ForeignKey("OrdenId")]
        public Orden Orden { get; set; }
        public int ServicioId { get; set; }
        [ForeignKey("ServicioId")]
        public Servicio Servicio { get; set; }
        public string ResultadoAutomatizado { get; set; }
        public int? EstadoServicioId { get; set; }
        
        public DateTime? FechaResultado { get; set; }        
         
        public string CodigoUnico { get; set; }
        public int CodigoUnicoExamen { get; set; }
        [MaxLength(50)]
        [Column(TypeName = "NVARCHAR")]
        public string Valor { get; set; }
        public string ValorReferencia { get; set; }
        public string EvaluacionPrueba { get; set; }
        public string FechaProcesaInterface { get; set; }
        public string Indicador { get; set; }
        public string ValorUnidad { get; set; }
        [MaxLength(50)]
        [Column(TypeName = "NVARCHAR")]
        public string Observacion { get; set; }
        

        public bool? FlagEnvioSE { get; set; }
        public bool? FlagResultadoEnvioSE { get; set; }
       
    }


    public class ReportResult
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
