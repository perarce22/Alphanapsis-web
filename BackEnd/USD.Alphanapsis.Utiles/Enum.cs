using System.ComponentModel;

namespace USD.Alphanapsis.Utiles
{

    public enum ETipoNotificacion
    {
        Paciente = 1,
        Medico = 2
    }
    public enum ESexo
    {
        Masculino = 1,
        Femenino = 2
    }
    public enum EEstadoRegistro
    {
        [Description("Activo")]
        Activo = 1,
        [Description("Inactivo")]
        Inactivo = 0
    }

    public enum EEstadoOrden
    {
        [Description("Pendiente")]
        Pendiente = 0,
        [Description("Enviado")]
        Enviado = 1,
        [Description("Procesado")]
        Procesado = 2,
        [Description("Aprobado")]
        Aprobado = 3,
        [Description("Analizando")]
        Analizando = 4
    }

    public enum EEstadoOrdenPaquete
    {
        [Description("Pendiente")]
        Pendiente = 0,
        [Description("Enviado")]
        Enviado = 1,
        [Description("Procesado")]
        Procesado = 2,
        [Description("Aprobado")]
        Aprobado = 3,
        [Description("Analizando")]
        Analizando = 4,
    }

    public enum EEstadoPrueba
    {
        [Description("Pendiente")]
        Pendiente = 0,
        [Description("Enviado")]
        Enviado = 1,
        [Description("Procesado")]
        Procesado = 2,
        [Description("Aprobado")]
        Aprobado = 3
    }

    public enum ETipoConectDBF
    {
        [Description("Jet.OLEDB")]
        JetOLEDB = 1,
        [Description("VFPOLEDB")]
        VFPOLEDB = 2
    }


    public enum DiasSemana
    {
        LUN = 1,
        MAR = 2,
        MIE = 3,
        JUE = 4,
        VIE = 5,
        SAB = 6,
        DOM = 7,
    }

    public enum EMeses 
    {
        
        Enero = 1,
        Febrero = 2,
        Marzo = 3,
        Abril = 4,
        Mayo = 5,
        Junio = 6,
        Julio = 7,
        Agosto = 8,
        Setiembre = 9,
        Octubre = 10,
        Noviembre = 11,
        Diciembre = 12

    }



    public enum Perfiles
    {
        Administrador = 1,
        Usuario = 2
    }
    public enum EEstadoProceso
    {
        [Description("Pendiente")]
        Pendiente = 0,
        [Description("Enviado")]
        Enviado = 1,
        [Description("Procesado")]
        Procesado = 2,
        [Description("Aprobado")]
        Aprobado = 3,
        [Description("Ejecutado")]
        Ejecutado = 4
    }
    public enum ETipoOrden
    {
        [Description("Particular")]
        Particular = 1,
        [Description("ESSALUD")]
        EsSalud = 2,
        [Description("Clinica")]
        Clinica = 3
    }
    public enum ESGSSSistemaSalud
    {
        [Description("SGSS")]
        SGSS = 1
    }
    public enum ESGSSTipoResultado
    {
        [Description("Normal")]
        Normal = 1,
        [Description("Patológico")]
        Patológico = 1
    }
    public enum ESGSSResultadoSOAP
    {
        [Description("Exito")]
        Exito = 1,
        [Description("Error")]
        Error = 0
    }
    public enum TipoCompatibilidad
    {
        [Description("Prueba Método LISS")]
        MetodoLISS = 1,
        [Description("Prueba Método Tubo")]
        MetodoTubo = 2,
        [Description("Sin Prueba Cruzada")]
        MetodoSinPrueba = 3
    }

    public enum TipoGestionCorrelativo
    {
        [Description("P")]
        Postulante = 1,
        [Description("R")]
        Receptor = 2,
        [Description("B")]
        Bolsa = 3
    }
    public enum TipoDatoDocumento
    {
        [Description("OTROS")]
        OTROS = 4
    }

    public enum TipoCorrelativo : int
    {
        [Description("O")]
        ORDEN_SOLICITUD = 1,
        [Description("C")]
        ORDEN_CPT = 2

    }

