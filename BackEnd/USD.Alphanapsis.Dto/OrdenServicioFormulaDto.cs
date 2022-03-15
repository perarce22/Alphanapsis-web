using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using USD.Alphanapsis.Utiles;

namespace USD.Alphanapsis.Dto
{
    public class OrdenServicioFormulaDto : EntidadBaseDto
    {
        public int OrdenServicioFormulaId { get; set; }
        public int ServicioId { get; set; }
        public ServicioDto Servicio { get; set; }
        [MaxLength(200)]
       
        public string Formula { get; set; }
    }
}
