using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace USD.Alphanapsis.Entidades
{
    [Table("Notificacion")]
    public class Notificacion : EntidadBase
    {
        public int NotificacionId { get; set; }

        [Required]
        public int TipoNotificacionId { get; set; }

        public DateTime? FechaEnvio { get; set; }
        

        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(250)]
        public string FROM { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(250)]
        public string TO { get; set; }


        [Column(TypeName = "VARCHAR")]
        [MaxLength(250)]
        public string CC { get; set; }

        [Column(TypeName = "VARCHAR")]
        [MaxLength(250)]
        public string BCC { get; set; }


        [Required]
        public string BODY { get; set; }

        [Required]
        [MaxLength(250)]
        public string SUBJECT { get; set; }
        public string ADJUNTO { get; set; }
        public string DIRECTORIO { get; set; }
        public int? IdAsociado { get; set; }
       
    }
}
