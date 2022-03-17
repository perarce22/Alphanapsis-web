using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD.Alphanapsis.Dto
{
    public class RequestTrazabilidad
    {
        public int ServicioId { get; set; }
        public string NombrePrueba { get; set; }
        public List<RequestValores> RequestValores { get; set; }
    }

    public class RequestValores
    {
        public string Anno { get; set; }
        public string Mes { get; set; }
        public decimal? Valor { get; set; }
    }

    public class DatosTrazabilidad
    {
        public int ServicioId { get; set; }
        public string NombrePrueba { get; set; }
        public string Anno { get; set; }
        public string Mes { get; set; }
        public string Valor { get; set; }
    }

    public class DatosOrdenResultado
    {
        public string NombrePrueba { get; set; }
        public decimal Valor { get; set; }
        public string Rango { get; set; }
        public string Indicador { get; set; }
    }
}
