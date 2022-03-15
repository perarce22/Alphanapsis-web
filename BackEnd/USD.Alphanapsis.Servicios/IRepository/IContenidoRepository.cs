using System;
using System.Collections.Generic;
using System.Text;
using USD.Alphanapsis.Dto.Custom;

namespace USD.Alphanapsis.Servicios.IRepository
{
    public interface IContenidoRepository
    {
        ICollection<TraduccionDto> ListarTraduccion(string prefijo);
    }
}
