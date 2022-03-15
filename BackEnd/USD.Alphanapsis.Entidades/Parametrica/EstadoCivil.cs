using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD.Alphanapsis.Entidades
{
    [Table("EstadoCivil")]
    public class EstadoCivil : EntidadBase
    {
        public int EstadoCivilId { get; set; }

        [Required]
        [MaxLength(50)]
        [Column(TypeName = "varchar")]
        public string Nombre { get; set; }
    }
}
