using System;
using System.Collections.Generic;
using System.Text;
using USD.Alphanapsis.Data;
using USD.Alphanapsis.Entidades;
using System.Linq;
namespace USD.Alphanapsis.Servicios.Repository
{
    public class ServicioSaludRepository : IServicioSaludRepository
    {
        private readonly ApplicationDbContext _bd;
        NLog.Logger logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        public ServicioSaludRepository(ApplicationDbContext bd)
        {
            _bd = bd;
        }
        public ICollection<ServicioSalud> ListarServicioSalud()
        {
            
            {
                try
                {
                    //IRepositorio<ServicioSalud> rep = new EfRepositorio<ServicioSalud>(ctx);

                    var lista = (from a in _bd.ServicioSalud
                                 where a.FlagActivo == true &&
                                       a.FlagEliminado == false
                                 orderby a.Nombre ascending
                                 select new
                                 {
                                     a.ServicioSaludId,
                                     a.Nombre,
                                     a.FlagActivo,
                                     a.FlagEliminado,
                                 });

                    var listaFinal = (from a in lista.ToList()
                                      select new ServicioSalud()
                                      {
                                          ServicioSaludId = a.ServicioSaludId,
                                          Nombre = a.Nombre,
                                          FlagActivo = a.FlagActivo,
                                          FlagEliminado = a.FlagEliminado,
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
        public ICollection<ServicioSalud> ListarServicioSalud(string filtro, bool? estado, int page, int rows, string sidx, string sord, out int nroTotalRegistros)
        {
            
            {
                try
                {
                    //IRepositorio<ServicioSalud> rep = new EfRepositorio<ServicioSalud>(ctx);

                    var lista = (from a in _bd.ServicioSalud
                                 where (a.FlagActivo == estado || !estado.HasValue) &&
                                       (string.IsNullOrEmpty(filtro) || a.Nombre.ToUpper().Contains(filtro.ToUpper()))
                                 orderby a.Nombre ascending
                                 select new
                                 {
                                     a.ServicioSaludId,
                                     a.Nombre,
                                     a.FlagActivo,
                                     a.FlagEliminado,
                                 });

                    nroTotalRegistros = lista.Count();
                    lista = lista.Skip((page - 1) * rows).Take(rows);

                    var listaFinal = (from a in lista.ToList()
                                      select new ServicioSalud()
                                      {
                                          ServicioSaludId = a.ServicioSaludId,
                                          Nombre = a.Nombre,
                                          FlagActivo = a.FlagActivo,
                                          FlagEliminado = a.FlagEliminado,
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
        public ServicioSalud ObtenerServicioSalud(int id)
        {
            
            {
                try
                {
                    //IRepositorio<ServicioSalud> rep = new EfRepositorio<ServicioSalud>(ctx);

                    var lista = (from a in _bd.ServicioSalud
                                 where a.ServicioSaludId == id
                                 select new
                                 {
                                     a.ServicioSaludId,
                                     a.Nombre,
                                     a.FlagActivo,
                                     a.FlagEliminado,
                                 });

                    var listaFinal = (from a in lista.ToList()
                                      select new ServicioSalud()
                                      {
                                          ServicioSaludId = a.ServicioSaludId,
                                          Nombre = a.Nombre,
                                          FlagActivo = a.FlagActivo,
                                          FlagEliminado = a.FlagEliminado,
                                      }).FirstOrDefault();

                    return listaFinal;

                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }
        public void RegistrarServicioSalud(ServicioSalud entidad)
        {
            
            {
                try
                {
                    //IRepositorio<ServicioSalud> rep = new EfRepositorio<ServicioSalud>(ctx);

                    if (entidad.ServicioSaludId == 0)
                    {
                        _bd.ServicioSalud.Add(entidad);
                        _bd.SaveChanges();

                    }
                    else
                    {
                        var ServicioSalud2 = _bd.ServicioSalud.Find(entidad.ServicioSaludId);
                        ServicioSalud2.Nombre = entidad.Nombre;
                        ServicioSalud2.FechaModificacion = entidad.FechaModificacion;
                        ServicioSalud2.ModificadoPor = entidad.ModificadoPor;
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
        public void EliminarServicioSalud(int id, string usuario)
        {
            
            {
                try
                {
                    //IRepositorio<ServicioSalud> rep = new EfRepositorio<ServicioSalud>(ctx);

                    var obj = _bd.ServicioSalud.Find(id);
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
        public void CambiarEstadoServicioSalud(int id, bool estado, string usuario)
        {
            
            {
                try
                {
                    //IRepositorio<ServicioSalud> rep = new EfRepositorio<ServicioSalud>(ctx);

                    var obj = _bd.ServicioSalud.Find(id);

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
        public ServicioSalud ObtenerServicioSalud(string codigoHIS)
        {
            try
            {
                
                {
                    //IRepositorio<ServicioSalud> rep = new EfRepositorio<ServicioSalud>(ctx);
                    return _bd.ServicioSalud.FirstOrDefault(o => o.CodigoHIS == codigoHIS);
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
