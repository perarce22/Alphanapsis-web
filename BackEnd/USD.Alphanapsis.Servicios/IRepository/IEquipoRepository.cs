using System;
using System.Collections.Generic;
using System.Text;
using USD.Alphanapsis.Dto;
using USD.Alphanapsis.Entidades;

namespace USD.Alphanapsis.Servicios.Repository
{
    public interface IEquipoRepository
    {
        ICollection<Equipo> ListarEquipo(string filtro, bool? estado, int page, int rows, out int nroTotalRegistros);
        EquipoDto ObtenerEquipo(int id);
        void EliminaEquipo(int id, bool estado, string usuario);
        int RegistrarEquipo(EquipoDto equipo);
        ICollection<ParametroInterfaz> ListarParametro(int tipoInterfazId);
        ICollection<Equipo> ListarAEAnalizador(int areaEstudioId);
        ICollection<ParametroInterfazDto> ListarParametrosAnalizador(string codigo);
        Equipo ObtenerDatosAnalizador(string codigo);
    }
}
