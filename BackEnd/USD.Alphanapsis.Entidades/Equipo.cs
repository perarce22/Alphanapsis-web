using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using USD.Alphanapsis.Entidades.Custom;

namespace USD.Alphanapsis.Entidades
{
    [Table("Equipo")]
    public  class Equipo : EntidadBase
    {
        public int EquipoId { get; set; }
        [MaxLength(100)]
        [Column(TypeName = "NVARCHAR")]
        public string Nombre { get; set; }
        [MaxLength(100)]
        [Column(TypeName = "NVARCHAR")]
        public string Marca { get; set; }
        [MaxLength(100)]
        [Column(TypeName = "NVARCHAR")]
        public string Modelo { get; set; }
        [MaxLength(100)]
        [Column(TypeName = "NVARCHAR")]
        public string Serie { get; set; }

        [MaxLength(100)]
        [Column(TypeName = "NVARCHAR")]
        public string CodUnico { get; set; }

        public int? AreaEstudioId { get; set; }

        [ForeignKey("AreaEstudioId")]
        public virtual AreaEstudio AreaEstudio { get; set; }

        public int? TipoInterfazId { get; set; }

        public int? TipoBarcodeId { get; set; }

        [ForeignKey("TipoInterfazId")]
        public virtual TipoInterfaz TipoInterfaz { get; set; }

        public bool? MatchAutomatico { get; set; }
         


    }
}
