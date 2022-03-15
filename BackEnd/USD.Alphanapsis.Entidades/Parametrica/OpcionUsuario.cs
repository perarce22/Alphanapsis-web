using System.ComponentModel.DataAnnotations.Schema;

namespace USD.Alphanapsis.Entidades
{
    [Table("OpcionUsuario")]
    public class OpcionUsuario : EntidadBase
    {
        public int OpcionUsuarioId { get; set; }
        public int? UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public virtual Usuario Usuario { get; set; }

        public int? OpcionId { get; set; }

        [ForeignKey("OpcionId")]
        public virtual Opcion Opcion { get; set; }
        
    }
}
