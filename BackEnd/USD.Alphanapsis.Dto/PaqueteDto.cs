using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using USD.Alphanapsis.Dto.Custom;
using USD.Alphanapsis.Entidades.Custom;

namespace USD.Alphanapsis.Dto
{
    public class PaqueteDto : EntidadBaseDto
    {
        public int PaqueteId { get; set; }
        [MaxLength(100)]
       
        public string Nombre { get; set; }
        [MaxLength(100)]
       
        public string Descripcion { get; set; }
        public int? AreaEstudioId { get; set; }
        public virtual AreaEstudioDto AreaEstudio { get; set; }
        //[MaxLength(20)]
        //[Column(TypeName = "NVARCHAR")]
        //public string CodigoCPT { get; set; }
        public int? TipoMuestraId { get; set; }
        public int? TipoMuestraAnalizadorId { get; set; }
        public virtual TipoMuestraAnalizadorDto TipoMuestraAnalizador { get; set; }
        public bool? ImprimeEtiqueta { get; set; }
        public bool? EstadisticaAgp { get; set; }
        
        public List<int> ServiciosIds { get; set; }
        
        public List<ComboDto> Servicios { get; set; }        
        
        public int? ImprimeEtiquetaId { get; set; }
        
        public int? EstadisticaAgpId { get; set; }
        
        public string Muestra { get; set; }
        
        public List<CodigosConexionDto> CodigosConexion { get; set; }
    }
}
