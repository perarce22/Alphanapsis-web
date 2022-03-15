using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using USD.Alphanapsis.Utiles;
using USD.Alphanapsis.Entidades.Custom;
using USD.Alphanapsis.Dto.Custom;

namespace USD.Alphanapsis.Dto
{
  public  class ServicioDto : EntidadBaseDto
    {
        public int ServicioId { get; set; }
        [MaxLength(100)]
       
        public string Nombre { get; set; }
        [MaxLength(1000)]
       
        public string Descripcion { get; set; }
        public int? AreaEstudioId { get; set; }
        public virtual AreaEstudioDto AreaEstudio { get; set; }
        public bool? Trazable { get; set; }
        public bool? ReporteMostrar { get; set; }
        public int? ReporteOrden { get; set; }
        public int? ReporteColumna { get; set; }
        [MaxLength(50)]
       
        public string ReporteNombre { get; set; }
        [MaxLength(10)]
       
        public string UnidadMedida { get; set; }
        [MaxLength(20)]
       
        public string Referencia { get; set; }
        public int? MetodoId { get; set; }
        public virtual MetodoDto Metodo { get; set; }
        public bool? EsCalculado { get; set; }
        public bool? TipoResultado { get; set; }
        public int? TipoDatoId { get; set; }
        public decimal? MultiplicarPor { get; set; }
        
        public int? TrazableId { get; set; }
        
        public int? ReporteMostrarId { get; set; }
        
        public int? EsCalculadoId { get; set; }
        
        public int? TipoResultadoId { get; set; }
        
        public List<InterfazDto> Interfaz { get; set; }
    }
}
