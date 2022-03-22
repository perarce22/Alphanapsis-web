using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using USD.Alphanapsis.Data;
using USD.Alphanapsis.Dto;

namespace USD.Alphanapsis.Servicios.Repository
{
    public class ReportesRepository
    {
        private readonly ApplicationDbContext _bd;
        NLog.Logger logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        public ReportesRepository(ApplicationDbContext bd)
        {
            _bd = bd;
        }
       
    }
}
