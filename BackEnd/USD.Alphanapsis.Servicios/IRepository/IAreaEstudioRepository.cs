using System;
using System.Collections.Generic;
using System.Text;
using USD.Alphanapsis.Dto;
using USD.Alphanapsis.Entidades;

namespace USD.Alphanapsis.Servicios.Repository
{
    public interface IAreaEstudioRepository
    {
        ICollection<AreaEstudio> ListarAreaEstudio(string filtro, bool? estado, int page, int rows, out int nroTotalRegistros);
        AreaEstudio ObtenerAreaEstudio(int id);
        void EliminaAreaEstudio(int id, string usuario);
        int RegistrarAreaEstudio(AreaEstudio areaEstudio);
        ICollection<AreaEstudio> ListarAreaEstudio();
    }
}
