using System;
using System.Collections.Generic;
using System.Text;
using USD.Alphanapsis.Dto;
using USD.Alphanapsis.Entidades;

namespace USD.Alphanapsis.Servicios.Repository
{
    public interface IOrdenServicioRepository
    {
        public ICollection<OrdenPaquete> ListarOrdenServicio(string filtro, bool? estado, int page, int rows, out int nroTotalRegistros);
        public OrdenPaquete ObtenerOrdenServicio(int id);
        public void EliminaOrdenServicio(int id, bool estado, string usuario);
        public int RegistrarOrdenServicio(OrdenPaquete ordenservicio);
        public ICollection<ReportResult> obtenerResultado(int ordenId, int equipoId);
    }
}
