using System.ComponentModel.DataAnnotations.Schema;

namespace USD.Alphanapsis.Entidades
{
    [Table("HISEquivPaqueteServicio")]
    public class HISEquivPaqueteServicio : EntidadBase
    {
        public int HISEquivPaqueteServicioId { get; set; }

        public string CodigoPruebaHIS { get; set; }

        public int PaqueteId { get; set; }

        public int ServicioId { get; set; }
    }
}
