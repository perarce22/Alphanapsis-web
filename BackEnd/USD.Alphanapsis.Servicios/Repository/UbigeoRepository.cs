using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USD.Alphanapsis.Data;
using USD.Alphanapsis.Entidades;

namespace USD.Alphanapsis.Servicios.Repository
{
    public class UbigeoRepository : IUbigeoRepository
    {
        private readonly ApplicationDbContext _bd;
        NLog.Logger logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        public UbigeoRepository(ApplicationDbContext bd)
        {
            _bd = bd;
        }

        public   Ubigeo ObtenerUbigeo(string codigo)
        {
            try
            {
                 
                {
                    return _bd.Ubigeo.FirstOrDefault(o => o.Codigo == codigo);
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
