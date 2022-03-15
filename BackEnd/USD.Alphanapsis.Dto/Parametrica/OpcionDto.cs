using System.ComponentModel.DataAnnotations.Schema;

namespace USD.Alphanapsis.Dto
{
    public class OpcionDto : EntidadBaseDto
    {
        public int OpcionId { get; set; }
        public string Etiqueta { get; set; }
        public string Url { get; set; }
        public int? ParentId { get; set; }
        public int? Orden { get; set; }
        public string Icono { get; set; }

        
        public bool Flag { get; set; }
        
        public string Parent { get; set; }
    }
}
