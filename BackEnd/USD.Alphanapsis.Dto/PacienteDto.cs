using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using USD.Alphanapsis.Utiles;

namespace USD.Alphanapsis.Dto
{
    public class PacienteDto : EntidadBaseDto
    {
        public int PacienteId { get; set; }
        [MaxLength(100)]
       
        public string ApellidoPaterno { get; set; }

        [MaxLength(100)]
       
        public string ApellidoMaterno { get; set; }

        [MaxLength(100)]
       
        public string Nombres { get; set; }
         
        [MaxLength(100)]
       
        public string CorreoElectronico { get; set; }
         
        public DateTime? FechaNacimiento { get; set; }

        public string FechaNacimientoStr
        {
            get
            {
                return FechaNacimiento.HasValue ? FechaNacimiento.Value.ToString("dd/MM/yyyy") : "";
            }
        }

        [MaxLength(100)]
       
        public string Direccion { get; set; }

        [MaxLength(130)]
       
        public string Telefono { get; set; }

        [MaxLength(13)]
       
        public string Celular { get; set; }

        public int? UbigeoId { get; set; }

        public UbigeoDto Ubigeo { get; set; }

        public int? TipoDocumentoId { get; set; }

        public TipoDocumentoDto TipoDocumento { get; set; }

        [MaxLength(50)]
       
        public string NumeroDocumento { get; set; }


        public int Sexo { get; set; }

        [MaxLength(50)]
       
        public string NroAsegurado { get; set; }

        [MaxLength(50)]
       
        public string NroHistoriaClinica { get; set; }

        
        public string SexoStr
        {
            get
            {
                return this.Sexo == 0 ? "" : Util.GetEnumDescription((ESexo)(this.Sexo));
            }
        }
        
        public string Telefonos
        {

            get { return string.Format("{0}/{1}", this.Telefono, this.Celular); }

        }
        
        public string NombreCompleto
        {

            get { return string.Format("{0} {1} {2}", this.ApellidoPaterno, this.ApellidoMaterno, this.Nombres); }
        }

        
        public string NombreCompletoAlt
        {

            get { return string.Format("{2} {0} {1}", this.ApellidoPaterno, this.ApellidoMaterno, this.Nombres); }

        }
        public int? Edad { get; set; }
        public string EdadStr
        {

            get { return Edad != null ? Edad.Value.ToString() : ""; }

        }



        

        public int? TipoAtencionId { get; set; }
    }
}
