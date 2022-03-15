using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace USD.Alphanapsis.Entidades
{
    [Table("ParametroInterfaz")]
    public class ParametroInterfaz : EntidadBase
    {
        public int ParametroInterfazId { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "NVARCHAR")]
        public string Parametro { get; set; }

        [MaxLength(250)]
        [Column(TypeName = "NVARCHAR")]
        public string Descripcion { get; set; }

        public int ConfigInterfaceId { get; set; }

        

        public int? TipoInterfazId { get; set; }

        [ForeignKey("TipoInterfazId")]
        public virtual TipoInterfaz TipoInterfaz { get; set; }
    }
}
