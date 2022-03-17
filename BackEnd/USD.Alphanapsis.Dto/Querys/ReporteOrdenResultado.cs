using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USD.Alphanapsis.Utiles;

namespace USD.Alphanapsis.Dto
{
    public class mvBPResult
    {

        public int TipoOrdenId { get; set; }
        public int OrdenId { get; set; }
        public string NumeroOrden { get; set; }
        public string FechaOrden { get; set; }
        public int AreaEstudioId { get; set; }
        public string AreaEstudio { get; set; }
        public string Sigla { get; set; }
        public string Reporte { get; set; }
        public int TipoMuestraId { get; set; }
        public int EquipoId { get; set; }
        public string Equipo { get; set; }
        public string TipoMuestra {
            get
            {                
                return TipoMuestraId == 0 ? "" : Util.GetEnumDescription((ETipoMuestra)(this.TipoMuestraId));
            }
        }
    }
}
