using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD.Alphanapsis.Entidades
{
    [Table("CentroSaludAsistencial")]
    public class CentroSaludAsistencial : EntidadBase
    {
        public int CentroSaludAsistencialId { get; set; }

        public int CentroSaludOrigenId { get; set; }
        [ForeignKey("CentroSaludOrigenId")]
        public CentroSaludOrigen CentroSaludOrigen { get; set; }

        [MaxLength(500)]
        [Column(TypeName = "varchar")]
        public string Nombre { get; set; }

        [MaxLength(10)]
        [Column(TypeName = "varchar")]
        public string CodigoInterno { get; set; }
    }
}
