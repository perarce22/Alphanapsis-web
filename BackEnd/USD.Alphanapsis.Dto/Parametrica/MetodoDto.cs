using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace USD.Alphanapsis.Dto
{
    public class MetodoDto : EntidadBaseDto
    {
        public int MetodoId { get; set; }

        [Required]
       
        [MaxLength(150)]
        public string Nombre { get; set; }


    }
}
