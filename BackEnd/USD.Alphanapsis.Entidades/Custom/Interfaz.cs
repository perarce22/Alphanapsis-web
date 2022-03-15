using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD.Alphanapsis.Entidades.Custom
{
    public class Interfaz
    {
        public int Id { set; get; }
        public int EquipoId { set; get; }
        public string Nombre { set; get; }
        public string Valor { set; get; }
    }

    public class CodigosConexion
    {
        public int Id { set; get; }
        public string Valor { set; get; }
    }

    public class CodigosUnicos
    {
        public string Valor { set; get; }
    }
}
