using System.ComponentModel.DataAnnotations.Schema;

namespace USD.Alphanapsis.Dto
{
    public class OrdenPaqueteTramasDto : EntidadBaseDto
    {
        public int OrdenPaqueteTramasId { get; set; }
        public int OrdenId { get; set; }
        public OrdenDto Orden { get; set; }
        public int OrdenPaqueteId { get; set; }
        public OrdenPaqueteDto OrdenPaquete { get; set; }
        public string TramaEnvio { get; set; }

        public string TramaResultado { get; set; }
    }
}
