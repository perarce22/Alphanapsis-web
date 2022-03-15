using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace USD.Alphanapsis.Entidades
{
    [Table("SGSSSolExaLabCPS")]
    public class SGSSSolExaLabCPS : EntidadBase
    {
        public int SGSSSolExaLabCPSId { get; set; }
        public int SGSSSolExaLabId { get; set; }
        [ForeignKey("SGSSSolExaLabId")]
        public SGSSSolExaLab SGSSSolExaLab { get; set; }
        public string SolEqpOriCenAsiCod { get; set; }
        public string SolEqpCenAsiCod { get; set; }
        public string SolEqpTipExaCod { get; set; }
        public decimal SolEqpExaNum { get; set; }
        public string SolEqpCPSCod { get; set; }
        public string SolEqpMueCod { get; set; }
        public string SolEqpSedExaCod { get; set; }
        public string SolEqpAreExaCod { get; set; }
        public DateTime? ResEqpTomaFec { get; set; }
        public string ResEqpTomaHor { get; set; }
        public string SolEqpProvCod { get; set; }
        public string SolEqpFlgTransEqp { get; set; }
        public int? OrdenId { get; set; }
        [ForeignKey("OrdenId")]
        public Orden Orden { get; set; }
        public int? OrdenPaqueteId { get; set; }
        [ForeignKey("OrdenPaqueteId")]
        public OrdenPaquete OrdenPaquete { get; set; }
        public int EstadoProcesoId { get; set; }
        
    }
}
