using System.ComponentModel.DataAnnotations.Schema;

namespace USD.Alphanapsis.Entidades
{
    [Table("OpcionPerfil")]
    public class OpcionPerfil : EntidadBase
    {
        public int OpcionPerfilId { get; set; }

        [ForeignKey("PerfilId")]
        public virtual Perfil Perfil { get; set; }
        public int? PerfilId { get; set; }

        [ForeignKey("OpcionId")]
        public virtual Opcion Opcion { get; set; }
        public int? OpcionId { get; set; }

        
    }
}
