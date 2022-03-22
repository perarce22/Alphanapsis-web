using System;
using System.Collections.Generic;
using System.Text;
using USD.Alphanapsis.Entidades;

namespace USD.Alphanapsis.Servicios.Repository
{
    public interface IServicioSaludRepository
    {
         
        public ICollection<ServicioSalud> ListarServicioSalud();
        public ICollection<ServicioSalud> ListarServicioSalud(string filtro, bool? estado, int page, int rows, string sidx, string sord, out int nroTotalRegistros);
        public ServicioSalud ObtenerServicioSalud(int id);
        public void RegistrarServicioSalud(ServicioSalud entidad);
        public void EliminarServicioSalud(int id, string usuario);
        public void CambiarEstadoServicioSalud(int id, bool estado, string usuario);
        public ServicioSalud ObtenerServicioSalud(string codigoHIS);
    }
}
