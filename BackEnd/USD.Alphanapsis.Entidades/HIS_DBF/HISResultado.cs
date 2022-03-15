using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD.Alphanapsis.Entidades
{
    public class HISResultado
    {
        public int HISEnvioExamenId { get; set; }

        public string HISNumero { get; set; }

        public DateTime Fecha { get; set; }

        public string Hora { get; set; }

        public string CodigoExamen { get; set; }

        public string Resultado { get; set; }

        public string IndicadorEnvio { get; set; }

        public DateTime FechaRespuesta { get; set; }

        public string HoraRespuesta { get; set; }

        public string UsuarioEnvia { get; set; }

        public string Minimo { get; set; }

        public string Maximo { get; set; }

        public DateTime FechaTransferencia { get; set; }

        public string UsuarioProcesa { get; set; }

        public int Comenta { get; set; }

        public string Comentario { get; set; }

        public int MiCodigo { get; set; }

        public int ANBCodigo { get; set; }

        public string ResAntibi { get; set; }

        public int CMIAntibi { get; set; }

        public string MicroOrgan { get; set; }

        public string Antibiotic { get; set; }
    }
}
