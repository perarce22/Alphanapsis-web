using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD.Alphanapsis.Entidades
{
    class Reportes
    {
    }

    public class ReporteConsumo
    {
        
        public string Mesreport { get; set; }

        public List<ReporteBioquimicaAnalito> ReporteBioAnalito { get; set; }

        public List<ReporteHemato> ReporteHemato { get; set; }

        public List<ReporteCoagulacion> ReporteCoagulacion { get; set; }

        public List<ReporteMicrobiologia> ReporteMicrobiologia { get; set; }

        public List<ReporteGasesElectrolitos> ReporteGasesElec { get; set; }

        public List<ReporteBioPerfiles> ReporteBioPerfiles { get; set; }

        public int? totalRptBioAnalito { get; set; }
        public int? totalRptHemato { get; set; }
        public int? totalRptCoagulacion { get; set; }
        public int? totalRptMicrobiologia { get; set; }
        public int? totalRptGasesElec { get; set; }
        public int? totalRptBioPerfiles { get; set; }

    }


    public class ReporteBioquimicaAnalito
    {

        public string Mes { get; set; }
        public int? AC_URIC { get; set; }
        public int? ALBU { get; set; }
        public int? AMILASA { get; set; }
        public int? BILI_DIR { get; set; }
        public int? BILI_TOT { get; set; }
        public int? BIOPROT { get; set; }
        public int? CALCIO { get; set; }
        // public int? CC3 { get; set; }
        // public int? CC4 { get; set; }
        public int? COLES { get; set; }
        public int? CREAT { get; set; }
        public int? D_CREAT { get; set; }
        public int? FALCA { get; set; }
        public int? FIERRO { get; set; }
        public int? FOSF { get; set; }
        public int? GGT { get; set; }
        //public int? GLUÇOBULINA { get; set; }
        public int? GLUCOSA { get; set; }
        public int? HDL_COL { get; set; }
        public int? LDH { get; set; }
        public int? LDL_COL { get; set; }
        public int? MICROAL { get; set; }
        //  public int? PCR { get; set; }
        public int? PRO_TOT { get; set; }
        public int? TGO { get; set; }
        public int? TGP { get; set; }
        public int? TRANSFERRINA { get; set; }
        public int? TRIG { get; set; }
        public int? UREA { get; set; }

    }

    public class ReporteHemato
    {
        public string Mes { get; set; }
        public int? CEL_LE { get; set; }
        public int? DOSAJE_HEMO { get; set; }
        public int? FROTIS_DE_SANGRE_PERIFERICA { get; set; }
        public int? GLOB_ROJO { get; set; }
        public int? GRUPO_SANG { get; set; }

        public int? HBA1C { get; set; }
        public int? HEMATOCRITO { get; set; }
        public int? HEMO_COMPL { get; set; }
        public int? HEMO_SIMPLE { get; set; }
        public int? LEUCOCITOS { get; set; }
        public int? PLAQUETAS { get; set; }
        public int? RETIC { get; set; }
        public int? RETR_COA { get; set; }
        public int? VEL_SED { get; set; }

    }

    public class ReporteCoagulacion 
    {
        public string Mes { get; set; }
        public int? APTT { get; set; }
        public int? FIB { get; set; }
        public int? PT { get; set; }
        public int? T_C { get; set; }
        public int? T_S { get; set; }

    }

    public class ReporteMicrobiologia 
    {
        public string Mes { get; set; }
        public int? ANTIBIOGRAMA__DE_SECRECIONES { get; set; }
        public int? ANTIBIOGRAMA_DE_UROCULTIVO { get; set; }
        public int? COLORACION_DE_GRAM_SECRECIONES { get; set; }
        public int? COLORACION_DE_GRAM_UROCULTIVO { get; set; }
        public int? COLORACIÓN_GRAM_DE_HECES { get; set; }
        public int? COPROCULTIVO { get; set; }
        public int? CULTIVO_DE_GERMENES_COMUNES { get; set; }
        public int? CULTIVO_DE_HONGOS { get; set; }
        public int? ESPERMATOGRAMA { get; set; }
        public int? EXAMEN_COMPLETO_DE_ORINA_CON_SEDIMENTO { get; set; }
        public int? EXAMEN_DIRECTO_DE_HECES { get; set; }
        public int? EXAMEN_DIRECTO_DE_HONGOS { get; set; }
        public int? EXAMEN_MICROSCOPICO_DE_SEDIMENTO_URINARIO { get; set; }
        public int? HEMOCULTIVO_Y_ANTIBIOGRAMA_ { get; set; }
        public int? PARASITOLOGICO_SERIADO_ { get; set; }
        public int? SEDI_BIN_BAS_2 { get; set; }
        public int? THEVENON { get; set; }


    }

    public class ReporteGasesElectrolitos
    {
        public string Mes { get; set; }
        public int? GASES_Y_ELECTROLITOS { get; set; }
        public int? GASES_Y_ELECTROLITOS_POC { get; set; }

    }



    public class ReporteBioPerfiles
    {
        public string Mes { get; set; }
        public int? ACIDO_URICO_AZAR { get; set; }
        public int? ACIDO_URICO_ORI24 { get; set; }
        public int? GASES_Y_ELECTROLITOS_POC { get; set; }
        public int? BIOPROT_24H { get; set; }
        public int? BIOPROT_AL_AZAR { get; set; }
        public int? CALCIO_EN_ORINA_24_HRS { get; set; }
        public int? CALCIO_EN_ORINA_AL_AZAR { get; set; }
        public int? CITOQUIMICO_DE_LIQUIDO_CEFALORRAQUIDEO { get; set; }
        public int? CITOQUIMICO_LIQUIDO_PLEURAL { get; set; }
        public int? CITOQUIMICOS_LIQUIDO_ASCITICO { get; set; }
        public int? CREA_ORI_24H { get; set; }
        public int? CREA_ORI_AZAR { get; set; }
        public int? DEPU_CREA { get; set; }
        public int? FOSFORO_EN_ORINA_24_HRS { get; set; }
        public int? FOSFORO_EN_ORINA_AL_AZAR { get; set; }
        public int? MICROALBUMINURIA_EN_ORINA_24H { get; set; }
        public int? PERFIL_HEPATICO { get; set; }
        public int? PERFIL_LIPIDICO { get; set; }
        public int? UREA_EN_ORINA_24_HORAS { get; set; }
        public int? UREA_EN_ORINA_AL_AZAR { get; set; }

    }


}
