using System;
using System.Collections.Generic;
using System.Text;
using USD.Alphanapsis.Data;
using USD.Alphanapsis.Entidades;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using USD.Alphanapsis.Dto;
using USD.Alphanapsis.Dto.Custom;
using USD.Alphanapsis.Utiles;

namespace USD.Alphanapsis.Servicios.Repository
{
    public class ServicioRepository : IServicioRepository
    {
        private readonly ApplicationDbContext _bd;
        NLog.Logger logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        public ServicioRepository(ApplicationDbContext bd)
        {
            _bd = bd;
        }
        public List<Servicio> ListarServicio(string filtro, bool? estado, int? areaId, int page, int rows, out int nroTotalRegistros)
        {

            
            {
                try
                {
                    //IRepositorio<Servicio> rep = new EfRepositorio<Servicio>(ctx);
                    //IRepositorio<AreaEstudio> repAE = new EfRepositorio<AreaEstudio>(ctx);

                    var lista = (from a in _bd.Servicio
                                 join b in _bd.AreaEstudio on a.AreaEstudioId equals b.AreaEstudioId into p0
                                 from q0 in p0.DefaultIfEmpty()
                                 where (a.FlagActivo == estado || !estado.HasValue)
                                 && (string.IsNullOrEmpty(filtro) || a.Nombre.Contains(filtro.ToUpper()))
                                 && a.FlagEliminado == false &&
                                 (areaId == null || a.AreaEstudioId == areaId)
                                 orderby a.Nombre ascending
                                 select new
                                 {
                                     a.Descripcion,
                                     a.Nombre,
                                     a.ServicioId,
                                     a.AreaEstudioId,
                                     a.Trazable,
                                     a.ReporteOrden,
                                     AreaEstudio = q0.Nombre,
                                     a.UnidadMedida,
                                     a.Referencia,
                                     a.FlagActivo,
                                     a.EsCalculado
                                 });
                    nroTotalRegistros = lista.Count();
                    lista = lista.Skip((page - 1) * rows).Take(rows);
                    var listaFinal = (from a in lista.ToList()
                                      select new Servicio
                                      {
                                          Descripcion = a.Descripcion,
                                          Nombre = a.Nombre,
                                          ServicioId = a.ServicioId,
                                          AreaEstudioId = a.AreaEstudioId,
                                          Trazable = a.Trazable,
                                          ReporteOrden = a.ReporteOrden,
                                          UnidadMedida = a.UnidadMedida,
                                          Referencia = a.Referencia,
                                          EsCalculado = a.EsCalculado,
                                          AreaEstudio = new AreaEstudio() { AreaEstudioId = a.AreaEstudioId == null ? 0 : a.AreaEstudioId.Value, Nombre = a.AreaEstudio },
                                          FlagActivo = a.FlagActivo
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

        public ServicioDto ObtenerServicio(int id)
        {
            try
            {
                
                {
                    int? dato = null;
                    //IRepositorio<Servicio> rep = new EfRepositorio<Servicio>(ctx);
                    var servicio = InitAutoMapper.mapper.Map<ServicioDto>(_bd.Servicio.Find(id));

                    var PARAM = (from a in _bd.Set<ServicioInterfaz>()
                                 where a.ServicioId == servicio.ServicioId
                                 && a.FlagActivo == true
                                 select a).Include("Equipo").ToList();

                    servicio.Interfaz = (from x in PARAM
                                         select new InterfazDto()
                                         {
                                             Id = x.ServicioInterfazId,
                                             Valor = x.CodigoInterfaz,
                                             EquipoId = x.EquipoId,
                                             Nombre = x.Equipo.Nombre
                                         }).ToList();

                    servicio.TrazableId = servicio.Trazable == null ? dato : (servicio.Trazable.Value ? (int)ETrazable.Trazable : (int)ETrazable.NoTrazable);
                    servicio.TipoResultadoId = servicio.TipoResultado == null ? dato : (servicio.TipoResultado.Value ? (int)EResultado.Cualitativo : (int)EResultado.Cuantitativo);
                    servicio.ReporteMostrarId = servicio.ReporteMostrar == null ? dato : (servicio.ReporteMostrar.Value ? (int)EReporteMostrar.ReporteMostrar : (int)EReporteMostrar.ReporteNoMostrar);
                    servicio.EsCalculadoId = servicio.EsCalculado == null ? dato : (servicio.EsCalculado.Value ? (int)ECalculado.Calculado : (int)ECalculado.NoCalculado);
                    return servicio;
                }
            }
            
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }
        }

        public void EliminaServicio(int id, string usuario)
        {
            
            {
                try
                {
                    //IRepositorio<Servicio> rep = new EfRepositorio<Servicio>(ctx);
                    var obj = _bd.Servicio.Find(id);
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

        public int RegistrarServicio(ServicioDto servicio)
        {
            
            {
                bool? dato = null;
                try
                {
                    //IRepositorio<Servicio> rep = new EfRepositorio<Servicio>(ctx);
                    if (servicio.ServicioId == 0)
                    {
                        servicio.TipoResultado = servicio.TipoResultadoId == null ? dato : (servicio.TipoResultadoId.Value == 1 ? true : false);
                        servicio.EsCalculado = servicio.EsCalculadoId == null ? dato : (servicio.EsCalculadoId.Value == 1 ? true : false);
                        servicio.Trazable = servicio.TrazableId == null ? dato : (servicio.TrazableId == 1 ? true : false);
                        servicio.ReporteMostrar = servicio.ReporteMostrarId == null ? dato : (servicio.ReporteMostrarId == 1 ? true : false);
                        _bd.Servicio.Add(InitAutoMapper.mapper.Map<Servicio>(servicio));

                        #region Interfaz
                        if (servicio.Interfaz != null)
                        {
                            foreach (var item in servicio.Interfaz)
                            {
                                var inter = new ServicioInterfaz()
                                {
                                    ServicioId = servicio.ServicioId,
                                    CodigoInterfaz = item.Valor,
                                    EquipoId = item.EquipoId,
                                    CreadoPor = servicio.CreadoPor,
                                    FechaCreacion = DateTime.Now,
                                    FlagActivo = true,
                                    FlagEliminado = false
                                };
                                _bd.Set<ServicioInterfaz>().Add(inter);
                            }

                            _bd.SaveChanges();
                        }
                        #endregion

                        return servicio.ServicioId;

                    }
                    else
                    {
                        #region Interfaz
                        if (servicio.Interfaz != null)
                        {
                            var lstInt = (from a in _bd.Set<ServicioInterfaz>()
                                          where a.ServicioId == servicio.ServicioId
                                          && a.FlagActivo == true
                                          select a).ToList();

                            lstInt = lstInt.Select(m =>
                            {
                                m.FlagActivo = false;
                                m.FlagEliminado = true;
                                m.ModificadoPor = servicio.ModificadoPor;
                                m.FechaModificacion = DateTime.Now;
                                return m;
                            }).ToList();

                            foreach (var item in servicio.Interfaz)
                            {
                                var param = new ServicioInterfaz()
                                {
                                    FlagActivo = true,
                                    FlagEliminado = false,
                                    CreadoPor = servicio.ModificadoPor,
                                    FechaCreacion = DateTime.Now,
                                    ServicioId = servicio.ServicioId,
                                    CodigoInterfaz = item.Valor,
                                    EquipoId = item.EquipoId
                                };
                                _bd.Set<ServicioInterfaz>().Add(param);
                            }
                        }

                        _bd.SaveChanges();
                        #endregion

                        var act = _bd.Servicio.FirstOrDefault(m => m.ServicioId == servicio.ServicioId); act.Descripcion = servicio.Descripcion;
                        act.Nombre = servicio.Nombre;
                        act.ServicioId = servicio.ServicioId;
                        act.EsCalculado = servicio.EsCalculadoId == null ? dato : (servicio.EsCalculadoId == 1 ? true : false);
                        act.Trazable = servicio.TrazableId == null ? dato : (servicio.TrazableId == 1 ? true : false);
                        act.TipoResultado = servicio.TipoResultadoId == null ? dato : (servicio.TipoResultadoId == 1 ? true : false);
                        act.ReporteMostrar = servicio.ReporteMostrarId == null ? dato : (servicio.ReporteMostrarId == 1 ? true : false);
                        act.ReporteOrden = servicio.ReporteOrden;
                        //act.CodigoInterfaz = servicio.CodigoInterfaz;
                        act.AreaEstudioId = servicio.AreaEstudioId;
                        act.ReporteColumna = servicio.ReporteColumna;
                        act.ReporteNombre = servicio.ReporteNombre;
                        act.UnidadMedida = servicio.UnidadMedida;
                        act.Referencia = servicio.Referencia;
                        act.MetodoId = servicio.MetodoId;
                        act.TipoDatoId = servicio.TipoDatoId;
                        act.MultiplicarPor = servicio.MultiplicarPor;
                        _bd.SaveChanges();
                        return act.ServicioId;
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
