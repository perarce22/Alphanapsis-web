using System;
using System.Collections.Generic;
using System.Text;
using USD.Alphanapsis.Dto;
using USD.Alphanapsis.Entidades;

namespace USD.Alphanapsis.Servicios.Repository
{
    public interface IPaqueteRepository
    {
        public IList<PaqueteDto> ListarPaquete(string filtro, bool? estado, int? areaId, int page, int rows, out int nroTotalRegistros);
        public IList<PaqueteEquipo> ListarPaqueteEquipo(string filtro, bool? estado, int? areaId);
        public PaqueteDto ObtenerPaquete(int id);
        public void EliminaPaquete(int id, string usuario);
        public int RegistrarPaquete(PaqueteDto paquete);
    }
}
