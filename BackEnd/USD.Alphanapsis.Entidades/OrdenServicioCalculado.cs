using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace USD.Alphanapsis.Entidades
{
    [Table("OrdenServicioCalculado")]
    public class OrdenServicioCalculado : EntidadBase
    {
        public int OrdenServicioCalculadoId { get; set; }
        public int OrdenServicioFormulaId { get; set; }
        [ForeignKey("OrdenServicioFormulaId")]
        public OrdenServicioFormula OrdenServicioFormula { get; set; }
        public int ServicioId { get; set; }
        [ForeignKey("ServicioId")]
        public Servicio Servicio { get; set; }
        [MaxLength(20)]
        [Column(TypeName = "NVARCHAR")]
        public string Codigo { get; set; }
        public int TipoMuestraAnalizadorId { get; set; }
    }
}
