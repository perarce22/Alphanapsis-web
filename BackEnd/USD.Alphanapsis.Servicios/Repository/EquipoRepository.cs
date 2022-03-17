using System;
using System.Collections.Generic;
using System.Text;
using USD.Alphanapsis.Data;
using System.Linq;
using USD.Alphanapsis.Dto;
using USD.Alphanapsis.Entidades;
using Microsoft.EntityFrameworkCore;
using USD.Alphanapsis.Dto.Custom;
using USD.Alphanapsis.Utiles;

namespace USD.Alphanapsis.Servicios.Repository
{
    public class EquipoRepository : IEquipoRepository
    {
        private readonly ApplicationDbContext _bd;
        NLog.Logger logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        public EquipoRepository(ApplicationDbContext bd)
        {
            _bd = bd;
        }

        public   ICollection<Equipo> ListarEquipo(string filtro, bool? estado, int page, int rows, out int nroTotalRegistros)
        {
            
            {
                try
                {
                    //IRepositorio<Equipo> rep = new EfRepositorio<Equipo>(ctx);
                    //IRepositorio<AreaEstudio> repAE = new EfRepositorio<AreaEstudio>(ctx);
                    var lista = (from a in _bd.Equipo
                                 join b in _bd.AreaEstudio on a.AreaEstudioId equals b.AreaEstudioId into p0
                                 from q0 in p0.DefaultIfEmpty()
                                 where (a.FlagActivo == estado || !estado.HasValue)
                                 && (string.IsNullOrEmpty(filtro) || a.Nombre.Contains(filtro.ToUpper()))
                                 && a.FlagEliminado == false
                                 orderby a.Nombre ascending
                                 select new
                                 {
                                     a.CreadoPor,
                                     a.EquipoId,
                                     a.FechaCreacion,
                                     a.FechaModificacion,
                                     a.FlagActivo,
                                     a.FlagEliminado,
                                     a.Marca,
                                     a.Modelo,
                                     a.ModificadoPor,
                                     a.Nombre,
                                     a.Serie,
                                     NombreAE = q0 == null ? "" : q0.Nombre,
                                     AreaEstudioId = q0 == null ? 0 : q0.AreaEstudioId,
                                 });
                    nroTotalRegistros = lista.Count();
                    lista = lista.Skip((page - 1) * rows).Take(rows);
                    var listaFinal = (from a in lista.ToList()
                                      select new Equipo
                                      {
                                          CreadoPor = a.CreadoPor,
                                          EquipoId = a.EquipoId,
                                          FechaCreacion = a.FechaCreacion,
                                          FechaModificacion = a.FechaModificacion,
                                          FlagActivo = a.FlagActivo,
                                          FlagEliminado = a.FlagEliminado,
                                          Marca = a.Marca,
                                          Modelo = a.Modelo,
                                          ModificadoPor = a.ModificadoPor,
                                          Nombre = a.Nombre,
                                          Serie = a.Serie,
                                          AreaEstudio = new AreaEstudio() { AreaEstudioId = a.AreaEstudioId, Nombre = a.NombreAE }
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
        public   EquipoDto ObtenerEquipo(int id)
        {
            try
            {
                
                {
                    int? dato = null;
                    //IRepositorio<Equipo> rep = new EfRepositorio<Equipo>(ctx);
                    var equipo = InitAutoMapper.mapper.Map<EquipoDto>(_bd.Equipo.Find(id)) ;
                    equipo.MatchAutomaticoId = equipo.MatchAutomatico == null ? dato : (equipo.MatchAutomatico.Value ? (int)EMatch.Match : (int)EMatch.NoMatch);

                    var serv = (from a in _bd.Set<PaqueteEquipo>()
                                where a.EquipoId == equipo.EquipoId
                                && a.FlagActivo == true
                                select a).Include("Paquete").ToList();

                    var PARAM = (from a in _bd.Set<ParametroEquipo>()
                                 where a.EquipoId == equipo.EquipoId
                                 && a.FlagActivo == true
                                 select a).Include("ParametroInterfaz").ToList();

                    equipo.Paquetes = (from x in serv
                                       select new ComboDto()
                                       {
                                           Id = x.Paquete.PaqueteId,
                                           Descripcion = x.Paquete.Nombre
                                       }).ToList();
                    equipo.Parametros = (from x in PARAM
                                         select new ParametroDto()
                                         {
                                             Id = x.ParametroEquipoId,
                                             Valor = x.Valor,
                                             ParametroId = x.ParametroInterfazId == null ? 0 : x.ParametroInterfazId.Value,
                                             NombreParametro = x.ParametroInterfazId == null ? "" : x.ParametroInterfaz.Parametro
                                         }).ToList();
                    return equipo;
                }
            }
            
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }
        }
        public   void EliminaEquipo(int id, bool estado, string usuario)
        {
            
            {
                try
                {
                    //IRepositorio<Equipo> rep = new EfRepositorio<Equipo>(ctx);
                    var obj = _bd.Equipo.Find(id);
                    obj.FlagActivo = false;
                    obj.FlagEliminado = true;
                    //obj.FlagActivo = estado;
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
        public   int RegistrarEquipo(EquipoDto equipo)
        {
            
            {
                bool? dato = null;
                try
                {
                    //IRepositorio<Equipo> rep = new EfRepositorio<Equipo>(ctx);

                    if (equipo.EquipoId == 0)
                    {
                        equipo.MatchAutomatico = equipo.MatchAutomaticoId == null ? dato : (equipo.MatchAutomaticoId.Value == 1 ? true : false);

                        if (equipo.Parametros != null)
                            foreach (var item in equipo.Parametros)
                            {
                                var paqser = new ParametroEquipo()
                                {
                                    ParametroInterfazId = item.ParametroId,
                                    Valor = item.Valor,
                                    Equipo = InitAutoMapper.mapper.Map<Equipo>(equipo),
                                    CreadoPor = equipo.CreadoPor,
                                    FechaCreacion = DateTime.Now,
                                    FlagActivo = true,
                                    FlagEliminado = false
                                };
                                _bd.Set<ParametroEquipo>().Add(paqser);
                            }

                        foreach (var item in equipo.PaquetesIds)
                        {
                            var paq = (from a in _bd.Set<Paquete>()
                                       where a.PaqueteId == item
                                       select a).FirstOrDefault();

                            var paqser = new PaqueteEquipo()
                            {
                                Equipo = InitAutoMapper.mapper.Map<Equipo>(equipo),
                                Paquete = paq,
                                CreadoPor = equipo.CreadoPor,
                                FechaCreacion = DateTime.Now,
                                FlagActivo = true,
                                FlagEliminado = false,
                            };

                            _bd.Set<PaqueteEquipo>().Add(paqser);

                            var lPc = _bd.Set<PaqueteConexion>().Where(o => o.PaqueteId == item && o.FlagActivo == true).ToList();

                            if (lPc.Count > 0)
                            {
                                foreach (var pc in lPc)
                                {
                                    var tipoMuestra = Util.GetEnumDescription((ETipoMuestra)paq.TipoMuestraId);
                                    var sgssEquiv = new IntEquivPaqueteEquipo()
                                    {
                                        CodigoCPS = pc.CodigoConexion,
                                        CodigoMuestra = tipoMuestra.Split('-')[1].ToString().Trim(),
                                        PaqueteId = item,
                                        EquipoId = equipo.EquipoId,
                                        CreadoPor = equipo.CreadoPor,
                                        FechaCreacion = equipo.FechaCreacion,
                                        FlagActivo = equipo.FlagActivo,
                                        FlagEliminado = equipo.FlagEliminado
                                    };
                                    _bd.Set<IntEquivPaqueteEquipo>().Add(sgssEquiv);
                                }
                            }

                            //if (paq.CodigoCPT != null)
                            //{
                            //    var tipoMuestra = Util.GetEnumDescription((ETipoMuestra)paq.TipoMuestraId);
                            //    var sgssEquiv = new IntEquivPaqueteEquipo()
                            //    {
                            //        CodigoCPS = paq.CodigoCPT,
                            //        CodigoMuestra = tipoMuestra.Split('-')[1].ToString().Trim(),
                            //        PaqueteId = item,
                            //        EquipoId = equipo.EquipoId,
                            //        CreadoPor = equipo.CreadoPor,
                            //        FechaCreacion = equipo.FechaCreacion,
                            //        FlagActivo = equipo.FlagActivo,
                            //        FlagEliminado = equipo.FlagEliminado
                            //    };
                            //    ctx.Set<IntEquivPaqueteEquipo>().Add(sgssEquiv);
                            //}

                        }
                        _bd.SaveChanges();
                        return equipo.EquipoId;
                    }
                    else
                    {
                        #region Parametro
                        var parametros = (from a in _bd.Set<ParametroEquipo>()
                                          where a.EquipoId == equipo.EquipoId
                                          && a.FlagActivo == true
                                          select a).ToList();

                        parametros = parametros.Select(m =>
                        {
                            m.FlagActivo = false;
                            m.FlagEliminado = true;
                            m.ModificadoPor = equipo.ModificadoPor;
                            m.FechaModificacion = DateTime.Now;
                            return m;
                        }).ToList();

                        foreach (var item in equipo.Parametros)
                        {
                            var param = new ParametroEquipo()
                            {
                                FlagActivo = true,
                                FlagEliminado = false,
                                CreadoPor = equipo.ModificadoPor,
                                FechaCreacion = DateTime.Now,
                                ParametroInterfazId = item.ParametroId,
                                Valor = item.Valor,
                                EquipoId = equipo.EquipoId
                            };
                            _bd.Set<ParametroEquipo>().Add(param);
                        }
                        #endregion

                        #region Paquete
                        var todos = (from a in _bd.Set<PaqueteEquipo>()
                                     where a.EquipoId == equipo.EquipoId
                                     && a.FlagActivo == true
                                     select a).ToList();

                        var dif = (from b in todos
                                   where !equipo.PaquetesIds.Contains(b.PaqueteId)
                                   select b).ToList();

                        foreach (var item in dif)
                        {
                            var serv = (from a in _bd.Set<PaqueteEquipo>()
                                        where a.PaqueteId == item.PaqueteId
                                        && a.EquipoId == equipo.EquipoId
                                        && a.FlagActivo == true
                                        select a).FirstOrDefault();

                            serv.FlagActivo = false;
                            serv.FlagEliminado = true;
                            serv.FechaModificacion = DateTime.Now;
                            serv.ModificadoPor = equipo.ModificadoPor;

                            var sgssEquiv = (from a in _bd.Set<IntEquivPaqueteEquipo>()
                                             where a.PaqueteId == item.PaqueteId && a.EquipoId == item.EquipoId
                                             select a).ToList();
                            foreach (var sgss in sgssEquiv)
                            {
                                _bd.Set<IntEquivPaqueteEquipo>().Remove(sgss);
                            }

                        }

                        foreach (var item in equipo.PaquetesIds)
                        {
                            var serv = (from a in _bd.Set<PaqueteEquipo>()
                                        where a.PaqueteId == item
                                        && a.EquipoId == equipo.EquipoId
                                        && a.FlagActivo == true
                                        select a).FirstOrDefault();

                            var paq = (from a in _bd.Set<Paquete>()
                                       where a.PaqueteId == item
                                       select a).FirstOrDefault();

                            if (serv == null)
                            {
                                var oldservicio = (from a in _bd.Set<Paquete>()
                                                   where a.PaqueteId == item
                                                   select a).FirstOrDefault();
                                var oldpaquete = (from a in _bd.Set<Equipo>()
                                                  where a.EquipoId == equipo.EquipoId
                                                  select a).FirstOrDefault();


                                var paqser = new PaqueteEquipo()
                                {
                                    Equipo = oldpaquete,
                                    Paquete = oldservicio,
                                    CreadoPor = equipo.ModificadoPor,
                                    FechaCreacion = DateTime.Now,
                                    FlagActivo = true,
                                    FlagEliminado = false
                                };
                                _bd.Set<PaqueteEquipo>().Add(paqser);

                                var lPc = _bd.Set<PaqueteConexion>().Where(o => o.PaqueteId == item && o.FlagActivo == true).ToList();

                                if (lPc.Count > 0)
                                {
                                    foreach (var pc in lPc)
                                    {
                                        var tipoMuestra = Util.GetEnumDescription((ETipoMuestra)paq.TipoMuestraId);
                                        var sgssEquiv = new IntEquivPaqueteEquipo()
                                        {
                                            CodigoCPS = pc.CodigoConexion,
                                            CodigoMuestra = tipoMuestra.Split('-')[1].ToString().Trim(),
                                            PaqueteId = item,
                                            EquipoId = equipo.EquipoId,
                                            CreadoPor = equipo.CreadoPor,
                                            FechaCreacion = equipo.FechaCreacion,
                                            FlagActivo = equipo.FlagActivo,
                                            FlagEliminado = equipo.FlagEliminado
                                        };
                                        _bd.Set<IntEquivPaqueteEquipo>().Add(sgssEquiv);
                                    }
                                }

                                //if (paq.CodigoCPT != null)
                                //{
                                //    var tipoMuestra = Util.GetEnumDescription((ETipoMuestra)paq.TipoMuestraId);
                                //    var sgssEquiv = new IntEquivPaqueteEquipo()
                                //    {
                                //        CodigoCPS = paq.CodigoCPT,
                                //        CodigoMuestra = tipoMuestra.Split('-')[1].ToString().Trim(),
                                //        PaqueteId = item,
                                //        EquipoId = equipo.EquipoId,
                                //        CreadoPor = equipo.CreadoPor,
                                //        FechaCreacion = equipo.FechaCreacion,
                                //        FlagActivo = equipo.FlagActivo,
                                //        FlagEliminado = equipo.FlagEliminado
                                //    };
                                //    ctx.Set<IntEquivPaqueteEquipo>().Add(sgssEquiv);
                                //}
                            }
                        }
                        #endregion

                        _bd.SaveChanges();

                        var act = _bd.Equipo.FirstOrDefault(m => m.EquipoId == equipo.EquipoId);

                        act.EquipoId = equipo.EquipoId;
                        act.FechaModificacion = equipo.FechaModificacion;
                        act.Marca = equipo.Marca;
                        act.Modelo = equipo.Modelo;
                        act.ModificadoPor = equipo.ModificadoPor;
                        act.Nombre = equipo.Nombre;
                        act.Serie = equipo.Serie;
                        act.AreaEstudioId = equipo.AreaEstudioId;
                        act.TipoInterfazId = equipo.TipoInterfazId;
                        act.MatchAutomatico = equipo.MatchAutomaticoId == null ? dato : (equipo.MatchAutomaticoId == 1 ? true : false);
                        _bd.SaveChanges();
                        return act.EquipoId;
                    }
                }
                
                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }
        public ICollection<ParametroInterfaz> ListarParametro(int tipoInterfazId)
        {
            
            {
                try
                {
                    //IRepositorio<ParametroInterfaz> rep = new EfRepositorio<ParametroInterfaz>(ctx);
                    var lista = (from a in _bd.ParametroInterfaz
                                 where a.FlagActivo == true
                                 && a.FlagEliminado == false && a.TipoInterfazId == tipoInterfazId
                                 orderby a.ConfigInterfaceId ascending
                                 select new
                                 {
                                     a.ParametroInterfazId,
                                     a.CreadoPor,
                                     a.FechaCreacion,
                                     a.FechaModificacion,
                                     a.FlagActivo,
                                     a.FlagEliminado,
                                     a.Parametro,
                                     a.Descripcion
                                 });

                    var listaFinal = (from a in lista.ToList()
                                      select new ParametroInterfaz
                                      {
                                          ParametroInterfazId = a.ParametroInterfazId,
                                          Parametro = a.Parametro,
                                          Descripcion = a.Descripcion,
                                          FlagActivo = a.FlagActivo,
                                          FlagEliminado = a.FlagEliminado
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
        public ICollection<Equipo> ListarAEAnalizador(int areaEstudioId)
        {
            
            {
                try
                {
                    //IRepositorio<Equipo> rep = new EfRepositorio<Equipo>(ctx);
                    //IRepositorio<AreaEstudio> repAE = new EfRepositorio<AreaEstudio>(ctx);
                    var lista = (from a in _bd.Equipo
                                 where (a.FlagActivo == true)
                                 && a.FlagEliminado == false && a.AreaEstudioId == areaEstudioId
                                 orderby a.Nombre ascending
                                 select new
                                 {
                                     a.EquipoId,
                                     a.Nombre
                                 });

                    var listaFinal = (from a in lista.ToList()
                                      select new Equipo
                                      {
                                          EquipoId = a.EquipoId,
                                          Nombre = a.Nombre
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

        #region Interfaces
        public ICollection<ParametroInterfazDto> ListarParametrosAnalizador(string codigo)
        {
            
            {
                try
                {
                    //IRepositorio<Equipo> repEq = new EfRepositorio<Equipo>(ctx);
                    //IRepositorio<ParametroEquipo> repPEq = new EfRepositorio<ParametroEquipo>(ctx);
                    //IRepositorio<ParametroInterfaz> repEqC = new EfRepositorio<ParametroInterfaz>(ctx);

                    var registros = (from a in _bd.Equipo
                                     join b in _bd.ParametroEquipo on a.EquipoId equals b.EquipoId
                                     join c in _bd.ParametroInterfaz on b.ParametroInterfazId equals c.ParametroInterfazId
                                     where (a.CodUnico == codigo && b.FlagActivo == true && b.FlagEliminado == false)
                                     select new
                                     {
                                         c.ParametroInterfazId,
                                         c.Parametro,
                                         c.ConfigInterfaceId,
                                         b.Valor,
                                         a.TipoInterfazId
                                     });

                    var listaFinal = (from a in registros.ToList()
                                      select new ParametroInterfazDto
                                      {
                                          ParametroInterfazId = a.ParametroInterfazId,
                                          Parametro = a.Parametro,
                                          ConfigInterfaceId = a.ConfigInterfaceId,
                                          Valor = a.Valor,
                                          TipoInterfazId = a.TipoInterfazId
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
        public   Equipo ObtenerDatosAnalizador(string codigo)
        {
            
            {
                try
                {
                    //IRepositorio<Equipo> repEq = new EfRepositorio<Equipo>(ctx);
                    var obj = (from a in _bd.Equipo
                               where a.CodUnico == codigo &&
                                     a.FlagActivo == true && a.FlagEliminado == false
                               select a).FirstOrDefault();
                    return obj;
                }
                catch(Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }
        #endregion
    }
}
