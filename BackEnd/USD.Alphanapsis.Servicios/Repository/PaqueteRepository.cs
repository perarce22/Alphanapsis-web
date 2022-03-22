using System;
using System.Collections.Generic;
using System.Text;
using USD.Alphanapsis.Data;
using USD.Alphanapsis.Entidades;
using System.Linq;
using USD.Alphanapsis.Dto;
using USD.Alphanapsis.Utiles;
using Microsoft.EntityFrameworkCore;
using USD.Alphanapsis.Dto.Custom;

namespace USD.Alphanapsis.Servicios.Repository
{
    public class PaqueteRepository : IPaqueteRepository
    {
        private readonly ApplicationDbContext _bd;
        NLog.Logger logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        public PaqueteRepository(ApplicationDbContext bd)
        {
            _bd = bd;
        }

        public IList<PaqueteDto> ListarPaquete(string filtro, bool? estado, int? areaId, int page, int rows, out int nroTotalRegistros)
        {


            {
                try
                {
                    //IRepositorio<Paquete> rep = new EfRepositorio<Paquete>(ctx);
                    //IRepositorio<AreaEstudio> repAE = new EfRepositorio<AreaEstudio>(ctx);
                    //IRepositorio<TipoMuestraAnalizador> repTM = new EfRepositorio<TipoMuestraAnalizador>(ctx);

                    var lista = (from a in _bd.Paquete
                                 join b in _bd.AreaEstudio on a.AreaEstudioId equals b.AreaEstudioId into p0
                                 from q0 in p0.DefaultIfEmpty()
                                 join c in _bd.TipoMuestraAnalizador on a.TipoMuestraAnalizadorId equals c.TipoMuestraAnalizadorId into p1
                                 from q1 in p1.DefaultIfEmpty()
                                 where (a.FlagActivo == estado || !estado.HasValue)
                                 && (string.IsNullOrEmpty(filtro) || a.Nombre.Contains(filtro.ToUpper()))
                                 && a.FlagEliminado == false &&
                                 (areaId == null || a.AreaEstudioId == areaId)
                                 orderby a.Nombre ascending
                                 select new
                                 {
                                     a.CreadoPor,
                                     a.Descripcion,
                                     a.FechaCreacion,
                                     a.FechaModificacion,
                                     a.FlagActivo,
                                     a.FlagEliminado,
                                     a.ModificadoPor,
                                     a.Nombre,
                                     a.PaqueteId,
                                     a.AreaEstudioId,
                                     AreaEstudio = q0.Nombre,
                                     a.TipoMuestraAnalizadorId,
                                     MuestraAnalizador = q1.Nombre,
                                     a.ImprimeEtiqueta,
                                     a.EstadisticaAgp
                                 });
                    nroTotalRegistros = lista.Count();
                    lista = lista.Skip((page - 1) * rows).Take(rows);
                    var listaFinal = (from a in lista.ToList()
                                      select new PaqueteDto
                                      {
                                          CreadoPor = a.CreadoPor,
                                          Descripcion = a.Descripcion,
                                          FechaCreacion = a.FechaCreacion,
                                          FechaModificacion = a.FechaModificacion,
                                          FlagActivo = a.FlagActivo,
                                          FlagEliminado = a.FlagEliminado,
                                          ModificadoPor = a.ModificadoPor,
                                          Nombre = a.Nombre,
                                          PaqueteId = a.PaqueteId,
                                          AreaEstudioId = a.AreaEstudioId,
                                          ImprimeEtiqueta = a.ImprimeEtiqueta,
                                          EstadisticaAgp = a.EstadisticaAgp,
                                          Muestra = a.TipoMuestraAnalizadorId == null ? "" : a.MuestraAnalizador,
                                          AreaEstudio = new AreaEstudioDto() { AreaEstudioId = a.AreaEstudioId == null ? 0 : a.AreaEstudioId.Value, Nombre = a.AreaEstudio },
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
        public IList<PaqueteEquipo> ListarPaqueteEquipo(string filtro, bool? estado, int? areaId)
        {


            {
                try
                {
                    //IRepositorio<Paquete> rep = new EfRepositorio<Paquete>(ctx);
                    //IRepositorio<PaqueteEquipo> repPE = new EfRepositorio<PaqueteEquipo>(ctx);
                    //IRepositorio<Equipo> repE = new EfRepositorio<Equipo>(ctx);

                    var lista = (from a in _bd.Paquete
                                 join b in _bd.PaqueteEquipo on a.PaqueteId equals b.PaqueteId
                                 join c in _bd.Equipo on b.EquipoId equals c.EquipoId
                                 where (a.FlagActivo == estado || !estado.HasValue)
                                 && (string.IsNullOrEmpty(filtro) || a.Nombre.ToUpper().Contains(filtro.ToUpper()) || c.Nombre.ToUpper().Contains(filtro.ToUpper()))
                                 && a.FlagEliminado == false && b.FlagEliminado == false &&
                                 (areaId == null || a.AreaEstudioId == areaId) //&& (a.EsCalculado == null || a.EsCalculado == false) 
                                 orderby a.Nombre ascending
                                 select new
                                 {
                                     a.Nombre,
                                     a.PaqueteId,
                                     a.AreaEstudioId,
                                     b.PaqueteEquipoId,
                                     NombreEquipo = c.Nombre,
                                     c.EquipoId
                                 });


                    var listaFinal = (from a in lista.ToList()
                                      select new PaqueteEquipo
                                      {
                                          PaqueteEquipoId = a.PaqueteEquipoId,
                                          EquipoId = a.EquipoId,
                                          PaqueteId = a.PaqueteId,
                                          Paquete = new Paquete() { PaqueteId = a.PaqueteId, Nombre = a.Nombre },
                                          Equipo = new Equipo() { EquipoId = a.EquipoId, Nombre = a.NombreEquipo }
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
        public PaqueteDto ObtenerPaquete(int id)
        {
            try
            {

                {
                    int? dato = null;
                    //IRepositorio<Paquete> rep = new EfRepositorio<Paquete>(ctx);
                    var entidad = _bd.Paquete.Find(id);

                    var paquete = InitAutoMapper.mapper.Map<PaqueteDto>(entidad);

                    paquete.ImprimeEtiquetaId = paquete.ImprimeEtiqueta == null ? dato : (paquete.ImprimeEtiqueta.Value ? (int)EImprimeEtiqueta.Imprimir : (int)EImprimeEtiqueta.NoImprimir);
                    paquete.EstadisticaAgpId = paquete.EstadisticaAgp == null ? dato : (paquete.EstadisticaAgp.Value ? (int)EEstadisticaAgp.Agrupado : (int)EEstadisticaAgp.NoAgrupado);

                    var serv = (from a in _bd.Set<PaqueteServicio>()
                                where a.PaqueteId == paquete.PaqueteId
                                && a.FlagActivo == true
                                select a).Include("Servicio").ToList();

                    paquete.Servicios = (from x in serv
                                         select new ComboDto()
                                         {
                                             Id = x.Servicio.ServicioId,
                                             Descripcion = x.Servicio.Nombre
                                         }).ToList();

                    var PARAM = (from a in _bd.Set<PaqueteConexion>()
                                 where a.PaqueteId == paquete.PaqueteId
                                 && a.FlagActivo == true
                                 select a).ToList();

                    paquete.CodigosConexion = (from x in PARAM
                                               select new CodigosConexionDto()
                                               {
                                                   Id = x.PaqueteConexionId,
                                                   Valor = x.CodigoConexion
                                               }).ToList();

                    return paquete;
                }
            }

            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }
        }
        public void EliminaPaquete(int id, string usuario)
        {

            {
                try
                {
                    //IRepositorio<Paquete> rep = new EfRepositorio<Paquete>(ctx);
                    var obj = _bd.Paquete.Find(id);
                    obj.FlagActivo = false;
                    obj.FlagEliminado = true;
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
        public int RegistrarPaquete(PaqueteDto paquete)
        {

            {

                bool? dato = null;
                try
                {
                    if (paquete.PaqueteId == 0)
                    {
                        paquete.ImprimeEtiqueta = paquete.ImprimeEtiquetaId == null ? dato : (paquete.ImprimeEtiquetaId.Value == 1 ? true : false);
                        paquete.EstadisticaAgp = paquete.EstadisticaAgpId == null ? dato : (paquete.EstadisticaAgpId.Value == 1 ? true : false);

                        foreach (var item in paquete.ServiciosIds)
                        {
                            var serv = (from a in _bd.Set<Servicio>()
                                        where a.ServicioId == item
                                        select a).FirstOrDefault();
                            var paqser = new PaqueteServicio()
                            {
                                Paquete = InitAutoMapper.mapper.Map<Paquete>(paquete),
                                Servicio = serv,
                                CreadoPor = paquete.CreadoPor,
                                FechaCreacion = DateTime.Now,
                                FlagActivo = true,
                                FlagEliminado = false
                            };
                            _bd.Set<PaqueteServicio>().Add(paqser);
                        }

                        _bd.SaveChanges();

                        #region CodigosConexion
                        if (paquete.CodigosConexion != null)
                        {
                            foreach (var item in paquete.CodigosConexion)
                            {
                                var pqConexion = new PaqueteConexion()
                                {
                                    PaqueteId = paquete.PaqueteId,
                                    CodigoConexion = item.Valor,
                                    CreadoPor = paquete.CreadoPor,
                                    FechaCreacion = DateTime.Now,
                                    FlagActivo = true,
                                    FlagEliminado = false
                                };
                                _bd.Set<PaqueteConexion>().Add(pqConexion);
                            }

                            _bd.SaveChanges();
                        }
                        #endregion

                        return paquete.PaqueteId;
                    }
                    else
                    {
                        #region CodigosConexion
                        if (paquete.CodigosConexion != null)
                        {
                            var lstInt = (from a in _bd.Set<PaqueteConexion>()
                                          where a.PaqueteId == paquete.PaqueteId
                                          && a.FlagActivo == true
                                          select a).ToList();

                            lstInt = lstInt.Select(m =>
                            {
                                m.FlagActivo = false;
                                m.FlagEliminado = true;
                                m.ModificadoPor = paquete.ModificadoPor;
                                m.FechaModificacion = DateTime.Now;
                                return m;
                            }).ToList();

                            foreach (var item in paquete.CodigosConexion)
                            {
                                var param = new PaqueteConexion()
                                {
                                    FlagActivo = true,
                                    FlagEliminado = false,
                                    CreadoPor = paquete.ModificadoPor,
                                    FechaCreacion = DateTime.Now,
                                    PaqueteId = paquete.PaqueteId,
                                    CodigoConexion = item.Valor
                                };
                                _bd.Set<PaqueteConexion>().Add(param);
                            }
                        }

                        _bd.SaveChanges();
                        #endregion

                        var todos = (from a in _bd.Set<PaqueteServicio>()
                                     where a.PaqueteId == paquete.PaqueteId
                                     && a.FlagActivo == true
                                     select a).ToList();

                        var dif = (from b in todos
                                   where !paquete.ServiciosIds.Contains(b.ServicioId)
                                   select b).ToList();

                        foreach (var item in dif)
                        {
                            var serv = (from a in _bd.Set<PaqueteServicio>()
                                        where a.ServicioId == item.ServicioId
                                        && a.PaqueteId == paquete.PaqueteId
                                        && a.FlagActivo == true
                                        select a).FirstOrDefault();

                            serv.FlagActivo = false;
                            serv.FlagEliminado = true;
                            serv.FechaModificacion = DateTime.Now;
                            serv.ModificadoPor = paquete.ModificadoPor;

                        }

                        foreach (var item in paquete.ServiciosIds)
                        {
                            var serv = (from a in _bd.Set<PaqueteServicio>()
                                        where a.ServicioId == item
                                        && a.PaqueteId == paquete.PaqueteId
                                        && a.FlagActivo == true
                                        select a).FirstOrDefault();
                            if (serv == null)
                            {
                                var oldservicio = (from a in _bd.Set<Servicio>()
                                                   where a.ServicioId == item
                                                   select a).FirstOrDefault();
                                var oldpaquete = (from a in _bd.Set<Paquete>()
                                                  where a.PaqueteId == paquete.PaqueteId
                                                  select a).FirstOrDefault();


                                var paqser = new PaqueteServicio()
                                {
                                    Paquete = oldpaquete,
                                    Servicio = oldservicio,
                                    CreadoPor = paquete.ModificadoPor,
                                    FechaCreacion = DateTime.Now,
                                    FlagActivo = true,
                                    FlagEliminado = false
                                };
                                _bd.Set<PaqueteServicio>().Add(paqser);
                            }
                        }

                        var sgssEquiv = (from a in _bd.Set<IntEquivPaqueteEquipo>()
                                         where a.PaqueteId == paquete.PaqueteId
                                         select a).ToList();

                        if (paquete.CodigosConexion == null)
                        {
                            foreach (var item in sgssEquiv)
                            {
                                _bd.Set<IntEquivPaqueteEquipo>().Remove(item);
                            }
                        }
                        else
                        {
                            foreach (var item in paquete.CodigosConexion)
                            {
                                if (sgssEquiv.Count > 0)
                                {
                                    var vPc = sgssEquiv.Where(o => o.CodigoCPS == item.Valor).FirstOrDefault();
                                    if (vPc != null)
                                    {
                                        var tipoMuestra = Util.GetEnumDescription((ETipoMuestra)paquete.TipoMuestraId);
                                        vPc.CodigoCPS = item.Valor;
                                        vPc.CodigoMuestra = tipoMuestra.Split('-')[1].ToString().Trim();
                                        vPc.CreadoPor = paquete.ModificadoPor;
                                        vPc.FechaCreacion = DateTime.Now;
                                        vPc.FlagActivo = true;
                                        vPc.FlagEliminado = false;
                                    }
                                }
                            }
                        }


                        _bd.SaveChanges();

                        //IRepositorio<Paquete> rep = new EfRepositorio<Paquete>(ctx);
                        var act = _bd.Paquete.FirstOrDefault(m => m.PaqueteId == paquete.PaqueteId);
                        act.Descripcion = paquete.Descripcion;
                        act.FechaModificacion = paquete.FechaModificacion;
                        act.ModificadoPor = paquete.ModificadoPor;
                        act.Nombre = paquete.Nombre;
                        act.PaqueteId = paquete.PaqueteId;
                        act.AreaEstudioId = paquete.AreaEstudioId;
                        act.ImprimeEtiqueta = paquete.ImprimeEtiquetaId == null ? dato : (paquete.ImprimeEtiquetaId == 1 ? true : false);
                        act.EstadisticaAgp = paquete.EstadisticaAgpId == null ? dato : (paquete.EstadisticaAgpId == 1 ? true : false);
                        act.TipoMuestraId = paquete.TipoMuestraId;
                        act.TipoMuestraAnalizadorId = paquete.TipoMuestraAnalizadorId;
                        _bd.SaveChanges();
                        return act.PaqueteId;
                    }
                }

                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }
    }
}
