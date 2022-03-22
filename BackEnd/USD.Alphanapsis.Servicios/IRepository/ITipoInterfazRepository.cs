using System;
using System.Collections.Generic;
using System.Text;
using USD.Alphanapsis.Entidades;

namespace USD.Alphanapsis.Servicios.Repository
{
    public interface ITipoInterfazRepository
    {
        public ICollection<TipoInterfaz> ListarTipoInterfaz();
        public ICollection<TipoInterfaz> ListarTipoInterfaz(string filtro, bool? estado, int page, int rows, string sidx, string sord, out int nroTotalRegistros);
        public TipoInterfaz ObtenerTipoInterfaz(int id);
        public void RegistrarTipoInterfaz(TipoInterfaz tipoInterfaz);
        public void EliminarTipoInterfaz(int id, string usuario);
        public void CambiarEstadoTipoInterfaz(int id, bool estado, string usuario);
    }
}
