using System;
using System.Collections.Generic;
using System.Text;
using USD.Alphanapsis.Entidades;

namespace USD.Alphanapsis.Servicios.Repository
{
    public interface IEspecialidadRepository
    {
        ICollection<Especialidad> ListarEspecialidad();
        ICollection<Especialidad> ListarEspecialidad(string filtro, bool? estado, int page, int rows, string sidx, string sord, out int nroTotalRegistros);
        Especialidad ObtenerEspecialidad(int id);
        void RegistrarEspecialidad(Especialidad especialidad);
        void EliminarEspecialidad(int id, string usuario);
        void CambiarEstadoEspecialidad(int id, bool estado, string usuario);

    }
}
