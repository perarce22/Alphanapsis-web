using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace USD.Alphanapsis.Entidades
{
    [Table("OrdenServicioFormula")]
    public class OrdenServicioFormula : EntidadBase
    {
        public int OrdenServicioFormulaId { get; set; }
        public int ServicioId { get; set; }
        [ForeignKey("ServicioId")]
        public Servicio Servicio { get; set; }
        [MaxLength(200)]
        [Column(TypeName = "NVARCHAR")]
        public string Formula { get; set; }
    }
}
