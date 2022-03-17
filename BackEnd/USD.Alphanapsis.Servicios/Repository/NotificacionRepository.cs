using System;
using System.Collections.Generic;
using System.Text;
using USD.Alphanapsis.Data;
using USD.Alphanapsis.Entidades;
using System.Linq;
namespace USD.Alphanapsis.Servicios.Repository
{
    public class NotificacionRepository : INotificacionRepository
    {
        private readonly ApplicationDbContext _bd;
        NLog.Logger logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        public NotificacionRepository(ApplicationDbContext bd)
        {
            _bd = bd;
        }

        public ICollection<Notificacion> ListarNotificacionPendiente()
        {

            
            {
                try
                {
                    //IRepositorio<Notificacion> rep = new EfRepositorio<Notificacion>(ctx);
                    var lista = (from a in _bd.Notificacion
                                 where a.FlagActivo == false
                                 && a.FlagEliminado == false
                                 && a.FechaEnvio == null
                                 orderby a.FechaCreacion ascending
                                 select new
                                 {
                                     a.ADJUNTO,
                                     a.BCC,
                                     a.BODY,
                                     a.CC,
                                     a.CreadoPor,
                                     a.DIRECTORIO,
                                     a.FechaCreacion,
                                     a.FechaEnvio,
                                     a.FechaModificacion,
                                     a.FlagActivo,
                                     a.FlagEliminado,
                                     a.FROM,
                                     a.IdAsociado,
                                     a.ModificadoPor,
                                     a.NotificacionId,
                                     a.SUBJECT,
                                     a.TipoNotificacionId,
                                     a.TO,
                                 });
                    var listaFinal = (from a in lista.ToList()
                                      select new Notificacion
                                      {
                                          ADJUNTO = a.ADJUNTO,
                                          BCC = a.BCC,
                                          BODY = a.BODY,
                                          CC = a.CC,
                                          CreadoPor = a.CreadoPor,
                                          DIRECTORIO = a.DIRECTORIO,
                                          FechaCreacion = a.FechaCreacion,
                                          FechaEnvio = a.FechaEnvio,
                                          FechaModificacion = a.FechaModificacion,
                                          FlagActivo = a.FlagActivo,
                                          FlagEliminado = a.FlagEliminado,
                                          FROM = a.FROM,
                                          IdAsociado = a.IdAsociado,
                                          ModificadoPor = a.ModificadoPor,
                                          NotificacionId = a.NotificacionId,
                                          SUBJECT = a.SUBJECT,
                                          TipoNotificacionId = a.TipoNotificacionId,
                                          TO = a.TO,
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

        public ICollection<Notificacion> ListarNotificacion(string filtro, bool? estado, int page, int rows, out int nroTotalRegistros)
        {

            
            {
                try
                {
                    //IRepositorio<Notificacion> rep = new EfRepositorio<Notificacion>(ctx);
                    var lista = (from a in _bd.Notificacion
                                 where (a.FlagActivo == estado || !estado.HasValue)
                                 && a.FlagEliminado == false
                                 orderby a.FechaCreacion ascending
                                 select new
                                 {
                                     a.ADJUNTO,
                                     a.BCC,
                                     a.BODY,
                                     a.CC,
                                     a.CreadoPor,
                                     a.DIRECTORIO,
                                     a.FechaCreacion,
                                     a.FechaEnvio,
                                     a.FechaModificacion,
                                     a.FlagActivo,
                                     a.FlagEliminado,
                                     a.FROM,
                                     a.IdAsociado,
                                     a.ModificadoPor,
                                     a.NotificacionId,
                                     a.SUBJECT,
                                     a.TipoNotificacionId,
                                     a.TO,
                                 });
                    nroTotalRegistros = lista.Count();
                    lista = lista.Skip((page - 1) * rows).Take(rows);
                    var listaFinal = (from a in lista.ToList()
                                      select new Notificacion
                                      {
                                          ADJUNTO = a.ADJUNTO,
                                          BCC = a.BCC,
                                          BODY = a.BODY,
                                          CC = a.CC,
                                          CreadoPor = a.CreadoPor,
                                          DIRECTORIO = a.DIRECTORIO,
                                          FechaCreacion = a.FechaCreacion,
                                          FechaEnvio = a.FechaEnvio,
                                          FechaModificacion = a.FechaModificacion,
                                          FlagActivo = a.FlagActivo,
                                          FlagEliminado = a.FlagEliminado,
                                          FROM = a.FROM,
                                          IdAsociado = a.IdAsociado,
                                          ModificadoPor = a.ModificadoPor,
                                          NotificacionId = a.NotificacionId,
                                          SUBJECT = a.SUBJECT,
                                          TipoNotificacionId = a.TipoNotificacionId,
                                          TO = a.TO,
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

        public  Notificacion ObtenerNotificacion(int id)
        {
            try
            { 
                {
                    //IRepositorio<Notificacion> rep = new EfRepositorio<Notificacion>(ctx); 
                    return _bd.Notificacion.Find(id);
                }
            } 
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }
        }

        public  void NotificacionEnviada(int id)
        {
            try
            {
                
                { 
                    var not = _bd.Notificacion.Find(id);
                    not.FlagActivo = true;
                    not.FechaModificacion = DateTime.Now;
                    not.ModificadoPor = "AUTO";
                    not.FechaEnvio = DateTime.Now;
                    _bd.SaveChanges();
                }
            } 
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }
        }

        public  void EliminaNotificacion(int id, bool estado, string usuario)
        {
            
            {
                try
                { 
                    var obj = _bd.Notificacion.Find(id);
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

        public  int RegistrarNotificacion(Notificacion notificacion)
        {
            
            {
                try
                {
                    _bd.Notificacion.Add(notificacion);
                    _bd.SaveChanges();
                    return notificacion.NotificacionId;
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
