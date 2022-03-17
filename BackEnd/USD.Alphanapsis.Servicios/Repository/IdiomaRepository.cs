using System;
using System.Collections.Generic;
using System.Text;
using USD.Alphanapsis.Data;
using USD.Alphanapsis.Entidades;
using System.Linq;
namespace USD.Alphanapsis.Servicios.Repository
{
    public class IdiomaRepository : IIdiomaRepository
    {
        private readonly ApplicationDbContext _bd;
        NLog.Logger logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        public IdiomaRepository(ApplicationDbContext bd)
        {
            _bd = bd;
        }
        public   ICollection<Idioma> ListarIdioma()
        {

            
            {
                try
                {
                    //IRepositorio<Idioma> rep = new EfRepositorio<Idioma>(ctx);
                    var lista = (from a in _bd.Idioma
                                 where a.FlagActivo == true
                                 orderby a.Nombre ascending
                                 select a).ToList();

                    return lista;
                }
                 
                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }
        public   Idioma ObtenerIdioma(string prefijo)
        {

            
            {
                try
                {
                    //IRepositorio<Idioma> rep = new EfRepositorio<Idioma>(ctx);
                    var idioma = (from a in _bd.Idioma
                                  where a.FlagActivo == true
                                  && a.Prefijo.ToUpper() == prefijo.ToUpper()
                                  select a).FirstOrDefault();

                    return idioma;
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
