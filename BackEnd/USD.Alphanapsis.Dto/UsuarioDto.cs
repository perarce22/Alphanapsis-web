using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace USD.Alphanapsis.Dto
{
    public  class UsuarioDto : EntidadBaseDto
    {
        public int UsuarioId { get; set; }

        //[MaxLength(50)]
       
        //public string Password { get; set; }

        [Required]
        [MaxLength(100)]
       
        public string ApellidoPaterno { get; set; }

        [MaxLength(100)]
       
        public string ApellidoMaterno { get; set; }

        [Required]
        [MaxLength(100)]
       
        public string Nombres { get; set; }

        [Required]
        [MaxLength(100)]
       
        public string CorreoElectronico { get; set; }

        [Required]
        [MaxLength(40)]
       
        public string Username { get; set; }        
        public int? EspecialidadId { get; set; }
        public virtual EspecialidadDto Especialidad { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public DateTime? FechaCese { get; set; }
        [MaxLength(20)]
       
        public string NumeroDocumento { get; set; }


        public int? TipoDocumentoId { get; set; }

        public virtual TipoDocumentoDto TipoDocumento { get; set; }

        [MaxLength(20)]
       
        public string CodigoInterno { get; set; }

        public int? TipoAtencionId { get; set; }

        public string FechaIngresoStr
        {
            get { return this.FechaIngreso.HasValue ? this.FechaIngreso.Value.ToString("dd/MM/yyyy") : ""; }
        }
        public string FechaCeseStr
        {
            get { return this.FechaCese.HasValue ? this.FechaCese.Value.ToString("dd/MM/yyyy") : ""; }
        }

        
        public List<PerfilDto> ListaPerfiles { get; set; }
      
        
        public List<int> ListaIdsPerfiles { get; set; }

         
        
        public string NombreCompleto
        {

            get { return string.Format("{0} {1}, {2}", this.ApellidoPaterno, this.ApellidoMaterno, this.Nombres); }
        }

        
        public string NombreCompletoAlt
        {

            get { return string.Format("{2} {0} {1}", this.ApellidoPaterno, this.ApellidoMaterno, this.Nombres); }

        }

        
        public int CentroSaludOrigenId { get; set; }

        
        public int CentroSaludAsistencialId { get; set; }

        
        public string Sedes { get; set; }
        
        public string Url { get; set; }
    }
}
