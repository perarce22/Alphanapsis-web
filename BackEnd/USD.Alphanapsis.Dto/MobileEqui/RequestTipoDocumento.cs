using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD.Alphanapsis.Dto
{
    public class RequestTipoDocumento
    {
        public int TipoDocumentoId { get; set; }       
        public string Nombre { get; set; }
        public int Longitud { get; set; }
    }
}
