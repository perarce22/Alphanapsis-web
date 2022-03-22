using System;
using System.Collections.Generic;
using System.Text;
using USD.Alphanapsis.Data;
using USD.Alphanapsis.Entidades;
using System.Linq;
namespace USD.Alphanapsis.Servicios.Repository
{
    public class TipoDocumentoRepository : ITipoDocumentoRepository
    {
        private readonly ApplicationDbContext _bd;
        NLog.Logger logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        public TipoDocumentoRepository(ApplicationDbContext bd)
        {
            _bd = bd;
        }

        public ICollection<TipoDocumento> ListarTipoDocumento(string filtro, bool? estado, int page, int rows, out int nroTotalRegistros)
        {
            
            {
                try
                {
                    var lista = (from a in _bd.TipoDocumento
                                 where (a.FlagActivo == estado || !estado.HasValue)
                                 && (string.IsNullOrEmpty(filtro) || a.Nombre.Contains(filtro.ToUpper()))
                                 && a.FlagEliminado == false
                                 orderby a.Nombre ascending
                                 select new
                                 {
                                     a.TipoDocumentoId,
                                     a.Nombre,
                                     a.CreadoPor,
                                     a.FechaCreacion,
                                     a.ModificadoPor,
                                     a.FechaModificacion,
                                     a.Longitud,
                                     a.FlagActivo
                                 });
                    nroTotalRegistros = lista.Count();

                    lista = lista.Skip((page - 1) * rows).Take(rows);

                    var listaFinal = (from a in lista.ToList()
                                      select new TipoDocumento
                                      {
                                          TipoDocumentoId = a.TipoDocumentoId,
                                          Nombre = a.Nombre,
                                          CreadoPor = a.CreadoPor,
                                          FechaCreacion = a.FechaCreacion,
                                          ModificadoPor = a.ModificadoPor,
                                          FechaModificacion = a.FechaModificacion,
                                          Longitud = a.Longitud,
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

        public TipoDocumento ObtenerTipoDocumento(int id)
        {
            try
            {
                
                {
                    //IRepositorio<TipoDocumento> rep = new EfRepositorio<TipoDocumento>(ctx);
                    return _bd.TipoDocumento.Find(id);
                }
            }
           
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }
        }

        public void EliminaTipoDocumento(int id, string usuario)
        {
            
            {
                try
                {
                    //IRepositorio<TipoDocumento> rep = new EfRepositorio<TipoDocumento>(ctx); 
                    var obj = _bd.TipoDocumento.Find(id);
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

        public int RegistrarTipoDocumento(TipoDocumento entidad)
        {
            
            {
                try
                {
                     
                    if (entidad.TipoDocumentoId == 0)
                    {
                        _bd.TipoDocumento.Add(entidad);
                        _bd.SaveChanges();
                        return entidad.TipoDocumentoId;
                    }
                    else
                    {
                        var act = _bd.TipoDocumento.FirstOrDefault(m => m.TipoDocumentoId == entidad.TipoDocumentoId);
                        act.Nombre = entidad.Nombre;
                        act.TipoDocumentoId = entidad.TipoDocumentoId;
                        act.Longitud = entidad.Longitud;
                        _bd.SaveChanges();
                        return act.TipoDocumentoId;
                    }
                }
               
                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }

        public ICollection<TipoDocumento> ListarTipoDocumento()
        {

            
            {
                try
                {
                    //IRepositorio<TipoDocumento> rep = new EfRepositorio<TipoDocumento>(ctx);
                    var lista = (from a in _bd.TipoDocumento
                                 where (a.FlagActivo == true)
                                 && a.FlagEliminado == false
                                 orderby a.Nombre ascending
                                 select new
                                 {
                                     a.Nombre,
                                     a.TipoDocumentoId,
                                     a.FlagActivo,
                                     a.Longitud
                                 });

                    var listaFinal = (from a in lista.ToList()
                                      select new TipoDocumento
                                      {
                                          Nombre = a.Nombre,
                                          TipoDocumentoId = a.TipoDocumentoId,
                                          FlagActivo = a.FlagActivo,
                                          Longitud = a.Longitud
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

        public TipoDocumento ObtenerTipoDocumento(string codigoHIS)
        {
            try
            {
                
                {
                    //IRepositorio<TipoDocumento> rep = new EfRepositorio<TipoDocumento>(ctx);
                    return _bd.TipoDocumento.FirstOrDefault(o => o.CodigoHIS == codigoHIS);
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
