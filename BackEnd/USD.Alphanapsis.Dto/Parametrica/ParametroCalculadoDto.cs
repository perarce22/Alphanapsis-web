using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace USD.Alphanapsis.Dto
{
    public class ParametroCalculadoDto : EntidadBaseDto
    {
        public int ParametroCalculadoId { get; set; }
        public int ServicioId { get; set; }
        public virtual ServicioDto Servicio { get; set; }
        public int PaqueteEquipoId { get; set; }
        public virtual PaqueteEquipoDto PaqueteEquipo { get; set; }
        
        public bool MarcaParametro { get; set; }
        
        public int EquipoId { get; set; }
    }
}
