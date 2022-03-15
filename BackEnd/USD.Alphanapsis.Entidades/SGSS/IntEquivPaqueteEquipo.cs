using System.ComponentModel.DataAnnotations.Schema;

namespace USD.Alphanapsis.Entidades
{
    [Table("IntEquivPaqueteEquipo")]
    public class IntEquivPaqueteEquipo : EntidadBase
    {
        public int IntEquivPaqueteEquipoId { get; set; }

        public string CodigoCPS { get; set; }

        public string CodigoMuestra { get; set; }

        public int PaqueteId { get; set; }

        public int EquipoId { get; set; }

        public string AreaHosp { get; set; }
    }
}
