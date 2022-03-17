using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD.Alphanapsis.Dto
{
    public class RequestOrdenPrueba
    {
        public int OrdenId { get; set; }
        public int OrdenPaqueteId { get; set; }
        public DateTime Fecha { get; set; }
        public int PacienteId { get; set; }
        public string NombreCompleto { get; set; }
        public string NombrePrueba { get; set; }       
        public string Estado { get; set; }
    }
}
