using System;
using System.Collections.Generic;
using System.Text;
using USD.Alphanapsis.Entidades;

namespace USD.Alphanapsis.Servicios.Repository
{
    public interface IProcedenciaRepository
    {
        public ICollection<Procedencia> ListarProcedencia();
        public ICollection<Procedencia> ListarProcedencia(string filtro, bool? estado, int page, int rows, string sidx, string sord, out int nroTotalRegistros);
        public Procedencia ObtenerProcedencia(int id);
        public void RegistrarProcedencia(Procedencia entidad);
        public void EliminarProcedencia(int id, string usuario);
        public void CambiarEstadoProcedencia(int id, bool estado, string usuario);
        public Procedencia ObtenerProcedencia(string codigoHIS);
        public Procedencia ObtenerProcedenciaHis(string id);
    }
}
