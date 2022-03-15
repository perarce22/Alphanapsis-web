using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using USD.Alphanapsis.Entidades.Custom;

namespace USD.Alphanapsis.Entidades
{
    [Table("ParametroEquipo")]
    public  class ParametroEquipo: EntidadBase
    {
        public int ParametroEquipoId { get; set; }
       
        [MaxLength(100)]
        [Column(TypeName = "NVARCHAR")]
        public string Valor { get; set; }

        public int EquipoId { get; set; }

        [ForeignKey("EquipoId")]
        public virtual Equipo Equipo { get; set; }

        public int? ParametroInterfazId { get; set; }

        [ForeignKey("ParametroInterfazId")]
        public virtual ParametroInterfaz ParametroInterfaz { get; set; }
    }
}
