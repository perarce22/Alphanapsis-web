using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD.Alphanapsis.Dto
{
    public class CorrelativoDto : EntidadBaseDto
    {
        public int CorrelativoId { get; set; }

        [Required]
        
        [MaxLength(10)]
        public string Prefijo { get; set; }

        [Required]
        public int TipoCorrelativo { get; set; }

        [Required]
        public int Valor { get; set; }

        [Required]
        
        [MaxLength(100)]
        public string Ceros { get; set; }

        public DateTime FechaEmision { get; set; }

        
        public string CodigoAutogenerado
        {
            get
            {
                if (this.Valor > 9999)
                    return string.Format("{0}", this.Ceros);
                else
                    return string.Format("{0}{1}{2}", "", this.Ceros, this.Valor.ToString());
            }
        }

    }
}
