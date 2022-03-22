using System;
using System.Collections.Generic;
using System.Text;
using USD.Alphanapsis.Entidades;

namespace USD.Alphanapsis.Servicios.Repository
{
    public interface ITipoMuestraAnalizadorRepository
    {
        public ICollection<TipoMuestraAnalizador> ListarTipoMuestraAnalizador(string filtro, bool? estado, int page, int rows, out int nroTotalRegistros);
        public TipoMuestraAnalizador ObtenerTipoMuestraAnalizador(int id);
        public void EliminaTipoMuestraAnalizador(int id, string usuario);
        public int RegistrarTipoMuestraAnalizador(TipoMuestraAnalizador entidad);
        public ICollection<TipoMuestraAnalizador> ListarTipoMuestraAnalizador();
        public TipoMuestraAnalizador ObtenerTipoMuestraAnalizador(string codigo);
    }
}
