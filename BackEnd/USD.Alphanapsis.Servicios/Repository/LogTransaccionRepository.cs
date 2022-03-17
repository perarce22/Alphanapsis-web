using System;
using System.Collections.Generic;
using System.Text;
using USD.Alphanapsis.Data;
using USD.Alphanapsis.Entidades;

namespace USD.Alphanapsis.Servicios.Repository
{
    public class LogTransaccionRepository : ILogTransaccionRepository
    {
        private readonly ApplicationDbContext _bd;
        NLog.Logger logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        public LogTransaccionRepository(ApplicationDbContext bd)
        {
            _bd = bd;
        }
        public   void RegisrarLog(string proceso, string resultado, string observacion, string usuario)
        {
             
            {
                try
                {
                    //IRepositorio<LogTransaccion> rep = new EfRepositorio<LogTransaccion>(ctx);
                    var log = new LogTransaccion()
                    {
                        Proceso = proceso,
                        Resultado = resultado,
                        Observacion = observacion,
                        CreadoPor = usuario,
                        FechaCreacion = DateTime.Now,
                        FlagActivo = true,
                        FlagEliminado = false
                    };

                    _bd.LogTransaccion.Add (log);
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
