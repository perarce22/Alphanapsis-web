using System;
using System.Collections.Generic;
using System.Text;
using USD.Alphanapsis.Data;
using USD.Alphanapsis.Entidades;
using System.Linq;
namespace USD.Alphanapsis.Servicios.Repository
{
    public class TipoInterfazRepository : ITipoInterfazRepository
    {
        private readonly ApplicationDbContext _bd;
        NLog.Logger logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        public TipoInterfazRepository(ApplicationDbContext bd)
        {
            _bd = bd;
        }

        public ICollection<TipoInterfaz> ListarTipoInterfaz()
        {
            
            {
                try
                {
                    //IRepositorio<TipoInterfaz> rep = new EfRepositorio<TipoInterfaz>(ctx);

                    var lista = (from a in _bd.TipoInterfaz
                                 where a.FlagActivo == true &&
                                       a.FlagEliminado == false
                                 orderby a.Nombre ascending
                                 select new
                                 {
                                     a.TipoInterfazId,
                                     a.Nombre,
                                     a.FlagActivo,
                                     a.FlagEliminado,
                                 });

                    var listaFinal = (from a in lista.ToList()
                                      select new TipoInterfaz()
                                      {
                                          TipoInterfazId = a.TipoInterfazId,
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
        public ICollection<TipoInterfaz> ListarTipoInterfaz(string filtro, bool? estado, int page, int rows, string sidx, string sord, out int nroTotalRegistros)
        {
            
            {
                try
                {
                    //IRepositorio<TipoInterfaz> rep = new EfRepositorio<TipoInterfaz>(ctx);

                    var lista = (from a in _bd.TipoInterfaz
                                 where (a.FlagActivo == estado || !estado.HasValue) &&
                                       (string.IsNullOrEmpty(filtro) || a.Nombre.ToUpper().Contains(filtro.ToUpper()))
                                 orderby a.Nombre ascending
                                 select new
                                 {
                                     a.TipoInterfazId,
                                     a.Nombre,
                                     a.FlagActivo,
                                     a.FlagEliminado,
                                 });

                    nroTotalRegistros = lista.Count();
                    lista = lista.Skip((page - 1) * rows).Take(rows);

                    var listaFinal = (from a in lista.ToList()
                                      select new TipoInterfaz()
                                      {
                                          TipoInterfazId = a.TipoInterfazId,
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
        public TipoInterfaz ObtenerTipoInterfaz(int id)
        {
            
            {
                try
                {
                    //IRepositorio<TipoInterfaz> rep = new EfRepositorio<TipoInterfaz>(ctx);

                    var lista = (from a in _bd.TipoInterfaz
                                 where a.TipoInterfazId == id
                                 select new
                                 {
                                     a.TipoInterfazId,
                                     a.Nombre,
                                     a.FlagActivo,
                                     a.FlagEliminado,
                                 });

                    var listaFinal = (from a in lista.ToList()
                                      select new TipoInterfaz()
                                      {
                                          TipoInterfazId = a.TipoInterfazId,
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
        public void RegistrarTipoInterfaz(TipoInterfaz tipoInterfaz)
        {
            
            {
                try
                {
                    //IRepositorio<TipoInterfaz> rep = new EfRepositorio<TipoInterfaz>(ctx);

                    if (tipoInterfaz.TipoInterfazId == 0)
                    {
                        _bd.TipoInterfaz.Add(tipoInterfaz);

                    }
                    else
                    {
                        var TipoInterfaz2 = _bd.TipoInterfaz.Find(tipoInterfaz.TipoInterfazId);
                        TipoInterfaz2.Nombre = tipoInterfaz.Nombre;
                        TipoInterfaz2.FechaModificacion = tipoInterfaz.FechaModificacion;
                        TipoInterfaz2.ModificadoPor = tipoInterfaz.ModificadoPor;
                        
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
        public void EliminarTipoInterfaz(int id, string usuario)
        {
            
            {
                try
                {

                    var obj = _bd.TipoInterfaz.Find(id);
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
        public void CambiarEstadoTipoInterfaz(int id, bool estado, string usuario)
        {
            
            {
                try
                {

                    var obj = _bd.TipoInterfaz.Find(id);

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
