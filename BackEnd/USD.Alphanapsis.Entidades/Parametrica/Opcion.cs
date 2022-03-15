using System.ComponentModel.DataAnnotations.Schema;

namespace USD.Alphanapsis.Entidades
{
    [Table("Opcion")]
    public class Opcion : EntidadBase
    {
        public int OpcionId { get; set; }
        public string Etiqueta { get; set; }
        public string Url { get; set; }
        public int? ParentId { get; set; }
        public int? Orden { get; set; }
        public string Icono { get; set; }

       
    }
}
