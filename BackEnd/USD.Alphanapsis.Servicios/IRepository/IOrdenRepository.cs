using System;
using System.Collections.Generic;
using System.Text;
using USD.Alphanapsis.Dto;
using USD.Alphanapsis.Dto.Custom;
using USD.Alphanapsis.Entidades;

namespace USD.Alphanapsis.Servicios.Repository
{
    public interface IOrdenRepository
    {
        public ICollection<Orden> ListarOrden(string filtro, int? estado, DateTime? fecha, DateTime? fechaF, int? centroId, int? sedeId, int page, int rows, out int nroTotalRegistros);
        public ICollection<OrdenPaqueteDto> ListarOrdenDetalle(int ordenId);
        public ICollection<OrdenPaqueteDto> ListarOrdenDetalleAgp(int ordenId);
            public ICollection<OrdenPaqueteDto> ListarOrdenDetalleAgpAprob(int ordenId);
        public ICollection<OrdenPaqueteDetalleDto> ListarOrdenDetalleServicio(int ordenPaqueteId);
        public ICollection<OrdenPaqueteDetalleDto> ListarOrdenDetalleServicioAgp(int ordenId, int equipoId, string nroOrden, int tipoAtencionId);
        public ICollection<OrdenPaqueteDetalleDto> ListarOrdenDetalleServicioAgpAprob(int ordenId, int equipoId, string nroOrden);
        public OrdenDto ObtenerOrden(int id, int equipoId, string nroOrden);
        public OrdenDto ObtenerOrden_x_Codigo(string codigo);
        public ICollection<Orden> ListarOrden();
        public Orden ObtenerOrden_x_Solicitud(string nroSol);
        public ICollection<OrdenPaqueteDto> ObtenerOrden_BarCode_ID(int ordenId);
        public void EliminaOrden(int id, bool estado, string usuario);
        public int RegistrarOrden(Orden orden);
        public void ActualizarOrdenServicio(OrdenPaqueteDetalle ordenPD);
        public OrdenPaqueteDetalle ObtenerPaqueteDetalle(int ordenId, string codigoHIS);
        public OrdenPaqueteDetalleDto ObtenerPaqueteDetalle(int ordenId, string codCPSSGSS, string codMuestraSGSS);
        public void AprobarResultadoPrueba(OrdenPaquete ordenPaquete);
        public void AprobarResultadoPruebaAgp(OrdenPaquete ordenPaquete, int centroSaludId);
        public void ActualizaInformeResultado(List<OrdenPaquete> lstOPaquete);
        public OrdenPaquete ObtenerInformeResultado(int ordenId, int equipoId, string nroOrden);
        public void ActualizaAnalizadorOrden(int ordenId, int equipoId, int areaEstudioId, int tipoMuestraId, int equipoNewId, string user);
        public ICollection<CodigosUnicosDto> ActualizaAnalizadorOrdenCodUnico(int ordenId, int equipoId, int areaEstudioId, int tipoMuestraId, int equipoNewId, string user);
        public void ActualizaTipoPacienteOrden(int ordenId, int tipoPacienteId, string user);
        public void RevertirOrdenPaquete(int ordenPId);
        public void AnularOrden(int ordenId, string usuario);
        #region Interfaces
        public ICollection<OrdenDto> ListarOrdenInterfaz(DateTime fecIni, DateTime fecFin, int idEquipo);
        public OrdenDto ObtenerOrden(string orden);
        public ICollection<OrdenPaqueteDetalle> ListarOrdenPruebaEnvio(string orden, int idEquipo);
        public string ListarOrdenPruebaEnvioAlp200(string orden, int idEquipo);
        public OrdenPaqueteDto ValidarMatchAutomatico(string orden);
        public ICollection<OrdenPaqueteDetalleDto> ListarOrdenPrueba(string orden, int idEquipo);
        public void EnviarTramaOrdenPaquete(string orden, string trama, int idEquipo);
        public void EnviarTramaOrdenPaqueteProc(string orden, string trama, int idEquipo);
        public void RecibirTramaOrdenPaquete(string orden, int ordenPaqueteId, string trama, int idEquipo);
        public void RecibirTramaOrdenPaquete(OrdenPaqueteDto ordenPQ);
        public void RecibirTramaOrdenPaqueteALPHAHem(OrdenPaqueteDto ordenPQ);
        public void ActualizarPruebas(List<OrdenPaqueteDetalleDto> pruebas, int ordenPaqueteId);

        #endregion
        #region Mobile
        public RequestDatosPaciente ConsultarPacienteDatos(int tipoDocId, string nroDoc, string token, int tipoConsulta);
        public RequestDatosPaciente ConsultarResultadoDatos(string nroOrden, int tipoConsulta);
        public ICollection<OrdenPaqueteDetalleDto> ListarOrdenDetalleResultado(string nroOrden);
        public ICollection<DatosOrdenResultado> ListarPerfilServicio(int ordenPaqueteId);
        public ICollection<RequestTrazabilidad> ConsultarPacienteTrazabilidad(int pacienteId, int trazableAnno);
        public bool GenerarTokenTrazabilidad(int tipoDocId, string nroDoc);
        public ICollection<RequestOrdenPrueba> ListarOrdenPruebaMovil(string filtro, DateTime? fecha);


        #endregion

        public Orden ObtenerOrden(int ordenId);

        #region Reporte Resultados
        public IEnumerable<ReporteOrdenResultado> ListarOrdenResultado(int ordenId, int page, int rows, out int nroTotalRegistros);
        public IEnumerable<mvBPOrderApproved> ListarOrdenesResultados(int BPId, int page, int rows, out int nroTotalRegistros);
        public IEnumerable<mvBPResult> ListarOPResultado(int bpOAId, int bpId, int ordenId, int page, int rows, out int nroTotalRegistros);
        #endregion
    }
}
