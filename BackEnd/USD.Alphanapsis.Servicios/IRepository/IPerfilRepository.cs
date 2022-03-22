using System;
using System.Collections.Generic;
using System.Text;
using USD.Alphanapsis.Dto;
using USD.Alphanapsis.Entidades;

namespace USD.Alphanapsis.Servicios.Repository
{
    public interface IPerfilRepository
    {
        public ICollection<Perfil> ListarPerfil(string filtro, bool? estado, int page, int rows, out int nroTotalRegistros);
        public Perfil ObtenerPerfil(int id);
        public void EliminaPerfil(int id, string usuario);
        public int RegistrarPerfil(Perfil perfil);
        public ICollection<Perfil> ListarPerfil();
        public ICollection<OpcionPerfilDto> ListarPerfilOpciones(int? perfilId, int page, int rows, out int nroTotalRegistros);
        public bool ActualizaOpcionPerfil(OpcionPerfilDto opcionPerfil);
    }
}
