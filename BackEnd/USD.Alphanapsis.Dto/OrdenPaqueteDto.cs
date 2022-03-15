using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using USD.Alphanapsis.Utiles;

namespace USD.Alphanapsis.Dto
{
    public class OrdenPaqueteDto : EntidadBaseDto
    {
        public int OrdenPaqueteId { get; set; }
        public int OrdenId { get; set; }
        public OrdenDto Orden { get; set; }
        public int PaqueteId { get; set; }
        public PaqueteDto Paquete { get; set; }    
        public DateTime? FechaEnvio { get; set; }
        public DateTime? FechaProcesamiento { get; set; }
        public int? EstadoOrdenPaqueteId { get; set; }
        public string EstadoOrdenPaqueteStr
        {
            get
            {
                return EstadoOrdenPaqueteId == null ? "" : Util.GetEnumDescription((EEstadoOrdenPaquete)(this.EstadoOrdenPaqueteId));
            }
        }
        public int? EquipoId { get; set; }
        public virtual EquipoDto Equipo { get; set; }        
        [MaxLength(500)]
       
        public string InformeResultado { get; set; }
        [MaxLength(20)]
       
        public string NroOrden { get; set; }
        public int? UsuarioApruebaId { get; set; }
        public DateTime? FechaAprobacion { get; set; }
        [MaxLength(100)]
       
        public string UsuarioInterface { get; set; }
        
        public OrdenPaqueteImagenesDto OrdenPaqueteImagenes { get; set; }
        
        public OrdenPaqueteTramasDto OrdenPaqueteTramas { get; set; }
        
        public List<OrdenPaqueteDetalleDto> OrdenPaqueteDetalles  { get; set; }
        
        public string Codigo { get; set; }
        
        public string Pruebas { get; set; }
        
        public string imgBarcode { get; set; }
        
        public string imgNombre { get; set; }
        
        public int? TipoMuestraAnalizadorId { get; set; }
        
        public int? AreaEstudioId { get; set; }

    }
}
