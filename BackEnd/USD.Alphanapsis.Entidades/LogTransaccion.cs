using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD.Alphanapsis.Entidades
{
    [Table("LogTransaccion")]
    public class LogTransaccion : EntidadBase
    {
        public int LogTransaccionId { get; set; }
        public string Proceso { get; set; }
        public string Resultado { get; set; }
        public string Observacion { get; set; }
    }
}
