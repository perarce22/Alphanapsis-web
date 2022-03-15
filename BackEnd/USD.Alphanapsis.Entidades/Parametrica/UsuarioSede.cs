using System.ComponentModel.DataAnnotations.Schema;

namespace USD.Alphanapsis.Entidades
{
    [Table("UsuarioSede")]
    public class UsuarioSede : EntidadBase
    {
        public int UsuarioSedeId { get; set; }

        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public virtual Usuario Usuario { get; set; }

        public int CentroSaludOrigenId { get; set; }

        [ForeignKey("CentroSaludOrigenId")]
        public virtual CentroSaludOrigen CentroSaludOrigen { get; set; }

        public int CentroSaludAsistencialId { get; set; }

        [ForeignKey("CentroSaludAsistencialId")]
        public virtual CentroSaludAsistencial CentroSaludAsistencial { get; set; }
    }
}
