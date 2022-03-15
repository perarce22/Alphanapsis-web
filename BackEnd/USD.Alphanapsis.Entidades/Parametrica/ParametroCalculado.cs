using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace USD.Alphanapsis.Entidades
{
    [Table("ParametroCalculado")]
    public class ParametroCalculado : EntidadBase
    {
        public int ParametroCalculadoId { get; set; }
        public int ServicioId { get; set; }
        [ForeignKey("ServicioId")]
        public virtual Servicio Servicio { get; set; }
        public int PaqueteEquipoId { get; set; }
        [ForeignKey("PaqueteEquipoId")]
        public virtual PaqueteEquipo PaqueteEquipo { get; set; }
       
    }
}
