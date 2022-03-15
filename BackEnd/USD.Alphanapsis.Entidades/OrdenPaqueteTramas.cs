using System.ComponentModel.DataAnnotations.Schema;

namespace USD.Alphanapsis.Entidades
{
    [Table("OrdenPaqueteTramas")]
    public class OrdenPaqueteTramas : EntidadBase
    {
        public int OrdenPaqueteTramasId { get; set; }
        public int OrdenId { get; set; }
        [ForeignKey("OrdenId")]
        public Orden Orden { get; set; }
        public int OrdenPaqueteId { get; set; }
        [ForeignKey("OrdenPaqueteId")]
        public OrdenPaquete OrdenPaquete { get; set; }
        public string TramaEnvio { get; set; }

        public string TramaResultado { get; set; }
    }
}
