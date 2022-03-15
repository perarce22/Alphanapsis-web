using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace USD.Alphanapsis.Entidades
{
    [Table("Perfil")]
    public class Perfil : EntidadBase
    {
        public int PerfilId { get; set; }

        [Required]
        [MaxLength(50)]
        [Column(TypeName = "NVARCHAR")]
        public string Nombre { get; set; }
    }
}
