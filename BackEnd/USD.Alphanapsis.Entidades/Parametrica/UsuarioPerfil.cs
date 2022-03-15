using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD.Alphanapsis.Entidades
{
    [Table("UsuarioPerfil")]
    public class UsuarioPerfil : EntidadBase
    {
        public int UsuarioPerfilId { get; set; }

        public int UsuarioId { get; set; }
        public int PerfilId { get; set; }

        [ForeignKey("PerfilId")]
        public virtual Perfil Perfil { get; set; }

        [ForeignKey("UsuarioId")]
        public virtual Usuario Usuario { get; set; }
       
    }
}
