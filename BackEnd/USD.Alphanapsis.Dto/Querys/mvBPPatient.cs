using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD.Alphanapsis.Dto
{
    public class mvBPPatient
    {
        public int BPOrderApprovedId { get; set; }
        public int BusinessPartnersId { get; set; }
        public int OrdenId { get; set; }
        public string NumeroOrden { get; set; }
        public string FechaOrden { get; set; }
        public int MascotaId { get; set; }
        public string Paciente { get; set; }
        public string NroHistoriaClinica { get; set; }
        public string Edad { get; set; }
        public string Especie { get; set; }
        public string Sexo { get; set; }
        public string Documento { get; set; }
    }
}
