using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD.Alphanapsis.Dto
{
    public class UsuarioPerfilDto : EntidadBaseDto
    {
        public int UsuarioPerfilId { get; set; }

        public int UsuarioId { get; set; }
        public int PerfilId { get; set; }

        public virtual PerfilDto Perfil { get; set; }

        public virtual UsuarioDto Usuario { get; set; }
       
    }
}
