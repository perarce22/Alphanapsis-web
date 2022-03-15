using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace USD.Alphanapsis.Entidades
{
    [Table("Usuario")]
    public  class Usuario : EntidadBase
    {
        public int UsuarioId { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "NVARCHAR")]
        public string Password { get; set; }

        [Required]
        [MaxLength(100)]
        [Column(TypeName = "NVARCHAR")]
        public string ApellidoPaterno { get; set; }

        [MaxLength(100)]
        [Column(TypeName = "NVARCHAR")]
        public string ApellidoMaterno { get; set; }

        [Required]
        [MaxLength(100)]
        [Column(TypeName = "NVARCHAR")]
        public string Nombres { get; set; }

        [Required]
        [MaxLength(100)]
        [Column(TypeName = "NVARCHAR")]
        public string CorreoElectronico { get; set; }

        [Required]
        [MaxLength(40)]
        [Column(TypeName = "NVARCHAR")]
        public string Username { get; set; }        
        public int? EspecialidadId { get; set; }
        [ForeignKey("EspecialidadId")]
        public virtual Especialidad Especialidad { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public DateTime? FechaCese { get; set; }
        [MaxLength(20)]
        [Column(TypeName = "NVARCHAR")]
        public string NumeroDocumento { get; set; }


        public int? TipoDocumentoId { get; set; }

        [ForeignKey("TipoDocumentoId")]
        public virtual TipoDocumento TipoDocumento { get; set; }

        [MaxLength(20)]
        [Column(TypeName = "NVARCHAR")]
        public string CodigoInterno { get; set; }

        public int? TipoAtencionId { get; set; }

        //public string FechaIngresoStr
        //{
        //    get { return this.FechaIngreso.HasValue ? this.FechaIngreso.Value.ToString("dd/MM/yyyy") : ""; }
        //}
        //public string FechaCeseStr
        //{
        //    get { return this.FechaCese.HasValue ? this.FechaCese.Value.ToString("dd/MM/yyyy") : ""; }
        //}

       
    }
}
