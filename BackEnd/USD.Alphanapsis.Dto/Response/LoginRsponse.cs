using System;
using System.Collections.Generic;
using System.Text;

namespace USD.Alphanapsis.Dto.Response
{
   public class LoginRsponse
    {
        public int UsuarioId { get; set; }
        public string Nombres { get; set; }
        public string Username { get; set; }
        public int? TipoAtencionId { get; set; }
        public int CentroSaludOrigenId { get; set; }
        public int CentroSaludAsistencialId { get; set; }
        public string Token { get; set; }
    }
}
