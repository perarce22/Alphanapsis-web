using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USD.Alphanapsis.Utiles;

namespace USD.Alphanapsis.Dto
{
    public class NotificacionDto : EntidadBaseDto
    {
        public int NotificacionId { get; set; }

        [Required]
        public int TipoNotificacionId { get; set; }

        public DateTime? FechaEnvio { get; set; }
        
        public string FechaEnvioStr
        {
            get
            {
                return FechaEnvio == null ? "" : Convert.ToDateTime(FechaEnvio).ToString("dd/MM/yyyy");
            }
        }
        
        public string FechaEnvioHHMMSSStr
        {
            get
            {
                return FechaEnvio == null ? "" : string.Format("{0:dd/MM/yyyy HH:mm:ss}", FechaEnvio);
            }
        }

        [Required]
        
        [MaxLength(250)]
        public string FROM { get; set; }

        [Required]
        
        [MaxLength(250)]
        public string TO { get; set; }


        
        [MaxLength(250)]
        public string CC { get; set; }

        
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
        
        public string TipoNotificacion
        {
            get
            {
                return this.TipoNotificacionId != 0 ? Util.GetEnumDescription((ETipoNotificacion)this.TipoNotificacionId) : "";
            }
        }
    }
}
