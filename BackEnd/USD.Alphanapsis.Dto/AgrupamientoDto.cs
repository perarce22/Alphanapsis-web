using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using USD.Alphanapsis.Dto.Custom;
using USD.Alphanapsis.Entidades.Custom;

namespace USD.Alphanapsis.Dto
{
    public class AgrupamientoDto : EntidadBaseDto
    {

        public int AgrupamientoId { get; set; }

        [MaxLength(100)]
        
        public string Nombre { get; set; }

        [MaxLength(60)]
        
        public string Descripcion { get; set; }

        public int? AreaEstudioId { get; set; }

        public virtual AreaEstudioDto AreaEstudio { get; set; }

        
        public List<int> ServiciosIds { get; set; }

        
        public List<ComboDto> Servicios { get; set; }

        [MaxLength(20)]
        
        public string Codigo { get; set; }


    }
}
