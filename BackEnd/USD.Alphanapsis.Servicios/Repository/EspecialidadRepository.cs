using System;
using System.Collections.Generic;
using System.Text;
using USD.Alphanapsis.Data;
using System.Linq;
using USD.Alphanapsis.Dto;
using USD.Alphanapsis.Entidades;

namespace USD.Alphanapsis.Servicios.Repository
{
    public class EspecialidadRepository : IEspecialidadRepository
    {
        private readonly ApplicationDbContext _bd;
        NLog.Logger logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        public EspecialidadRepository(ApplicationDbContext bd)
        {
            _bd = bd;
        }
        public ICollection<Especialidad> ListarEspecialidad()
        {
            
            {
                try
                {
                    //IRepositorio<Especialidad> rep = new EfRepositorio<Especialidad>(ctx);

                    var lista = (from a in _bd.Especialidad
                                 where a.FlagActivo == true &&
                                       a.FlagEliminado == false
                                 orderby a.Nombre ascending
                                 select new
                                 {
                                     a.EspecialidadId,
                                     a.Nombre,
                                     a.FlagActivo,
                                     a.FlagEliminado,
                                 });

                    var listaFinal = (from a in lista.ToList()
                                      select new Especialidad()
                                      {
                                          EspecialidadId = a.EspecialidadId,
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
        public ICollection<Especialidad> ListarEspecialidad(string filtro, bool? estado, int page, int rows, string sidx, string sord, out int nroTotalRegistros)
        {
            
            {
                try
                {
                    //IRepositorio<Especialidad> rep = new EfRepositorio<Especialidad>(ctx);

                    var lista = (from a in _bd.Especialidad
                                 where (a.FlagActivo == estado || !estado.HasValue) &&
                                       (string.IsNullOrEmpty(filtro) || a.Nombre.ToUpper().Contains(filtro.ToUpper()))
                                 orderby a.Nombre ascending
                                 select new
                                 {
                                     a.EspecialidadId,
                                     a.Nombre,
                                     a.FlagActivo,
                                     a.FlagEliminado,
                                 });

                    nroTotalRegistros = lista.Count();
                    lista = lista.Skip((page - 1) * rows).Take(rows);

                    var listaFinal = (from a in lista.ToList()
                                      select new Especialidad()
                                      {
                                          EspecialidadId = a.EspecialidadId,
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
        public Especialidad ObtenerEspecialidad(int id)
        {
            
            {
                try
                {
                    //IRepositorio<Especialidad> rep = new EfRepositorio<Especialidad>(ctx);

                    var lista = (from a in _bd.Especialidad
                                 where a.EspecialidadId == id
                                 select new
                                 {
                                     a.EspecialidadId,
                                     a.Nombre,
                                     a.FlagActivo,
                                     a.FlagEliminado,
                                 });

                    var listaFinal = (from a in lista.ToList()
                                      select new Especialidad()
                                      {
                                          EspecialidadId = a.EspecialidadId,
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
        public void RegistrarEspecialidad(Especialidad especialidad)
        {
            
            {
                try
                {
                    //IRepositorio<Especialidad> rep = new EfRepositorio<Especialidad>(ctx);

                    if (especialidad.EspecialidadId == 0)
                    {
                        _bd.Especialidad.Add(especialidad);
                        _bd.SaveChanges();

                    }
                    else
                    {
                        var Especialidad2 = _bd.Especialidad.Find(especialidad.EspecialidadId);
                        Especialidad2.Nombre = especialidad.Nombre;
                        Especialidad2.FechaModificacion = especialidad.FechaModificacion;
                        Especialidad2.ModificadoPor = especialidad.ModificadoPor;
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
        public void EliminarEspecialidad(int id, string usuario)
        {
            
            {
                try
                {
                    //IRepositorio<Especialidad> rep = new EfRepositorio<Especialidad>(ctx);
                    var obj = _bd.Especialidad.Find(id);
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
        public void CambiarEstadoEspecialidad(int id, bool estado, string usuario)
        {
            
            {
                try
                {
                    //IRepositorio<Especialidad> rep = new EfRepositorio<Especialidad>(ctx);

                    var obj = _bd.Especialidad.Find(id);
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
    }
}
