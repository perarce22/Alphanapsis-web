using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace USD.Alphanapsis.Entidades
{
    [Table("OrdenPaquete")]
    public class OrdenPaquete : EntidadBase
    {
        public int OrdenPaqueteId { get; set; }
        public int OrdenId { get; set; }
        [ForeignKey("OrdenId")]
        public Orden Orden { get; set; }
        public int PaqueteId { get; set; }
        [ForeignKey("PaqueteId")]
        public Paquete Paquete { get; set; }    
        public DateTime? FechaEnvio { get; set; }
        public DateTime? FechaProcesamiento { get; set; }
        public int? EstadoOrdenPaqueteId { get; set; }
        
        public int? EquipoId { get; set; }
        [ForeignKey("EquipoId")]
        public virtual Equipo Equipo { get; set; }        
        [MaxLength(500)]
        [Column(TypeName = "NVARCHAR")]
        public string InformeResultado { get; set; }
        [MaxLength(20)]
        [Column(TypeName = "NVARCHAR")]
        public string NroOrden { get; set; }
        public int? UsuarioApruebaId { get; set; }
        public DateTime? FechaAprobacion { get; set; }
        [MaxLength(100)]
        [Column(TypeName = "NVARCHAR")]
        public string UsuarioInterface { get; set; }
        

    }
}
