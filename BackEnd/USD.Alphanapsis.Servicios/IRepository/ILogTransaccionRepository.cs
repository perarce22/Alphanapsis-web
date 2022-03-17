using System;
using System.Collections.Generic;
using System.Text;

namespace USD.Alphanapsis.Servicios.Repository
{
    public interface ILogTransaccionRepository
    {
        void RegisrarLog(string proceso, string resultado, string observacion, string usuario);
    }
}
