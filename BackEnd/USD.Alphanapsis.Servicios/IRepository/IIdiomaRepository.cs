using System;
using System.Collections.Generic;
using System.Text;
using USD.Alphanapsis.Entidades;

namespace USD.Alphanapsis.Servicios.Repository
{
    public interface IIdiomaRepository
    {
        ICollection<Idioma> ListarIdioma();
        Idioma ObtenerIdioma(string prefijo);
    }
}
