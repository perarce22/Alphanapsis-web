using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD.Alphanapsis.Dto
{
    public class RequestDatosPaciente
    {
        public int OrdenId { get; set; }
        public int OrdenPaqueteId { get; set; }
        public int PacienteId { get; set; }
        public string NombreCompleto { get; set; }
        public int Edad { get; set; }
        public string NombrePaquete { get; set; }
        public string Fecha { get; set; }
        public string Estado { get; set; }
    }
}
