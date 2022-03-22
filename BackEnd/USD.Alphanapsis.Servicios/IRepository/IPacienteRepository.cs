using System;
using System.Collections.Generic;
using System.Text;
using USD.Alphanapsis.Dto;
using USD.Alphanapsis.Entidades;

namespace USD.Alphanapsis.Servicios.Repository
{
    public interface IPacienteRepository
    {
        public ICollection<Paciente> ListarPaciente(string filtro, bool? estado, int page, int rows, out int nroTotalRegistros);
        public ICollection<Paciente> ListarBuscar(string filtro);
        public Paciente PacienteBuscar(string dni);
        public Paciente ObtenerPaciente(int id);
        public void EliminaPaciente(int id, string usuario);
        public int RegistrarPaciente(Paciente paciente);
        public Paciente ObtenerPaciente(string nroAseg, string nroHistClinica);
        public PacienteDto obtenerPacientexOrden(int ordenId);
    }
}
