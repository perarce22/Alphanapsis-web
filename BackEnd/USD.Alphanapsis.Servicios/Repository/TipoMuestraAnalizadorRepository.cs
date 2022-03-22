using System;
using System.Collections.Generic;
using System.Text;
using USD.Alphanapsis.Data;
using USD.Alphanapsis.Entidades;
using System.Linq;
namespace USD.Alphanapsis.Servicios.Repository
{
    public class TipoMuestraAnalizadorRepository : ITipoMuestraAnalizadorRepository
    {
        private readonly ApplicationDbContext _bd;
        NLog.Logger logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        public TipoMuestraAnalizadorRepository(ApplicationDbContext bd)
        {
            _bd = bd;
        }
        public ICollection<TipoMuestraAnalizador> ListarTipoMuestraAnalizador(string filtro, bool? estado, int page, int rows, out int nroTotalRegistros)
        {
            
            {
                try
                {
                    //IRepositorio<TipoMuestraAnalizador> rep = new EfRepositorio<TipoMuestraAnalizador>(ctx);
                    var lista = (from a in _bd.TipoMuestraAnalizador
                                 where (a.FlagActivo == estado || !estado.HasValue)
                                 && (string.IsNullOrEmpty(filtro) || a.Nombre.Contains(filtro.ToUpper()))
                                 && a.FlagEliminado == false
                                 orderby a.Nombre ascending
                                 select new
                                 {
                                     a.TipoMuestraAnalizadorId,
                                     a.Nombre,
                                     a.Codigo,
                                     a.CreadoPor,
                                     a.FechaCreacion,
                                     a.ModificadoPor,
                                     a.FechaModificacion,
                                     a.FlagActivo
                                 });
                    nroTotalRegistros = lista.Count();

                    lista = lista.Skip((page - 1) * rows).Take(rows);

                    var listaFinal = (from a in lista.ToList()
                                      select new TipoMuestraAnalizador
                                      {
                                          TipoMuestraAnalizadorId = a.TipoMuestraAnalizadorId,
                                          Nombre = a.Nombre,
                                          Codigo = a.Codigo,
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

        public TipoMuestraAnalizador ObtenerTipoMuestraAnalizador(int id)
        {
            try
            {
                
                {
                    //IRepositorio<TipoMuestraAnalizador> rep = new EfRepositorio<TipoMuestraAnalizador>(ctx);
                    return _bd.TipoMuestraAnalizador.Find(id);
                }
            }
           
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }
        }

        public void EliminaTipoMuestraAnalizador(int id, string usuario)
        {
            
            {
                try
                {
                    //IRepositorio<TipoMuestraAnalizador> rep = new EfRepositorio<TipoMuestraAnalizador>(ctx); 
                    var obj = _bd.TipoMuestraAnalizador.Find(id);
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

        public int RegistrarTipoMuestraAnalizador(TipoMuestraAnalizador entidad)
        {
            
            {
                try
                {
                     
                    if (entidad.TipoMuestraAnalizadorId == 0)
                    {
                        _bd.TipoMuestraAnalizador.Add(entidad);
                        _bd.SaveChanges();
                        return entidad.TipoMuestraAnalizadorId;
                    }
                    else
                    {
                        var act = _bd.TipoMuestraAnalizador.FirstOrDefault(m => m.TipoMuestraAnalizadorId == entidad.TipoMuestraAnalizadorId);
                        act.Nombre = entidad.Nombre;
                        act.Codigo = act.TipoMuestraAnalizadorId.ToString();
                        act.TipoMuestraAnalizadorId = entidad.TipoMuestraAnalizadorId;
                        _bd.SaveChanges();
                        return act.TipoMuestraAnalizadorId;
                    }
                }
              
                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }

        public ICollection<TipoMuestraAnalizador> ListarTipoMuestraAnalizador()
        {

            
            {
                try
                {
                    //IRepositorio<TipoMuestraAnalizador> rep = new EfRepositorio<TipoMuestraAnalizador>(ctx);
                    var lista = (from a in _bd.TipoMuestraAnalizador
                                 where (a.FlagActivo == true)
                                 && a.FlagEliminado == false
                                 orderby a.Nombre ascending
                                 select new
                                 {
                                     a.Nombre,
                                     a.TipoMuestraAnalizadorId,
                                     a.Codigo,
                                     a.FlagActivo
                                 });

                    var listaFinal = (from a in lista.ToList()
                                      select new TipoMuestraAnalizador
                                      {
                                          Nombre = a.Nombre,
                                          TipoMuestraAnalizadorId = a.TipoMuestraAnalizadorId,
                                          Codigo = a.Codigo,
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

        public TipoMuestraAnalizador ObtenerTipoMuestraAnalizador(string codigo)
        {
            try
            {
                
                {
                    //IRepositorio<TipoMuestraAnalizador> rep = new EfRepositorio<TipoMuestraAnalizador>(ctx);
                    return _bd.TipoMuestraAnalizador.FirstOrDefault(o => o.Codigo == codigo);
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
