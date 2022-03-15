using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace USD.Alphanapsis.Entidades
{
    [Table("Medico")]
    public class Medico : EntidadBase
    {
        public int MedicoId { get; set; }
         
        [MaxLength(20)]
        [Column(TypeName = "NVARCHAR")]
        public string NumeroDocumento { get; set; }


        public int TipoDocumentoId { get; set; }

        [ForeignKey("TipoDocumentoId")]
        public virtual TipoDocumento TipoDocumento { get; set; }


        [MaxLength(20)]
        [Column(TypeName = "NVARCHAR")]
        public string CodigoInterno { get; set; }

        [MaxLength(20)]
        [Column(TypeName = "NVARCHAR")]
        public string NroColegiatura { get; set; }
         
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

        [MaxLength(130)]
        [Column(TypeName = "NVARCHAR")]
        public string Telefono { get; set; }

        [MaxLength(13)]
        [Column(TypeName = "NVARCHAR")]
        public string Celular { get; set; }

        public int Sexo { get; set; }
         
    }
}
