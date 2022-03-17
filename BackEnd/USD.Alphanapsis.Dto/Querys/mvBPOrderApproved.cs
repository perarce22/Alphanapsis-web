using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD.Alphanapsis.Dto
{
    public class mvBPOrderApproved
    {
        public int BPOrderApprovedId { get; set; }
        public int OrdenId { get; set; }
        public string NroOrden { get; set; }
        public string FechaOrden { get; set; }
        public string NroHistClinica { get; set; }
        public string Paciente { get; set; }
        public string Edad { get; set; }
        public string Especie { get; set; }
        public string Estado { get; set; }
    }
}
