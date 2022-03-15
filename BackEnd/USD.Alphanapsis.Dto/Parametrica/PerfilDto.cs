using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace USD.Alphanapsis.Dto
{
    public class PerfilDto : EntidadBaseDto
    {
        public int PerfilId { get; set; }

        [Required]
        [MaxLength(50)]
       
        public string Nombre { get; set; }
    }
}
