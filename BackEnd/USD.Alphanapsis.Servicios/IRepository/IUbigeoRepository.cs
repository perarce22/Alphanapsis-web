using System;
using System.Collections.Generic;
using System.Text;
using USD.Alphanapsis.Entidades;

namespace USD.Alphanapsis.Servicios.Repository
{
    public interface IUbigeoRepository
    {
        public Ubigeo ObtenerUbigeo(string codigo);
    }
}
