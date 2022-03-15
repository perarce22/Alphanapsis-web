using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using USD.Alphanapsis.Utiles;

namespace USD.Alphanapsis.Dto
{
    public class OrdenServicioCalculadoDto : EntidadBaseDto
    {
        public int OrdenServicioCalculadoId { get; set; }
        public int OrdenServicioFormulaId { get; set; }
        public OrdenServicioFormulaDto OrdenServicioFormula { get; set; }
        public int ServicioId { get; set; }
        public ServicioDto Servicio { get; set; }
        [MaxLength(20)]
       
        public string Codigo { get; set; }
        public int TipoMuestraAnalizadorId { get; set; }
    }
}
