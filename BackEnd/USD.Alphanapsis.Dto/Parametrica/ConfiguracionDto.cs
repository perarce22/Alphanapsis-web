using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD.Alphanapsis.Dto
{
    public class ConfiguracionDto : EntidadBaseDto
    {
        public int ConfiguracionId { get; set; }

        [Required]
       
        [MaxLength(50)]
        public string Parametro { get; set; }

        [Required]
        [MaxLength(100)]
        public string Valor { get; set; }

        [Required]
       
        [MaxLength(250)]
        public string Descripcion { get; set; }

    }
}
