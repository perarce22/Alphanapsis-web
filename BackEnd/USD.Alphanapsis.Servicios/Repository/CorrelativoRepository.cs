using System;
using System.Collections.Generic;
using System.Text;
using USD.Alphanapsis.Data;

namespace USD.Alphanapsis.Servicios.Repository
{
    public class CorrelativoRepository
    {
        private readonly ApplicationDbContext _bd;
        NLog.Logger logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        public CorrelativoRepository(ApplicationDbContext bd)
        {
            _bd = bd;
        }
    }
}