    public enum ConfigInterface
    {
        EQACTIVO = 0,
        EQANALIZADOR = 1,
        BITSSEGUNDO = 2,
        BITSDATO = 3,
        BITSPARADA = 4,
        BITSPARIDAD = 5,
        BITSPUERTO = 6,
        BITSCONTROLFLUJO = 7,
        CODIGOMUESTRA = 8,
        TCP_IP = 0,
        TCP_PUERTO = 1
    }
    public enum ETipoVista
    {
        [Description("Resultado")]
        Resultado = 1,
        [Description("Trazabilidad")]
        Trazabilidad = 2
    }
    public enum ETrazable
    {
        [Description("Trazable")]
        Trazable = 1,
        [Description("No Trazable")]
        NoTrazable = 0
    }
    public enum EResultado
    {
        [Description("Cualitativo")]
        Cualitativo = 1,
        [Description("Cuantitativo")]
        Cuantitativo = 0
    }
    public enum EMatch
    {
        [Description("MatchAnalizador")]
        Match = 1,
        [Description("No Match")]
        NoMatch = 0
    }
    public enum EReporteMostrar
    {
        [Description("SI")]
        ReporteMostrar = 1,
        [Description("NO")]
        ReporteNoMostrar = 0
    }
    public enum ECalculado
    {
        [Description("SI")]
        Calculado = 1,
        [Description("NO")]
        NoCalculado = 0
    }
    public enum EImprimeEtiqueta
    {
        [Description("SI")]
        Imprimir = 1,
        [Description("NO")]
        NoImprimir = 0
    }
    public enum EEstadisticaAgp
    {
        [Description("SI")]
        Agrupado = 1,
        [Description("NO")]
        NoAgrupado = 0
    }
    public enum ETipoCoumunicacion
    {
        [Description("Purto")]
        PuertoSerial = 1,
        [Description("TCP")]
        TCPIP = 2
    }
    public enum ETipoServicio : int
    {
        ProcesoTodos = 0,
        ProcesoNotificaciones = 1,
        ProcesoTareas = 2,
        ProcesoInterfaceEquipo = 3,
        ProcesoSincroSGSS = 4,
        ProcesoTask = 5
    }

    public enum ETipoAtencion
    {
        [Description("Emergencia")]
        Emergencia = 1,
        [Description("Rutina")]
        Rutina = 2,
        [Description("Admin")]
        Admin = 3
    }

    public enum ETipoMuestra
    {
        [Description("Suero - 01")]
        Suero = 1,
        [Description("Suero 30 MIN - 02")]
        Suero30M = 2,
        [Description("Suero 60 MIN - 03")]
        Suero60M = 3,
        [Description("Suero 120 MIN - 05")]
        Suero120M = 4,
        [Description("Orina - 21")]
        Orina = 5,
        [Description("Orina 24 Hrs - 22")]
        Orina24Hrs = 6,
        [Description("Sangre Total - 41")]
        Sangre = 7,
        [Description("Plasma - 45")]
        Plasma = 8,
        [Description("Heces - 31")]
        Heces1 = 9,
        [Description("Heces - 32")]
        Heces2 = 10,
        [Description("Heces - 33")]
        Heces3 = 11,
        [Description("TestGraham - 37")]
        Graham = 12,
        [Description("Otros1 - 47")]
        Otros = 13,
    }
    public enum EMuestraAnalizador
    {
        [Description("Suero")]
        Suero = 1,
        [Description("Suero 60 MIN")]
        Suero60M = 2,
        [Description("Suero 120 MIN")]
        Suero120M = 3,
        [Description("Orina")]
        Orina = 4,
        [Description("Sangre Total")]
        Sangre = 5,
        [Description("Heces")]
        Heces = 6,
        [Description("Graham")]
        Graham = 7,
        [Description("Plasma")]
        Plasma = 8,
        [Description("LIQ. PLEURAL")]
        LIQPLEURAL = 9,
        [Description("LIQ. ASCITICO")]
        LIQASCITICO = 10,
        [Description("LCR")]
        LCR = 11,
        [Description("Sangre Factor")]
        SangreF = 12,
        [Description("Orina 24H")]
        Orina24H = 13
    }

    public enum ETipoOA
    {
        [Description("Laboratorio")]
        Emergencia = 5,
        [Description("Patología")]
        Rutina = 9
    }

    public enum ESede
    {
        [Description("Lima")]
        Lima = 01,
        [Description("Surco")]
        Surco = 02,
        [Description("Chorrillos")]
        Chorrillos = 03
    }

    public enum ECodigoExternoSE
    {
        [Description("MS")]
        MeisonSante = 1,
        [Description("SSHU")]
        EsSaludHuaraz = 2
    }

    public enum EEstadoMaglumi
    {
        PENDIENTE = 0,
        ENVIADO = 1,
        CONRESPUESTA = 2
    }

    public enum ETipoDato
    {
        [Description("Entero")]
        Entero = 1,
        [Description("Decimal_10_2")]
        Decimal_10_2 = 2,
        [Description("Decimal_10_3")]
        Decimal_10_3 = 3,
        [Description("Decimal_10_4")]
        Decimal_10_4 = 4
    }

    public enum EtipoBarcode
    {
        [Description("CODE128")]
        CODE128 = 1,
        [Description("CODE39")]
        CODE39 = 2,
        [Description("CODE128A")]
        CODE128A = 3,
        [Description("CODE128B")]
        CODE128B = 4,
        [Description("CODE128C")]
        CODE128C = 5,
        [Description("CODE39EXTENDED")]
        CODE39EXTENDED = 6,
        [Description("CODE39MOD43")]
        CODE39MOD43 = 7,
        [Description("CODE11")]
        CODE11 = 8,
    }
}
