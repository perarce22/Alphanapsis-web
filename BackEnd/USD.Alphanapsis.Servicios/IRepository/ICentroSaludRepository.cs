using System;
using System.Collections.Generic;
using System.Text;
using USD.Alphanapsis.Dto;
using USD.Alphanapsis.Entidades;

namespace USD.Alphanapsis.Servicios.Repository
{
    public interface ICentroSaludRepository
    {
        ICollection<CentroSaludOrigen> ListarCentroSaludOrigen(string filtro, bool? estado, int page, int rows, out int nroTotalRegistros);
        CentroSaludOrigen ObtenerCentroSaludOrigen(int id);
        void EliminaCentroSaludOrigen(int id, string usuario);
        int RegistrarCentroSaludOrigen(CentroSaludOrigen entidad);
        ICollection<CentroSaludAsistencial> ListarSedeCentroSalud(int Id);
        ICollection<CentroSaludAsistencial> ListarSedeCentroSaludAll(int Id);
        CentroSaludAsistencial ObtenerCentroSaludSede(int id);
        CentroSaludAsistencial ObtenerCentroSaludSede(string codSede);
        ICollection<CentroSaludAsistencial> ListarSedeCentroSaludAsistenAll();

    }
}
