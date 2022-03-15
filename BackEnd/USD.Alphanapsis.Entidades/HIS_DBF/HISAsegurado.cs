using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD.Alphanapsis.Entidades
{
    public class HISAsegurado
    {
        public string HISNumero { get; set; }

        public DateTime FechaPrueba { get; set; }

        public string NroAsegurado { get; set; }

        public string NroHistClinica { get; set; }

        public string Nombre { get; set; }

        public string Sexo { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string CodigoUbicacion { get; set; }

        public string CodigoDomicilio { get; set; }

        public string TipoDocumento { get; set; }

        public string NroDocumento { get; set; }

        public string NroTelefono { get; set; }

        public List<HISExamen> HISExamen { get; set; }
    }
}
