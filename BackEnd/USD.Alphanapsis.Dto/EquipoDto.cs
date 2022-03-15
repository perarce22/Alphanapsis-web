using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using USD.Alphanapsis.Dto.Custom;
using USD.Alphanapsis.Entidades.Custom;

namespace USD.Alphanapsis.Dto
{
    public  class EquipoDto : EntidadBaseDto
    {
        public int EquipoId { get; set; }
        [MaxLength(100)]
       
        public string Nombre { get; set; }
        [MaxLength(100)]
       
        public string Marca { get; set; }
        [MaxLength(100)]
       
        public string Modelo { get; set; }
        [MaxLength(100)]
       
        public string Serie { get; set; }

        [MaxLength(100)]
       
        public string CodUnico { get; set; }

        public int? AreaEstudioId { get; set; }

        public virtual AreaEstudioDto AreaEstudio { get; set; }

        public int? TipoInterfazId { get; set; }

        public int? TipoBarcodeId { get; set; }

        public virtual TipoInterfazDto TipoInterfaz { get; set; }

        public bool? MatchAutomatico { get; set; }
        
        public int? MatchAutomaticoId { get; set; }
        //[MaxLength(100)]
        //[Column(TypeName = "NVARCHAR")]
        //public string PuertoCom { get; set; }
        //[MaxLength(100)]
        //[Column(TypeName = "NVARCHAR")]
        //public string BitsDatos { get; set; }
        //[MaxLength(100)]
        //[Column(TypeName = "NVARCHAR")]
        //public string BitsParada { get; set; }
        //[MaxLength(100)]
        //[Column(TypeName = "NVARCHAR")]
        //public string BitsSegundo { get; set; }
        //[MaxLength(100)]
        //[Column(TypeName = "NVARCHAR")]
        //public string Paridad { get; set; }
        //[MaxLength(100)]
        //[Column(TypeName = "NVARCHAR")]
        //public string ControlFlujo { get; set; }

        
        public List<int> PaquetesIds { get; set; }

        
        public List<ComboDto> Paquetes { get; set; }

        
        public List<ParametroDto> Parametros { get; set; }


    }
}
