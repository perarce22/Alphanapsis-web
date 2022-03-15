using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using USD.Alphanapsis.Dto.Custom;
using USD.Alphanapsis.Entidades.Custom;
using USD.Alphanapsis.Utiles;

namespace USD.Alphanapsis.Dto
{
    public class OrdenDto : EntidadBaseDto
    {
        public int OrdenId { get; set; }
        [MaxLength(100)]
       
        public string Codigo { get; set; }

        public DateTime FechaEmision { get; set; }
        
        public string FechaEmisionStr { get {
                return FechaEmision.ToString("dd/MM/yyyy");
            } }

        public int? MedicoId { get; set; }

        public MedicoDto Medico { get; set; }

        public int PacienteId { get; set; }

        public PacienteDto Paciente { get; set; }

        public int TipoOrdenId { get; set; }

        public TipoOrdenDto TipoOrden { get; set; }

        public List<int> Paquetes { get; set; }

        //[MaxLength(50)]
        //[Column(TypeName = "NVARCHAR")]
        

        public int? EstadoOrdenId { get; set; }
        public string EstadoOrdenStr
        {
            get
            {
                return EstadoOrdenId == null ? "" : Util.GetEnumDescription((EEstadoOrden)(this.EstadoOrdenId));
            }
        }


        [MaxLength(50)]
       
        public string NroHistoriaClinica { get; set; }

        [MaxLength(100)]
       
        public string HISNumero { get; set; }

        public int? CentroSaludOrigenId { get; set; }

        public int? CentroSaludAsistencialId { get; set; }

        public CentroSaludOrigenDto CentroSaludOrigen { get; set; }

        public CentroSaludAsistencialDto CentroSaludAsistencial { get; set; }

        [MaxLength(20)]
       
        public string NroCama { get; set; }

        [MaxLength(500)]
       
        public string Diagnostico { get; set; }

        public int? ServicioSaludId { get; set; }

        public ServicioSaludDto ServicioSalud { get; set; }

        public int? ProcedenciaId { get; set; }

        public ProcedenciaDto Procedencia { get; set; }

        public int? TipoAtencionId { get; set; }
        public int? TipoPacienteId { get; set; }

        public TipoPacienteDto TipoPaciente { get; set; }

        
        public List<OrdenPaqueteDetalleDto> OrdenPaqueteDetalles { get; set; }

        
        public List<ComboDto> ListaPaquetes { get; set; }

        
        public int AreaEstudioId { get; set; }
        
        public int EquipoId { get; set; }
        
        public string NroOrden { get; set; }
    }
}
