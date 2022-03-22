using System;
using System.Collections.Generic;
using System.Text;
using USD.Alphanapsis.Entidades;

namespace USD.Alphanapsis.Servicios.Repository
{
    public interface ITipoPacienteRepository
    {
        public ICollection<TipoPaciente> ListarTipoPaciente(string filtro, bool? estado, int page, int rows, out int nroTotalRegistros);
        public TipoPaciente ObtenerTipoPaciente(int id);
        public void EliminaTipoPaciente(int id, string usuario);
        public int RegistrarTipoPaciente(TipoPaciente entidad);
        public ICollection<TipoPaciente> ListarTipoPaciente();
        public TipoPaciente ObtenerTipoPaciente(string codigoHIS);
    }
}
