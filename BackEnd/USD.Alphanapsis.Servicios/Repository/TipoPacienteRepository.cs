﻿using System;
using System.Collections.Generic;
using System.Text;
using USD.Alphanapsis.Data;

namespace USD.Alphanapsis.Servicios.Repository
{
    public class TipoPacienteRepository
    {
        private readonly ApplicationDbContext _bd;
        NLog.Logger logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        public TipoPacienteRepository(ApplicationDbContext bd)
        {
            _bd = bd;
        }
    }
}
