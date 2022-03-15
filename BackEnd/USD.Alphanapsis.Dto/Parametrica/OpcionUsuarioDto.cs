using System.ComponentModel.DataAnnotations.Schema;

namespace USD.Alphanapsis.Dto
{
    public class OpcionUsuarioDto : EntidadBaseDto
    {
        public int OpcionUsuarioId { get; set; }
        public int? UsuarioId { get; set; }

        public virtual UsuarioDto Usuario { get; set; }

        public int? OpcionId { get; set; }

        public virtual OpcionDto Opcion { get; set; }
        
        public bool State
        {
            get
            {
                return OpcionUsuarioId > 0;
            }
        }
    }
}
