﻿using System;
using System.Collections.Generic;
using System.Text;
using USD.Alphanapsis.Data;

namespace USD.Alphanapsis.Servicios.Repository
{
    public class ProcedenciaRepository
    {
        private readonly ApplicationDbContext _bd;
        NLog.Logger logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        public ProcedenciaRepository(ApplicationDbContext bd)
        {
            _bd = bd;
        }
    }
}
