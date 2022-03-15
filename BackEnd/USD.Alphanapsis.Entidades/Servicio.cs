using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using USD.Alphanapsis.Entidades.Custom;

namespace USD.Alphanapsis.Entidades
{
    [Table("Servicio")]
  public  class Servicio : EntidadBase
    {
        public int ServicioId { get; set; }
        [MaxLength(100)]
        [Column(TypeName = "NVARCHAR")]
        public string Nombre { get; set; }
        [MaxLength(1000)]
        [Column(TypeName = "NVARCHAR")]
        public string Descripcion { get; set; }
        public int? AreaEstudioId { get; set; }
        [ForeignKey("AreaEstudioId")]
        public virtual AreaEstudio AreaEstudio { get; set; }
        public bool? Trazable { get; set; }
        public bool? ReporteMostrar { get; set; }
        public int? ReporteOrden { get; set; }
        public int? ReporteColumna { get; set; }
        [MaxLength(50)]
        [Column(TypeName = "NVARCHAR")]
        public string ReporteNombre { get; set; }
        [MaxLength(10)]
        [Column(TypeName = "NVARCHAR")]
        public string UnidadMedida { get; set; }
        [MaxLength(20)]
        [Column(TypeName = "NVARCHAR")]
        public string Referencia { get; set; }
        public int? MetodoId { get; set; }
        [ForeignKey("MetodoId")]
        public virtual Metodo Metodo { get; set; }
        public bool? EsCalculado { get; set; }
        public bool? TipoResultado { get; set; }
        public int? TipoDatoId { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal? MultiplicarPor { get; set; }
        
    }
}
