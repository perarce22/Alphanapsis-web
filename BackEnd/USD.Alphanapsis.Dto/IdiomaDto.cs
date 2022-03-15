using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD.Alphanapsis.Dto
{
    public class IdiomaDto : EntidadBaseDto
    {
        public int IdiomaId { get; set; }

        [Required]
       
        [MaxLength(200)]
        public string Nombre { get; set; }


        [Required]
       
        [MaxLength(10)]
        public string Prefijo { get; set; }

    }
}
