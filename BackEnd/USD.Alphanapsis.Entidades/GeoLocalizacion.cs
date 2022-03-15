using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD.Alphanapsis.Entidades
{
    [Table("GeoIp")]
    public class GeoIp : EntidadBase
    {
        public int GeoIpId { get; set; }

        [Required]
        [Column(TypeName = "BIGINT")]
        public Int64 IPNINI { get; set; }


        [Required]
        [Column(TypeName = "BIGINT")]
        public Int64  IPNFIN { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR")]
        [MaxLength(4)]
        public string CC02 { get; set; }

    }
}
