using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD.Alphanapsis.Dto
{
    public class GeoIpDto : EntidadBaseDto
    {
        public int GeoIpId { get; set; }

        [Required]
        public Int64 IPNINI { get; set; }


        [Required]
        public Int64  IPNFIN { get; set; }

        [Required]
       
        [MaxLength(4)]
        public string CC02 { get; set; }

    }
}
