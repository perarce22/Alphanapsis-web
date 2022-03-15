using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using USD.Alphanapsis.Entidades.Custom;

namespace USD.Alphanapsis.Entidades
{
    public class EntidadBase
    {
        [Required]
        public bool FlagActivo { get; set; }
        [Required]
        public bool FlagEliminado { get; set; }
        [Required]
        [Column(TypeName = "NVARCHAR")]
        [MaxLength(100)]
        public string CreadoPor { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }
        [Column(TypeName = "NVARCHAR")]
        [MaxLength(100)]
        public string ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
        
    }
}
