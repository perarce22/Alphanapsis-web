using System;
using System.Collections.Generic;
using System.Text;
using USD.Alphanapsis.Dto;
using USD.Alphanapsis.Entidades;

namespace USD.Alphanapsis.Servicios.IRepository
{
    public interface IUsuarioRepository
    {
        ICollection<UsuarioDto> GetUsuarios();
        UsuarioDto AutenticarUsuario(string username, string password);
        UsuarioSedeDto ExisteUsuarioSede(int userId, int centroSedeId);
        public ICollection<Usuario> ListarUsuario(string filtro, bool? estado, int page, int rows, out int nroTotalRegistros);
        public Usuario ObtenerUsuario(int id);
        public void EliminaUsuario(int id, string usuario);
        public int RegistrarUsuario(UsuarioDto usuario);
        public void CambiarContrasena(int id, string password, string usuario);
        public ICollection<Opcion> ListarOpciones(int usuarioId, string prefijo);
        public void RegistrarOpcionUsuario(List<int> listaOpciones, int usuarioId, string usuarioActual);
        public ICollection<OpcionUsuario> ListarOpcionesUsuario(int usuarioId, out int nroTotalRegistros);
        public ICollection<UsuarioSede> ObtenerUsuarioSede(int userId, int centroSedeId);
        public bool UpdateEstado(int userId);
        public bool ActualizaUsuarioSede(int userId, int centroSedeId, string creadoPor);
        public mvBPAccess ValidationBP(string userName, string userPassw);
        public mvBPPatient GetPatient(int bpId, int ordenId);
    }
}
