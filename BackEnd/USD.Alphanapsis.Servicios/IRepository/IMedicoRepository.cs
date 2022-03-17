using System;
using System.Collections.Generic;
using System.Text;
using USD.Alphanapsis.Entidades;

namespace USD.Alphanapsis.Servicios.Repository
{
    public interface IMedicoRepository
    {
        ICollection<Medico> ListarMedico(string filtro, bool? estado, int page, int rows, out int nroTotalRegistros);
        ICollection<Medico> BuscarMedico(string filtro);
        Medico ObtenerMedico(int id);
        Medico ObtenerMedico(string nroDocumento);
        void EliminaMedico(int id, string usuario);
        int RegistrarMedico(Medico medico);

    }
}
