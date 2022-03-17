using System;
using USD.Alphanapsis.Dto;
using USD.Alphanapsis.Entidades;

namespace USD.Alphanapsis.Servicios.Repository
{
    public interface ICorrelativoRepository
    {
        Correlativo ObtenerCorrelativo(int tipoCorrelativo, int centroId, string usuario);
        Correlativo RegistrarCorrelativo(int tipoCorrelativo, int centroId, string usuario, DateTime fechaEmision);
    }
}
