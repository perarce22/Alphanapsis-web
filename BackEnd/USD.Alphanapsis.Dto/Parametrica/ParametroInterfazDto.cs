using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace USD.Alphanapsis.Dto
{
    public class ParametroInterfazDto : EntidadBaseDto
    {
        public int ParametroInterfazId { get; set; }

        [MaxLength(50)]
       
        public string Parametro { get; set; }

        [MaxLength(250)]
       
        public string Descripcion { get; set; }

        public int ConfigInterfaceId { get; set; }

        
        public string Valor { get; set; }

        public int? TipoInterfazId { get; set; }

        public virtual TipoInterfazDto TipoInterfaz { get; set; }
    }
}
