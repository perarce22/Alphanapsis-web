using System;
using System.Collections.Generic;
using System.Text;
using USD.Alphanapsis.Dto;
using USD.Alphanapsis.Entidades;

namespace USD.Alphanapsis.Servicios.Repository
{
    public interface IAgrupamientoRepository
    {
        void EliminaAgrupamiento(int id, string usuario);
        ICollection<Agrupamiento> ListarAgrupamiento(string filtro, bool? estado, int? areaId, int page, int rows, out int nroTotalRegistros);
        AgrupamientoDto ObtenerAgrupamiento(int Id);
        int RegistrarAgrupamiento(AgrupamientoDto agrupa);

    }
}
