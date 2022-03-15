using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace USD.Alphanapsis.Entidades
{
    [Table("OrdenReporteCorrelativo")]
    public class OrdenReporteCorrelativo : EntidadBase
    {

        public int OrdenReporteCorrelativoId { get; set; }
        public string Lineas { get; set; }
        public string Sucursal { get; set; }
        public string CodigoOA { get; set; }
        public DateTime Fecha { get; set; }
        public string Grupo { get; set; }
        public string NombreReporte { get; set; }
        public string Correlativo { get; set; }
        public int OrdenId { get; set; }

    }
}
