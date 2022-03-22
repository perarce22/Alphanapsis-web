using System;
using System.Collections.Generic;
using System.Text;
using USD.Alphanapsis.Entidades;

namespace USD.Alphanapsis.Servicios.Repository
{
    public interface ITipoDocumentoRepository
    {
        public ICollection<TipoDocumento> ListarTipoDocumento(string filtro, bool? estado, int page, int rows, out int nroTotalRegistros);
        public TipoDocumento ObtenerTipoDocumento(int id);
        public void EliminaTipoDocumento(int id, string usuario);
        public int RegistrarTipoDocumento(TipoDocumento entidad);
        public ICollection<TipoDocumento> ListarTipoDocumento();
        public TipoDocumento ObtenerTipoDocumento(string codigoHIS);
    }
}
