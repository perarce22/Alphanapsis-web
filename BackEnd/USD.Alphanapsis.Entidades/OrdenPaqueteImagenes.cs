using System.ComponentModel.DataAnnotations.Schema;

namespace USD.Alphanapsis.Entidades
{
    [Table("OrdenPaqueteImagenes")]
    public class OrdenPaqueteImagenes : EntidadBase
    {
        public int OrdenPaqueteImagenesId { get; set; }
        public int OrdenId { get; set; }
        [ForeignKey("OrdenId")]
        public Orden Orden { get; set; }
        public int OrdenPaqueteId { get; set; }
        [ForeignKey("OrdenPaqueteId")]
        public OrdenPaquete OrdenPaquete { get; set; }
        [Column(TypeName = "image")]
        public byte[] RBCHistograma { get; set; }
        [Column(TypeName = "image")]
        public byte[] PLTHistograma { get; set; }
        [Column(TypeName = "image")]
        public byte[] WBCHistograma { get; set; }
        [Column(TypeName = "image")]
        public byte[] S0Histograma { get; set; }
        [Column(TypeName = "image")]
        public byte[] S10DIFFScattergram { get; set; }
        [Column(TypeName = "image")]
        public byte[] S90DDIFFScattergram { get; set; }
    }
}
