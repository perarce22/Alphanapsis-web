using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace USD.Alphanapsis.Entidades
{
    [Table("Paciente")]
    public class Paciente : EntidadBase
    {
        public int PacienteId { get; set; }
        [MaxLength(100)]
        [Column(TypeName = "NVARCHAR")]
        public string ApellidoPaterno { get; set; }

        [MaxLength(100)]
        [Column(TypeName = "NVARCHAR")]
        public string ApellidoMaterno { get; set; }

        [MaxLength(100)]
        [Column(TypeName = "NVARCHAR")]
        public string Nombres { get; set; }
         
        [MaxLength(100)]
        [Column(TypeName = "NVARCHAR")]
        public string CorreoElectronico { get; set; }
         
        [Column(TypeName = "DATE")]
        public DateTime? FechaNacimiento { get; set; }

        

        [MaxLength(100)]
        [Column(TypeName = "NVARCHAR")]
        public string Direccion { get; set; }

        [MaxLength(130)]
        [Column(TypeName = "NVARCHAR")]
        public string Telefono { get; set; }

        [MaxLength(13)]
        [Column(TypeName = "NVARCHAR")]
        public string Celular { get; set; }

        public int? UbigeoId { get; set; }

        [ForeignKey("UbigeoId")]
        public Ubigeo Ubigeo { get; set; }

        public int? TipoDocumentoId { get; set; }

        [ForeignKey("TipoDocumentoId")]
        public TipoDocumento TipoDocumento { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "NVARCHAR")]
        public string NumeroDocumento { get; set; }


        public int Sexo { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "NVARCHAR")]
        public string NroAsegurado { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "NVARCHAR")]
        public string NroHistoriaClinica { get; set; }

         
        public int? Edad { get; set; }
        public string EdadStr
        {

            get { return Edad != null ? Edad.Value.ToString() : ""; }

        }



        
    }
}
