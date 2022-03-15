using System.ComponentModel.DataAnnotations.Schema;

namespace USD.Alphanapsis.Dto
{
    public class OpcionPerfilDto : EntidadBaseDto
    {
        public int OpcionPerfilId { get; set; }

        public virtual PerfilDto Perfil { get; set; }
        public int? PerfilId { get; set; }

        public virtual OpcionDto Opcion { get; set; }
        public int? OpcionId { get; set; }

        
        public bool State
        {
            get
            {
                return OpcionPerfilId > 0;
            }
        }

        
        public bool Flag { get; set; }
    }
}
