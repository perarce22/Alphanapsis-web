using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using USD.Alphanapsis.Entidades.Custom;


namespace USD.Alphanapsis.Entidades
{
    [Table("Orden")]
    public class Orden : EntidadBase
    {
        public int OrdenId { get; set; }
        [MaxLength(100)]
        [Column(TypeName = "NVARCHAR")]
        public string Codigo { get; set; }

        [Column(TypeName = "DATE")]
        public DateTime FechaEmision { get; set; }
        

        public int? MedicoId { get; set; }

        [ForeignKey("MedicoId")]
        public Medico Medico { get; set; }

        public int PacienteId { get; set; }

        [ForeignKey("PacienteId")]
        public Paciente Paciente { get; set; }

        public int TipoOrdenId { get; set; }

        [ForeignKey("TipoOrdenId")]
        public TipoOrden TipoOrden { get; set; }

        //deberia estar en el dto
        //public List<int> Paquetes { get; set; }

        //[MaxLength(50)]
        //[Column(TypeName = "NVARCHAR")]
        

        public int? EstadoOrdenId { get; set; }
        


        [MaxLength(50)]
        [Column(TypeName = "NVARCHAR")]
        public string NroHistoriaClinica { get; set; }

        [MaxLength(100)]
        [Column(TypeName = "NVARCHAR")]
        public string HISNumero { get; set; }

        public int? CentroSaludOrigenId { get; set; }

        public int? CentroSaludAsistencialId { get; set; }

        [ForeignKey("CentroSaludOrigenId")]
        public CentroSaludOrigen CentroSaludOrigen { get; set; }

        [ForeignKey("CentroSaludAsistencialId")]
        public CentroSaludAsistencial CentroSaludAsistencial { get; set; }

        [MaxLength(20)]
        [Column(TypeName = "NVARCHAR")]
        public string NroCama { get; set; }

        [MaxLength(500)]
        [Column(TypeName = "NVARCHAR")]
        public string Diagnostico { get; set; }

        public int? ServicioSaludId { get; set; }

        [ForeignKey("ServicioSaludId")]
        public ServicioSalud ServicioSalud { get; set; }

        public int? ProcedenciaId { get; set; }

        [ForeignKey("ProcedenciaId")]
        public Procedencia Procedencia { get; set; }

        public int? TipoAtencionId { get; set; }
        public int? TipoPacienteId { get; set; }

        [ForeignKey("TipoPacienteId")]
        public TipoPaciente TipoPaciente { get; set; }


        [NotMapped]
        public List<OrdenPaqueteDetalle> OrdenPaqueteDetalles { get; set; }
        [NotMapped]
        public List<int> Paquetes { get; set; }
        [NotMapped]
        public int EquipoId { get; set; }
        [NotMapped]
        public string NroOrden { get; set; }
    }
}
