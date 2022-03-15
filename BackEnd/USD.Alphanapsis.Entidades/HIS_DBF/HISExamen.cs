using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD.Alphanapsis.Entidades
{
    public class HISExamen
    {
        public int HISEnvioExamenId { get; set; }

        public DateTime FechaPrueba { get; set; }

        public string CodigoPrueba { get; set; }

        public string CodigoPerfilPrueba { get; set; }

        public string CodigoLab { get; set; }
       
    }
}
