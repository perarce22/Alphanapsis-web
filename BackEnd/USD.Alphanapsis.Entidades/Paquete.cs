using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using USD.Alphanapsis.Entidades.Custom;

namespace USD.Alphanapsis.Entidades
{
    [Table("Paquete")]
    public class Paquete : EntidadBase
    {
        public int PaqueteId { get; set; }
        [MaxLength(100)]
        [Column(TypeName = "NVARCHAR")]
        public string Nombre { get; set; }
        [MaxLength(100)]
        [Column(TypeName = "NVARCHAR")]
        public string Descripcion { get; set; }
        public int? AreaEstudioId { get; set; }
        [ForeignKey("AreaEstudioId")]
        public virtual AreaEstudio AreaEstudio { get; set; }
        //[MaxLength(20)]
        //[Column(TypeName = "NVARCHAR")]
        //public string CodigoCPT { get; set; }
        public int? TipoMuestraId { get; set; }
        public int? TipoMuestraAnalizadorId { get; set; }
        [ForeignKey("TipoMuestraAnalizadorId")]
        public virtual TipoMuestraAnalizador TipoMuestraAnalizador { get; set; }
        public bool? ImprimeEtiqueta { get; set; }
        public bool? EstadisticaAgp { get; set; }
       
    }
}
