using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using USD.Alphanapsis.Entidades.Custom;

namespace USD.Alphanapsis.Dto
{
    public  class ParametroEquipoDto: EntidadBaseDto
    {
        public int ParametroEquipoId { get; set; }
       
        [MaxLength(100)]
       
        public string Valor { get; set; }

        public int EquipoId { get; set; }

        public virtual EquipoDto Equipo { get; set; }

        public int? ParametroInterfazId { get; set; }

        public virtual ParametroInterfazDto ParametroInterfaz { get; set; }
    }
}
