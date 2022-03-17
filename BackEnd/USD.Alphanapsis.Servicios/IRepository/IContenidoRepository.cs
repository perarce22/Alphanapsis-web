using System;
using System.Collections.Generic;
using System.Text;
using USD.Alphanapsis.Dto;
using USD.Alphanapsis.Dto.Custom;
using USD.Alphanapsis.Entidades;
using USD.Alphanapsis.Entidades.Custom;

namespace USD.Alphanapsis.Servicios.IRepository
{
    public interface IContenidoRepository
    {
        ICollection<Traduccion> ListarTraduccion(string prefijo);
        void GrabarTraduccion(ICollection<ContenidoEstaticoIdioma> contenido, string usuario);
    }
}
