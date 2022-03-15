using System.ComponentModel.DataAnnotations.Schema;

namespace USD.Alphanapsis.Dto
{
    public class UsuarioSedeDto : EntidadBaseDto
    {
        public int UsuarioSedeId { get; set; }

        public int UsuarioId { get; set; }

        public virtual UsuarioDto Usuario { get; set; }

        public int CentroSaludOrigenId { get; set; }

        public virtual CentroSaludOrigenDto CentroSaludOrigen { get; set; }

        public int CentroSaludAsistencialId { get; set; }

        public virtual CentroSaludAsistencialDto CentroSaludAsistencial { get; set; }
    }
}
