using System.ComponentModel.DataAnnotations.Schema;

namespace USD.Alphanapsis.Entidades
{
    [Table("HISEquivPaqueteEquipo")]
    public class HISEquivPaqueteEquipo : EntidadBase
    {
        public int HISEquivPaqueteEquipoId { get; set; }

        public string CodigoPruebaHIS { get; set; }

        public int PaqueteId { get; set; }

        public int EquipoId { get; set; }
    }
}
