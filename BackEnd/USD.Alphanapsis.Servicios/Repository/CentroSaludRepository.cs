using System;
using System.Collections.Generic;
using System.Text;
using USD.Alphanapsis.Data;
using USD.Alphanapsis.Dto;
using System.Linq;
using USD.Alphanapsis.Entidades;

namespace USD.Alphanapsis.Servicios.Repository
{
    public class CentroSaludRepository : ICentroSaludRepository
    {
        private readonly ApplicationDbContext _bd;
        NLog.Logger logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        public CentroSaludRepository(ApplicationDbContext bd)
        {
            _bd = bd;
        }
        public ICollection<CentroSaludOrigen> ListarCentroSaludOrigen(string filtro, bool? estado, int page, int rows, out int nroTotalRegistros)
        {
            
            {
                try
                {
                    //IRepositorio<CentroSaludOrigen> rep = new EfRepositorio<CentroSaludOrigen>(ctx);
                    var lista = (from a in _bd.CentroSaludOrigen
                                 where (a.FlagActivo == estado || !estado.HasValue)
                                 && (string.IsNullOrEmpty(filtro) || a.Nombre.Contains(filtro.ToUpper()))
                                 && a.FlagEliminado == false
                                 orderby a.Nombre ascending
                                 select new
                                 {
                                     a.CentroSaludOrigenId,
                                     a.Nombre,
                                     a.CreadoPor,
                                     a.FechaCreacion,
                                     a.ModificadoPor,
                                     a.FechaModificacion,
                                     a.FlagActivo
                                 });
                    nroTotalRegistros = lista.Count();

                    lista = lista.Skip((page - 1) * rows).Take(rows);

                    var listaFinal = (from a in lista.ToList()
                                      select new CentroSaludOrigen
                                      {
                                          CentroSaludOrigenId = a.CentroSaludOrigenId,
                                          Nombre = a.Nombre,
                                          CreadoPor = a.CreadoPor,
                                          FechaCreacion = a.FechaCreacion,
                                          ModificadoPor = a.ModificadoPor,
                                          FechaModificacion = a.FechaModificacion,
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

        public CentroSaludOrigen ObtenerCentroSaludOrigen(int id)
        {
            try
            {
                
                {
                    //IRepositorio<CentroSaludOrigen> rep = new EfRepositorio<CentroSaludOrigen>(ctx);
                    return _bd.CentroSaludOrigen.Find(id);
                }
            }
            
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }
        }

        public  void EliminaCentroSaludOrigen(int id, string usuario)
        {
            
            {
                try
                {
                    //IRepositorio<CentroSaludOrigen> rep = new EfRepositorio<CentroSaludOrigen>(ctx); 
                    var obj = _bd.CentroSaludOrigen.Find(id);
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

        public  int RegistrarCentroSaludOrigen(CentroSaludOrigen entidad)
        {
            
            {
                try
                {
                    //IRepositorio<CentroSaludOrigen> rep = new EfRepositorio<CentroSaludOrigen>(ctx);
                    if (entidad.CentroSaludOrigenId == 0)
                    {
                        _bd.CentroSaludOrigen.Add(entidad);
                        _bd.SaveChanges();
                        return entidad.CentroSaludOrigenId;
                    }
                    else
                    {
                        var act = _bd.CentroSaludOrigen.FirstOrDefault(m => m.CentroSaludOrigenId == entidad.CentroSaludOrigenId);
                        act.Nombre = entidad.Nombre;
                        _bd.SaveChanges();
                        return act.CentroSaludOrigenId;
                    }
                }
                
                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }

        public ICollection<CentroSaludAsistencial> ListarSedeCentroSalud(int Id)
        {
            {
                try
                {
                    //IRepositorio<CentroSaludAsistencial> rep = new EfRepositorio<CentroSaludAsistencial>(ctx);
                    var lista = (from a in _bd.CentroSaludAsistencial
                                 where a.FlagActivo == true
                                 && a.FlagEliminado == false && a.CentroSaludOrigenId == Id
                                 orderby a.Nombre ascending
                                 select new
                                 {
                                     a.Nombre,
                                     a.CentroSaludOrigenId,
                                     a.CentroSaludAsistencialId,
                                     a.FlagActivo,
                                     a.CodigoInterno
                                 });

                    var listaFinal = (from a in lista.ToList()
                                      select new CentroSaludAsistencial
                                      {
                                          Nombre = a.Nombre,
                                          CentroSaludOrigenId = a.CentroSaludOrigenId,
                                          CentroSaludAsistencialId = a.CentroSaludAsistencialId,
                                          FlagActivo = a.FlagActivo,
                                          CodigoInterno = a.CodigoInterno
                                      }).ToList();
                    return  (listaFinal);
                }
                
                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }

        public ICollection<CentroSaludAsistencial> ListarSedeCentroSaludAll(int Id)
        {

            
            {
                try
                {
                    //IRepositorio<CentroSaludAsistencial> rep = new EfRepositorio<CentroSaludAsistencial>(ctx);
                    var lista = (from a in _bd.CentroSaludAsistencial
                                 where a.CentroSaludOrigenId == Id
                                 orderby a.Nombre ascending
                                 select new
                                 {
                                     a.Nombre,
                                     a.CentroSaludOrigenId,
                                     a.CentroSaludAsistencialId,
                                     a.FlagActivo
                                 });

                    var listaFinal = (from a in lista.ToList()
                                      select new CentroSaludAsistencial
                                      {
                                          Nombre = a.Nombre,
                                          CentroSaludOrigenId = a.CentroSaludOrigenId,
                                          CentroSaludAsistencialId = a.CentroSaludAsistencialId,
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

        public  CentroSaludAsistencial ObtenerCentroSaludSede(int id)
        {
            try
            {
                
                {
                    //IRepositorio<CentroSaludAsistencial> rep = new EfRepositorio<CentroSaludAsistencial>(ctx);
                    return  (_bd.CentroSaludAsistencial.Find(id));
                }
            }
            
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }
        }

        public CentroSaludAsistencial ObtenerCentroSaludSede(string codSede)
        {
            
            {
                try
                {
                    //IRepositorio<CentroSaludAsistencial> rep = new EfRepositorio<CentroSaludAsistencial>(ctx);
                    var lista = (from a in _bd.CentroSaludAsistencial
                                 where a.CodigoInterno == codSede
                                 orderby a.Nombre ascending
                                 select new
                                 {
                                     a.Nombre,
                                     a.CentroSaludOrigenId,
                                     a.CentroSaludAsistencialId,
                                     a.FlagActivo
                                 });

                    var listaFinal = (from a in lista.ToList()
                                      select new CentroSaludAsistencial
                                      {
                                          Nombre = a.Nombre,
                                          CentroSaludOrigenId = a.CentroSaludOrigenId,
                                          CentroSaludAsistencialId = a.CentroSaludAsistencialId,
                                          FlagActivo = a.FlagActivo
                                      }).ToList();
                    return listaFinal.FirstOrDefault();
                }
                 
                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }

        public  ICollection<CentroSaludAsistencial> ListarSedeCentroSaludAsistenAll()
        {
            
            {
                try
                {
                    //IRepositorio<CentroSaludAsistencial> rep = new EfRepositorio<CentroSaludAsistencial>(ctx);
                    var lista = (from a in _bd.CentroSaludAsistencial
                                 orderby a.Nombre ascending
                                 select new
                                 {
                                     a.Nombre,
                                     a.CentroSaludOrigenId,
                                     a.CentroSaludAsistencialId,
                                     a.FlagActivo
                                 });

                    var listaFinal = (from a in lista.ToList()
                                      select new CentroSaludAsistencial
                                      {
                                          Nombre = a.Nombre,
                                          CentroSaludOrigenId = a.CentroSaludOrigenId,
                                          CentroSaludAsistencialId = a.CentroSaludAsistencialId,
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
    }
}
