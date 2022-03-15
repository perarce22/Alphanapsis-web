using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD.Alphanapsis.Dto.Custom
{
    public class InterfazDto
    {
        public int Id { set; get; }
        public int EquipoId { set; get; }
        public string Nombre { set; get; }
        public string Valor { set; get; }
    }

    public class CodigosConexionDto
    {
        public int Id { set; get; }
        public string Valor { set; get; }
    }

    public class CodigosUnicosDto
    {
        public string Valor { set; get; }
    }
}
