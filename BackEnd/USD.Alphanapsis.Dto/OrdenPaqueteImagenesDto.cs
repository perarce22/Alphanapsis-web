using System.ComponentModel.DataAnnotations.Schema;

namespace USD.Alphanapsis.Dto
{
    public class OrdenPaqueteImagenesDto : EntidadBaseDto
    {
        public int OrdenPaqueteImagenesId { get; set; }
        public int OrdenId { get; set; }
        public OrdenDto Orden { get; set; }
        public int OrdenPaqueteId { get; set; }
        public OrdenPaqueteDto OrdenPaquete { get; set; }
        public byte[] RBCHistograma { get; set; }
        public byte[] PLTHistograma { get; set; }
        public byte[] WBCHistograma { get; set; }
        public byte[] S0Histograma { get; set; }
        public byte[] S10DIFFScattergram { get; set; }
        public byte[] S90DDIFFScattergram { get; set; }
    }
}
