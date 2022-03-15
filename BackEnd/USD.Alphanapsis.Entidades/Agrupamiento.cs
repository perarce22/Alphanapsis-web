using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using USD.Alphanapsis.Entidades.Custom;

namespace USD.Alphanapsis.Entidades
{
    [Table("Agrupamiento")]
    public class Agrupamiento : EntidadBase
    {

        public int AgrupamientoId { get; set; }

        [MaxLength(100)]
        [Column(TypeName = "varchar")]
        public string Nombre { get; set; }

        [MaxLength(60)]
        [Column(TypeName = "varchar")]
        public string Descripcion { get; set; }

        public int? AreaEstudioId { get; set; }

        [ForeignKey("AreaEstudioId")]
        public virtual AreaEstudio AreaEstudio { get; set; }

       

        [MaxLength(20)]
        [Column(TypeName = "varchar")]
        public string Codigo { get; set; }


    }
}
