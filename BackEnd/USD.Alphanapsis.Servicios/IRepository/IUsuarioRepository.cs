using System;
using System.Collections.Generic;
using System.Text;
using USD.Alphanapsis.Dto;

namespace USD.Alphanapsis.Servicios.IRepository
{
    public interface IUsuarioRepository
    {
        ICollection<UsuarioDto> GetUsuarios();
        UsuarioDto AutenticarUsuario(string username, string password);
        UsuarioSedeDto ExisteUsuarioSede(int userId, int centroSedeId);
    }
}
