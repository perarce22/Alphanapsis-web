using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using USD.Alphanapsis.Utiles;

namespace USD.Alphanapsis.Dto
{
    public class MedicoDto : EntidadBaseDto
    {
        public int MedicoId { get; set; }
         
        [MaxLength(20)]
       
        public string NumeroDocumento { get; set; }


        public int TipoDocumentoId { get; set; }

        public virtual TipoDocumentoDto TipoDocumento { get; set; }


        [MaxLength(20)]
       
        public string CodigoInterno { get; set; }

        [MaxLength(20)]
       
        public string NroColegiatura { get; set; }
         
        [MaxLength(100)]
       
        public string ApellidoPaterno { get; set; }

        [MaxLength(100)]
       
        public string ApellidoMaterno { get; set; }
         
        [MaxLength(100)]
       
        public string Nombres { get; set; }

        [MaxLength(100)]
       
        public string CorreoElectronico { get; set; }

        [MaxLength(130)]
       
        public string Telefono { get; set; }

        [MaxLength(13)]
       
        public string Celular { get; set; }

        public int Sexo { get; set; }

        public string SexoStr
        {
            get
            {
                return this.Sexo == 0 ? "" : Util.GetEnumDescription((ESexo)(this.Sexo));
            }
        }

        public string NombreCompleto
        {

            get { return string.Format("{0} {1} {2}", this.ApellidoPaterno, this.ApellidoMaterno, this.Nombres); }
        }

        public string NombreCompletoAlt
        {

            get { return string.Format("{2} {0} {1}", this.ApellidoPaterno, this.ApellidoMaterno, this.Nombres); }

        }

        public string Telefonos
        {

            get { return string.Format("{0}/{1}", this.Telefono, this.Celular); }

        }

    }
}
