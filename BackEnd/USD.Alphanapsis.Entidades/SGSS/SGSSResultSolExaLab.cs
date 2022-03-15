using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD.Alphanapsis.Entidades
{
    public class SGSSResultSolExaLab
    {
        public int SGSSSolExaLabId { get; set; }
        public string ResEqpOriCenAsiCod { get; set; }
        public string ResEqpCenAsiCod { get; set; }
        public string ResEqpTipExaCod { get; set; }
        public long ResEqpSolExaNum { get; set; }
        public string ResEqpCPSCod { get; set; }
        public string ResEqpProEqLCod { get; set; }
        public string ResEqpResExaFec { get; set; }
        public string ResEqpTipDocIdenPerCod { get; set; }
        public string ResEqpPerAsisDocIdenNum { get; set; }
        public string ResEqpSisCod { get; set; }
        public string ResEqpUsuCreCod { get; set; }
        public string ResEqpCreFec { get; set; }
        public long ResEqpCanMue { get; set; }
        public string ResEqpTipCod { get; set; }
        public string ResEqpInf { get; set; }
        public List<SGSSResultSolExaLabMue> ListaResEqpMueItem { get; set; }
        public int EstadoProcesoId { get; set; }
    }

    public class SGSSResultSolExaLabMue
    {
        public int SGSSSolExaLabCPSId { get; set; }
        public string ResEqpMueCod { get; set; }
        public long ResEqpExaElmOrd { get; set; }
        public string ResEqpExaElmDes { get; set; }
        public string ResEqpExaDes { get; set; }
        public string ResEqpExaUnd { get; set; }
        public string ResEqpNorInfFemVal { get; set; }
        public string ResEqpNorSupFemCal { get; set; }
        public string ResEqpNorInfMasVal { get; set; }
        public string ResEqpNorSupMasVal { get; set; }
        public string ResEqpNorOtrVal { get; set; }
        public string ResEqpExaObs { get; set; }
        public string ResEqpRevTipDocIdenPerCod { get; set; }
        public string ResEqpRevPerAsisDocIdenNum { get; set; }
        public string ResEqpRevExaObs { get; set; }
        public string ResEqpRevExaFec { get; set; }
        public string ResEqpValTipDocIdenPerCod { get; set; }
        public string ResEqpValPerAsisDocIdenNum { get; set; }
        public string ResEqpValExaObs { get; set; }
        public string ResEqpValExaFec { get; set; }
        public string ResEqpPrvCod { get; set; }
        public int? OrdenPaqueteId { get; set; }
    }
}
