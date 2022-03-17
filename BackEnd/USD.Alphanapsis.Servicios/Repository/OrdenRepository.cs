using System;
using System.Collections.Generic;
using System.Text;
using USD.Alphanapsis.Data;
using USD.Alphanapsis.Entidades;
using System.Linq;
using USD.Alphanapsis.Utiles;
using USD.Alphanapsis.Dto;
using USD.Alphanapsis.Dto.Custom;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace USD.Alphanapsis.Servicios.Repository
{
    public class OrdenRepository
    {
        private readonly ApplicationDbContext _bd;
        NLog.Logger logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        public OrdenRepository(ApplicationDbContext bd)
        {
            _bd = bd;
        }

        public ICollection<Orden> ListarOrden(string filtro, int? estado, DateTime? fecha, DateTime? fechaF, int? centroId, int? sedeId, int page, int rows, out int nroTotalRegistros)
        {
            {
                try
                {
                    //IRepositorio<Orden> rep = new EfRepositorio<Orden>(ctx);
                    //IRepositorio<OrdenPaquete> reppaq = new EfRepositorio<OrdenPaquete>(ctx);
                    //IRepositorio<Medico> repMedico = new EfRepositorio<Medico>(ctx);
                    //IRepositorio<Paciente> repPaciente = new EfRepositorio<Paciente>(ctx);
                    //IRepositorio<Paquete> repPaquete = new EfRepositorio<Paquete>(ctx);
                    //IRepositorio<TipoDocumento> repTipoDoc = new EfRepositorio<TipoDocumento>(ctx);

                    var codOrden = "";
                    try
                    {
                        codOrden = filtro == null ? null : Convert.ToInt32(filtro).ToString();
                    }
                    catch
                    { codOrden = null; }


                    var lista = (from aa in _bd.Orden
                                 join b in _bd.Medico on aa.MedicoId equals b.MedicoId into p0
                                 from q0 in p0.DefaultIfEmpty()
                                 join c in _bd.Paciente on aa.PacienteId equals c.PacienteId
                                 join d in _bd.TipoDocumento on c.TipoDocumentoId equals d.TipoDocumentoId into p1
                                 from q1 in p1.DefaultIfEmpty()
                                 where aa.FlagActivo == true
                                       && (string.IsNullOrEmpty(filtro) || aa.Codigo.Contains(codOrden.ToUpper()) || c.ApellidoMaterno.Contains(filtro.ToUpper())
                                            || c.ApellidoPaterno.Contains(filtro.ToUpper()) || c.Nombres.Contains(filtro.ToUpper()) ||
                                          (c.ApellidoPaterno + " " + c.ApellidoMaterno + " " + c.Nombres).Contains(filtro.ToUpper()) || aa.HISNumero.Contains(filtro) ||
                                          c.NumeroDocumento.Contains(filtro)) &&
                                           //(fecha == null || aa.FechaEmision == fecha) && 
                                           (aa.CentroSaludOrigenId == centroId || centroId == null) &&
                                          (aa.CentroSaludAsistencialId == sedeId || sedeId == null)
                                       && aa.FlagEliminado == false &&
                                       ((aa.FechaEmision >= fecha && aa.FechaEmision <= fechaF) ||
                                         (aa.FechaEmision == fecha) || (fecha == null && fechaF == null))

                                 orderby aa.FechaEmision descending, aa.FechaCreacion descending
                                 select new
                                 {
                                     aa.OrdenId,
                                     aa.Codigo,
                                     aa.HISNumero,
                                     aa.CreadoPor,
                                     aa.FechaCreacion,
                                     aa.FechaEmision,
                                     aa.FechaModificacion,
                                     aa.FlagActivo,
                                     aa.FlagEliminado,
                                     aa.MedicoId,
                                     aa.ModificadoPor,
                                     aa.TipoOrdenId,
                                     aa.TipoPacienteId,
                                     MedicoNombre = q0.Nombres,
                                     MedicoAP = q0.ApellidoPaterno,
                                     MedicoAM = q0.ApellidoMaterno,
                                     PacienteNombre = c.Nombres,
                                     PacienteAP = c.ApellidoPaterno,
                                     PacienteAM = c.ApellidoMaterno,
                                     c.FechaNacimiento,
                                     c.TipoDocumentoId,
                                     TipoDocumentoPac = q1.Nombre,
                                     c.NumeroDocumento,
                                     c.Edad,
                                     Estado = aa.EstadoOrdenId
                                 });

                    lista = (from a in lista
                             where (!estado.HasValue || a.Estado == estado.Value)
                             select a
                            );

                    nroTotalRegistros = lista.Count();
                    lista = lista.Skip((page - 1) * rows).Take(rows);
                    var ordenes = lista.ToList();
                    var listaFinal = (from a in ordenes
                                      select new Orden()
                                      {
                                          Codigo = a.Codigo,
                                          HISNumero = a.HISNumero,
                                          CreadoPor = a.CreadoPor,
                                          FechaCreacion = a.FechaCreacion,
                                          FechaEmision = a.FechaEmision,
                                          FechaModificacion = a.FechaModificacion,
                                          FlagActivo = a.FlagActivo,
                                          FlagEliminado = a.FlagEliminado,
                                          MedicoId = a.MedicoId,
                                          ModificadoPor = a.ModificadoPor,
                                          OrdenId = a.OrdenId,
                                          TipoOrdenId = a.TipoOrdenId,
                                          TipoPacienteId = a.TipoPacienteId,
                                          EstadoOrdenId = a.Estado == (int)EEstadoOrdenPaquete.Pendiente || a.Estado == (int)EEstadoOrdenPaquete.Enviado ? (int)EEstadoOrdenPaquete.Pendiente :
                                                          a.Estado,
                                          Medico = new Medico()
                                          {
                                              Nombres = a.MedicoNombre,
                                              ApellidoMaterno = a.MedicoAM,
                                              ApellidoPaterno = a.MedicoAP
                                          },
                                          Paciente = new Paciente()
                                          {
                                              Nombres = a.PacienteNombre,
                                              ApellidoMaterno = a.PacienteAM,
                                              ApellidoPaterno = a.PacienteAP,
                                              TipoDocumentoId = a.TipoDocumentoId,
                                              NumeroDocumento = a.NumeroDocumento,
                                              FechaNacimiento = a.FechaNacimiento,
                                              TipoDocumento = new TipoDocumento() { TipoDocumentoId = a.TipoDocumentoId == null ? 0 : a.TipoDocumentoId.Value, Nombre = a.TipoDocumentoPac },
                                              Edad = a.Edad
                                          }
                                      }).ToList();
                    return listaFinal;
                }

                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }

        public ICollection<OrdenPaqueteDto> ListarOrdenDetalle(int ordenId)
        {

            {
                try
                {
                    //IRepositorio<Orden> rep = new EfRepositorio<Orden>(ctx);
                    //IRepositorio<OrdenPaquete> reppaq = new EfRepositorio<OrdenPaquete>(ctx);
                    //IRepositorio<Paquete> repPaquete = new EfRepositorio<Paquete>(ctx);
                    //IRepositorio<AreaEstudio> repAE = new EfRepositorio<AreaEstudio>(ctx);
                    //IRepositorio<Equipo> repEq = new EfRepositorio<Equipo>(ctx);
                    //IRepositorio<Paciente> repPaciente = new EfRepositorio<Paciente>(ctx);

                    var lista = (from aa in _bd.Orden
                                 join q in _bd.OrdenPaquete on aa.OrdenId equals q.OrdenId
                                 join w in _bd.Paquete on q.PaqueteId equals w.PaqueteId
                                 join c in _bd.AreaEstudio on w.AreaEstudioId equals c.AreaEstudioId
                                 join d in _bd.Equipo on q.EquipoId equals d.EquipoId into p0
                                 from q0 in p0.DefaultIfEmpty()
                                 join e in _bd.Paciente on aa.PacienteId equals e.PacienteId
                                 where aa.FlagActivo == true && aa.FlagEliminado == false &&
                                       aa.OrdenId == ordenId
                                 orderby aa.FechaCreacion descending
                                 select new
                                 {
                                     aa.OrdenId,
                                     aa.HISNumero,
                                     q.OrdenPaqueteId,
                                     q.EstadoOrdenPaqueteId,
                                     PaqueteNombre = w.Nombre,
                                     aa.Codigo,
                                     aa.CreadoPor,
                                     aa.FechaCreacion,
                                     aa.FechaEmision,
                                     aa.FechaModificacion,
                                     aa.FlagActivo,
                                     aa.FlagEliminado,
                                     aa.ModificadoPor,
                                     aa.TipoOrdenId,
                                     c.AreaEstudioId,
                                     AreaEstudio = c.Nombre,
                                     c.Sigla,
                                     c.Reporte,
                                     q.EquipoId,
                                     NombreEquipo = q0.Nombre,
                                     PacienteNombre = e.Nombres,
                                     PacienteAP = e.ApellidoPaterno,
                                     PacienteAM = e.ApellidoMaterno,
                                 });

                    var listaFinal = (from a in lista.ToList()
                                      select new OrdenPaqueteDto
                                      {
                                          Paquete = new PaqueteDto()
                                          {
                                              Nombre = a.PaqueteNombre,
                                              AreaEstudio = new AreaEstudioDto() { AreaEstudioId = a.AreaEstudioId, Nombre = a.AreaEstudio, Sigla = a.Sigla, Reporte = a.Reporte },
                                          },
                                          FechaCreacion = a.FechaEmision,
                                          Codigo = a.Codigo,
                                          OrdenPaqueteId = a.OrdenPaqueteId,
                                          EstadoOrdenPaqueteId = a.EstadoOrdenPaqueteId,
                                          Equipo = new EquipoDto() { EquipoId = a.EquipoId == null ? 0 : a.EquipoId.Value, Nombre = a.NombreEquipo },
                                          Orden = new OrdenDto()
                                          {
                                              OrdenId = a.OrdenId,
                                              HISNumero = a.HISNumero,
                                              Paciente = new PacienteDto()
                                              {
                                                  Nombres = a.PacienteNombre,
                                                  ApellidoMaterno = a.PacienteAM,
                                                  ApellidoPaterno = a.PacienteAP
                                              }
                                          }
                                      }).ToList();
                    return listaFinal;
                }

                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }

        public ICollection<OrdenPaqueteDto> ListarOrdenDetalleAgp(int ordenId)
        {

            {
                try
                {
                    //IRepositorio<Orden> rep = new EfRepositorio<Orden>(ctx);
                    //IRepositorio<OrdenPaquete> reppaq = new EfRepositorio<OrdenPaquete>(ctx);
                    //IRepositorio<Paquete> repPaquete = new EfRepositorio<Paquete>(ctx);
                    //IRepositorio<AreaEstudio> repAE = new EfRepositorio<AreaEstudio>(ctx);
                    //IRepositorio<Equipo> repEq = new EfRepositorio<Equipo>(ctx);
                    //IRepositorio<Paciente> repPaciente = new EfRepositorio<Paciente>(ctx);
                    //IRepositorio<PaqueteServicio> repPqSrv = new EfRepositorio<PaqueteServicio>(ctx);
                    //IRepositorio<Servicio> repSrv = new EfRepositorio<Servicio>(ctx);
                    //IRepositorio<TipoMuestraAnalizador> repTipoMA = new EfRepositorio<TipoMuestraAnalizador>(ctx);

                    var lista = (from aa in _bd.Orden
                                 join q in _bd.OrdenPaquete on aa.OrdenId equals q.OrdenId
                                 join w in _bd.Paquete on q.PaqueteId equals w.PaqueteId
                                 join c in _bd.AreaEstudio on w.AreaEstudioId equals c.AreaEstudioId
                                 join d in _bd.Equipo on q.EquipoId equals d.EquipoId into p0
                                 from q0 in p0.DefaultIfEmpty()
                                 join e in _bd.Paciente on aa.PacienteId equals e.PacienteId
                                 join f in _bd.TipoMuestraAnalizador on w.TipoMuestraAnalizadorId equals f.TipoMuestraAnalizadorId into p1
                                 from q1 in p1.DefaultIfEmpty()
                                 where aa.FlagActivo == true && aa.FlagEliminado == false &&
                                       q.FlagActivo == true && q.FlagEliminado == false && aa.OrdenId == ordenId
                                 orderby aa.FechaCreacion descending
                                 select new
                                 {
                                     aa.OrdenId,
                                     aa.HISNumero,
                                     q.OrdenPaqueteId,
                                     q.EstadoOrdenPaqueteId,
                                     PaqueteNombre = w.Nombre,
                                     w.TipoMuestraAnalizadorId,
                                     MuestraAnlizador = q1.Nombre,
                                     aa.Codigo,
                                     aa.CreadoPor,
                                     aa.FechaCreacion,
                                     aa.FechaEmision,
                                     aa.FechaModificacion,
                                     aa.FlagActivo,
                                     aa.FlagEliminado,
                                     aa.ModificadoPor,
                                     aa.TipoOrdenId,
                                     c.AreaEstudioId,
                                     AreaEstudio = c.Nombre,
                                     c.Sigla,
                                     c.Reporte,
                                     q.EquipoId,
                                     q.NroOrden,
                                     NombreEquipo = q0.Nombre,
                                     PacienteNombre = e.Nombres,
                                     PacienteAP = e.ApellidoPaterno,
                                     PacienteAM = e.ApellidoMaterno,
                                     Pruebas = w.Descripcion
                                 }).ToList();

                    var listaFinal = lista.GroupBy(grp => new
                    {
                        grp.OrdenId,
                        grp.NroOrden,
                        grp.HISNumero,
                        grp.Codigo,
                        grp.CreadoPor,
                        grp.FechaEmision,
                        grp.TipoOrdenId,
                        grp.AreaEstudioId,
                        grp.AreaEstudio,
                        grp.Sigla,
                        grp.Reporte,
                        grp.EquipoId,
                        grp.NombreEquipo,
                        grp.PacienteNombre,
                        grp.PacienteAP,
                        grp.PacienteAM,
                        grp.TipoMuestraAnalizadorId,
                        grp.MuestraAnlizador
                    }).Select(grp => new OrdenPaqueteDto()
                    {
                        NroOrden = grp.Key.NroOrden,
                        Paquete = new PaqueteDto()
                        {
                            Nombre = "Pruebas para " + grp.Key.AreaEstudio,
                            AreaEstudio = new AreaEstudioDto() { AreaEstudioId = grp.Key.AreaEstudioId, Nombre = grp.Key.AreaEstudio, Sigla = grp.Key.Sigla, Reporte = grp.Key.Reporte },
                            Muestra = grp.Key.TipoMuestraAnalizadorId == null ? "" : grp.Key.MuestraAnlizador,
                            TipoMuestraAnalizadorId = grp.Key.TipoMuestraAnalizadorId
                        },
                        FechaCreacion = grp.Key.FechaEmision,
                        Codigo = grp.Key.Codigo,
                        Equipo = new EquipoDto() { EquipoId = grp.Key.EquipoId == null ? 0 : grp.Key.EquipoId.Value, Nombre = grp.Key.NombreEquipo, AreaEstudioId = grp.Key.AreaEstudioId },
                        Orden = new OrdenDto()
                        {
                            OrdenId = grp.Key.OrdenId,
                            HISNumero = grp.Key.HISNumero,
                            Paciente = new PacienteDto()
                            {
                                Nombres = grp.Key.PacienteNombre,
                                ApellidoMaterno = grp.Key.PacienteAM,
                                ApellidoPaterno = grp.Key.PacienteAP
                            }
                        },
                        OrdenId = grp.Key.OrdenId,
                        Pruebas = string.Join(" ", grp.Select(m => m.Pruebas).Distinct())
                    }).ToList();

                    foreach (var item in listaFinal)
                    {
                        var lstPQ = (from a in _bd.OrdenPaquete
                                     where a.EquipoId == item.Equipo.EquipoId && a.OrdenId == item.OrdenId &&
                                           a.NroOrden == item.NroOrden && a.FlagActivo == true
                                     select a.OrdenPaqueteId).ToList();

                        var countEstadoPendiente = (from a in _bd.OrdenPaquete
                                                    where a.EstadoOrdenPaqueteId == (int)EEstadoOrdenPaquete.Pendiente &&
                                                          a.EquipoId == item.Equipo.EquipoId && a.OrdenId == item.OrdenId &&
                                                          a.NroOrden == item.NroOrden && a.FlagActivo == true
                                                    select a.OrdenPaqueteId).ToList().Count;

                        var countEstadoEnviado = (from a in _bd.OrdenPaquete
                                                  where a.EstadoOrdenPaqueteId == (int)EEstadoOrdenPaquete.Enviado &&
                                                        a.EquipoId == item.Equipo.EquipoId && a.OrdenId == item.OrdenId &&
                                                        a.NroOrden == item.NroOrden && a.FlagActivo == true
                                                  select a.OrdenPaqueteId).ToList().Count;

                        var countEstadoProcesado = (from a in _bd.OrdenPaquete
                                                    where (a.EstadoOrdenPaqueteId == (int)EEstadoOrdenPaquete.Procesado) &&
                                                          a.EquipoId == item.Equipo.EquipoId && a.OrdenId == item.OrdenId &&
                                                          a.NroOrden == item.NroOrden && a.FlagActivo == true
                                                    select a.OrdenPaqueteId).Count();

                        var countEstadoAprobado = (from a in _bd.OrdenPaquete
                                                   where (a.EstadoOrdenPaqueteId == (int)EEstadoOrdenPaquete.Aprobado) &&
                                                          a.EquipoId == item.Equipo.EquipoId && a.OrdenId == item.OrdenId &&
                                                          a.NroOrden == item.NroOrden && a.FlagActivo == true
                                                   select a.OrdenPaqueteId).Count();

                        item.EstadoOrdenPaqueteId = countEstadoAprobado == lstPQ.Count ? (int)EEstadoOrdenPaquete.Aprobado :
                                               (countEstadoEnviado > 0 ? (int)EEstadoOrdenPaquete.Analizando :
                                               (countEstadoPendiente > 0 ? (int)EEstadoOrdenPaquete.Pendiente : (int)EEstadoOrdenPaquete.Procesado));
                    }

                    return listaFinal;
                }

                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }

        public ICollection<OrdenPaqueteDto> ListarOrdenDetalleAgpAprob(int ordenId)
        {

            {
                try
                {
                    //IRepositorio<Orden> rep = new EfRepositorio<Orden>(ctx);
                    //IRepositorio<OrdenPaquete> reppaq = new EfRepositorio<OrdenPaquete>(ctx);
                    //IRepositorio<Paquete> repPaquete = new EfRepositorio<Paquete>(ctx);
                    //IRepositorio<AreaEstudio> repAE = new EfRepositorio<AreaEstudio>(ctx);
                    //IRepositorio<Equipo> repEq = new EfRepositorio<Equipo>(ctx);
                    //IRepositorio<Paciente> repPaciente = new EfRepositorio<Paciente>(ctx);
                    //IRepositorio<PaqueteServicio> repPqSrv = new EfRepositorio<PaqueteServicio>(ctx);
                    //IRepositorio<Servicio> repSrv = new EfRepositorio<Servicio>(ctx);
                    //IRepositorio<TipoMuestraAnalizador> repTipoMA = new EfRepositorio<TipoMuestraAnalizador>(ctx);

                    var lista = (from aa in _bd.Orden
                                 join q in _bd.OrdenPaquete on aa.OrdenId equals q.OrdenId
                                 join w in _bd.Paquete on q.PaqueteId equals w.PaqueteId
                                 join c in _bd.AreaEstudio on w.AreaEstudioId equals c.AreaEstudioId
                                 join d in _bd.Equipo on q.EquipoId equals d.EquipoId into p0
                                 from q0 in p0.DefaultIfEmpty()
                                 join e in _bd.Paciente on aa.PacienteId equals e.PacienteId
                                 join f in _bd.TipoMuestraAnalizador on w.TipoMuestraAnalizadorId equals f.TipoMuestraAnalizadorId into p1
                                 from q1 in p1.DefaultIfEmpty()
                                 where aa.FlagActivo == true && aa.FlagEliminado == false &&
                                       q.FlagActivo == true && q.FlagEliminado == false && aa.OrdenId == ordenId &&
                                       q.EstadoOrdenPaqueteId == (int)EEstadoOrdenPaquete.Aprobado

                                 orderby aa.FechaCreacion descending
                                 select new
                                 {
                                     aa.OrdenId,
                                     aa.HISNumero,
                                     q.OrdenPaqueteId,
                                     q.EstadoOrdenPaqueteId,
                                     PaqueteNombre = w.Nombre,
                                     w.TipoMuestraAnalizadorId,
                                     MuestraAnlizador = q1.Nombre,
                                     aa.Codigo,
                                     aa.CreadoPor,
                                     aa.FechaCreacion,
                                     aa.FechaEmision,
                                     aa.FechaModificacion,
                                     aa.FlagActivo,
                                     aa.FlagEliminado,
                                     aa.ModificadoPor,
                                     aa.TipoOrdenId,
                                     c.AreaEstudioId,
                                     AreaEstudio = c.Nombre,
                                     c.Sigla,
                                     c.Reporte,
                                     q.EquipoId,
                                     q.NroOrden,
                                     NombreEquipo = q0.Nombre,
                                     PacienteNombre = e.Nombres,
                                     PacienteAP = e.ApellidoPaterno,
                                     PacienteAM = e.ApellidoMaterno,
                                     Pruebas = w.Descripcion
                                 }).ToList();

                    var listaFinal = lista.GroupBy(grp => new
                    {
                        grp.OrdenId,
                        grp.NroOrden,
                        grp.HISNumero,
                        grp.Codigo,
                        grp.CreadoPor,
                        grp.FechaEmision,
                        grp.TipoOrdenId,
                        grp.AreaEstudioId,
                        grp.AreaEstudio,
                        grp.Sigla,
                        grp.Reporte,
                        grp.EquipoId,
                        grp.NombreEquipo,
                        grp.PacienteNombre,
                        grp.PacienteAP,
                        grp.PacienteAM,
                        grp.TipoMuestraAnalizadorId,
                        grp.MuestraAnlizador
                    }).Select(grp => new OrdenPaqueteDto()
                    {
                        NroOrden = grp.Key.NroOrden,
                        Paquete = new PaqueteDto()
                        {
                            Nombre = "Pruebas para " + grp.Key.AreaEstudio,
                            AreaEstudio = new AreaEstudioDto() { AreaEstudioId = grp.Key.AreaEstudioId, Nombre = grp.Key.AreaEstudio, Sigla = grp.Key.Sigla, Reporte = grp.Key.Reporte },
                            Muestra = grp.Key.TipoMuestraAnalizadorId == null ? "" : grp.Key.MuestraAnlizador,
                            TipoMuestraAnalizadorId = grp.Key.TipoMuestraAnalizadorId
                        },
                        FechaCreacion = grp.Key.FechaEmision,
                        Codigo = grp.Key.Codigo,
                        Equipo = new EquipoDto() { EquipoId = grp.Key.EquipoId == null ? 0 : grp.Key.EquipoId.Value, Nombre = grp.Key.NombreEquipo, AreaEstudioId = grp.Key.AreaEstudioId },
                        Orden = new OrdenDto()
                        {
                            OrdenId = grp.Key.OrdenId,
                            HISNumero = grp.Key.HISNumero,
                            Paciente = new PacienteDto()
                            {
                                Nombres = grp.Key.PacienteNombre,
                                ApellidoMaterno = grp.Key.PacienteAM,
                                ApellidoPaterno = grp.Key.PacienteAP
                            }
                        },
                        OrdenId = grp.Key.OrdenId,
                        Pruebas = string.Join(" ", grp.Select(m => m.Pruebas).Distinct())
                    }).ToList();

                    foreach (var item in listaFinal)
                    {
                        var lstPQ = (from a in _bd.OrdenPaquete
                                     where a.EquipoId == item.Equipo.EquipoId && a.OrdenId == item.OrdenId &&
                                           a.NroOrden == item.NroOrden && a.FlagActivo == true
                                     select a.OrdenPaqueteId).ToList();

                        var countEstadoPendiente = (from a in _bd.OrdenPaquete
                                                    where a.EstadoOrdenPaqueteId == (int)EEstadoOrdenPaquete.Pendiente &&
                                                          a.EquipoId == item.Equipo.EquipoId && a.OrdenId == item.OrdenId &&
                                                          a.NroOrden == item.NroOrden && a.FlagActivo == true
                                                    select a.OrdenPaqueteId).ToList().Count;

                        var countEstadoEnviado = (from a in _bd.OrdenPaquete
                                                  where a.EstadoOrdenPaqueteId == (int)EEstadoOrdenPaquete.Enviado &&
                                                        a.EquipoId == item.Equipo.EquipoId && a.OrdenId == item.OrdenId &&
                                                        a.NroOrden == item.NroOrden && a.FlagActivo == true
                                                  select a.OrdenPaqueteId).ToList().Count;

                        var countEstadoProcesado = (from a in _bd.OrdenPaquete
                                                    where (a.EstadoOrdenPaqueteId == (int)EEstadoOrdenPaquete.Procesado) &&
                                                          a.EquipoId == item.Equipo.EquipoId && a.OrdenId == item.OrdenId &&
                                                          a.NroOrden == item.NroOrden && a.FlagActivo == true
                                                    select a.OrdenPaqueteId).Count();

                        var countEstadoAprobado = (from a in _bd.OrdenPaquete
                                                   where (a.EstadoOrdenPaqueteId == (int)EEstadoOrdenPaquete.Aprobado) &&
                                                          a.EquipoId == item.Equipo.EquipoId && a.OrdenId == item.OrdenId &&
                                                          a.NroOrden == item.NroOrden && a.FlagActivo == true
                                                   select a.OrdenPaqueteId).Count();

                        item.EstadoOrdenPaqueteId = countEstadoAprobado == lstPQ.Count ? (int)EEstadoOrdenPaquete.Aprobado :
                                               (countEstadoEnviado > 0 ? (int)EEstadoOrdenPaquete.Analizando :
                                               (countEstadoPendiente > 0 ? (int)EEstadoOrdenPaquete.Pendiente : (int)EEstadoOrdenPaquete.Procesado));
                    }

                    return listaFinal;
                }

                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }

        public ICollection<OrdenPaqueteDetalleDto> ListarOrdenDetalleServicio(int ordenPaqueteId)
        {


            {
                try
                {

                    //IRepositorio<OrdenPaqueteDetalle> reppaq = new EfRepositorio<OrdenPaqueteDetalle>(ctx);
                    //IRepositorio<Servicio> repserv = new EfRepositorio<Servicio>(ctx);
                    //IRepositorio<OrdenPaquete> repop = new EfRepositorio<OrdenPaquete>(ctx);
                    //IRepositorio<Orden> repord = new EfRepositorio<Orden>(ctx);
                    //IRepositorio<Paciente> reppac = new EfRepositorio<Paciente>(ctx);

                    var lista = (from a in _bd.OrdenPaqueteDetalle
                                 join q in _bd.Servicio on a.ServicioId equals q.ServicioId
                                 join r in _bd.OrdenPaquete on a.OrdenPaqueteId equals r.OrdenPaqueteId
                                 join s in _bd.Orden on r.OrdenId equals s.OrdenId
                                 join t in _bd.Paciente on s.PacienteId equals t.PacienteId
                                 where a.FlagActivo == true
                                 && a.FlagEliminado == false
                                 && a.OrdenPaqueteId == ordenPaqueteId
                                 orderby q.Nombre ascending
                                 select new
                                 {
                                     a.OrdenPaqueteDetalleId,
                                     a.OrdenPaqueteId,
                                     q.Nombre,
                                     a.EstadoServicioId,
                                     a.FechaCreacion,
                                     a.FechaResultado,
                                     a.Valor,
                                     a.ValorReferencia,
                                     a.Observacion,
                                     t.CorreoElectronico,
                                     a.EvaluacionPrueba,
                                     a.Indicador
                                 });

                    var listaFinal = (from a in lista.ToList()
                                      select new OrdenPaqueteDetalleDto
                                      {
                                          OrdenPaqueteDetalleId = a.OrdenPaqueteDetalleId,
                                          OrdenPaqueteId = a.OrdenPaqueteId,
                                          Servicio = new ServicioDto() { Nombre = a.Nombre },
                                          EstadoServicioId = a.EstadoServicioId,
                                          FechaCreacion = a.FechaCreacion,
                                          FechaResultado = a.FechaResultado,
                                          Valor = a.Valor,
                                          ValorReferencia = a.ValorReferencia,
                                          Observacion = a.Observacion,
                                          CorreoElectronico = a.CorreoElectronico,
                                          EvaluacionPrueba = a.EvaluacionPrueba,
                                          Indicador = a.Indicador
                                      }).ToList();

                    return listaFinal;
                }

                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }

        public ICollection<OrdenPaqueteDetalleDto> ListarOrdenDetalleServicioAgp(int ordenId, int equipoId, string nroOrden, int tipoAtencionId)
        {


            {
                try
                {
                    //IRepositorio<OrdenPaqueteDetalle> reppaq = new EfRepositorio<OrdenPaqueteDetalle>(ctx);
                    //IRepositorio<Servicio> repserv = new EfRepositorio<Servicio>(ctx);
                    //IRepositorio<OrdenPaquete> repop = new EfRepositorio<OrdenPaquete>(ctx);
                    //IRepositorio<Orden> repord = new EfRepositorio<Orden>(ctx);
                    //IRepositorio<Paciente> reppac = new EfRepositorio<Paciente>(ctx);

                    var lista = (from a in _bd.OrdenPaqueteDetalle
                                 join q in _bd.Servicio on a.ServicioId equals q.ServicioId
                                 join r in _bd.OrdenPaquete on a.OrdenPaqueteId equals r.OrdenPaqueteId
                                 join s in _bd.Orden on r.OrdenId equals s.OrdenId
                                 join t in _bd.Paciente on s.PacienteId equals t.PacienteId
                                 where a.FlagActivo == true
                                 && a.FlagEliminado == false && q.FlagActivo == true
                                 && s.OrdenId == ordenId && r.EquipoId == equipoId && r.NroOrden == nroOrden
                                 // orderby q.Nombre ascending
                                 orderby q.ReporteOrden ascending
                                 select new
                                 {
                                     s.OrdenId,
                                     a.OrdenPaqueteDetalleId,
                                     a.OrdenPaqueteId,
                                     q.Nombre,
                                     q.Descripcion,
                                     q.UnidadMedida,
                                     q.Referencia,
                                     a.EstadoServicioId,
                                     a.FechaCreacion,
                                     a.FechaResultado,
                                     a.Valor,
                                     a.ValorReferencia,
                                     a.ValorUnidad,
                                     a.Observacion,
                                     t.CorreoElectronico,
                                     a.EvaluacionPrueba,
                                     a.Indicador
                                 });

                    var listaFinal = (from a in lista.ToList()
                                      select new OrdenPaqueteDetalleDto
                                      {
                                          OrdenId = a.OrdenId,
                                          OrdenPaqueteDetalleId = a.OrdenPaqueteDetalleId,
                                          OrdenPaqueteId = a.OrdenPaqueteId,
                                          Servicio = new ServicioDto() { Nombre = a.Nombre, Descripcion = a.Descripcion, },
                                          EstadoServicioId = a.EstadoServicioId,
                                          FechaCreacion = a.FechaCreacion,
                                          FechaResultado = a.FechaResultado,
                                          Valor = a.Valor == null ? "" : a.Valor,
                                          ValorReferencia = a.Referencia == null ? (a.ValorReferencia == null ? "" : a.ValorReferencia) : a.Referencia,
                                          ValorUnidad = a.UnidadMedida == null ? (a.ValorUnidad == null ? "" : a.ValorUnidad) : a.UnidadMedida,
                                          Observacion = a.Observacion == null ? "" : a.Observacion,
                                          CorreoElectronico = a.CorreoElectronico,
                                          EvaluacionPrueba = a.EvaluacionPrueba,
                                          Indicador = a.Indicador,
                                          TipoAtencionId = tipoAtencionId
                                      }).ToList();
                    return listaFinal;
                }

                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }

        public ICollection<OrdenPaqueteDetalleDto> ListarOrdenDetalleServicioAgpAprob(int ordenId, int equipoId, string nroOrden)
        {


            {
                try
                {
                    //IRepositorio<OrdenPaqueteDetalle> reppaq = new EfRepositorio<OrdenPaqueteDetalle>(ctx);
                    //IRepositorio<Servicio> repserv = new EfRepositorio<Servicio>(ctx);
                    //IRepositorio<OrdenPaquete> repop = new EfRepositorio<OrdenPaquete>(ctx);
                    //IRepositorio<Orden> repord = new EfRepositorio<Orden>(ctx);
                    //IRepositorio<Paciente> reppac = new EfRepositorio<Paciente>(ctx);

                    var lista = (from a in _bd.OrdenPaqueteDetalle
                                 join q in _bd.Servicio on a.ServicioId equals q.ServicioId
                                 join r in _bd.OrdenPaquete on a.OrdenPaqueteId equals r.OrdenPaqueteId
                                 join s in _bd.Orden on r.OrdenId equals s.OrdenId
                                 join t in _bd.Paciente on s.PacienteId equals t.PacienteId
                                 where a.FlagActivo == true
                                 && a.FlagEliminado == false && q.FlagActivo == true
                                 && s.OrdenId == ordenId && r.EquipoId == equipoId && r.NroOrden == nroOrden &&
                                 (q.ReporteMostrar == null || q.ReporteMostrar == true)
                                 // orderby q.Nombre ascending
                                 orderby q.ReporteOrden ascending
                                 select new
                                 {
                                     s.OrdenId,
                                     a.OrdenPaqueteDetalleId,
                                     a.OrdenPaqueteId,
                                     q.Nombre,
                                     q.Descripcion,
                                     q.UnidadMedida,
                                     q.Referencia,
                                     a.EstadoServicioId,
                                     a.FechaCreacion,
                                     a.FechaResultado,
                                     a.Valor,
                                     a.ValorReferencia,
                                     a.ValorUnidad,
                                     a.Observacion,
                                     t.CorreoElectronico,
                                     a.EvaluacionPrueba,
                                     a.Indicador
                                 });

                    var listaFinal = (from a in lista.ToList()
                                      select new OrdenPaqueteDetalleDto
                                      {
                                          OrdenId = a.OrdenId,
                                          OrdenPaqueteDetalleId = a.OrdenPaqueteDetalleId,
                                          OrdenPaqueteId = a.OrdenPaqueteId,
                                          Servicio = new ServicioDto() { Nombre = a.Nombre, Descripcion = a.Descripcion, },
                                          EstadoServicioId = a.EstadoServicioId,
                                          FechaCreacion = a.FechaCreacion,
                                          FechaResultado = a.FechaResultado,
                                          Valor = a.Valor == null ? "" : a.Valor,
                                          ValorReferencia = a.Referencia == null ? (a.ValorReferencia == null ? "" : a.ValorReferencia) : a.Referencia,
                                          ValorUnidad = a.UnidadMedida == null ? (a.ValorUnidad == null ? "" : a.ValorUnidad) : a.UnidadMedida,
                                          Observacion = a.Observacion == null ? "" : a.Observacion,
                                          CorreoElectronico = a.CorreoElectronico,
                                          EvaluacionPrueba = a.EvaluacionPrueba,
                                          Indicador = a.Indicador
                                      }).ToList();
                    return listaFinal;
                }

                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }

        public OrdenDto ObtenerOrden(int id, int equipoId, string nroOrden)
        {
            try
            {

                {

                    //IRepositorio<Orden> rep = new EfRepositorio<Orden>(ctx);
                    //IRepositorio<Paciente> repPac = new EfRepositorio<Paciente>(ctx);
                    //IRepositorio<Medico> repMed = new EfRepositorio<Medico>(ctx);
                    //IRepositorio<OrdenPaquete> repOP = new EfRepositorio<OrdenPaquete>(ctx);
                    //IRepositorio<PaqueteEquipo> repPQE = new EfRepositorio<PaqueteEquipo>(ctx);
                    //IRepositorio<Paquete> repPQ = new EfRepositorio<Paquete>(ctx);

                    var lista = (from a in _bd.Orden
                                 join b in _bd.Paciente on a.PacienteId equals b.PacienteId
                                 join c in _bd.Medico on a.MedicoId equals c.MedicoId
                                 where a.OrdenId == id
                                 select new
                                 {
                                     a.OrdenId,
                                     a.FechaEmision,
                                     a.Codigo,
                                     a.HISNumero,
                                     a.NroHistoriaClinica,
                                     a.NroCama,
                                     a.Diagnostico,
                                     a.ServicioSaludId,
                                     a.ProcedenciaId,
                                     a.PacienteId,
                                     PacApePat = b.ApellidoPaterno,
                                     PacApeMat = b.ApellidoMaterno,
                                     PacNombre = b.Nombres,
                                     PacTipDoc = b.TipoDocumentoId,
                                     PacNroDoc = b.NumeroDocumento,
                                     PacSexo = b.Sexo,
                                     PacEdad = b.Edad,
                                     PacCel = b.Celular,
                                     PacHist = b.NroHistoriaClinica,
                                     PacCorreo = b.CorreoElectronico,
                                     c.MedicoId,
                                     MedApePat = c.ApellidoPaterno,
                                     MedApeMat = c.ApellidoMaterno,
                                     MedNombre = c.Nombres,
                                     MedTipDoc = c.TipoDocumentoId,
                                     MedNroDoc = c.NumeroDocumento,
                                     MedCel = c.Celular,
                                     MedColeg = c.NroColegiatura,
                                     MedCorreo = c.CorreoElectronico
                                 });

                    var orden = (from a in lista.ToList()
                                 select new OrdenDto
                                 {
                                     OrdenId = a.OrdenId,
                                     FechaEmision = a.FechaEmision,
                                     Codigo = a.Codigo,
                                     ServicioSaludId = a.ServicioSaludId,
                                     Diagnostico = a.Diagnostico,
                                     NroCama = a.NroCama,
                                     HISNumero = a.HISNumero,
                                     NroHistoriaClinica = a.NroHistoriaClinica,
                                     ProcedenciaId = a.ProcedenciaId,
                                     PacienteId = a.PacienteId,
                                     MedicoId = a.MedicoId,
                                     Paciente = new PacienteDto()
                                     {
                                         PacienteId = a.PacienteId,
                                         ApellidoPaterno = a.PacApePat,
                                         ApellidoMaterno = a.PacApeMat,
                                         Nombres = a.PacNombre,
                                         TipoDocumentoId = a.PacTipDoc,
                                         NumeroDocumento = a.PacNroDoc,
                                         Sexo = a.PacSexo,
                                         Edad = a.PacEdad,
                                         Celular = a.PacCel,
                                         NroHistoriaClinica = a.PacHist,
                                         CorreoElectronico = a.PacCorreo
                                     },
                                     Medico = new MedicoDto()
                                     {
                                         MedicoId = a.MedicoId,
                                         ApellidoPaterno = a.MedApePat,
                                         ApellidoMaterno = a.MedApeMat,
                                         Nombres = a.MedNombre,
                                         TipoDocumentoId = a.MedTipDoc,
                                         NumeroDocumento = a.MedNroDoc,
                                         Celular = a.MedCel,
                                         NroColegiatura = a.MedColeg,
                                         CorreoElectronico = a.MedCorreo
                                     }
                                 }).FirstOrDefault();

                    var pqt = (from a in _bd.OrdenPaquete
                               where a.OrdenId == id && a.EquipoId == equipoId && a.NroOrden == nroOrden && a.FlagActivo == true
                               select a).Include("Paquete").Include("Equipo").ToList();

                    orden.AreaEstudioId = pqt.Select(o => o.Paquete.AreaEstudioId).FirstOrDefault().Value;

                    orden.ListaPaquetes = (from x in pqt
                                           join y in _bd.PaqueteEquipo on new { EquipoId = x.EquipoId.Value, x.PaqueteId } equals new { y.EquipoId, y.PaqueteId }
                                           join z in _bd.Paquete on y.PaqueteId equals z.PaqueteId
                                           where y.FlagActivo == true //z.EsCalculado == false || z.EsCalculado == null && 
                                           select new ComboDto()
                                           {
                                               Id = y.PaqueteEquipoId,
                                               Descripcion = x.Paquete.Nombre + " - " + x.Equipo.Nombre
                                           }).ToList();

                    return orden;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }
        }

        public OrdenDto ObtenerOrden_x_Codigo(string codigo)
        {
            try
            {

                {
                    //IRepositorio<Orden> rep = new EfRepositorio<Orden>(ctx);
                    //IRepositorio<OrdenPaquete> repPQ = new EfRepositorio<OrdenPaquete>(ctx);
                    //IRepositorio<Paciente> rep1 = new EfRepositorio<Paciente>(ctx);

                    var lista = (from a in _bd.Orden
                                 join b in _bd.Paciente on a.PacienteId equals b.PacienteId
                                 join c in _bd.OrdenPaquete on a.OrdenId equals c.OrdenId
                                 where c.NroOrden == codigo
                                 select new
                                 {
                                     c.NroOrden,
                                     b.ApellidoPaterno,
                                     b.ApellidoMaterno,
                                     b.Nombres,
                                     a.FechaEmision,
                                     a.HISNumero
                                 });

                    var orden = (from a in lista.ToList()
                                 select new OrdenDto
                                 {
                                     NroOrden = a.NroOrden,
                                     FechaEmision = a.FechaEmision,
                                     HISNumero = a.HISNumero,
                                     Paciente = new PacienteDto
                                     {
                                         ApellidoPaterno = a.ApellidoPaterno,
                                         ApellidoMaterno = a.ApellidoMaterno,
                                         Nombres = a.Nombres
                                     }
                                 }
                                 ).FirstOrDefault();
                    return orden;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }
        }


        public ICollection<Orden> ListarOrden()
        {
            try
            {

                {
                    //IRepositorio<Orden> rep = new EfRepositorio<Orden>(ctx);
                    var lista = (from a in _bd.Orden

                                 where a.FlagActivo == true && a.FlagEliminado == false
                                 select new
                                 {
                                     a.OrdenId,
                                     a.FechaEmision,
                                     a.FechaCreacion,
                                     a.HISNumero,
                                     a.FlagActivo
                                 });

                    var orden = (from a in lista.ToList()
                                 select new Orden
                                 {
                                     OrdenId = a.OrdenId,
                                     FechaEmision = a.FechaEmision,
                                     HISNumero = a.HISNumero,
                                     FechaCreacion = a.FechaCreacion,
                                     FlagActivo = a.FlagActivo

                                 }
                                 ).ToList();
                    return orden;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }
        }


        public Orden ObtenerOrden_x_Solicitud(string nroSol)
        {
            try
            {
                {
                    //IRepositorio<Orden> rep = new EfRepositorio<Orden>(ctx);
                    //IRepositorio<OrdenPaquete> repPQ = new EfRepositorio<OrdenPaquete>(ctx);
                    //IRepositorio<Paciente> rep1 = new EfRepositorio<Paciente>(ctx);

                    var lista = (from a in _bd.Orden
                                 join b in _bd.OrdenPaquete on a.OrdenId equals b.OrdenId
                                 where a.HISNumero == nroSol && a.FlagActivo == true && b.FlagActivo == true
                                 select new
                                 {
                                     a.Codigo,
                                     a.FechaEmision,
                                     a.HISNumero
                                 });

                    var orden = (from a in lista.ToList()
                                 select new Orden
                                 {
                                     Codigo = a.Codigo,
                                     FechaEmision = a.FechaEmision,
                                     HISNumero = a.HISNumero
                                 }
                                 ).FirstOrDefault();
                    return orden;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }
        }
        public ICollection<OrdenPaqueteDto> ObtenerOrden_BarCode_ID(int ordenId)
        {

            {
                try
                {
                    //IRepositorio<Orden> rep = new EfRepositorio<Orden>(ctx);
                    //IRepositorio<OrdenPaquete> reppaq = new EfRepositorio<OrdenPaquete>(ctx);
                    //IRepositorio<Paquete> repPaquete = new EfRepositorio<Paquete>(ctx);
                    //IRepositorio<Paciente> repPaciente = new EfRepositorio<Paciente>(ctx);
                    //IRepositorio<PaqueteServicio> repPqSrv = new EfRepositorio<PaqueteServicio>(ctx);
                    //IRepositorio<Servicio> repSrv = new EfRepositorio<Servicio>(ctx);
                    //IRepositorio<AreaEstudio> repAE = new EfRepositorio<AreaEstudio>(ctx);
                    //IRepositorio<TipoMuestraAnalizador> repTipoMA = new EfRepositorio<TipoMuestraAnalizador>(ctx);
                    //IRepositorio<TipoPaciente> repTP = new EfRepositorio<TipoPaciente>(ctx);
                    //IRepositorio<Equipo> repEqui = new EfRepositorio<Equipo>(ctx);

                    var lista = (from aa in _bd.Orden
                                 join q in _bd.OrdenPaquete on aa.OrdenId equals q.OrdenId
                                 join w in _bd.Paquete on q.PaqueteId equals w.PaqueteId
                                 join e in _bd.Paciente on aa.PacienteId equals e.PacienteId
                                 join f in _bd.AreaEstudio on w.AreaEstudioId equals f.AreaEstudioId
                                 join g in _bd.TipoMuestraAnalizador on w.TipoMuestraAnalizadorId equals g.TipoMuestraAnalizadorId into p1
                                 from q1 in p1.DefaultIfEmpty()
                                 join h in _bd.TipoPaciente on aa.TipoPacienteId equals h.TipoPacienteId into p2
                                 from q2 in p2.DefaultIfEmpty()
                                 join n in _bd.Equipo on q.EquipoId equals n.EquipoId
                                 where aa.FlagActivo == true && aa.FlagEliminado == false &&
                                       q.FlagActivo == true && q.FlagEliminado == false && aa.OrdenId == ordenId &&
                                       (w.ImprimeEtiqueta == null || w.ImprimeEtiqueta == true)
                                 orderby aa.FechaCreacion descending
                                 select new
                                 {
                                     aa.OrdenId,
                                     aa.HISNumero,
                                     q.OrdenPaqueteId,
                                     q.EstadoOrdenPaqueteId,
                                     PaqueteNombre = w.Nombre,
                                     w.TipoMuestraAnalizadorId,
                                     MuestraAnalizador = q1.Nombre,
                                     aa.Codigo,
                                     aa.FechaEmision,
                                     aa.FechaCreacion,
                                     q.NroOrden,
                                     PacienteNombre = e.Nombres,
                                     PacienteAP = e.ApellidoPaterno,
                                     PacienteAM = e.ApellidoMaterno,
                                     e.Edad,
                                     Pruebas = w.Descripcion,
                                     AreaEstudio = f.Nombre,
                                     TipoPaciente = q2.Nombre,
                                     n.EquipoId,
                                     n.TipoBarcodeId
                                 }).ToList();

                    var listaFinal = lista.GroupBy(grp => new
                    {
                        grp.OrdenId,
                        grp.NroOrden,
                        grp.HISNumero,
                        grp.Codigo,
                        grp.FechaEmision,
                        grp.FechaCreacion,
                        grp.PacienteNombre,
                        grp.PacienteAP,
                        grp.PacienteAM,
                        grp.Edad,
                        grp.TipoMuestraAnalizadorId,
                        grp.MuestraAnalizador,
                        grp.AreaEstudio,
                        grp.TipoPaciente,
                        grp.TipoBarcodeId,
                        grp.EquipoId
                    }).Select(grp => new OrdenPaqueteDto()
                    {
                        NroOrden = grp.Key.NroOrden,
                        Paquete = new PaqueteDto()
                        {
                            Muestra = grp.Key.TipoMuestraAnalizadorId == null ? "" : grp.Key.MuestraAnalizador,
                            AreaEstudio = new AreaEstudioDto() { Nombre = grp.Key.AreaEstudio }
                        },
                        Equipo = new EquipoDto()
                        {
                            EquipoId = grp.Key.EquipoId,
                            TipoBarcodeId = grp.Key.TipoBarcodeId
                        },
                        Codigo = grp.Key.Codigo,
                        Orden = new OrdenDto()
                        {
                            OrdenId = grp.Key.OrdenId,
                            FechaEmision = grp.Key.FechaEmision,
                            FechaCreacion = grp.Key.FechaCreacion,
                            HISNumero = grp.Key.HISNumero,
                            Paciente = new PacienteDto()
                            {
                                Nombres = grp.Key.PacienteNombre,
                                ApellidoMaterno = grp.Key.PacienteAM,
                                ApellidoPaterno = grp.Key.PacienteAP,
                                Edad = grp.Key.Edad,
                            },
                            TipoPaciente = new TipoPacienteDto() { Nombre = grp.Key.TipoPaciente }
                        },
                        OrdenId = grp.Key.OrdenId,
                        Pruebas = string.Join(" ", grp.Select(m => m.Pruebas).Distinct()).Length > 23 ? string.Join(" ", grp.Select(m => m.Pruebas).Distinct()).Substring(0, 23) : string.Join(" ", grp.Select(m => m.Pruebas).Distinct())
                    }).ToList();

                    return listaFinal;
                }

                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }
        public void EliminaOrden(int id, bool estado, string usuario)
        {

            {
                try
                {
                    var obj = _bd.Orden.Find(id);
                    obj.FlagActivo = estado;
                    obj.ModificadoPor = usuario;
                    obj.FechaModificacion = DateTime.Now;
                    _bd.SaveChanges();
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }

        public int RegistrarOrden(Orden orden)
        {



            var ordenId = 0;
            var ordPQ = new List<OrdenPaqueteDto>();

            try
            {
                //IRepositorio<Orden> rep = new EfRepositorio<Orden>(ctx);
                //IRepositorio<Paciente> repPaciente = new EfRepositorio<Paciente>(ctx);
                //IRepositorio<Medico> repMedico = new EfRepositorio<Medico>(ctx);
                //IRepositorio<OrdenPaquete> repPQ = new EfRepositorio<OrdenPaquete>(ctx);
                //IRepositorio<OrdenPaqueteDetalle> repPQD = new EfRepositorio<OrdenPaqueteDetalle>(ctx);
                //IRepositorio<PaqueteEquipo> repPE = new EfRepositorio<PaqueteEquipo>(ctx);
                //IRepositorio<Paquete> repPaq = new EfRepositorio<Paquete>(ctx);
                //IRepositorio<SGSSSolExaLabCPS> repSGSSCPS = new EfRepositorio<SGSSSolExaLabCPS>(ctx);

                #region Paciente
                var paciente = (from a in _bd.Set<Paciente>()
                                where a.PacienteId == orden.Paciente.PacienteId
                                select a).FirstOrDefault();

                if (paciente == null)
                {
                    orden.Paciente.CreadoPor = orden.CreadoPor;
                    orden.Paciente.FechaCreacion = orden.FechaCreacion;
                    orden.Paciente.FlagActivo = orden.FlagActivo;
                    orden.Paciente.FlagEliminado = orden.FlagEliminado;

                    _bd.Paciente.Add(orden.Paciente);

                }
                else
                {
                    paciente.TipoDocumentoId = orden.Paciente.TipoDocumentoId;
                    paciente.NumeroDocumento = orden.Paciente.NumeroDocumento;
                    paciente.Nombres = orden.Paciente.Nombres;
                    paciente.ApellidoPaterno = orden.Paciente.ApellidoPaterno;
                    paciente.ApellidoMaterno = orden.Paciente.ApellidoMaterno;
                    paciente.Celular = orden.Paciente.Celular;
                    paciente.FechaNacimiento = null;
                    paciente.Sexo = orden.Paciente.Sexo;
                    paciente.CorreoElectronico = orden.Paciente.CorreoElectronico;
                    paciente.NroHistoriaClinica = orden.Paciente.NroHistoriaClinica;
                    paciente.Edad = orden.Paciente.Edad;
                    //repPaciente.Update(paciente);

                    orden.Paciente = paciente;
                }
                #endregion

                #region Medico
                if (orden.Medico != null)
                {
                    var medico = (from a in _bd.Set<Medico>()
                                  where a.MedicoId == orden.Medico.MedicoId
                                  select a).FirstOrDefault();

                    if (medico == null)
                    {
                        if (orden.Medico.Nombres != null || orden.Medico.ApellidoPaterno != null)
                        {
                            orden.Medico.TipoDocumentoId = 1;
                            orden.Medico.CreadoPor = orden.CreadoPor;
                            orden.Medico.FechaCreacion = orden.FechaCreacion;
                            orden.Medico.FlagActivo = orden.FlagActivo;
                            orden.Medico.FlagEliminado = orden.FlagEliminado;
                            _bd.Medico.Add(orden.Medico);
                            //repMedico.Insert(orden.Medico);
                        }
                        else
                            orden.Medico = null;


                    }
                    else
                    {

                        medico.TipoDocumentoId = orden.Medico.TipoDocumentoId;
                        medico.NumeroDocumento = orden.Medico.NumeroDocumento;
                        medico.Nombres = orden.Medico.Nombres;
                        medico.ApellidoPaterno = orden.Medico.ApellidoPaterno;
                        medico.ApellidoMaterno = orden.Medico.ApellidoMaterno;
                        medico.Celular = orden.Medico.Celular;
                        medico.CorreoElectronico = orden.Medico.CorreoElectronico;
                        medico.NroColegiatura = orden.Medico.NroColegiatura;
                        //repMedico.Update(medico);

                        orden.Medico = medico;
                    }
                }
                #endregion

                #region Orden
                if (orden.OrdenId == 0)
                {
                    //var correla = ServiceManager<CorrelativoSvc>.Provider.RegistrarCorrelativo((int)TipoCorrelativo.ORDEN_SOLICITUD, orden.CentroSaludAsistencialId.Value, orden.CreadoPor, orden.FechaEmision);

                    var centroId = orden.CentroSaludAsistencialId.Value;
                    var fechaEmision = orden.FechaEmision;
                    var tipoCorrelativo = (int)TipoCorrelativo.ORDEN_SOLICITUD;
                    var annio = fechaEmision.Year;
                    //IRepositorio<Correlativo> repCorr = new EfRepositorio<Correlativo>(ctx);

                    var correlativo = _bd.Correlativo.Where(m => m.TipoCorrelativo == tipoCorrelativo && m.FechaEmision.Year == annio &&
                                                               m.FechaEmision.Month == fechaEmision.Month).OrderByDescending(p => p.CorrelativoId).FirstOrDefault();

                    var indent = centroId.ToString().PadLeft(1, '0');
                    var year = fechaEmision.ToString("yy");
                    var month = fechaEmision.Month.ToString().PadLeft(2, '0');
                    var day = fechaEmision.Day.ToString().PadLeft(2, '0');

                    if (correlativo == null)
                    {
                        _bd.Correlativo.Add(new Correlativo()
                        {
                            Valor = 1,
                            Ceros = indent + year + month + "000",
                            FechaEmision = fechaEmision,
                            FechaCreacion = DateTime.Now,
                            CreadoPor = orden.CreadoPor,
                            FlagActivo = true,
                            TipoCorrelativo = tipoCorrelativo,
                            Prefijo = Util.GetEnumDescription((TipoCorrelativo)tipoCorrelativo)
                        });
                    }
                    else
                    {
                        if (correlativo.Valor + 1 > 9999)
                        {
                            var corrVal = correlativo.Valor + 1 - 9999;

                            _bd.Correlativo.Add(new Correlativo()
                            {
                                Valor = correlativo.Valor + 1,
                                Ceros = indent + corrVal.ToString().PadLeft(4, '0') + year + month,
                                FechaEmision = fechaEmision,
                                FechaCreacion = DateTime.Now,
                                CreadoPor = orden.CreadoPor,
                                FlagActivo = true,
                                TipoCorrelativo = tipoCorrelativo,
                                Prefijo = Util.GetEnumDescription((TipoCorrelativo)tipoCorrelativo)
                            });
                        }
                        else
                        {
                            _bd.Correlativo.Add(new Correlativo()
                            {
                                Valor = correlativo.Valor + 1,
                                Ceros = indent + year + month + "".PadLeft(4 - (correlativo.Valor + 1).ToString().Length, '0'),
                                FechaEmision = fechaEmision,
                                FechaCreacion = DateTime.Now,
                                CreadoPor = orden.CreadoPor,
                                FlagActivo = true,
                                TipoCorrelativo = tipoCorrelativo,
                                Prefijo = Util.GetEnumDescription((TipoCorrelativo)tipoCorrelativo)
                            });
                        }
                    }

                    var correla = _bd.Correlativo.Where(m => m.TipoCorrelativo == tipoCorrelativo && m.FechaEmision.Year == annio &&
                                                           m.FechaEmision.Month == fechaEmision.Month).OrderByDescending(p => p.CorrelativoId).FirstOrDefault();

                    var dtoCorrelativo = InitAutoMapper.mapper.Map<CorrelativoDto>(correla);

                    orden.Codigo = dtoCorrelativo.CodigoAutogenerado;
                    //orden.CorrelativoId = correla.CorrelativoId;
                    orden.EstadoOrdenId = (int)EEstadoOrden.Pendiente;

                    //rep.Insert(orden);
                    _bd.Orden.Add(orden);

                    ordenId = orden.OrdenId;
                }
                else
                {
                    var act = _bd.Orden.FirstOrDefault(m => m.OrdenId == orden.OrdenId);
                    act.Codigo = orden.Codigo;
                    act.FechaEmision = orden.FechaEmision;
                    act.PacienteId = orden.Paciente.PacienteId;
                    act.MedicoId = orden.Medico.MedicoId;
                    act.ModificadoPor = orden.ModificadoPor;
                    act.FechaModificacion = orden.FechaModificacion;
                    act.ProcedenciaId = orden.ProcedenciaId;
                    act.ServicioSaludId = orden.ServicioSaludId;
                    act.NroCama = orden.NroCama;
                    act.Diagnostico = orden.Diagnostico;

                    //rep.Update(act);

                    ordenId = act.OrdenId;

                    orden.Paquetes = orden.Paquetes == null ? new List<int>() : orden.Paquetes;

                    ordPQ = InitAutoMapper.mapper.Map<List<OrdenPaqueteDto>>( _bd.OrdenPaquete.Where(o => o.OrdenId == orden.OrdenId && o.FlagActivo == true &&
                                                       o.EquipoId == orden.EquipoId && o.NroOrden == orden.NroOrden).ToList());

                    foreach (var item in ordPQ)
                    {
                        item.FlagActivo = false;
                        item.FlagEliminado = true;
                        item.ModificadoPor = orden.ModificadoPor;
                        item.FechaModificacion = orden.FechaModificacion;
                        //repPQ.Update(item);

                        item.OrdenPaqueteDetalles = new List<OrdenPaqueteDetalleDto>();

                        var ordPDQ = _bd.OrdenPaqueteDetalle.Where(o => o.OrdenPaqueteId == item.OrdenPaqueteId).ToList();

                        foreach (var pqd in ordPDQ)
                        {
                            pqd.FlagActivo = false;
                            pqd.FlagEliminado = true;
                            pqd.ModificadoPor = orden.ModificadoPor;
                            pqd.FechaModificacion = orden.FechaModificacion;
                            //repPQD.Update(pqd);

                            item.OrdenPaqueteDetalles.Add(InitAutoMapper.mapper.Map<OrdenPaqueteDetalleDto>(pqd));
                        }
                    }
                }
                #endregion

                var lstCalculado = (from a in _bd.Set<ParametroCalculado>()
                                    join b in _bd.Set<PaqueteEquipo>() on a.PaqueteEquipoId equals b.PaqueteEquipoId
                                    select new
                                    {
                                        a.ServicioId,
                                        a.PaqueteEquipoId,
                                        b.EquipoId
                                    });

                var parametroCalculado = (from a in lstCalculado.ToList()
                                          select new ParametroCalculadoDto
                                          {
                                              ServicioId = a.ServicioId,
                                              PaqueteEquipoId = a.PaqueteEquipoId,
                                              EquipoId = a.EquipoId
                                          }).ToList();

                var paqTmp = new Paquete();
                var lstPaqueteEquipo = new List<PaqueteEquipoDto>();

                foreach (var item in orden.Paquetes)
                {
                    var pqe = (from a in _bd.PaqueteEquipo
                               join b in _bd.Paquete on a.PaqueteId equals b.PaqueteId
                               where a.PaqueteEquipoId == item && a.FlagActivo == true
                               select new
                               {
                                   a.PaqueteEquipoId,
                                   a.PaqueteId,
                                   a.EquipoId,
                                   MuestraAnalizadorId = b.TipoMuestraAnalizadorId == null ? 0 : b.TipoMuestraAnalizadorId.Value
                               }).ToList();

                    var pqeT = pqe.FirstOrDefault();

                    if (pqe.Count() > 0)
                        lstPaqueteEquipo.Add(new PaqueteEquipoDto() { PaqueteEquipoId = pqeT.PaqueteEquipoId, PaqueteId = pqeT.PaqueteId, EquipoId = pqeT.EquipoId, MuestraAnalizadorId = pqeT.MuestraAnalizadorId });

                }

                var lstAGP = lstPaqueteEquipo.GroupBy(grp => new
                {
                    grp.MuestraAnalizadorId
                }).Select(grp => new PaqueteEquipoDto()
                {
                    MuestraAnalizadorId = grp.Key.MuestraAnalizadorId
                });

                foreach (var paqEqAGP in lstAGP)
                {


                    var paquetes = lstPaqueteEquipo.Where(o => o.MuestraAnalizadorId == paqEqAGP.MuestraAnalizadorId).ToList();

                    orden.Paquetes = paquetes.Select(o => o.PaqueteEquipoId).ToList();

                    while (orden.Paquetes.Count > 0)
                    {
                        var item = orden.Paquetes[0];

                        var paqueteEquipo = lstPaqueteEquipo.Where(o => o.PaqueteEquipoId == item).FirstOrDefault();
                        var equipoID = paqueteEquipo.EquipoId;

                        var op = new OrdenPaquete()
                        {
                            FlagActivo = true,
                            FlagEliminado = false,
                            CreadoPor = orden.CreadoPor,
                            FechaCreacion = orden.FechaCreacion,
                            OrdenId = orden.OrdenId,
                            PaqueteId = paqueteEquipo.PaqueteId,
                            EquipoId = equipoID,
                            //NroOrden = correla.CodigoAutogenerado,
                            NroOrden = orden.Codigo + paqEqAGP.MuestraAnalizadorId.ToString().PadLeft(2, '0'),
                            EstadoOrdenPaqueteId = (int)EEstadoOrdenPaquete.Pendiente
                        };

                        var dOp = ordPQ.Where(o => o.OrdenId == orden.OrdenId && o.PaqueteId == paqueteEquipo.PaqueteId && o.EquipoId == equipoID).FirstOrDefault();
                        SGSSSolExaLabCPS sgssCPS = null;
                        if (dOp != null)
                        {
                            op.EstadoOrdenPaqueteId = dOp.EstadoOrdenPaqueteId;
                            op.FechaProcesamiento = dOp.FechaProcesamiento;
                            op.UsuarioApruebaId = dOp.UsuarioApruebaId;
                            op.UsuarioInterface = dOp.UsuarioInterface;
                            op.FechaAprobacion = dOp.FechaAprobacion;
                            op.InformeResultado = dOp.InformeResultado;

                            sgssCPS = _bd.SGSSSolExaLabCPS.Where(o => o.OrdenId == orden.OrdenId && o.OrdenPaqueteId == dOp.OrdenPaqueteId).FirstOrDefault();

                        }

                        //repPQ.Insert(op);
                        _bd.OrdenPaquete.Add(op);

                        if (sgssCPS != null)
                        {
                            sgssCPS.CreadoPor = "Admin";
                            sgssCPS.FechaCreacion = DateTime.Now;
                            sgssCPS.FlagActivo = true;
                            sgssCPS.FlagEliminado = false;
                            sgssCPS.OrdenPaqueteId = op.OrdenPaqueteId;
                            //repSGSSCPS.Update(sgssCPS);
                        }


                        var ser = (from a in _bd.Set<PaqueteServicio>()
                                   where a.PaqueteId == paqueteEquipo.PaqueteId
                                   && a.FlagActivo == true
                                   select a.Servicio).ToList();

                        foreach (var s in ser)
                        {
                            foreach (var pc in parametroCalculado.Where(o => o.MarcaParametro == false && o.EquipoId == equipoID))
                            {
                                pc.MarcaParametro = pc.ServicioId == s.ServicioId ? true : false;
                            }

                            var servInt = _bd.Set<ServicioInterfaz>().Where(o => o.ServicioId == s.ServicioId && o.EquipoId == equipoID &&
                                                                                 o.FlagActivo == true && o.FlagEliminado == false).FirstOrDefault();

                            var opd = new OrdenPaqueteDetalle()
                            {
                                FlagActivo = true,
                                FlagEliminado = false,
                                CreadoPor = orden.CreadoPor,
                                FechaCreacion = orden.FechaCreacion,
                                OrdenId = orden.OrdenId,
                                OrdenPaquete = op,
                                Servicio = s,
                                CodigoUnico = servInt == null ? null : servInt.CodigoInterfaz, //s.CodigoInterfaz,
                                EstadoServicioId = (int)EEstadoPrueba.Pendiente
                            };

                            if (dOp != null && dOp.OrdenPaqueteDetalles != null)
                            {
                                var detOp = dOp.OrdenPaqueteDetalles.Where(o => o.OrdenId == orden.OrdenId && o.ServicioId == s.ServicioId).FirstOrDefault();
                                if (detOp != null)
                                {
                                    opd.ResultadoAutomatizado = detOp.ResultadoAutomatizado;
                                    opd.EstadoServicioId = detOp.EstadoServicioId;
                                    opd.FechaResultado = detOp.FechaResultado;
                                    opd.Valor = detOp.Valor;
                                    opd.ValorReferencia = detOp.ValorReferencia;
                                    opd.EvaluacionPrueba = detOp.EvaluacionPrueba;
                                    opd.FechaProcesaInterface = detOp.FechaProcesaInterface;
                                    opd.Indicador = detOp.Indicador;
                                    opd.ValorUnidad = detOp.ValorUnidad;
                                    opd.Observacion = detOp.Observacion;
                                }
                            }

                            //repPQD.Insert(opd);
                            _bd.OrdenPaqueteDetalle.Add(opd);
                        }

                        var pqAgp = parametroCalculado.Where(o => o.EquipoId == equipoID).GroupBy(grp => new
                        {
                            grp.PaqueteEquipoId
                        }).Select(grp => new ParametroCalculado()
                        {
                            PaqueteEquipoId = grp.Key.PaqueteEquipoId
                        }).ToList();

                        foreach (var pc in pqAgp)
                        {
                            if (parametroCalculado.Where(o => o.PaqueteEquipoId == pc.PaqueteEquipoId && o.MarcaParametro == true && o.EquipoId == equipoID).ToList().Count ==
                                parametroCalculado.Where(o => o.PaqueteEquipoId == pc.PaqueteEquipoId && o.EquipoId == equipoID).ToList().Count)
                            {
                                if (!orden.Paquetes.Contains(pc.PaqueteEquipoId))
                                    orden.Paquetes.Add(pc.PaqueteEquipoId);

                                parametroCalculado.RemoveAll(o => o.PaqueteEquipoId == pc.PaqueteEquipoId);

                                var pqDato = _bd.PaqueteEquipo.Where(o => o.PaqueteEquipoId == pc.PaqueteEquipoId && o.EquipoId == equipoID).FirstOrDefault();

                                lstPaqueteEquipo.Add(new PaqueteEquipoDto() { PaqueteId = pqDato.PaqueteId, PaqueteEquipoId = pc.PaqueteEquipoId, EquipoId = equipoID });
                            }
                        }

                        orden.Paquetes.Remove(item);
                    }
                }


                _bd.SaveChanges();

                return ordenId;

            }
            
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }


        }

        public void ActualizarOrdenServicio(OrdenPaqueteDetalle ordenPD)
        {

            {
                try
                {
                    var valor = ordenPD.Valor;
                    var ordenServicio = _bd.OrdenPaqueteDetalle.Find(ordenPD.OrdenPaqueteDetalleId);
                    ordenServicio.FechaResultado = ordenPD.FechaResultado;
                    ordenServicio.Valor = valor;
                    ordenServicio.ValorReferencia = ordenPD.ValorReferencia;
                    ordenServicio.ValorUnidad = ordenPD.ValorUnidad;
                    ordenServicio.Observacion = ordenPD.Observacion;
                    ordenServicio.FechaModificacion = ordenPD.FechaModificacion;
                    ordenServicio.ModificadoPor = ordenPD.ModificadoPor;
                    ordenServicio.EstadoServicioId = (int)EEstadoPrueba.Procesado;

                    var valorReferencia = ordenServicio.ValorReferencia;


                    if (!string.IsNullOrEmpty(valorReferencia))
                    {
                        if (valorReferencia.Contains("-"))
                        {
                            Decimal i = 0;
                            var a = valorReferencia.Split('-')[0].ToString();
                            var b = valorReferencia.Split('-')[1].ToString();

                            bool resulta = Decimal.TryParse(a, out i);
                            bool resultb = Decimal.TryParse(b, out i);

                            try
                            {
                                var valorDec = Convert.ToDecimal(valor);
                                if (resulta == true && resultb == true)
                                {
                                    var valorR1 = Convert.ToDecimal(valorReferencia.Split('-')[0].ToString());
                                    var valorR2 = Convert.ToDecimal(valorReferencia.Split('-')[1].ToString());
                                    ordenServicio.EvaluacionPrueba = valorDec >= valorR1 && valorDec <= valorR2 ? "N" : valorDec < valorR1 ? "L" : valorDec > valorR2 ? "H" : "";
                                    ordenServicio.Indicador = valorDec >= valorR1 && valorDec <= valorR2 ? "#24E711" : valorDec < valorR1 ? "#F8F32B" : valorDec > valorR2 ? "#F80000" : "";

                                }
                            }
                            catch
                            { }
                        }
                    }

                    _bd.SaveChanges();


                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }

        public OrdenPaqueteDetalle ObtenerPaqueteDetalle(int ordenId, string codigoHIS)
        {


            {
                try
                {
                    //IRepositorio<OrdenPaqueteDetalle> reppaq = new EfRepositorio<OrdenPaqueteDetalle>(ctx);
                    //IRepositorio<OrdenPaquete> repop = new EfRepositorio<OrdenPaquete>(ctx);
                    //IRepositorio<HISEquivPaqueteServicio> repserv = new EfRepositorio<HISEquivPaqueteServicio>(ctx);

                    var lista = (from a in _bd.OrdenPaqueteDetalle
                                 join b in _bd.OrdenPaquete on a.OrdenPaqueteId equals b.OrdenPaqueteId
                                 join c in _bd.HISEquivPaqueteServicio on new { b.PaqueteId, a.ServicioId } equals new { c.PaqueteId, c.ServicioId }
                                 where a.FlagActivo == true && a.FlagEliminado == false &&
                                       b.OrdenId == ordenId && c.CodigoPruebaHIS == codigoHIS
                                 select new
                                 {
                                     a.OrdenPaqueteDetalleId,
                                     a.OrdenPaqueteId
                                 });

                    var ordPaq = (from a in lista.ToList()
                                  select new OrdenPaqueteDetalle
                                  {
                                      OrdenPaqueteDetalleId = a.OrdenPaqueteDetalleId,
                                      OrdenPaqueteId = a.OrdenPaqueteId
                                  }).FirstOrDefault();
                    return ordPaq;
                }

                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }

        public OrdenPaqueteDetalleDto ObtenerPaqueteDetalle(int ordenId, string codCPSSGSS, string codMuestraSGSS)
        {
            {
                try
                {
                    //IRepositorio<OrdenPaqueteDetalle> reppaqd = new EfRepositorio<OrdenPaqueteDetalle>(ctx);
                    //IRepositorio<OrdenPaquete> repop = new EfRepositorio<OrdenPaquete>(ctx);
                    //IRepositorio<Paquete> reppaq = new EfRepositorio<Paquete>(ctx);
                    //IRepositorio<IntEquivPaqueteEquipo> repserv = new EfRepositorio<IntEquivPaqueteEquipo>(ctx);

                    var lista = (from a in _bd.OrdenPaqueteDetalle
                                 join b in _bd.OrdenPaquete on a.OrdenPaqueteId equals b.OrdenPaqueteId
                                 join c in _bd.IntEquivPaqueteEquipo on new { b.PaqueteId } equals new { c.PaqueteId }
                                 join d in _bd.Paquete on b.PaqueteId equals d.PaqueteId
                                 where a.FlagActivo == true && a.FlagEliminado == false &&
                                       b.OrdenId == ordenId && c.CodigoCPS == codCPSSGSS && c.CodigoMuestra == codMuestraSGSS
                                 select new
                                 {
                                     a.OrdenPaqueteDetalleId,
                                     a.OrdenPaqueteId,
                                     d.Nombre
                                 });

                    var ordPaq = (from a in lista.ToList()
                                  select new OrdenPaqueteDetalleDto
                                  {
                                      OrdenPaqueteDetalleId = a.OrdenPaqueteDetalleId,
                                      OrdenPaqueteId = a.OrdenPaqueteId,
                                      NombrePaquete = a.Nombre
                                  }).FirstOrDefault();
                    return ordPaq;
                }

                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }

        public void AprobarResultadoPrueba(OrdenPaquete ordenPaquete)
        {

            {
                try
                {
                    //IRepositorio<Orden> repOrd = new EfRepositorio<Orden>(ctx);
                    //IRepositorio<OrdenPaquete> rep = new EfRepositorio<OrdenPaquete>(ctx);
                    //IRepositorio<OrdenPaqueteDetalle> repPD = new EfRepositorio<OrdenPaqueteDetalle>(ctx); 
                    //IRepositorio<SGSSSolExaLabCPS> repCPS = new EfRepositorio<SGSSSolExaLabCPS>(ctx);
                    //IRepositorio<OrdenPaqueteAcceso> repPQA = new EfRepositorio<OrdenPaqueteAcceso>(ctx);
                    //IRepositorio<Servicio> repServ = new EfRepositorio<Servicio>(ctx);
                    //IRepositorio<TrazabilidadServicio> repTra = new EfRepositorio<TrazabilidadServicio>(ctx);

                    var token = Util.GenerarToken(Util.Get<int>("Token.Longitud"));
                    var ordPqBD = _bd.OrdenPaquete.Find(ordenPaquete.OrdenPaqueteId);
                    var ordBD = _bd.Orden.Find(ordPqBD.OrdenId);

                    var ordPaqAcceso = new OrdenPaqueteAcceso()
                    {
                        OrdenId = ordPqBD.OrdenId,
                        OrdenPaqueteId = ordPqBD.OrdenPaqueteId,
                        Token = token.ToUpper(),
                        FechaIniVigencia = DateTime.Now,
                        FechaFinVigencia = DateTime.Now.AddDays(Util.Get<int>("Token.Resultado.Dias")),
                        FechaCreacion = DateTime.Now,
                        CreadoPor = ordenPaquete.ModificadoPor,
                        FlagActivo = true,
                        FlagEliminado = false
                    };
                    _bd.OrdenPaqueteAcceso.Add(ordPaqAcceso);


                    ordPqBD.EstadoOrdenPaqueteId = (int)EEstadoOrdenPaquete.Aprobado;
                    ordPqBD.ModificadoPor = ordenPaquete.ModificadoPor;
                    ordPqBD.FechaModificacion = ordenPaquete.FechaModificacion;
                    ordPqBD.UsuarioApruebaId = ordenPaquete.UsuarioApruebaId;
                    ordPqBD.FechaAprobacion = ordenPaquete.FechaAprobacion;
                    _bd.SaveChanges();

                    var listOrdPD = (from a in _bd.OrdenPaqueteDetalle
                                     where a.OrdenPaqueteId == ordenPaquete.OrdenPaqueteId &&
                                           a.FlagActivo == true && a.FlagEliminado == false
                                     select new
                                     {
                                         a.OrdenPaqueteDetalleId
                                     }).ToList();

                    //NEW HIS
                    var sgssExa = _bd.SGSSSolExaLabCPS.Where(o => o.OrdenId == ordPqBD.OrdenId && o.OrdenPaqueteId == ordPqBD.OrdenPaqueteId).FirstOrDefault();

                    if (sgssExa != null)
                    {
                        sgssExa.EstadoProcesoId = (int)EEstadoProceso.Aprobado;
                        sgssExa.CreadoPor = "UNIVE";
                        sgssExa.FechaCreacion = DateTime.Now;
                        sgssExa.FlagActivo = true;
                        sgssExa.FlagEliminado = false;
                        //repCPS.Update(sgssExa);
                        _bd.SaveChanges();
                    }

                    foreach (var item in listOrdPD)
                    {
                        var ordpd = _bd.OrdenPaqueteDetalle.Find(item.OrdenPaqueteDetalleId);
                        ordpd.EstadoServicioId = (int)EEstadoPrueba.Aprobado;
                        ordpd.ModificadoPor = ordenPaquete.ModificadoPor;
                        ordpd.FechaModificacion = ordenPaquete.FechaModificacion;
                        _bd.SaveChanges();

                        var ordser = _bd.Servicio.Find(ordpd.ServicioId);
                        var validaTrazabilidad = ordser.Trazable == null ? false : (ordser.Trazable.Value ? true : false);

                        if (validaTrazabilidad)
                        {
                            var trazable = _bd.TrazabilidadServicio.Where(o => o.ServicioId == ordser.ServicioId && o.PacienteId == ordBD.PacienteId &&
                                                                   o.TrazabilidadAnno == DateTime.Now.Year && o.TrazabilidadMes == DateTime.Now.Month).FirstOrDefault();
                            if (trazable != null)
                            {
                                trazable.Valor = ordpd.Valor;
                                trazable.ModificadoPor = ordenPaquete.ModificadoPor;
                                trazable.FechaModificacion = DateTime.Now;
                                //repTra.Update(trazable);
                                _bd.SaveChanges();
                            }
                            else
                            {
                                var trazableAnnoMes = new TrazabilidadServicio()
                                {
                                    PacienteId = ordBD.PacienteId,
                                    ServicioId = ordpd.ServicioId,
                                    Valor = ordpd.Valor,
                                    TrazabilidadAnno = DateTime.Now.Year,
                                    TrazabilidadMes = DateTime.Now.Month,
                                    CreadoPor = ordenPaquete.ModificadoPor,
                                    FechaCreacion = DateTime.Now,
                                    FlagActivo = true,
                                    FlagEliminado = false
                                };

                                _bd.TrazabilidadServicio.Add(trazableAnnoMes);
                                _bd.SaveChanges();

                            }
                        }



                    }

                    var listOrdPendiente = (from a in _bd.OrdenPaquete
                                            where a.OrdenId == ordPqBD.OrdenId &&
                                                  a.FlagActivo == true && a.FlagEliminado == false &&
                                                  a.EstadoOrdenPaqueteId != (int)EEstadoOrdenPaquete.Aprobado
                                            select new
                                            {
                                                a.OrdenId,
                                                a.OrdenPaqueteId
                                            }).ToList();

                    if (listOrdPendiente.Count() == 0)
                    {
                        ordBD.EstadoOrdenId = (int)EEstadoOrdenPaquete.Aprobado;
                        ordBD.ModificadoPor = ordenPaquete.ModificadoPor;
                        ordBD.FechaModificacion = ordenPaquete.FechaModificacion;
                        //repOrd.Update(ordBD);
                        _bd.SaveChanges();
                    }

                }

                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }

        public void AprobarResultadoPruebaAgp(OrdenPaquete ordenPaquete, int centroSaludId)
        {

            {
                try
                {
                    //IRepositorio<Orden> repOrd = new EfRepositorio<Orden>(ctx);
                    //IRepositorio<OrdenPaquete> rep = new EfRepositorio<OrdenPaquete>(ctx);
                    //IRepositorio<OrdenPaqueteDetalle> repPD = new EfRepositorio<OrdenPaqueteDetalle>(ctx);
                    //IRepositorio<SGSSSolExaLabCPS> repCPS = new EfRepositorio<SGSSSolExaLabCPS>(ctx);
                    //IRepositorio<OrdenPaqueteAcceso> repPQA = new EfRepositorio<OrdenPaqueteAcceso>(ctx);
                    //IRepositorio<Servicio> repServ = new EfRepositorio<Servicio>(ctx);
                    //IRepositorio<TrazabilidadServicio> repTra = new EfRepositorio<TrazabilidadServicio>(ctx);
                    //IRepositorio<CentroSaludOrigen> repCSO = new EfRepositorio<CentroSaludOrigen>(ctx);
                    //IRepositorio<MSSolExaLabDet> repMSDet = new EfRepositorio<MSSolExaLabDet>(ctx);
                    //IRepositorio<MSSolExaLab> repMS = new EfRepositorio<MSSolExaLab>(ctx);

                    var centroSal = _bd.CentroSaludOrigen.Find(centroSaludId);

                    int msId = 0;


                    var token = Util.GenerarToken(Util.Get<int>("Token.Longitud"));
                    var ordBD = _bd.Orden.Find(ordenPaquete.OrdenId);

                    var lstOrdPqBD = (from a in _bd.OrdenPaquete
                                      where a.OrdenId == ordenPaquete.OrdenId &&
                                            a.EquipoId == ordenPaquete.EquipoId &&
                                            a.NroOrden == ordenPaquete.NroOrden &&
                                            a.FlagActivo == true && a.FlagEliminado == false
                                      select new
                                      {
                                          a.OrdenPaqueteId
                                      }).ToList();

                    if (centroSal.CodigoExterno == Util.GetEnumDescription(ECodigoExternoSE.MeisonSante))
                    {


                        foreach (var itemOrdenPaqueteBD in lstOrdPqBD)
                        {

                            var ordPqBD = _bd.OrdenPaquete.Find(itemOrdenPaqueteBD.OrdenPaqueteId);
                            var flag = 0;

                            var listOrdPD = (from a in _bd.OrdenPaqueteDetalle
                                             where a.OrdenPaqueteId == itemOrdenPaqueteBD.OrdenPaqueteId &&
                                                   a.FlagActivo == true && a.FlagEliminado == false

                                             select new
                                             {
                                                 a.OrdenPaqueteDetalleId,
                                                 a.FechaResultado,
                                                 a.FlagResultadoEnvioSE
                                             }).ToList();

                            foreach (var itemOPD in listOrdPD)
                            {

                                if (itemOPD.FechaResultado != null)
                                {



                                    var ordpd = _bd.OrdenPaqueteDetalle.Find(itemOPD.OrdenPaqueteDetalleId);
                                    ordpd.EstadoServicioId = (int)EEstadoPrueba.Aprobado;
                                    ordpd.ModificadoPor = ordenPaquete.ModificadoPor;
                                    ordpd.FlagResultadoEnvioSE = true;
                                    ordpd.FechaModificacion = ordenPaquete.FechaModificacion;
                                    //repPD.Update(ordpd);
                                    _bd.SaveChanges();
                                }

                            }

                            var listActualiOrdPD = (from a in _bd.OrdenPaqueteDetalle
                                                    where a.OrdenPaqueteId == itemOrdenPaqueteBD.OrdenPaqueteId &&
                                                          a.FlagActivo == true && a.FlagEliminado == false

                                                    select new
                                                    {
                                                        a.OrdenPaqueteDetalleId,
                                                        a.FechaResultado,
                                                        a.FlagResultadoEnvioSE
                                                    }).ToList();


                            foreach (var itemActOPD in listActualiOrdPD)
                            {

                                if (itemActOPD.FlagResultadoEnvioSE != true)
                                {

                                    flag = 1;

                                }


                            }



                            if (flag == 0)
                            {
                                ordPqBD.EstadoOrdenPaqueteId = (int)EEstadoOrdenPaquete.Aprobado;
                                ordPqBD.InformeResultado = ordenPaquete.InformeResultado;
                                ordPqBD.ModificadoPor = ordenPaquete.ModificadoPor;
                                ordPqBD.FechaModificacion = ordenPaquete.FechaModificacion;
                                ordPqBD.UsuarioApruebaId = ordenPaquete.UsuarioApruebaId;
                                ordPqBD.FechaAprobacion = ordenPaquete.FechaAprobacion;
                                //rep.Update(ordPqBD);
                                _bd.SaveChanges();

                                var msDet = _bd.MSSolExaLabDet.Where(o => o.OrdenId == ordPqBD.OrdenId && o.OrdenPaqueteId == ordPqBD.OrdenPaqueteId).FirstOrDefault();



                                if (msDet != null)
                                {
                                    msId = msDet.MSSolExaLabId;

                                    msDet.EstadoProcesoId = (int)EEstadoProceso.Aprobado;
                                    msDet.CreadoPor = "UNIVE";
                                    msDet.FechaCreacion = DateTime.Now;
                                    msDet.FlagActivo = true;
                                    msDet.FlagEliminado = false;
                                    //repMSDet.Update(msDet);
                                    _bd.SaveChanges();
                                }
                            }



                        }

                        var listOrdenesPendiente = (from a in _bd.OrdenPaquete
                                                    where a.OrdenId == ordenPaquete.OrdenId &&
                                                          a.FlagActivo == true && a.FlagEliminado == false &&
                                                          a.EstadoOrdenPaqueteId != (int)EEstadoOrdenPaquete.Aprobado
                                                    select new
                                                    {
                                                        a.OrdenId,
                                                        a.OrdenPaqueteId
                                                    }).ToList();

                        if (listOrdenesPendiente.Count() == 0)
                        {

                            //APROBACION DE LA TABLA ORDEN
                            ordBD.EstadoOrdenId = (int)EEstadoOrdenPaquete.Aprobado;
                            ordBD.ModificadoPor = ordenPaquete.ModificadoPor;
                            ordBD.FechaModificacion = ordenPaquete.FechaModificacion;
                            //repOrd.Update(ordBD);
                            _bd.SaveChanges();

                            var msoll = _bd.MSSolExaLab.Where(m => m.OrdenId == ordBD.OrdenId).FirstOrDefault();

                            if (msoll != null)
                            {

                                // APROBACION DE LA TABLA MSSolExaLab
                                var mssBD = _bd.MSSolExaLab.Find(msId);
                                mssBD.EstadoProcesoId = (int)EEstadoProceso.Aprobado;
                                mssBD.ModificadoPor = ordenPaquete.ModificadoPor;
                                mssBD.FechaModificacion = ordenPaquete.FechaModificacion;
                                mssBD.CreadoPor = "UNIVE";
                                //repMS.Update(mssBD);
                                _bd.SaveChanges();
                            }


                        }

                    }
                    else
                    {


                        object[] parameters = { ordenPaquete.OrdenId, ordenPaquete.EquipoId, ordenPaquete.NroOrden, ordenPaquete.ModificadoPor,
                                                    ordenPaquete.InformeResultado, ordenPaquete.UsuarioApruebaId };

                        _bd.Database.ExecuteSqlRaw("exec [sp_OrdenPaquete_Aprobar] {0}, {1}, {2}, {3}, {4}, {5}", parameters);


                        var listOrdPendiente = (from a in _bd.OrdenPaquete
                                                where a.OrdenId == ordenPaquete.OrdenId &&
                                                      a.FlagActivo == true && a.FlagEliminado == false &&
                                                      a.EstadoOrdenPaqueteId != (int)EEstadoOrdenPaquete.Aprobado
                                                select new
                                                {
                                                    a.OrdenId,
                                                    a.OrdenPaqueteId
                                                }).ToList();

                        if (listOrdPendiente.Count() == 0)
                        {
                            ordBD.EstadoOrdenId = (int)EEstadoOrdenPaquete.Aprobado;
                            ordBD.ModificadoPor = ordenPaquete.ModificadoPor;
                            ordBD.FechaModificacion = ordenPaquete.FechaModificacion;
                            //repOrd.Update(ordBD);
                            _bd.SaveChanges();
                        }
                        //}

                    }


                }

                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }

        public void ActualizaInformeResultado(List<OrdenPaquete> lstOPaquete)
        {

            {
                try
                {

                    //IRepositorio<OrdenPaquete> rep = new EfRepositorio<OrdenPaquete>(ctx);


                    foreach (var itemOPqBD in lstOPaquete)
                    {
                        var ordPqBD = _bd.OrdenPaquete.Find(itemOPqBD.OrdenPaqueteId);
                        ordPqBD.InformeResultado = itemOPqBD.InformeResultado;
                        _bd.SaveChanges();

                        try
                        {

                            object[] parameters = { itemOPqBD.OrdenPaqueteId };

                            _bd.Database.ExecuteSqlRaw("exec [sp_Orden_Servicio_Calculo] {0}", parameters);
                        }
                        catch { }
                    }
                }

                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }

        public OrdenPaquete ObtenerInformeResultado(int ordenId, int equipoId, string nroOrden)
        {


            {
                try
                {

                    var lista = (from a in _bd.OrdenPaquete
                                 where a.FlagActivo == true
                                 && a.FlagEliminado == false
                                 && a.OrdenId == ordenId && a.EquipoId == equipoId && a.NroOrden == nroOrden
                                 select new
                                 {
                                     a.InformeResultado
                                 });

                    var OrdPaq = (from a in lista.ToList()
                                  select new OrdenPaquete
                                  {
                                      InformeResultado = a.InformeResultado
                                  }).FirstOrDefault();
                    return OrdPaq;
                }

                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }

        public void ActualizaAnalizadorOrden(int ordenId, int equipoId, int areaEstudioId, int tipoMuestraId, int equipoNewId, string user)
        {

            {
                try
                {
                    object[] parameters = { ordenId, equipoId, areaEstudioId, tipoMuestraId, equipoNewId, user };

                    _bd.Database.ExecuteSqlRaw("exec [sp_Orden_CambioAnalizador] {0}, {1}, {2}, {3}, {4}, {5}", parameters);

                }

                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }

        public ICollection<CodigosUnicosDto> ActualizaAnalizadorOrdenCodUnico(int ordenId, int equipoId, int areaEstudioId, int tipoMuestraId, int equipoNewId, string user)
        {

            {
                try
                {
                    //TODO: Revisar ejecucion PAP
                    //object[] parameters = { ordenId, equipoId, areaEstudioId, tipoMuestraId, equipoNewId, user };

                    //return ctx.Database.SqlQuery<CodigosUnicosDto>("[sp_Orden_CambioAnalizador_CodUnicos] {0}, {1}, {2}, {3}, {4}, {5}", parameters).ToList();
                    return null;
                }

                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }

        public void ActualizaTipoPacienteOrden(int ordenId, int tipoPacienteId, string user)
        {

            {
                try
                {
                    object[] parameters = { ordenId, tipoPacienteId, user };

                    _bd.Database.ExecuteSqlRaw("[sp_Orden_CambioTipoPaciente] {0}, {1}, {2}", parameters);

                }

                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }

        public void RevertirOrdenPaquete(int ordenPId)
        {

            {
                try
                {


                    var ordenP = _bd.OrdenPaquete.Find(ordenPId);

                    ordenP.EstadoOrdenPaqueteId = (int)EEstadoOrdenPaquete.Procesado;



                    var ordenPD = _bd.OrdenPaqueteDetalle.Where(o => o.OrdenPaqueteId == ordenPId);

                    foreach (var item in ordenPD)
                    {
                        item.EstadoServicioId = (int)EEstadoOrdenPaquete.Procesado;
                    }
                    _bd.SaveChanges();
                }

                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }

        public void AnularOrden(int ordenId, string usuario)
        {

            {
                try
                {
                    var orden = _bd.Orden.Find(ordenId);

                    orden.FlagActivo = false;
                    orden.FlagEliminado = true;
                    orden.ModificadoPor = usuario;
                    orden.FechaModificacion = DateTime.Now;
                    _bd.SaveChanges();

                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }

        #region Interfaces
        public ICollection<OrdenDto> ListarOrdenInterfaz(DateTime fecIni, DateTime fecFin, int idEquipo)
        {


            {
                try
                {
                    //IRepositorio<Orden> rep = new EfRepositorio<Orden>(ctx);
                    //IRepositorio<OrdenPaquete> repPq = new EfRepositorio<OrdenPaquete>(ctx);

                    var lista = (from aa in _bd.Orden
                                 join bb in _bd.OrdenPaquete on aa.OrdenId equals bb.OrdenId
                                 where aa.FlagActivo == true && (aa.FechaEmision >= fecIni && aa.FechaEmision <= fecFin) &&
                                        bb.EquipoId == idEquipo && (bb.EstadoOrdenPaqueteId != (int)EEstadoOrdenPaquete.Aprobado &&
                                              bb.EstadoOrdenPaqueteId != (int)EEstadoOrdenPaquete.Procesado)
                                 orderby aa.FechaEmision, aa.FechaCreacion descending
                                 select new
                                 {
                                     bb.NroOrden
                                 });

                    var listaFinal = (from a in lista
                                      select new
                                      {
                                          a.NroOrden
                                      }).ToList().GroupBy(grp => new
                                      {
                                          grp.NroOrden
                                      }).Select(grp => new OrdenDto()
                                      {
                                          NroOrden = grp.Key.NroOrden
                                      }).ToList();

                    return listaFinal;
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }
        public OrdenDto ObtenerOrden(string orden)
        {

            {
                try
                {

                    //IRepositorio<Orden> rep = new EfRepositorio<Orden>(ctx);
                    //IRepositorio<OrdenPaquete> repPaq = new EfRepositorio<OrdenPaquete>(ctx);
                    //IRepositorio<OrdenPaqueteDetalle> repPrueba = new EfRepositorio<OrdenPaqueteDetalle>(ctx);
                    //IRepositorio<Paciente> repPac = new EfRepositorio<Paciente>(ctx);

                    var ordenDato = (from a in _bd.Orden
                                     join b in _bd.OrdenPaquete on a.OrdenId equals b.OrdenId
                                     where b.NroOrden == orden
                                     && a.FlagActivo == true
                                     select a).Include("Paciente").FirstOrDefault();

                    var dto = InitAutoMapper.mapper.Map<OrdenDto>(ordenDato);
                    if (dto != null)
                    {
                        var listaPruebas = (from a in _bd.Orden
                                            join b in _bd.OrdenPaquete on a.OrdenId equals b.OrdenId
                                            join c in _bd.OrdenPaqueteDetalle on b.OrdenPaqueteId equals c.OrdenPaqueteId
                                            where b.NroOrden == orden && a.OrdenId == ordenDato.OrdenId
                                                //&& a.EstadoInterfaceId == (int)EstadoInterface.PENDIENTE
                                                && a.FlagActivo == true
                                                && b.FlagActivo == true
                                                && c.FlagActivo == true
                                            select c).ToList();


                        dto.OrdenPaqueteDetalles = InitAutoMapper.mapper.Map<List<OrdenPaqueteDetalleDto>>(listaPruebas);
                    }

                    return dto;

                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }
        public ICollection<OrdenPaqueteDetalle> ListarOrdenPruebaEnvio(string orden, int idEquipo)
        {

            {
                try
                {
                    //IRepositorio<Orden> rep = new EfRepositorio<Orden>(ctx);
                    //IRepositorio<OrdenPaquete> repPaq = new EfRepositorio<OrdenPaquete>(ctx);
                    //IRepositorio<OrdenPaqueteDetalle> repPrueba = new EfRepositorio<OrdenPaqueteDetalle>(ctx);
                    //IRepositorio<PaqueteEquipo> repPaqEq = new EfRepositorio<PaqueteEquipo>(ctx);
                    //IRepositorio<Servicio> repServ = new EfRepositorio<Servicio>(ctx);

                    var listaPruebas = (from a in _bd.Orden
                                        join b in _bd.OrdenPaquete on a.OrdenId equals b.OrdenId
                                        join c in _bd.OrdenPaqueteDetalle on new { b.OrdenPaqueteId, a.OrdenId } equals new { c.OrdenPaqueteId, OrdenId = c.OrdenId.Value }
                                        join d in _bd.PaqueteEquipo on new { b.PaqueteId, EquipoId = b.EquipoId.Value, FlagActivo = true, FlagEliminado = false }
                                                             equals new { d.PaqueteId, d.EquipoId, d.FlagActivo, d.FlagEliminado }
                                        join e in _bd.Servicio on c.ServicioId equals e.ServicioId
                                        where b.NroOrden == orden && d.EquipoId == idEquipo /*&& (b.EstadoOrdenPaqueteId != (int)EEstadoOrdenPaquete.Aprobado &&
                                              b.EstadoOrdenPaqueteId != (int)EEstadoOrdenPaquete.Procesado ) */&&
                                              (c.EstadoServicioId != (int)EEstadoPrueba.Aprobado && c.EstadoServicioId != (int)EEstadoPrueba.Procesado)
                                        //&& b.EstadoInterfaceId== (int)EstadoInterface.PENDIENTE
                                        && (e.EsCalculado == null || e.EsCalculado == false)
                                        && c.FlagActivo == true
                                        && b.FlagActivo == true
                                        && d.FlagActivo == true
                                        select new
                                        {
                                            c.CodigoUnico,
                                            e.Nombre
                                        }).ToList();

                    var ordenPD = (from a in listaPruebas.ToList()
                                   select new OrdenPaqueteDetalle()
                                   {
                                       CodigoUnico = a.CodigoUnico,
                                       Servicio = new Servicio
                                       {
                                           Nombre = a.Nombre
                                       }
                                   }
                                 ).ToList();

                    return ordenPD;

                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }
        public string ListarOrdenPruebaEnvioAlp200(string orden, int idEquipo)
        {

            {
                try
                {
                    var dato = "";
                    object[] parameters = { orden, idEquipo };
                    //TODO: REVISAR EJECUCION PAP
                    //dato = ctx.Database.SqlQuery<string>("[sp_ALP200_CodUnicos] {0}, {1}", parameters).First();

                    //return dato;
                    return null;

                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }
        public OrdenPaqueteDto ValidarMatchAutomatico(string orden)
        {

            {
                try
                {
                    //IRepositorio<OrdenPaquete> repPaq = new EfRepositorio<OrdenPaquete>(ctx);
                    //IRepositorio<Paquete> repPq = new EfRepositorio<Paquete>(ctx);
                    //IRepositorio<Equipo> repEq = new EfRepositorio<Equipo>(ctx);

                    var listaPruebas = (from a in _bd.OrdenPaquete
                                        join b in _bd.Paquete on a.PaqueteId equals b.PaqueteId
                                        join c in _bd.Equipo on a.EquipoId equals c.EquipoId
                                        where a.NroOrden == orden && c.MatchAutomatico == true
                                        && a.FlagActivo == true
                                        && b.FlagActivo == true
                                        && c.FlagActivo == true
                                        select new
                                        {
                                            a.OrdenId,
                                            a.EquipoId,
                                            b.TipoMuestraAnalizadorId,
                                            c.AreaEstudioId
                                        }).ToList();

                    var ordenP = (from a in listaPruebas.ToList()
                                  select new OrdenPaqueteDto()
                                  {
                                      OrdenId = a.OrdenId,
                                      EquipoId = a.EquipoId,
                                      TipoMuestraAnalizadorId = a.TipoMuestraAnalizadorId,
                                      AreaEstudioId = a.AreaEstudioId
                                  }
                                 ).ToList().FirstOrDefault();

                    return ordenP;

                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }
        public ICollection<OrdenPaqueteDetalleDto> ListarOrdenPrueba(string orden, int idEquipo)
        {

            {
                try
                {
                    int? dat = null;

                    //IRepositorio<Orden> rep = new EfRepositorio<Orden>(ctx);
                    //IRepositorio<OrdenPaquete> repPaq = new EfRepositorio<OrdenPaquete>(ctx);
                    //IRepositorio<OrdenPaqueteDetalle> repPrueba = new EfRepositorio<OrdenPaqueteDetalle>(ctx);
                    //IRepositorio<PaqueteEquipo> repPaqEq = new EfRepositorio<PaqueteEquipo>(ctx);
                    //IRepositorio<Servicio> repSev = new EfRepositorio<Servicio>(ctx);

                    var lista = (from a in _bd.Orden
                                 join b in _bd.OrdenPaquete on a.OrdenId equals b.OrdenId
                                 join c in _bd.OrdenPaqueteDetalle on b.OrdenPaqueteId equals c.OrdenPaqueteId
                                 join d in _bd.PaqueteEquipo on new { b.PaqueteId, EquipoId = b.EquipoId.Value } equals new { d.PaqueteId, d.EquipoId }
                                 join e in _bd.Servicio on c.ServicioId equals e.ServicioId
                                 where b.NroOrden == orden && d.EquipoId == idEquipo &&
                                       (c.EstadoServicioId != (int)EEstadoPrueba.Aprobado)
                                 //&& (b.EstadoOrdenPaqueteId != (int)EEstadoOrdenPaquete.Aprobado //&&
                                 //b.EstadoOrdenPaqueteId != (int)EEstadoOrdenPaquete.Procesado && b.EstadoOrdenPaqueteId != (int)EEstadoOrdenPaquete.Enviado
                                 //)
                                 //&& b.EstadoInterfaceId== (int)EstadoInterface.PENDIENTE
                                 && c.FlagActivo == true
                                 && b.FlagActivo == true
                                 && d.FlagActivo == true
                                 select new
                                 {
                                     c.OrdenPaqueteDetalleId,
                                     c.OrdenPaqueteId,
                                     c.CodigoUnico,
                                     c.CodigoUnicoExamen,
                                     c.ResultadoAutomatizado,
                                     e.UnidadMedida,
                                     e.Referencia,
                                     e.TipoResultado,
                                     e.TipoDatoId,
                                     e.MultiplicarPor
                                 }).ToList();

                    var listaPruebas = (from a in lista.ToList()
                                        select new OrdenPaqueteDetalleDto
                                        {
                                            OrdenPaqueteDetalleId = a.OrdenPaqueteDetalleId,
                                            OrdenPaqueteId = a.OrdenPaqueteId,
                                            CodigoUnico = a.CodigoUnico,
                                            CodigoUnicoExamen = a.CodigoUnicoExamen,
                                            ResultadoAutomatizado = a.ResultadoAutomatizado,
                                            ValorReferencia = a.Referencia,
                                            ValorUnidad = a.UnidadMedida,
                                            TipoResultadoId = a.TipoResultado == null ? dat : (a.TipoResultado.Value ? 1 : 0),
                                            NroOrden = orden,
                                            TipoDatoId = a.TipoDatoId,
                                            MultiplicarPor = a.MultiplicarPor
                                        }).ToList();

                    return listaPruebas;

                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }
        public void EnviarTramaOrdenPaquete(string orden, string trama, int idEquipo)
        {

            {
                try
                {
                    //IRepositorio<Orden> rep = new EfRepositorio<Orden>(ctx);
                    //IRepositorio<OrdenPaquete> repPaq = new EfRepositorio<OrdenPaquete>(ctx);
                    //IRepositorio<OrdenPaqueteTramas> repPaqTrama = new EfRepositorio<OrdenPaqueteTramas>(ctx);
                    //IRepositorio<PaqueteEquipo> repPaqEq = new EfRepositorio<PaqueteEquipo>(ctx);

                    var ordenPaqBD = (from a in _bd.Orden
                                      join b in _bd.OrdenPaquete on a.OrdenId equals b.OrdenId
                                      join c in _bd.PaqueteEquipo on b.PaqueteId equals c.PaqueteId
                                      where b.NroOrden == orden && c.EquipoId == idEquipo
                                      select b);

                    foreach (var item in ordenPaqBD)
                    {
                        item.FechaEnvio = DateTime.Now;
                        item.EstadoOrdenPaqueteId = (int)EEstadoOrdenPaquete.Enviado;
                    }
                    _bd.SaveChanges();
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }
        public void EnviarTramaOrdenPaqueteProc(string orden, string trama, int idEquipo)
        {

            {
                try
                {

                    object[] parameters = { orden, idEquipo, trama };

                    //VER OTRA FORMA DE GRABAR TRAMA
                    //ctx.Database.ExecuteSqlCommand("[sp_ALP_ActualizaTramas] {0}, {1}, {2}", parameters);

                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }
        public void RecibirTramaOrdenPaquete(string orden, int ordenPaqueteId, string trama, int idEquipo)
        {

            {
                try
                {
                    //IRepositorio<Orden> rep = new EfRepositorio<Orden>(ctx);
                    //IRepositorio<OrdenPaquete> repPaq = new EfRepositorio<OrdenPaquete>(ctx);
                    //IRepositorio<OrdenPaqueteDetalle> repPaqDet = new EfRepositorio<OrdenPaqueteDetalle>(ctx);
                    //IRepositorio<OrdenPaqueteTramas> repPaqTrama = new EfRepositorio<OrdenPaqueteTramas>(ctx);
                    //IRepositorio<PaqueteEquipo> repPaqEq = new EfRepositorio<PaqueteEquipo>(ctx);

                    var ordenPaqBD = (from a in _bd.Orden
                                      join b in _bd.OrdenPaquete on a.OrdenId equals b.OrdenId
                                      join c in _bd.PaqueteEquipo on b.PaqueteId equals c.PaqueteId
                                      where b.NroOrden == orden && c.EquipoId == idEquipo && b.OrdenPaqueteId == ordenPaqueteId
                                      select b).FirstOrDefault();

                    if (ordenPaqBD != null)
                    {
                        var opdPendiente = _bd.OrdenPaqueteDetalle.Where(o => o.OrdenPaqueteId == ordenPaqBD.OrdenPaqueteId &&
                                                                       (o.EstadoServicioId == (int)EEstadoPrueba.Pendiente ||
                                                                        o.EstadoServicioId == (int)EEstadoPrueba.Enviado) &&
                                                                        o.OrdenId == ordenPaqBD.OrdenId).Count();

                        if (opdPendiente == 0 && ordenPaqBD.EstadoOrdenPaqueteId != (int)EEstadoOrdenPaquete.Aprobado)
                        {
                            ordenPaqBD.FechaModificacion = DateTime.Now;
                            ordenPaqBD.ModificadoPor = "AUTO";
                            ordenPaqBD.FechaProcesamiento = DateTime.Now;
                            ordenPaqBD.EstadoOrdenPaqueteId = (int)EEstadoOrdenPaquete.Procesado;
                        }

                        _bd.SaveChanges();


                    }
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }
        public void RecibirTramaOrdenPaquete(OrdenPaqueteDto ordenPQ)
        {

            {
                try
                {
                    //IRepositorio<Orden> rep = new EfRepositorio<Orden>(ctx);
                    //IRepositorio<OrdenPaquete> repPaq = new EfRepositorio<OrdenPaquete>(ctx);
                    //IRepositorio<OrdenPaqueteTramas> repPaqTrama = new EfRepositorio<OrdenPaqueteTramas>(ctx);
                    //IRepositorio<PaqueteEquipo> repPaqEq = new EfRepositorio<PaqueteEquipo>(ctx);

                    var ordenPaqBD = (from a in _bd.Orden
                                      join b in _bd.OrdenPaquete on a.OrdenId equals b.OrdenId
                                      join c in _bd.PaqueteEquipo on b.PaqueteId equals c.PaqueteId
                                      where b.NroOrden == ordenPQ.Orden.NroOrden && c.EquipoId == ordenPQ.EquipoId && b.OrdenPaqueteId == ordenPQ.OrdenPaqueteId
                                      select b).FirstOrDefault();

                    if (ordenPaqBD != null)
                    {
                        ordenPaqBD.UsuarioInterface = ordenPQ.UsuarioInterface;

                        ordenPaqBD.FechaModificacion = DateTime.Now;
                        ordenPaqBD.ModificadoPor = "AUTO";
                        ordenPaqBD.FechaProcesamiento = DateTime.Now;
                        ordenPaqBD.EstadoOrdenPaqueteId = (int)EEstadoOrdenPaquete.Procesado;

                        _bd.SaveChanges();


                    }
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }
        public void RecibirTramaOrdenPaqueteALPHAHem(OrdenPaqueteDto ordenPQ)
        {

            {
                try
                {
                    //IRepositorio<Orden> rep = new EfRepositorio<Orden>(ctx);
                    //IRepositorio<OrdenPaquete> repPaq = new EfRepositorio<OrdenPaquete>(ctx);
                    //IRepositorio<OrdenPaqueteImagenes> repPaqImg = new EfRepositorio<OrdenPaqueteImagenes>(ctx);
                    //IRepositorio<OrdenPaqueteTramas> repPaqTrama = new EfRepositorio<OrdenPaqueteTramas>(ctx);
                    //IRepositorio<PaqueteEquipo> repPaqEq = new EfRepositorio<PaqueteEquipo>(ctx);

                    var ordenPaqBD = (from a in _bd.Orden
                                      join b in _bd.OrdenPaquete on a.OrdenId equals b.OrdenId
                                      join c in _bd.PaqueteEquipo on b.PaqueteId equals c.PaqueteId
                                      where b.NroOrden == ordenPQ.Orden.NroOrden && c.EquipoId == ordenPQ.EquipoId && b.OrdenPaqueteId == ordenPQ.OrdenPaqueteId
                                      select b).FirstOrDefault();

                    if (ordenPaqBD != null)
                    {
                        ordenPaqBD.FechaModificacion = DateTime.Now;
                        ordenPaqBD.ModificadoPor = "AUTO";
                        ordenPaqBD.FechaProcesamiento = DateTime.Now;
                        ordenPaqBD.EstadoOrdenPaqueteId = (int)EEstadoOrdenPaquete.Procesado;

                        _bd.SaveChanges();


                    }

                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }
        public void ActualizarPruebas(List<OrdenPaqueteDetalleDto> pruebas, int ordenPaqueteId)
        {

            {
                try
                {
                    var clone = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                    var Ids = pruebas.Select(x => x.CodigoUnicoExamen).ToList();
                    //IRepositorio<OrdenPaqueteDetalle> repPrueba = new EfRepositorio<OrdenPaqueteDetalle>(ctx);

                    var listaPruebas = (from a in _bd.OrdenPaqueteDetalle
                                        where a.OrdenPaqueteId == ordenPaqueteId && Ids.Contains(a.CodigoUnicoExamen)
                                        select a).ToList();

                    foreach (var item in listaPruebas)
                    {
                        var obj = pruebas.FirstOrDefault(x => x.CodigoUnicoExamen == item.CodigoUnicoExamen);
                        if (obj != null)
                        {

                            if (!string.IsNullOrEmpty(obj.ValorReferencia))
                            {
                                var valorDec = 0M;
                                var valorStr = "";
                                var valorR1 = 0M;
                                var valorR2 = 0M;

                                try
                                {
                                    valorDec = Convert.ToDecimal(obj.Valor, clone);

                                    if (obj.MultiplicarPor != null)
                                        valorDec *= obj.MultiplicarPor.Value;

                                    if (obj.TipoDatoId != null)
                                    {
                                        switch (obj.TipoDatoId)
                                        {
                                            case (int)ETipoDato.Entero:
                                                valorDec = Math.Round(valorDec, 0, MidpointRounding.AwayFromZero);
                                                break;
                                            case (int)ETipoDato.Decimal_10_2:
                                                valorDec = decimal.Round(valorDec, 2);
                                                break;
                                            case (int)ETipoDato.Decimal_10_3:
                                                valorDec = decimal.Round(valorDec, 3);
                                                break;
                                            case (int)ETipoDato.Decimal_10_4:
                                                valorDec = decimal.Round(valorDec, 4);
                                                break;
                                            default:
                                                break;
                                        }
                                    }

                                    var valorS = obj.ValorReferencia.Split('-')[0].ToString();
                                    valorS = valorS.Replace(",", "").Replace(" ", "");
                                    valorR1 = Util.EsNumero(valorS, true) ? Convert.ToDecimal(valorS, clone) : 0;
                                    valorS = obj.ValorReferencia.Split('-')[1].ToString().Replace(',', '.');
                                    valorR2 = Util.EsNumero(valorS, true) ? Convert.ToDecimal(valorS, clone) : 0;

                                    obj.Valor = valorDec.ToString();

                                }
                                catch
                                {
                                    valorStr = obj.Valor;
                                }

                                try
                                {
                                    if (obj.TipoResultadoId == null || obj.TipoResultadoId == 0)
                                    {
                                        item.EvaluacionPrueba = valorR1 >= 0 && valorR2 > 0 ? (valorDec >= valorR1 && valorDec <= valorR2 ? "N" : valorDec < valorR1 ? "L" : valorDec > valorR2 ? "H" : "") :
                                                                (string.IsNullOrEmpty(obj.EvaluacionPrueba) ? "" : obj.EvaluacionPrueba);
                                        item.Indicador = valorR1 >= 0 && valorR2 > 0 ? (valorDec >= valorR1 && valorDec <= valorR2 ? "#24E711" : valorDec < valorR1 ? "#F8F32B" : valorDec > valorR2 ? "#F80000" : "") :
                                                                  (string.IsNullOrEmpty(obj.EvaluacionPrueba) ? "" : obj.EvaluacionPrueba == "N" ? "#24E711" : obj.EvaluacionPrueba == "L" ? "#F8F32B" : "#F80000");

                                    }
                                    else
                                    {
                                        obj.Indicador = "";
                                        obj.ValorReferencia = "";
                                        obj.ValorUnidad = "";
                                        obj.ResultadoAutomatizado = "";
                                        item.EvaluacionPrueba = valorR1 >= 0 && valorR2 > 0 ? (valorDec >= valorR1 && valorDec <= valorR2 ? "NO REACTIVO" : valorDec < valorR1 ? "INDETERMINADO" : valorDec > valorR2 ? "REACTIVO" : "") :
                                                                (string.IsNullOrEmpty(obj.EvaluacionPrueba) ? "" : obj.EvaluacionPrueba);

                                    }


                                }
                                catch
                                {
                                    item.Indicador = obj.Indicador;
                                    item.EvaluacionPrueba = obj.EvaluacionPrueba;
                                }
                            }

                            item.FechaModificacion = DateTime.Now;
                            item.FechaProcesaInterface = obj.FechaProcesaInterface;
                            item.ModificadoPor = obj.ModificadoPor;
                            item.ResultadoAutomatizado = obj.ResultadoAutomatizado;
                            item.Valor = obj.Valor;
                            item.ValorReferencia = obj.ValorReferencia;
                            item.ValorUnidad = obj.ValorUnidad;
                            item.EstadoServicioId = obj.EstadoServicioId;
                            item.FechaResultado = obj.FechaResultado;

                            //item.BIntOrden.FechaModificacion = DateTime.Now;
                            //item.EstadoInterfaceId = (int)EstadoInterface.CONRESPUESTA;
                        }
                    }

                    _bd.SaveChanges();

                    try
                    {
                        object[] parameters = { ordenPaqueteId };

                        _bd.Database.ExecuteSqlRaw("exec [sp_Orden_Servicio_Calculo] {0}", parameters);
                    }
                    catch { }

                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }
        #endregion

        #region Mobile
        public RequestDatosPaciente ConsultarPacienteDatos(int tipoDocId, string nroDoc, string token, int tipoConsulta)
        {

            {
                try
                {
                    object[] parameters = { tipoDocId, nroDoc, token.ToUpper() };
                    var datosPaciente = new RequestDatosPaciente();
                    //TODO: Verificar la ejecucion PAP
                    //if (tipoConsulta == (int)ETipoVista.Resultado)
                    //    datosPaciente = _bd.Database.SqlQuery<RequestDatosPaciente>("[sp_ConsultaPacienteOrden] {0}, {1}, {2}", parameters).FirstOrDefault();
                    //if (tipoConsulta == (int)ETipoVista.Trazabilidad)
                    //    datosPaciente = _bd.Database.SqlQuery<RequestDatosPaciente>("[sp_ConsultaPacienteTrazabilidad] {0}, {1}, {2}", parameters).FirstOrDefault();

                    return datosPaciente;
                }

                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }
        public RequestDatosPaciente ConsultarResultadoDatos(string nroOrden, int tipoConsulta)
        {

            {
                try
                {
                    object[] parameters = { nroOrden };
                    var datosPaciente = new RequestDatosPaciente();
                    //TODO: Verificar la ejecucion PAP
                    //if (tipoConsulta == (int)ETipoVista.Resultado)
                    //    datosPaciente = ctx.Database.SqlQuery<RequestDatosPaciente>("[sp_ConsultaResultadoOrden] {0}", parameters).FirstOrDefault();
                    //if (tipoConsulta == (int)ETipoVista.Trazabilidad)
                    //    datosPaciente = ctx.Database.SqlQuery<RequestDatosPaciente>("[sp_ConsultaResultadoTrazabilidad] {0}", parameters).FirstOrDefault();

                    return datosPaciente;
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }
        public ICollection<OrdenPaqueteDetalleDto> ListarOrdenDetalleResultado(string nroOrden)
        {


            {
                try
                {
                    //IRepositorio<OrdenPaqueteDetalle> reppaq = new EfRepositorio<OrdenPaqueteDetalle>(ctx);
                    //IRepositorio<Servicio> repserv = new EfRepositorio<Servicio>(ctx);
                    //IRepositorio<OrdenPaquete> repop = new EfRepositorio<OrdenPaquete>(ctx);
                    //IRepositorio<Orden> repord = new EfRepositorio<Orden>(ctx);
                    //IRepositorio<Paciente> reppac = new EfRepositorio<Paciente>(ctx);

                    var lista = (from a in _bd.OrdenPaqueteDetalle
                                 join q in _bd.Servicio on a.ServicioId equals q.ServicioId
                                 join r in _bd.OrdenPaquete on a.OrdenPaqueteId equals r.OrdenPaqueteId
                                 join s in _bd.Orden on r.OrdenId equals s.OrdenId
                                 join t in _bd.Paciente on s.PacienteId equals t.PacienteId
                                 where a.FlagActivo == true
                                 && a.FlagEliminado == false
                                 && s.Codigo == nroOrden
                                 orderby r.OrdenPaqueteId ascending
                                 select new
                                 {
                                     a.OrdenPaqueteDetalleId,
                                     a.OrdenPaqueteId,
                                     q.Nombre,
                                     a.EstadoServicioId,
                                     a.FechaCreacion,
                                     a.FechaResultado,
                                     a.Valor,
                                     a.ValorReferencia,
                                     t.CorreoElectronico,
                                     a.EvaluacionPrueba,
                                     a.Indicador
                                 });

                    var listaFinal = (from a in lista.ToList()
                                      select new OrdenPaqueteDetalleDto
                                      {
                                          OrdenPaqueteDetalleId = a.OrdenPaqueteDetalleId,
                                          OrdenPaqueteId = a.OrdenPaqueteId,
                                          Servicio = new ServicioDto() { Nombre = a.Nombre },
                                          EstadoServicioId = a.EstadoServicioId,
                                          FechaCreacion = a.FechaCreacion,
                                          FechaResultado = a.FechaResultado,
                                          Valor = a.Valor,
                                          ValorReferencia = a.ValorReferencia,
                                          CorreoElectronico = a.CorreoElectronico,
                                          EvaluacionPrueba = a.EvaluacionPrueba,
                                          Indicador = a.Indicador
                                      }).ToList();
                    return listaFinal;
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }
        public ICollection<DatosOrdenResultado> ListarPerfilServicio(int ordenPaqueteId)
        {


            {
                try
                {
                    object[] parameters = { ordenPaqueteId };
                    //TODO: Verificar la ejecucion PAP
                    //var datosResultados = ctx.Database.SqlQuery<DatosOrdenResultado>("[sp_ConsultaResultadoPerfil] {0}", parameters).ToList();

                    //return datosResultados;
                    return null;
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }
        public ICollection<RequestTrazabilidad> ConsultarPacienteTrazabilidad(int pacienteId, int trazableAnno)
        {

            {
                try
                {
                    object[] parameters = { pacienteId, trazableAnno };
                    //TODO: Verificar la ejecucion PAP
                    //var datosTraza = ctx.Database.SqlQuery<DatosTrazabilidad>("[sp_ConsultaServicioTrazabilidad] {0}, {1}", parameters).ToList();
                    //if (datosTraza.Count > 0)
                    //{
                    //    var lista = datosTraza.GroupBy(grp => new
                    //    {
                    //        grp.ServicioId,
                    //        grp.NombrePrueba
                    //    }).Select(grp => new RequestTrazabilidad()
                    //    {
                    //        ServicioId = grp.Key.ServicioId,
                    //        NombrePrueba = grp.Key.NombrePrueba,
                    //        RequestValores = grp.Select(o => new RequestValores()
                    //        {
                    //            Anno = o.Anno,
                    //            Mes = o.Mes,
                    //            Valor = Convert.ToDecimal(o.Valor)
                    //        }).ToList()
                    //    }).ToList();

                    //    return lista;
                    //}
                    //else
                    return null;

                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }
        public bool GenerarTokenTrazabilidad(int tipoDocId, string nroDoc)
        {

            {
                var result = false;
                try
                {
                    //IRepositorio<TrazabilidadAcceso> repTraza = new EfRepositorio<TrazabilidadAcceso>(ctx);
                    //IRepositorio<Paciente> repPac = new EfRepositorio<Paciente>(ctx);

                    var token = Util.GenerarToken(Util.Get<int>("Token.Longitud"));

                    var paciente = _bd.Paciente.Where(o => o.TipoDocumentoId == tipoDocId && o.NumeroDocumento == nroDoc).FirstOrDefault();

                    if (paciente != null)
                    {
                        var trazaAcceso = new TrazabilidadAcceso()
                        {
                            PacienteId = paciente.PacienteId,
                            Token = token.ToUpper(),
                            FechaIniVigencia = DateTime.Now,
                            FechaFinVigencia = DateTime.Now.AddDays(Util.Get<int>("Token.Trazabilidad.Dias")),
                            FechaCreacion = DateTime.Now,
                            CreadoPor = "Admin",
                            FlagActivo = true,
                            FlagEliminado = false
                        };
                        _bd.TrazabilidadAcceso.Add(trazaAcceso);
                        _bd.SaveChanges();

                        var pacienteId = paciente.PacienteId;

                        object[] parameters = { pacienteId, token };

                        _bd.Database.ExecuteSqlRaw("exec [USP_REGISTRAR_NOTIFICACION_TOKEN_TRAZABILIDAD] {0}, {1}", parameters);
                        result = true;
                    }

                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }

                return result;
            }
        }
        public ICollection<RequestOrdenPrueba> ListarOrdenPruebaMovil(string filtro, DateTime? fecha)
        {

            {
                try
                {
                    //IRepositorio<Orden> rep = new EfRepositorio<Orden>(ctx);
                    //IRepositorio<OrdenPaquete> reppaq = new EfRepositorio<OrdenPaquete>(ctx);
                    //IRepositorio<Paquete> repPaquete = new EfRepositorio<Paquete>(ctx);
                    //IRepositorio<AreaEstudio> repAE = new EfRepositorio<AreaEstudio>(ctx);
                    //IRepositorio<Equipo> repEq = new EfRepositorio<Equipo>(ctx);
                    //IRepositorio<Paciente> repPaciente = new EfRepositorio<Paciente>(ctx);

                    var lista = (from aa in _bd.Orden
                                 join q in _bd.OrdenPaquete on aa.OrdenId equals q.OrdenId
                                 join w in _bd.Paquete on q.PaqueteId equals w.PaqueteId
                                 join e in _bd.Paciente on aa.PacienteId equals e.PacienteId
                                 where aa.FlagActivo == true && aa.FlagEliminado == false &&
                                       (fecha == null || aa.FechaEmision == fecha) &&
                                       (string.IsNullOrEmpty(filtro) || e.ApellidoMaterno.Contains(filtro.ToUpper()) || e.ApellidoPaterno.Contains(filtro.ToUpper()) ||
                                       e.Nombres.Contains(filtro.ToUpper()) || (e.ApellidoPaterno + " " + e.ApellidoMaterno + " " + e.Nombres).Contains(filtro.ToUpper()))
                                 orderby aa.FechaCreacion descending
                                 select new
                                 {
                                     aa.OrdenId,
                                     q.OrdenPaqueteId,
                                     q.EstadoOrdenPaqueteId,
                                     PaqueteNombre = w.Nombre,
                                     aa.FechaEmision,
                                     e.PacienteId,
                                     PacienteNombre = e.Nombres,
                                     PacienteAP = e.ApellidoPaterno,
                                     PacienteAM = e.ApellidoMaterno,
                                 });

                    var listaFinal = (from a in lista.ToList()
                                      select new RequestOrdenPrueba
                                      {
                                          OrdenId = a.OrdenId,
                                          OrdenPaqueteId = a.OrdenPaqueteId,
                                          PacienteId = a.PacienteId,
                                          NombreCompleto = a.PacienteAP + " " + a.PacienteAM + " " + a.PacienteNombre,
                                          Fecha = a.FechaEmision,
                                          NombrePrueba = a.PaqueteNombre,
                                          Estado = Util.GetEnumDescription((EEstadoOrdenPaquete)a.EstadoOrdenPaqueteId)
                                      }).ToList();
                    return listaFinal;
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }
        #endregion

        public Orden ObtenerOrden(int ordenId)
        {

            {

                var result = _bd.Orden.Find(ordenId);

                return result;

            }
        }

        #region Reporte Resultados
        public IEnumerable<ReporteOrdenResultado> ListarOrdenResultado(int ordenId, int page, int rows, out int nroTotalRegistros)
        {

            {
                try
                {

                    object[] parameters = { ordenId };
                    //TODO: Revisar ejecucion PAP
                    //var listaFinal = ctx.Database.SqlQuery<ReporteOrdenResultado>("[sp_WR_ListaOrdenResultado] {0}", parameters).ToList();

                    nroTotalRegistros = 0; // listaFinal.Count();

                    //return listaFinal;
                    return new List<ReporteOrdenResultado>();
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }

        public IEnumerable<mvBPOrderApproved> ListarOrdenesResultados(int BPId, int page, int rows, out int nroTotalRegistros)
        {

            {
                try
                {

                    object[] parameters = { BPId };
                    //TODO: Revisar ejecucion PAP
                    //var listaFinal = ctx.Database.SqlQuery<mvBPOrderApproved>("[sp_mv_ListOrderAprob] {0}", parameters).ToList();

                    nroTotalRegistros = 0; // listaFinal.Count();

                    //return listaFinal;
                    return null;
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }

        public IEnumerable<mvBPResult> ListarOPResultado(int bpOAId, int bpId, int ordenId, int page, int rows, out int nroTotalRegistros)
        {

            {
                try
                {

                    object[] parameters = { bpOAId, ordenId };

                    //var listaFinal = ctx.Database.SqlQuery<mvBPResult>("[sp_mv_ListaOrdenPqResultado] {0}, {1}", parameters).ToList();

                    nroTotalRegistros = 0; // listaFinal.Count();

                    //return listaFinal;
                    return null;
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }

        #endregion
    }
}
