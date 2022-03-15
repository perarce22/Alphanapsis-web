using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD.Alphanapsis.Entidades
{
    [Table("SGSSSolExaLab")]
    public class SGSSSolExaLab : EntidadBase
    {
        public int SGSSSolExaLabId { get; set; }
        public string SolEqpOriCenAsiCod { get; set; }
        public string SolEqpCenAsiCod { get; set; }
        public string SolEqpTipExaCod { get; set; }
        public decimal SolEqpExaNum { get; set; }
        public string SolEqpProEqLCod { get; set; }
        public DateTime? SolEqpSolExaFec { get; set; }
        public string SolEqpOrdCod { get; set; }
        public string SolEqpTipDocIdenPerCod { get; set; }
        public string SolEqpPerAsisDocIden { get; set; }
        public string SolEqpProColCod { get; set; }
        public string SolEqpProApePat { get; set; }
        public string SolEqpProApeMat { get; set; }
        public string SolEqpProPriNom { get; set; }
        public string SolEqpProSegNom { get; set; }
        public string SolEqpPacTipDocIdenCod { get; set; }
        public string SolEqpPacDocIdenNum { get; set; }
        public string SolEqpPacApePat { get; set; }
        public string SolEqpPacApeMat { get; set; }
        public string SolEqpPacPriNom { get; set; }
        public string SolEqpPacSegNom { get; set; }     
        public decimal? SolEqpPacHisCliNum { get; set; }
        public string SolEqpPacAutCod { get; set; }
        public string SolEqpPacSexCod { get; set; }
        public DateTime? SolEqpPacNacFec { get; set; }
        public decimal? SolEqpPacEdad { get; set; }
        public string SolEqpPacEstCivCod { get; set; }
        public string SolEqpPacTelFij { get; set; }
        public string SolEqpPacTelCel { get; set; }
        public string SolEqpPacFamTel { get; set; }
        public string SolEqpAreHosCod { get; set; }
        public string SolEqpSerHosCod { get; set; }
        public string SolEqpEmeCod { get; set; }
        public string SolEqpTopEmeCod { get; set; }
        public string SolEqpEstEnfCod { get; set; }
        public string SolEqpHabCod { get; set; }
        public string SolEqpCamCod { get; set; }
        public string SolEqpCenQuiCod { get; set; }
        public string SolEqpSalOpeCod { get; set; }
        public string SolEqpSisCod { get; set; }
        public string SolEqpDirIp { get; set; }
        public string SolEqpUsuCreCod { get; set; }
        public string SolEqpCreFec { get; set; }
        public string SolFlgExito { get; set; }
        public string SolFlgTransferencia { get; set; }
        public int? OrdenId { get; set; }
        [ForeignKey("OrdenId")]
        public Orden Orden { get; set; }
        public int EstadoProcesoId { get; set; }
        
    }

    public class DatoPaqueteEquipo
    {
        public int PaqueteId { get; set; }
        public int EquipoId { get; set; }
        public string AreaHosp { get; set; }
    }

}
