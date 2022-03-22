using System;
using System.Collections.Generic;
using System.Text;
using USD.Alphanapsis.Data;
using USD.Alphanapsis.Entidades;
using System.Linq;
namespace USD.Alphanapsis.Servicios.Repository
{
    public class ProcedenciaRepository : IProcedenciaRepository
    {
        private readonly ApplicationDbContext _bd;
        NLog.Logger logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        public ProcedenciaRepository(ApplicationDbContext bd)
        {
            _bd = bd;
        }

        public ICollection<Procedencia> ListarProcedencia()
        {
            
            {
                try
                {
                    //IRepositorio<Procedencia> rep = new EfRepositorio<Procedencia>(ctx);

                    var lista = (from a in _bd.Procedencia
                                 where a.FlagActivo == true &&
                                       a.FlagEliminado == false
                                 orderby a.Nombre ascending
                                 select new
                                 {
                                     a.ProcedenciaId,
                                     a.Nombre,
                                     a.FlagActivo,
                                     a.FlagEliminado,
                                 });

                    var listaFinal = (from a in lista.ToList()
                                      select new Procedencia()
                                      {
                                          ProcedenciaId = a.ProcedenciaId,
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
        public ICollection<Procedencia> ListarProcedencia(string filtro, bool? estado, int page, int rows, string sidx, string sord, out int nroTotalRegistros)
        {
            
            {
                try
                {
                    //IRepositorio<Procedencia> rep = new EfRepositorio<Procedencia>(ctx);

                    var lista = (from a in _bd.Procedencia
                                 where (a.FlagActivo == estado || !estado.HasValue) &&
                                       (string.IsNullOrEmpty(filtro) || a.Nombre.ToUpper().Contains(filtro.ToUpper()))
                                 orderby a.Nombre ascending
                                 select new
                                 {
                                     a.ProcedenciaId,
                                     a.Nombre,
                                     a.FlagActivo,
                                     a.FlagEliminado,
                                 });

                    nroTotalRegistros = lista.Count();
                    lista = lista.Skip((page - 1) * rows).Take(rows);

                    var listaFinal = (from a in lista.ToList()
                                      select new Procedencia()
                                      {
                                          ProcedenciaId = a.ProcedenciaId,
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
        public Procedencia ObtenerProcedencia(int id)
        {
            
            {
                try
                {
                    //IRepositorio<Procedencia> rep = new EfRepositorio<Procedencia>(ctx);

                    var lista = (from a in _bd.Procedencia
                                 where a.ProcedenciaId == id
                                 select new
                                 {
                                     a.ProcedenciaId,
                                     a.Nombre,
                                     a.FlagActivo,
                                     a.FlagEliminado,
                                 });

                    var listaFinal = (from a in lista.ToList()
                                      select new Procedencia()
                                      {
                                          ProcedenciaId = a.ProcedenciaId,
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
        public void RegistrarProcedencia(Procedencia entidad)
        {
            
            {
                try
                {
                    //IRepositorio<Procedencia> rep = new EfRepositorio<Procedencia>(ctx);

                    if (entidad.ProcedenciaId == 0)
                    {
                        _bd.Procedencia.Add(entidad);

                    }
                    else
                    {
                        var Procedencia2 = _bd.Procedencia.Find(entidad.ProcedenciaId);
                        Procedencia2.Nombre = entidad.Nombre;
                        Procedencia2.FechaModificacion = entidad.FechaModificacion;
                        Procedencia2.ModificadoPor = entidad.ModificadoPor;
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
        public void EliminarProcedencia(int id, string usuario)
        {
            
            {
                try
                {
                    //IRepositorio<Procedencia> rep = new EfRepositorio<Procedencia>(ctx);

                    var obj = _bd.Procedencia.Find(id);
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
        public void CambiarEstadoProcedencia(int id, bool estado, string usuario)
        {
            
            {
                try
                {
                    //IRepositorio<Procedencia> rep = new EfRepositorio<Procedencia>(ctx);

                    var obj = _bd.Procedencia.Find(id);

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
        public Procedencia ObtenerProcedencia(string codigoHIS)
        {
            try
            {
                
                {
                    //IRepositorio<Procedencia> rep = new EfRepositorio<Procedencia>(ctx);
                    return _bd.Procedencia.FirstOrDefault(o => o.CodigoHIS == codigoHIS);
                }
            }
           
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }
        }

        public Procedencia ObtenerProcedenciaHis(string id)
        {
            
            {
                try
                {
                    //IRepositorio<Procedencia> rep = new EfRepositorio<Procedencia>(ctx);

                    var lista = (from a in _bd.Procedencia
                                 where a.CodigoHIS == id
                                 select new
                                 {
                                     a.ProcedenciaId,
                                     a.Nombre,
                                     a.FlagActivo,
                                     a.FlagEliminado,
                                 });

                    var listaFinal = (from a in lista.ToList()
                                      select new Procedencia()
                                      {
                                          ProcedenciaId = a.ProcedenciaId,
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
    }
}
