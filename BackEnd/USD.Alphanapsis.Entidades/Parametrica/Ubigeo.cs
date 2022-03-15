using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD.Alphanapsis.Entidades
{
    [Table("Ubigeo")]
    public class Ubigeo : EntidadBase
    {
        public int UbigeoId { get; set; }
        [MaxLength(6)]
        [Column(TypeName = "NVARCHAR")]
        public string Codigo { get; set; }
        [MaxLength(2)]
        [Column(TypeName = "NVARCHAR")]
        public string DepartamentoId { get; set; }
        [MaxLength(50)]
        [Column(TypeName = "NVARCHAR")]
        public string Departamento { get; set; }
        [MaxLength(2)]
        [Column(TypeName = "NVARCHAR")]
        public string ProvinciaId { get; set; }
        [MaxLength(50)]
        [Column(TypeName = "NVARCHAR")]
        public string Provincia { get; set; }
        [MaxLength(2)]
        [Column(TypeName = "NVARCHAR")]
        public string DistritoId { get; set; }
        [MaxLength(50)]
        [Column(TypeName = "NVARCHAR")]
        public string Distrito { get; set; }

       



    }
}
