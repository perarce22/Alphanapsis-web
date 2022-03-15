using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace USD.Alphanapsis.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AreaEstudio",
                columns: table => new
                {
                    AreaEstudioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Sigla = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    CodigoInterno = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    Reporte = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Descripcion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    FlagActivo = table.Column<bool>(type: "bit", nullable: false),
                    FlagEliminado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaEstudio", x => x.AreaEstudioId);
                });

            migrationBuilder.CreateTable(
                name: "CentroSaludOrigen",
                columns: table => new
                {
                    CentroSaludOrigenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    CodigoInterno = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    CodigoExterno = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    FlagActivo = table.Column<bool>(type: "bit", nullable: false),
                    FlagEliminado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentroSaludOrigen", x => x.CentroSaludOrigenId);
                });

            migrationBuilder.CreateTable(
                name: "Configuracion",
                columns: table => new
                {
                    ConfiguracionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Parametro = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    Valor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "NVARCHAR(250)", maxLength: 250, nullable: false),
                    ModificadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configuracion", x => x.ConfiguracionId);
                });

            migrationBuilder.CreateTable(
                name: "ContenidoEstatico",
                columns: table => new
                {
                    ContenidoEstaticoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Campo = table.Column<string>(type: "NVARCHAR(200)", maxLength: 200, nullable: false),
                    Descripcion = table.Column<string>(type: "NVARCHAR(4000)", maxLength: 4000, nullable: false),
                    FlagActivo = table.Column<bool>(type: "bit", nullable: false),
                    FlagEliminado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContenidoEstatico", x => x.ContenidoEstaticoId);
                });

            migrationBuilder.CreateTable(
                name: "Correlativo",
                columns: table => new
                {
                    CorrelativoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prefijo = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    TipoCorrelativo = table.Column<int>(type: "INT", nullable: false),
                    Valor = table.Column<int>(type: "INT", nullable: false),
                    Ceros = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    FechaEmision = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FlagActivo = table.Column<bool>(type: "bit", nullable: false),
                    FlagEliminado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Correlativo", x => x.CorrelativoId);
                });

            migrationBuilder.CreateTable(
                name: "Especialidad",
                columns: table => new
                {
                    EspecialidadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    FlagActivo = table.Column<bool>(type: "bit", nullable: false),
                    FlagEliminado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidad", x => x.EspecialidadId);
                });

            migrationBuilder.CreateTable(
                name: "EstadoCivil",
                columns: table => new
                {
                    EstadoCivilId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    FlagActivo = table.Column<bool>(type: "bit", nullable: false),
                    FlagEliminado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoCivil", x => x.EstadoCivilId);
                });

            migrationBuilder.CreateTable(
                name: "GeoIp",
                columns: table => new
                {
                    GeoIpId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IPNINI = table.Column<long>(type: "BIGINT", nullable: false),
                    IPNFIN = table.Column<long>(type: "BIGINT", nullable: false),
                    CC02 = table.Column<string>(type: "NVARCHAR(4)", maxLength: 4, nullable: false),
                    FlagActivo = table.Column<bool>(type: "bit", nullable: false),
                    FlagEliminado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeoIp", x => x.GeoIpId);
                });

            migrationBuilder.CreateTable(
                name: "HISEnvioExamen",
                columns: table => new
                {
                    HISEnvioExamenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HISNumero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaPrueba = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CodigoPrueba = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoPerfilPrueba = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoLab = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoSec = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoSede = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoMedico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NroAsegurado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NroHistClinica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CodigoUbicacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoDomicilio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoDocumento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NroDocumento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NroTelefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NroActoMedico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoProcesoId = table.Column<int>(type: "int", nullable: false),
                    OrdenId = table.Column<int>(type: "int", nullable: false),
                    OrdenPaqueteId = table.Column<int>(type: "int", nullable: false),
                    OrdenPaqueteDetalleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HISEnvioExamen", x => x.HISEnvioExamenId);
                });

            migrationBuilder.CreateTable(
                name: "HISEquivPaqueteEquipo",
                columns: table => new
                {
                    HISEquivPaqueteEquipoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoPruebaHIS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaqueteId = table.Column<int>(type: "int", nullable: false),
                    EquipoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HISEquivPaqueteEquipo", x => x.HISEquivPaqueteEquipoId);
                });

            migrationBuilder.CreateTable(
                name: "HISEquivPaqueteServicio",
                columns: table => new
                {
                    HISEquivPaqueteServicioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoPruebaHIS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaqueteId = table.Column<int>(type: "int", nullable: false),
                    ServicioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HISEquivPaqueteServicio", x => x.HISEquivPaqueteServicioId);
                });

            migrationBuilder.CreateTable(
                name: "Idioma",
                columns: table => new
                {
                    IdiomaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "NVARCHAR(200)", maxLength: 200, nullable: false),
                    Prefijo = table.Column<string>(type: "NVARCHAR(10)", maxLength: 10, nullable: false),
                    FlagActivo = table.Column<bool>(type: "bit", nullable: false),
                    FlagEliminado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idioma", x => x.IdiomaId);
                });

            migrationBuilder.CreateTable(
                name: "IntEquivPaqueteEquipo",
                columns: table => new
                {
                    IntEquivPaqueteEquipoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoCPS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoMuestra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaqueteId = table.Column<int>(type: "int", nullable: false),
                    EquipoId = table.Column<int>(type: "int", nullable: false),
                    AreaHosp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntEquivPaqueteEquipo", x => x.IntEquivPaqueteEquipoId);
                });

            migrationBuilder.CreateTable(
                name: "LogTransaccion",
                columns: table => new
                {
                    LogTransaccionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Proceso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Resultado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlagActivo = table.Column<bool>(type: "bit", nullable: false),
                    FlagEliminado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogTransaccion", x => x.LogTransaccionId);
                });

            migrationBuilder.CreateTable(
                name: "Metodo",
                columns: table => new
                {
                    MetodoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "NVARCHAR(150)", maxLength: 150, nullable: false),
                    FlagActivo = table.Column<bool>(type: "bit", nullable: false),
                    FlagEliminado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metodo", x => x.MetodoId);
                });

            migrationBuilder.CreateTable(
                name: "MSSolExaLab",
                columns: table => new
                {
                    MSSolExaLabId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdenId = table.Column<int>(type: "int", nullable: false),
                    EstadoProcesoId = table.Column<int>(type: "int", nullable: false),
                    Sucursal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Origen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SucursalLab = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoTarifa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prioridad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NroCama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoOrden = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RUCContratante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodUbicacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaAtencion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Empleadora_Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaLimiteAtencion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoOrdenAtencion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoOrdenAtencion_Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentoPago = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoPaciente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdPaciente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PacienteCompleto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitularNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioOrden = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Usuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contrasena = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoEspecialidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnidadNegocio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Local = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion_Paciente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono_Paciente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Celular_Paciente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tarifa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdConsultaExterna = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoHC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PacienteNombres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PacienteAPPaterno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PacienteAPMaterno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaNacimientoPac = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoDocumento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Documento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoAtencion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Especialidad_Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoOA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdOrdenAtencion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicoNombres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicoAPPaterno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicoAPMaterno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdMedico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicoTipoDocumento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicoDocumento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicoCorreoelectronico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicoTelefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicoCelular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicoSexo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicoCMP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Empleadora_RUC = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MSSolExaLab", x => x.MSSolExaLabId);
                });

            migrationBuilder.CreateTable(
                name: "MSSolExaLabDet",
                columns: table => new
                {
                    MSSolExaLabDetiD = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MSSolExaLabId = table.Column<int>(type: "int", nullable: false),
                    OrdenId = table.Column<int>(type: "int", nullable: true),
                    OrdenPaqueteId = table.Column<int>(type: "int", nullable: true),
                    EstadoProcesoId = table.Column<int>(type: "int", nullable: false),
                    CodigoOA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdOrdenAtencion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IndRevertido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Linea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaEmision = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Componente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComponenteNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CantidadSolicitada = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoDocumento = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MSSolExaLabDet", x => x.MSSolExaLabDetiD);
                });

            migrationBuilder.CreateTable(
                name: "Notificacion",
                columns: table => new
                {
                    NotificacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoNotificacionId = table.Column<int>(type: "int", nullable: false),
                    FechaEnvio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FROM = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    TO = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    CC = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: true),
                    BCC = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: true),
                    BODY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SUBJECT = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ADJUNTO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DIRECTORIO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdAsociado = table.Column<int>(type: "int", nullable: true),
                    FlagActivo = table.Column<bool>(type: "bit", nullable: false),
                    FlagEliminado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notificacion", x => x.NotificacionId);
                });

            migrationBuilder.CreateTable(
                name: "Opcion",
                columns: table => new
                {
                    OpcionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Etiqueta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    Orden = table.Column<int>(type: "int", nullable: true),
                    Icono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlagActivo = table.Column<bool>(type: "bit", nullable: false),
                    FlagEliminado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opcion", x => x.OpcionId);
                });

            migrationBuilder.CreateTable(
                name: "OrdenReporteCorrelativo",
                columns: table => new
                {
                    OrdenReporteCorrelativoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lineas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sucursal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoOA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Grupo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreReporte = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correlativo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrdenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenReporteCorrelativo", x => x.OrdenReporteCorrelativoId);
                });

            migrationBuilder.CreateTable(
                name: "Perfil",
                columns: table => new
                {
                    PerfilId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    FlagActivo = table.Column<bool>(type: "bit", nullable: false),
                    FlagEliminado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfil", x => x.PerfilId);
                });

            migrationBuilder.CreateTable(
                name: "Procedencia",
                columns: table => new
                {
                    ProcedenciaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    CodigoHIS = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: true),
                    FlagActivo = table.Column<bool>(type: "bit", nullable: false),
                    FlagEliminado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedencia", x => x.ProcedenciaId);
                });

            migrationBuilder.CreateTable(
                name: "ServicioSalud",
                columns: table => new
                {
                    ServicioSaludId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    CodigoHIS = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: true),
                    FlagActivo = table.Column<bool>(type: "bit", nullable: false),
                    FlagEliminado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicioSalud", x => x.ServicioSaludId);
                });

            migrationBuilder.CreateTable(
                name: "TipoDocumento",
                columns: table => new
                {
                    TipoDocumentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    Longitud = table.Column<int>(type: "int", nullable: false),
                    CodigoHIS = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: true),
                    FlagActivo = table.Column<bool>(type: "bit", nullable: false),
                    FlagEliminado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDocumento", x => x.TipoDocumentoId);
                });

            migrationBuilder.CreateTable(
                name: "TipoInterfaz",
                columns: table => new
                {
                    TipoInterfazId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    FlagActivo = table.Column<bool>(type: "bit", nullable: false),
                    FlagEliminado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoInterfaz", x => x.TipoInterfazId);
                });

            migrationBuilder.CreateTable(
                name: "TipoMuestraAnalizador",
                columns: table => new
                {
                    TipoMuestraAnalizadorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    Codigo = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: true),
                    FlagActivo = table.Column<bool>(type: "bit", nullable: false),
                    FlagEliminado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMuestraAnalizador", x => x.TipoMuestraAnalizadorId);
                });

            migrationBuilder.CreateTable(
                name: "TipoOrden",
                columns: table => new
                {
                    TipoOrdenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    FlagActivo = table.Column<bool>(type: "bit", nullable: false),
                    FlagEliminado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoOrden", x => x.TipoOrdenId);
                });

            migrationBuilder.CreateTable(
                name: "TipoPaciente",
                columns: table => new
                {
                    TipoPacienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    CodigoHIS = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: true),
                    FlagActivo = table.Column<bool>(type: "bit", nullable: false),
                    FlagEliminado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPaciente", x => x.TipoPacienteId);
                });

            migrationBuilder.CreateTable(
                name: "Ubigeo",
                columns: table => new
                {
                    UbigeoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "NVARCHAR(6)", maxLength: 6, nullable: true),
                    DepartamentoId = table.Column<string>(type: "NVARCHAR(2)", maxLength: 2, nullable: true),
                    Departamento = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: true),
                    ProvinciaId = table.Column<string>(type: "NVARCHAR(2)", maxLength: 2, nullable: true),
                    Provincia = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: true),
                    DistritoId = table.Column<string>(type: "NVARCHAR(2)", maxLength: 2, nullable: true),
                    Distrito = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: true),
                    ModificadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ubigeo", x => x.UbigeoId);
                });

            migrationBuilder.CreateTable(
                name: "Agrupamiento",
                columns: table => new
                {
                    AgrupamientoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Descripcion = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: true),
                    AreaEstudioId = table.Column<int>(type: "int", nullable: true),
                    Codigo = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    FlagActivo = table.Column<bool>(type: "bit", nullable: false),
                    FlagEliminado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agrupamiento", x => x.AgrupamientoId);
                    table.ForeignKey(
                        name: "FK_Agrupamiento_AreaEstudio_AreaEstudioId",
                        column: x => x.AreaEstudioId,
                        principalTable: "AreaEstudio",
                        principalColumn: "AreaEstudioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CentroSaludAsistencial",
                columns: table => new
                {
                    CentroSaludAsistencialId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CentroSaludOrigenId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    CodigoInterno = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    FlagActivo = table.Column<bool>(type: "bit", nullable: false),
                    FlagEliminado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentroSaludAsistencial", x => x.CentroSaludAsistencialId);
                    table.ForeignKey(
                        name: "FK_CentroSaludAsistencial_CentroSaludOrigen_CentroSaludOrigenId",
                        column: x => x.CentroSaludOrigenId,
                        principalTable: "CentroSaludOrigen",
                        principalColumn: "CentroSaludOrigenId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContenidoEstaticoIdioma",
                columns: table => new
                {
                    ContenidoEstaticoIdiomaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdiomaId = table.Column<int>(type: "int", nullable: false),
                    ContenidoEstaticoId = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<string>(type: "NVARCHAR(4000)", maxLength: 4000, nullable: false),
                    FlagActivo = table.Column<bool>(type: "bit", nullable: false),
                    FlagEliminado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContenidoEstaticoIdioma", x => x.ContenidoEstaticoIdiomaId);
                    table.ForeignKey(
                        name: "FK_ContenidoEstaticoIdioma_ContenidoEstatico_ContenidoEstaticoId",
                        column: x => x.ContenidoEstaticoId,
                        principalTable: "ContenidoEstatico",
                        principalColumn: "ContenidoEstaticoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContenidoEstaticoIdioma_Idioma_IdiomaId",
                        column: x => x.IdiomaId,
                        principalTable: "Idioma",
                        principalColumn: "IdiomaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Servicio",
                columns: table => new
                {
                    ServicioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    Descripcion = table.Column<string>(type: "NVARCHAR(1000)", maxLength: 1000, nullable: true),
                    AreaEstudioId = table.Column<int>(type: "int", nullable: true),
                    Trazable = table.Column<bool>(type: "bit", nullable: true),
                    ReporteMostrar = table.Column<bool>(type: "bit", nullable: true),
                    ReporteOrden = table.Column<int>(type: "int", nullable: true),
                    ReporteColumna = table.Column<int>(type: "int", nullable: true),
                    ReporteNombre = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: true),
                    UnidadMedida = table.Column<string>(type: "NVARCHAR(10)", maxLength: 10, nullable: true),
                    Referencia = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: true),
                    MetodoId = table.Column<int>(type: "int", nullable: true),
                    EsCalculado = table.Column<bool>(type: "bit", nullable: true),
                    TipoResultado = table.Column<bool>(type: "bit", nullable: true),
                    TipoDatoId = table.Column<int>(type: "int", nullable: true),
                    MultiplicarPor = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FlagActivo = table.Column<bool>(type: "bit", nullable: false),
                    FlagEliminado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicio", x => x.ServicioId);
                    table.ForeignKey(
                        name: "FK_Servicio_AreaEstudio_AreaEstudioId",
                        column: x => x.AreaEstudioId,
                        principalTable: "AreaEstudio",
                        principalColumn: "AreaEstudioId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Servicio_Metodo_MetodoId",
                        column: x => x.MetodoId,
                        principalTable: "Metodo",
                        principalColumn: "MetodoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OpcionPerfil",
                columns: table => new
                {
                    OpcionPerfilId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PerfilId = table.Column<int>(type: "int", nullable: true),
                    OpcionId = table.Column<int>(type: "int", nullable: true),
                    FlagActivo = table.Column<bool>(type: "bit", nullable: false),
                    FlagEliminado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpcionPerfil", x => x.OpcionPerfilId);
                    table.ForeignKey(
                        name: "FK_OpcionPerfil_Opcion_OpcionId",
                        column: x => x.OpcionId,
                        principalTable: "Opcion",
                        principalColumn: "OpcionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OpcionPerfil_Perfil_PerfilId",
                        column: x => x.PerfilId,
                        principalTable: "Perfil",
                        principalColumn: "PerfilId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Medico",
                columns: table => new
                {
                    MedicoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroDocumento = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: true),
                    TipoDocumentoId = table.Column<int>(type: "int", nullable: false),
                    CodigoInterno = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: true),
                    NroColegiatura = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: true),
                    ApellidoPaterno = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    ApellidoMaterno = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    Nombres = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    CorreoElectronico = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    Telefono = table.Column<string>(type: "NVARCHAR(130)", maxLength: 130, nullable: true),
                    Celular = table.Column<string>(type: "NVARCHAR(13)", maxLength: 13, nullable: true),
                    Sexo = table.Column<int>(type: "int", nullable: false),
                    FlagActivo = table.Column<bool>(type: "bit", nullable: false),
                    FlagEliminado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medico", x => x.MedicoId);
                    table.ForeignKey(
                        name: "FK_Medico_TipoDocumento_TipoDocumentoId",
                        column: x => x.TipoDocumentoId,
                        principalTable: "TipoDocumento",
                        principalColumn: "TipoDocumentoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: true),
                    ApellidoPaterno = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    ApellidoMaterno = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    Nombres = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    CorreoElectronico = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    Username = table.Column<string>(type: "NVARCHAR(40)", maxLength: 40, nullable: false),
                    EspecialidadId = table.Column<int>(type: "int", nullable: true),
                    FechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaCese = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NumeroDocumento = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: true),
                    TipoDocumentoId = table.Column<int>(type: "int", nullable: true),
                    CodigoInterno = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: true),
                    TipoAtencionId = table.Column<int>(type: "int", nullable: true),
                    FlagActivo = table.Column<bool>(type: "bit", nullable: false),
                    FlagEliminado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_Usuario_Especialidad_EspecialidadId",
                        column: x => x.EspecialidadId,
                        principalTable: "Especialidad",
                        principalColumn: "EspecialidadId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuario_TipoDocumento_TipoDocumentoId",
                        column: x => x.TipoDocumentoId,
                        principalTable: "TipoDocumento",
                        principalColumn: "TipoDocumentoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Equipo",
                columns: table => new
                {
                    EquipoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    Marca = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    Modelo = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    Serie = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    CodUnico = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    AreaEstudioId = table.Column<int>(type: "int", nullable: true),
                    TipoInterfazId = table.Column<int>(type: "int", nullable: true),
                    TipoBarcodeId = table.Column<int>(type: "int", nullable: true),
                    MatchAutomatico = table.Column<bool>(type: "bit", nullable: true),
                    FlagActivo = table.Column<bool>(type: "bit", nullable: false),
                    FlagEliminado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipo", x => x.EquipoId);
                    table.ForeignKey(
                        name: "FK_Equipo_AreaEstudio_AreaEstudioId",
                        column: x => x.AreaEstudioId,
                        principalTable: "AreaEstudio",
                        principalColumn: "AreaEstudioId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipo_TipoInterfaz_TipoInterfazId",
                        column: x => x.TipoInterfazId,
                        principalTable: "TipoInterfaz",
                        principalColumn: "TipoInterfazId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ParametroInterfaz",
                columns: table => new
                {
                    ParametroInterfazId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Parametro = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: true),
                    Descripcion = table.Column<string>(type: "NVARCHAR(250)", maxLength: 250, nullable: true),
                    ConfigInterfaceId = table.Column<int>(type: "int", nullable: false),
                    TipoInterfazId = table.Column<int>(type: "int", nullable: true),
                    FlagActivo = table.Column<bool>(type: "bit", nullable: false),
                    FlagEliminado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParametroInterfaz", x => x.ParametroInterfazId);
                    table.ForeignKey(
                        name: "FK_ParametroInterfaz_TipoInterfaz_TipoInterfazId",
                        column: x => x.TipoInterfazId,
                        principalTable: "TipoInterfaz",
                        principalColumn: "TipoInterfazId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Paquete",
                columns: table => new
                {
                    PaqueteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    Descripcion = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    AreaEstudioId = table.Column<int>(type: "int", nullable: true),
                    TipoMuestraId = table.Column<int>(type: "int", nullable: true),
                    TipoMuestraAnalizadorId = table.Column<int>(type: "int", nullable: true),
                    ImprimeEtiqueta = table.Column<bool>(type: "bit", nullable: true),
                    EstadisticaAgp = table.Column<bool>(type: "bit", nullable: true),
                    FlagActivo = table.Column<bool>(type: "bit", nullable: false),
                    FlagEliminado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paquete", x => x.PaqueteId);
                    table.ForeignKey(
                        name: "FK_Paquete_AreaEstudio_AreaEstudioId",
                        column: x => x.AreaEstudioId,
                        principalTable: "AreaEstudio",
                        principalColumn: "AreaEstudioId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Paquete_TipoMuestraAnalizador_TipoMuestraAnalizadorId",
                        column: x => x.TipoMuestraAnalizadorId,
                        principalTable: "TipoMuestraAnalizador",
                        principalColumn: "TipoMuestraAnalizadorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    PacienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApellidoPaterno = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    ApellidoMaterno = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    Nombres = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    CorreoElectronico = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "DATE", nullable: true),
                    Direccion = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    Telefono = table.Column<string>(type: "NVARCHAR(130)", maxLength: 130, nullable: true),
                    Celular = table.Column<string>(type: "NVARCHAR(13)", maxLength: 13, nullable: true),
                    UbigeoId = table.Column<int>(type: "int", nullable: true),
                    TipoDocumentoId = table.Column<int>(type: "int", nullable: true),
                    NumeroDocumento = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: true),
                    Sexo = table.Column<int>(type: "int", nullable: false),
                    NroAsegurado = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: true),
                    NroHistoriaClinica = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: true),
                    Edad = table.Column<int>(type: "int", nullable: true),
                    FlagActivo = table.Column<bool>(type: "bit", nullable: false),
                    FlagEliminado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.PacienteId);
                    table.ForeignKey(
                        name: "FK_Paciente_TipoDocumento_TipoDocumentoId",
                        column: x => x.TipoDocumentoId,
                        principalTable: "TipoDocumento",
                        principalColumn: "TipoDocumentoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Paciente_Ubigeo_UbigeoId",
                        column: x => x.UbigeoId,
                        principalTable: "Ubigeo",
                        principalColumn: "UbigeoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrdenServicioFormula",
                columns: table => new
                {
                    OrdenServicioFormulaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServicioId = table.Column<int>(type: "int", nullable: false),
                    Formula = table.Column<string>(type: "NVARCHAR(200)", maxLength: 200, nullable: true),
                    FlagActivo = table.Column<bool>(type: "bit", nullable: false),
                    FlagEliminado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenServicioFormula", x => x.OrdenServicioFormulaId);
                    table.ForeignKey(
                        name: "FK_OrdenServicioFormula_Servicio_ServicioId",
                        column: x => x.ServicioId,
                        principalTable: "Servicio",
                        principalColumn: "ServicioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServicioAgrupamiento",
                columns: table => new
                {
                    ServicioAgrupamientoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgrupamientoId = table.Column<int>(type: "int", nullable: true),
                    ServicioId = table.Column<int>(type: "int", nullable: false),
                    FlagActivo = table.Column<bool>(type: "bit", nullable: false),
                    FlagEliminado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicioAgrupamiento", x => x.ServicioAgrupamientoId);
                    table.ForeignKey(
                        name: "FK_ServicioAgrupamiento_Agrupamiento_AgrupamientoId",
                        column: x => x.AgrupamientoId,
                        principalTable: "Agrupamiento",
                        principalColumn: "AgrupamientoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServicioAgrupamiento_Servicio_ServicioId",
                        column: x => x.ServicioId,
                        principalTable: "Servicio",
                        principalColumn: "ServicioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpcionUsuario",
                columns: table => new
                {
                    OpcionUsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
                    OpcionId = table.Column<int>(type: "int", nullable: true),
                    FlagActivo = table.Column<bool>(type: "bit", nullable: false),
                    FlagEliminado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpcionUsuario", x => x.OpcionUsuarioId);
                    table.ForeignKey(
                        name: "FK_OpcionUsuario_Opcion_OpcionId",
                        column: x => x.OpcionId,
                        principalTable: "Opcion",
                        principalColumn: "OpcionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OpcionUsuario_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioPerfil",
                columns: table => new
                {
                    UsuarioPerfilId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    PerfilId = table.Column<int>(type: "int", nullable: false),
                    FlagActivo = table.Column<bool>(type: "bit", nullable: false),
                    FlagEliminado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioPerfil", x => x.UsuarioPerfilId);
                    table.ForeignKey(
                        name: "FK_UsuarioPerfil_Perfil_PerfilId",
                        column: x => x.PerfilId,
                        principalTable: "Perfil",
                        principalColumn: "PerfilId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioPerfil_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioSede",
                columns: table => new
                {
                    UsuarioSedeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    CentroSaludOrigenId = table.Column<int>(type: "int", nullable: false),
                    CentroSaludAsistencialId = table.Column<int>(type: "int", nullable: false),
                    FlagActivo = table.Column<bool>(type: "bit", nullable: false),
                    FlagEliminado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioSede", x => x.UsuarioSedeId);
                    table.ForeignKey(
                        name: "FK_UsuarioSede_CentroSaludAsistencial_CentroSaludAsistencialId",
                        column: x => x.CentroSaludAsistencialId,
                        principalTable: "CentroSaludAsistencial",
                        principalColumn: "CentroSaludAsistencialId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioSede_CentroSaludOrigen_CentroSaludOrigenId",
                        column: x => x.CentroSaludOrigenId,
                        principalTable: "CentroSaludOrigen",
                        principalColumn: "CentroSaludOrigenId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsuarioSede_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServicioInterfaz",
                columns: table => new
                {
                    ServicioInterfazId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServicioId = table.Column<int>(type: "int", nullable: false),
                    EquipoId = table.Column<int>(type: "int", nullable: false),
                    CodigoInterfaz = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: true),
                    FlagActivo = table.Column<bool>(type: "bit", nullable: false),
                    FlagEliminado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicioInterfaz", x => x.ServicioInterfazId);
                    table.ForeignKey(
                        name: "FK_ServicioInterfaz_Equipo_EquipoId",
                        column: x => x.EquipoId,
                        principalTable: "Equipo",
                        principalColumn: "EquipoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServicioInterfaz_Servicio_ServicioId",
                        column: x => x.ServicioId,
                        principalTable: "Servicio",
                        principalColumn: "ServicioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParametroEquipo",
                columns: table => new
                {
                    ParametroEquipoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    EquipoId = table.Column<int>(type: "int", nullable: false),
                    ParametroInterfazId = table.Column<int>(type: "int", nullable: true),
                    FlagActivo = table.Column<bool>(type: "bit", nullable: false),
                    FlagEliminado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParametroEquipo", x => x.ParametroEquipoId);
                    table.ForeignKey(
                        name: "FK_ParametroEquipo_Equipo_EquipoId",
                        column: x => x.EquipoId,
                        principalTable: "Equipo",
                        principalColumn: "EquipoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParametroEquipo_ParametroInterfaz_ParametroInterfazId",
                        column: x => x.ParametroInterfazId,
                        principalTable: "ParametroInterfaz",
                        principalColumn: "ParametroInterfazId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PaqueteConexion",
                columns: table => new
                {
                    PaqueteConexionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaqueteId = table.Column<int>(type: "int", nullable: false),
                    CodigoConexion = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: true),
                    FlagActivo = table.Column<bool>(type: "bit", nullable: false),
                    FlagEliminado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaqueteConexion", x => x.PaqueteConexionId);
                    table.ForeignKey(
                        name: "FK_PaqueteConexion_Paquete_PaqueteId",
                        column: x => x.PaqueteId,
                        principalTable: "Paquete",
                        principalColumn: "PaqueteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaqueteEquipo",
                columns: table => new
                {
                    PaqueteEquipoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipoId = table.Column<int>(type: "int", nullable: false),
                    PaqueteId = table.Column<int>(type: "int", nullable: false),
                    FlagActivo = table.Column<bool>(type: "bit", nullable: false),
                    FlagEliminado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaqueteEquipo", x => x.PaqueteEquipoId);
                    table.ForeignKey(
                        name: "FK_PaqueteEquipo_Equipo_EquipoId",
                        column: x => x.EquipoId,
                        principalTable: "Equipo",
                        principalColumn: "EquipoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaqueteEquipo_Paquete_PaqueteId",
                        column: x => x.PaqueteId,
                        principalTable: "Paquete",
                        principalColumn: "PaqueteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaqueteServicio",
                columns: table => new
                {
                    PaqueteServicioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServicioId = table.Column<int>(type: "int", nullable: false),
                    PaqueteId = table.Column<int>(type: "int", nullable: false),
                    FlagActivo = table.Column<bool>(type: "bit", nullable: false),
                    FlagEliminado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaqueteServicio", x => x.PaqueteServicioId);
                    table.ForeignKey(
                        name: "FK_PaqueteServicio_Paquete_PaqueteId",
                        column: x => x.PaqueteId,
                        principalTable: "Paquete",
                        principalColumn: "PaqueteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaqueteServicio_Servicio_ServicioId",
                        column: x => x.ServicioId,
                        principalTable: "Servicio",
                        principalColumn: "ServicioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orden",
                columns: table => new
                {
                    OrdenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    FechaEmision = table.Column<DateTime>(type: "DATE", nullable: false),
                    MedicoId = table.Column<int>(type: "int", nullable: true),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    TipoOrdenId = table.Column<int>(type: "int", nullable: false),
                    EstadoOrdenId = table.Column<int>(type: "int", nullable: true),
                    NroHistoriaClinica = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: true),
                    HISNumero = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    CentroSaludOrigenId = table.Column<int>(type: "int", nullable: true),
                    CentroSaludAsistencialId = table.Column<int>(type: "int", nullable: true),
                    NroCama = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: true),
                    Diagnostico = table.Column<string>(type: "NVARCHAR(500)", maxLength: 500, nullable: true),
                    ServicioSaludId = table.Column<int>(type: "int", nullable: true),
                    ProcedenciaId = table.Column<int>(type: "int", nullable: true),
                    TipoAtencionId = table.Column<int>(type: "int", nullable: true),
                    TipoPacienteId = table.Column<int>(type: "int", nullable: true),
                    FlagActivo = table.Column<bool>(type: "bit", nullable: false),
                    FlagEliminado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orden", x => x.OrdenId);
                    table.ForeignKey(
                        name: "FK_Orden_CentroSaludAsistencial_CentroSaludAsistencialId",
                        column: x => x.CentroSaludAsistencialId,
                        principalTable: "CentroSaludAsistencial",
                        principalColumn: "CentroSaludAsistencialId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orden_CentroSaludOrigen_CentroSaludOrigenId",
                        column: x => x.CentroSaludOrigenId,
                        principalTable: "CentroSaludOrigen",
                        principalColumn: "CentroSaludOrigenId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orden_Medico_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medico",
                        principalColumn: "MedicoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orden_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Paciente",
                        principalColumn: "PacienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orden_Procedencia_ProcedenciaId",
                        column: x => x.ProcedenciaId,
                        principalTable: "Procedencia",
                        principalColumn: "ProcedenciaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orden_ServicioSalud_ServicioSaludId",
                        column: x => x.ServicioSaludId,
                        principalTable: "ServicioSalud",
                        principalColumn: "ServicioSaludId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orden_TipoOrden_TipoOrdenId",
                        column: x => x.TipoOrdenId,
                        principalTable: "TipoOrden",
                        principalColumn: "TipoOrdenId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orden_TipoPaciente_TipoPacienteId",
                        column: x => x.TipoPacienteId,
                        principalTable: "TipoPaciente",
                        principalColumn: "TipoPacienteId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrazabilidadAcceso",
                columns: table => new
                {
                    TrazabilidadAccesoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaIniVigencia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFinVigencia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FlagActivo = table.Column<bool>(type: "bit", nullable: false),
                    FlagEliminado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrazabilidadAcceso", x => x.TrazabilidadAccesoId);
                    table.ForeignKey(
                        name: "FK_TrazabilidadAcceso_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Paciente",
                        principalColumn: "PacienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrazabilidadServicio",
                columns: table => new
                {
                    TrazabilidadServicioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    ServicioId = table.Column<int>(type: "int", nullable: false),
                    TrazabilidadAnno = table.Column<int>(type: "int", nullable: false),
                    TrazabilidadMes = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: true),
                    FlagActivo = table.Column<bool>(type: "bit", nullable: false),
                    FlagEliminado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrazabilidadServicio", x => x.TrazabilidadServicioId);
                    table.ForeignKey(
                        name: "FK_TrazabilidadServicio_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Paciente",
                        principalColumn: "PacienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrazabilidadServicio_Servicio_ServicioId",
                        column: x => x.ServicioId,
                        principalTable: "Servicio",
                        principalColumn: "ServicioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdenServicioCalculado",
                columns: table => new
                {
                    OrdenServicioCalculadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdenServicioFormulaId = table.Column<int>(type: "int", nullable: false),
                    ServicioId = table.Column<int>(type: "int", nullable: false),
                    Codigo = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: true),
                    TipoMuestraAnalizadorId = table.Column<int>(type: "int", nullable: false),
                    FlagActivo = table.Column<bool>(type: "bit", nullable: false),
                    FlagEliminado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenServicioCalculado", x => x.OrdenServicioCalculadoId);
                    table.ForeignKey(
                        name: "FK_OrdenServicioCalculado_OrdenServicioFormula_OrdenServicioFormulaId",
                        column: x => x.OrdenServicioFormulaId,
                        principalTable: "OrdenServicioFormula",
                        principalColumn: "OrdenServicioFormulaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdenServicioCalculado_Servicio_ServicioId",
                        column: x => x.ServicioId,
                        principalTable: "Servicio",
                        principalColumn: "ServicioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ParametroCalculado",
                columns: table => new
                {
                    ParametroCalculadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServicioId = table.Column<int>(type: "int", nullable: false),
                    PaqueteEquipoId = table.Column<int>(type: "int", nullable: false),
                    ModificadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParametroCalculado", x => x.ParametroCalculadoId);
                    table.ForeignKey(
                        name: "FK_ParametroCalculado_PaqueteEquipo_PaqueteEquipoId",
                        column: x => x.PaqueteEquipoId,
                        principalTable: "PaqueteEquipo",
                        principalColumn: "PaqueteEquipoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParametroCalculado_Servicio_ServicioId",
                        column: x => x.ServicioId,
                        principalTable: "Servicio",
                        principalColumn: "ServicioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdenPaquete",
                columns: table => new
                {
                    OrdenPaqueteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdenId = table.Column<int>(type: "int", nullable: false),
                    PaqueteId = table.Column<int>(type: "int", nullable: false),
                    FechaEnvio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaProcesamiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstadoOrdenPaqueteId = table.Column<int>(type: "int", nullable: true),
                    EquipoId = table.Column<int>(type: "int", nullable: true),
                    InformeResultado = table.Column<string>(type: "NVARCHAR(500)", maxLength: 500, nullable: true),
                    NroOrden = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: true),
                    UsuarioApruebaId = table.Column<int>(type: "int", nullable: true),
                    FechaAprobacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioInterface = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    FlagActivo = table.Column<bool>(type: "bit", nullable: false),
                    FlagEliminado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenPaquete", x => x.OrdenPaqueteId);
                    table.ForeignKey(
                        name: "FK_OrdenPaquete_Equipo_EquipoId",
                        column: x => x.EquipoId,
                        principalTable: "Equipo",
                        principalColumn: "EquipoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenPaquete_Orden_OrdenId",
                        column: x => x.OrdenId,
                        principalTable: "Orden",
                        principalColumn: "OrdenId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdenPaquete_Paquete_PaqueteId",
                        column: x => x.PaqueteId,
                        principalTable: "Paquete",
                        principalColumn: "PaqueteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SGSSSolExaLab",
                columns: table => new
                {
                    SGSSSolExaLabId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SolEqpOriCenAsiCod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolEqpCenAsiCod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolEqpTipExaCod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolEqpExaNum = table.Column<decimal>(type: "decimal(10,0)", precision: 10, scale: 0, nullable: false),
                    SolEqpProEqLCod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolEqpSolExaFec = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SolEqpOrdCod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolEqpTipDocIdenPerCod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolEqpPerAsisDocIden = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolEqpProColCod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolEqpProApePat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolEqpProApeMat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolEqpProPriNom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolEqpProSegNom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolEqpPacTipDocIdenCod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolEqpPacDocIdenNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolEqpPacApePat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolEqpPacApeMat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolEqpPacPriNom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolEqpPacSegNom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolEqpPacHisCliNum = table.Column<decimal>(type: "decimal(10,0)", precision: 10, scale: 0, nullable: true),
                    SolEqpPacAutCod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolEqpPacSexCod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolEqpPacNacFec = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SolEqpPacEdad = table.Column<decimal>(type: "decimal(3,0)", precision: 3, scale: 0, nullable: true),
                    SolEqpPacEstCivCod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolEqpPacTelFij = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolEqpPacTelCel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolEqpPacFamTel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolEqpAreHosCod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolEqpSerHosCod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolEqpEmeCod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolEqpTopEmeCod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolEqpEstEnfCod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolEqpHabCod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolEqpCamCod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolEqpCenQuiCod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolEqpSalOpeCod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolEqpSisCod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolEqpDirIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolEqpUsuCreCod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolEqpCreFec = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolFlgExito = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolFlgTransferencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrdenId = table.Column<int>(type: "int", nullable: true),
                    EstadoProcesoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SGSSSolExaLab", x => x.SGSSSolExaLabId);
                    table.ForeignKey(
                        name: "FK_SGSSSolExaLab_Orden_OrdenId",
                        column: x => x.OrdenId,
                        principalTable: "Orden",
                        principalColumn: "OrdenId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrdenPaqueteAcceso",
                columns: table => new
                {
                    OrdenPaqueteAccesoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdenId = table.Column<int>(type: "int", nullable: false),
                    OrdenPaqueteId = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaIniVigencia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFinVigencia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FlagActivo = table.Column<bool>(type: "bit", nullable: false),
                    FlagEliminado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenPaqueteAcceso", x => x.OrdenPaqueteAccesoId);
                    table.ForeignKey(
                        name: "FK_OrdenPaqueteAcceso_Orden_OrdenId",
                        column: x => x.OrdenId,
                        principalTable: "Orden",
                        principalColumn: "OrdenId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdenPaqueteAcceso_OrdenPaquete_OrdenPaqueteId",
                        column: x => x.OrdenPaqueteId,
                        principalTable: "OrdenPaquete",
                        principalColumn: "OrdenPaqueteId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrdenPaqueteDetalle",
                columns: table => new
                {
                    OrdenPaqueteDetalleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdenPaqueteId = table.Column<int>(type: "int", nullable: false),
                    OrdenId = table.Column<int>(type: "int", nullable: true),
                    ServicioId = table.Column<int>(type: "int", nullable: false),
                    ResultadoAutomatizado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoServicioId = table.Column<int>(type: "int", nullable: true),
                    FechaResultado = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CodigoUnico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoUnicoExamen = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: true),
                    ValorReferencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EvaluacionPrueba = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaProcesaInterface = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Indicador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorUnidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacion = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: true),
                    FlagEnvioSE = table.Column<bool>(type: "bit", nullable: true),
                    FlagResultadoEnvioSE = table.Column<bool>(type: "bit", nullable: true),
                    FlagActivo = table.Column<bool>(type: "bit", nullable: false),
                    FlagEliminado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenPaqueteDetalle", x => x.OrdenPaqueteDetalleId);
                    table.ForeignKey(
                        name: "FK_OrdenPaqueteDetalle_Orden_OrdenId",
                        column: x => x.OrdenId,
                        principalTable: "Orden",
                        principalColumn: "OrdenId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenPaqueteDetalle_OrdenPaquete_OrdenPaqueteId",
                        column: x => x.OrdenPaqueteId,
                        principalTable: "OrdenPaquete",
                        principalColumn: "OrdenPaqueteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdenPaqueteDetalle_Servicio_ServicioId",
                        column: x => x.ServicioId,
                        principalTable: "Servicio",
                        principalColumn: "ServicioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdenPaqueteImagenes",
                columns: table => new
                {
                    OrdenPaqueteImagenesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdenId = table.Column<int>(type: "int", nullable: false),
                    OrdenPaqueteId = table.Column<int>(type: "int", nullable: false),
                    RBCHistograma = table.Column<byte[]>(type: "image", nullable: true),
                    PLTHistograma = table.Column<byte[]>(type: "image", nullable: true),
                    WBCHistograma = table.Column<byte[]>(type: "image", nullable: true),
                    S0Histograma = table.Column<byte[]>(type: "image", nullable: true),
                    S10DIFFScattergram = table.Column<byte[]>(type: "image", nullable: true),
                    S90DDIFFScattergram = table.Column<byte[]>(type: "image", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenPaqueteImagenes", x => x.OrdenPaqueteImagenesId);
                    table.ForeignKey(
                        name: "FK_OrdenPaqueteImagenes_Orden_OrdenId",
                        column: x => x.OrdenId,
                        principalTable: "Orden",
                        principalColumn: "OrdenId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdenPaqueteImagenes_OrdenPaquete_OrdenPaqueteId",
                        column: x => x.OrdenPaqueteId,
                        principalTable: "OrdenPaquete",
                        principalColumn: "OrdenPaqueteId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrdenPaqueteTramas",
                columns: table => new
                {
                    OrdenPaqueteTramasId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdenId = table.Column<int>(type: "int", nullable: false),
                    OrdenPaqueteId = table.Column<int>(type: "int", nullable: false),
                    TramaEnvio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TramaResultado = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenPaqueteTramas", x => x.OrdenPaqueteTramasId);
                    table.ForeignKey(
                        name: "FK_OrdenPaqueteTramas_Orden_OrdenId",
                        column: x => x.OrdenId,
                        principalTable: "Orden",
                        principalColumn: "OrdenId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdenPaqueteTramas_OrdenPaquete_OrdenPaqueteId",
                        column: x => x.OrdenPaqueteId,
                        principalTable: "OrdenPaquete",
                        principalColumn: "OrdenPaqueteId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GalenoSolExaLab",
                columns: table => new
                {
                    GalenoSolExaLabId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SGSSSolExaLabId = table.Column<int>(type: "int", nullable: false),
                    FechaMovimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumMovimiento = table.Column<int>(type: "int", nullable: false),
                    NumCuenta = table.Column<int>(type: "int", nullable: false),
                    FinanciamientoId = table.Column<int>(type: "int", nullable: false),
                    Financiamiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumOrden = table.Column<int>(type: "int", nullable: false),
                    TipoId = table.Column<int>(type: "int", nullable: true),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServicioId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Servicio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ubigeo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumHistoriaPac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumDocumentoPac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApePatPac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApeMatPac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombresPac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FecNacimientoPac = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SexoPac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CMPMedico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApePatMedico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApeMatMedico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombresMedico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrdenId = table.Column<int>(type: "int", nullable: true),
                    EstadoProcesoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GalenoSolExaLab", x => x.GalenoSolExaLabId);
                    table.ForeignKey(
                        name: "FK_GalenoSolExaLab_Orden_OrdenId",
                        column: x => x.OrdenId,
                        principalTable: "Orden",
                        principalColumn: "OrdenId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GalenoSolExaLab_SGSSSolExaLab_SGSSSolExaLabId",
                        column: x => x.SGSSSolExaLabId,
                        principalTable: "SGSSSolExaLab",
                        principalColumn: "SGSSSolExaLabId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SGSSSolExaLabCPS",
                columns: table => new
                {
                    SGSSSolExaLabCPSId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SGSSSolExaLabId = table.Column<int>(type: "int", nullable: false),
                    SolEqpOriCenAsiCod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolEqpCenAsiCod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolEqpTipExaCod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolEqpExaNum = table.Column<decimal>(type: "decimal(10,0)", precision: 10, scale: 0, nullable: false),
                    SolEqpCPSCod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolEqpMueCod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolEqpSedExaCod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolEqpAreExaCod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResEqpTomaFec = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResEqpTomaHor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolEqpProvCod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolEqpFlgTransEqp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrdenId = table.Column<int>(type: "int", nullable: true),
                    OrdenPaqueteId = table.Column<int>(type: "int", nullable: true),
                    EstadoProcesoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SGSSSolExaLabCPS", x => x.SGSSSolExaLabCPSId);
                    table.ForeignKey(
                        name: "FK_SGSSSolExaLabCPS_Orden_OrdenId",
                        column: x => x.OrdenId,
                        principalTable: "Orden",
                        principalColumn: "OrdenId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SGSSSolExaLabCPS_OrdenPaquete_OrdenPaqueteId",
                        column: x => x.OrdenPaqueteId,
                        principalTable: "OrdenPaquete",
                        principalColumn: "OrdenPaqueteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SGSSSolExaLabCPS_SGSSSolExaLab_SGSSSolExaLabId",
                        column: x => x.SGSSSolExaLabId,
                        principalTable: "SGSSSolExaLab",
                        principalColumn: "SGSSSolExaLabId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GalenoSolExaLabDet",
                columns: table => new
                {
                    GalenoSolExaLabDetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GalenoSolExaLabId = table.Column<int>(type: "int", nullable: false),
                    NumMovimiento = table.Column<int>(type: "int", nullable: false),
                    NumCuenta = table.Column<int>(type: "int", nullable: false),
                    FinanciamientoId = table.Column<int>(type: "int", nullable: false),
                    NumOrden = table.Column<int>(type: "int", nullable: false),
                    CodigoCPT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescripcionCPT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaProgramada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstadoProcesoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GalenoSolExaLabDet", x => x.GalenoSolExaLabDetId);
                    table.ForeignKey(
                        name: "FK_GalenoSolExaLabDet_GalenoSolExaLab_GalenoSolExaLabId",
                        column: x => x.GalenoSolExaLabId,
                        principalTable: "GalenoSolExaLab",
                        principalColumn: "GalenoSolExaLabId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agrupamiento_AreaEstudioId",
                table: "Agrupamiento",
                column: "AreaEstudioId");

            migrationBuilder.CreateIndex(
                name: "IX_CentroSaludAsistencial_CentroSaludOrigenId",
                table: "CentroSaludAsistencial",
                column: "CentroSaludOrigenId");

            migrationBuilder.CreateIndex(
                name: "IX_ContenidoEstaticoIdioma_ContenidoEstaticoId",
                table: "ContenidoEstaticoIdioma",
                column: "ContenidoEstaticoId");

            migrationBuilder.CreateIndex(
                name: "IX_ContenidoEstaticoIdioma_IdiomaId",
                table: "ContenidoEstaticoIdioma",
                column: "IdiomaId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipo_AreaEstudioId",
                table: "Equipo",
                column: "AreaEstudioId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipo_TipoInterfazId",
                table: "Equipo",
                column: "TipoInterfazId");

            migrationBuilder.CreateIndex(
                name: "IX_GalenoSolExaLab_OrdenId",
                table: "GalenoSolExaLab",
                column: "OrdenId");

            migrationBuilder.CreateIndex(
                name: "IX_GalenoSolExaLab_SGSSSolExaLabId",
                table: "GalenoSolExaLab",
                column: "SGSSSolExaLabId");

            migrationBuilder.CreateIndex(
                name: "IX_GalenoSolExaLabDet_GalenoSolExaLabId",
                table: "GalenoSolExaLabDet",
                column: "GalenoSolExaLabId");

            migrationBuilder.CreateIndex(
                name: "IX_Medico_TipoDocumentoId",
                table: "Medico",
                column: "TipoDocumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_OpcionPerfil_OpcionId",
                table: "OpcionPerfil",
                column: "OpcionId");

            migrationBuilder.CreateIndex(
                name: "IX_OpcionPerfil_PerfilId",
                table: "OpcionPerfil",
                column: "PerfilId");

            migrationBuilder.CreateIndex(
                name: "IX_OpcionUsuario_OpcionId",
                table: "OpcionUsuario",
                column: "OpcionId");

            migrationBuilder.CreateIndex(
                name: "IX_OpcionUsuario_UsuarioId",
                table: "OpcionUsuario",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_CentroSaludAsistencialId",
                table: "Orden",
                column: "CentroSaludAsistencialId");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_CentroSaludOrigenId",
                table: "Orden",
                column: "CentroSaludOrigenId");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_MedicoId",
                table: "Orden",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_PacienteId",
                table: "Orden",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_ProcedenciaId",
                table: "Orden",
                column: "ProcedenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_ServicioSaludId",
                table: "Orden",
                column: "ServicioSaludId");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_TipoOrdenId",
                table: "Orden",
                column: "TipoOrdenId");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_TipoPacienteId",
                table: "Orden",
                column: "TipoPacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenPaquete_EquipoId",
                table: "OrdenPaquete",
                column: "EquipoId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenPaquete_OrdenId",
                table: "OrdenPaquete",
                column: "OrdenId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenPaquete_PaqueteId",
                table: "OrdenPaquete",
                column: "PaqueteId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenPaqueteAcceso_OrdenId",
                table: "OrdenPaqueteAcceso",
                column: "OrdenId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenPaqueteAcceso_OrdenPaqueteId",
                table: "OrdenPaqueteAcceso",
                column: "OrdenPaqueteId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenPaqueteDetalle_OrdenId",
                table: "OrdenPaqueteDetalle",
                column: "OrdenId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenPaqueteDetalle_OrdenPaqueteId",
                table: "OrdenPaqueteDetalle",
                column: "OrdenPaqueteId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenPaqueteDetalle_ServicioId",
                table: "OrdenPaqueteDetalle",
                column: "ServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenPaqueteImagenes_OrdenId",
                table: "OrdenPaqueteImagenes",
                column: "OrdenId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenPaqueteImagenes_OrdenPaqueteId",
                table: "OrdenPaqueteImagenes",
                column: "OrdenPaqueteId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenPaqueteTramas_OrdenId",
                table: "OrdenPaqueteTramas",
                column: "OrdenId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenPaqueteTramas_OrdenPaqueteId",
                table: "OrdenPaqueteTramas",
                column: "OrdenPaqueteId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenServicioCalculado_OrdenServicioFormulaId",
                table: "OrdenServicioCalculado",
                column: "OrdenServicioFormulaId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenServicioCalculado_ServicioId",
                table: "OrdenServicioCalculado",
                column: "ServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenServicioFormula_ServicioId",
                table: "OrdenServicioFormula",
                column: "ServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_TipoDocumentoId",
                table: "Paciente",
                column: "TipoDocumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_UbigeoId",
                table: "Paciente",
                column: "UbigeoId");

            migrationBuilder.CreateIndex(
                name: "IX_Paquete_AreaEstudioId",
                table: "Paquete",
                column: "AreaEstudioId");

            migrationBuilder.CreateIndex(
                name: "IX_Paquete_TipoMuestraAnalizadorId",
                table: "Paquete",
                column: "TipoMuestraAnalizadorId");

            migrationBuilder.CreateIndex(
                name: "IX_PaqueteConexion_PaqueteId",
                table: "PaqueteConexion",
                column: "PaqueteId");

            migrationBuilder.CreateIndex(
                name: "IX_PaqueteEquipo_EquipoId",
                table: "PaqueteEquipo",
                column: "EquipoId");

            migrationBuilder.CreateIndex(
                name: "IX_PaqueteEquipo_PaqueteId",
                table: "PaqueteEquipo",
                column: "PaqueteId");

            migrationBuilder.CreateIndex(
                name: "IX_PaqueteServicio_PaqueteId",
                table: "PaqueteServicio",
                column: "PaqueteId");

            migrationBuilder.CreateIndex(
                name: "IX_PaqueteServicio_ServicioId",
                table: "PaqueteServicio",
                column: "ServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_ParametroCalculado_PaqueteEquipoId",
                table: "ParametroCalculado",
                column: "PaqueteEquipoId");

            migrationBuilder.CreateIndex(
                name: "IX_ParametroCalculado_ServicioId",
                table: "ParametroCalculado",
                column: "ServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_ParametroEquipo_EquipoId",
                table: "ParametroEquipo",
                column: "EquipoId");

            migrationBuilder.CreateIndex(
                name: "IX_ParametroEquipo_ParametroInterfazId",
                table: "ParametroEquipo",
                column: "ParametroInterfazId");

            migrationBuilder.CreateIndex(
                name: "IX_ParametroInterfaz_TipoInterfazId",
                table: "ParametroInterfaz",
                column: "TipoInterfazId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicio_AreaEstudioId",
                table: "Servicio",
                column: "AreaEstudioId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicio_MetodoId",
                table: "Servicio",
                column: "MetodoId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicioAgrupamiento_AgrupamientoId",
                table: "ServicioAgrupamiento",
                column: "AgrupamientoId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicioAgrupamiento_ServicioId",
                table: "ServicioAgrupamiento",
                column: "ServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicioInterfaz_EquipoId",
                table: "ServicioInterfaz",
                column: "EquipoId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicioInterfaz_ServicioId",
                table: "ServicioInterfaz",
                column: "ServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_SGSSSolExaLab_OrdenId",
                table: "SGSSSolExaLab",
                column: "OrdenId");

            migrationBuilder.CreateIndex(
                name: "IX_SGSSSolExaLabCPS_OrdenId",
                table: "SGSSSolExaLabCPS",
                column: "OrdenId");

            migrationBuilder.CreateIndex(
                name: "IX_SGSSSolExaLabCPS_OrdenPaqueteId",
                table: "SGSSSolExaLabCPS",
                column: "OrdenPaqueteId");

            migrationBuilder.CreateIndex(
                name: "IX_SGSSSolExaLabCPS_SGSSSolExaLabId",
                table: "SGSSSolExaLabCPS",
                column: "SGSSSolExaLabId");

            migrationBuilder.CreateIndex(
                name: "IX_TrazabilidadAcceso_PacienteId",
                table: "TrazabilidadAcceso",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_TrazabilidadServicio_PacienteId",
                table: "TrazabilidadServicio",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_TrazabilidadServicio_ServicioId",
                table: "TrazabilidadServicio",
                column: "ServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_EspecialidadId",
                table: "Usuario",
                column: "EspecialidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_TipoDocumentoId",
                table: "Usuario",
                column: "TipoDocumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioPerfil_PerfilId",
                table: "UsuarioPerfil",
                column: "PerfilId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioPerfil_UsuarioId",
                table: "UsuarioPerfil",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioSede_CentroSaludAsistencialId",
                table: "UsuarioSede",
                column: "CentroSaludAsistencialId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioSede_CentroSaludOrigenId",
                table: "UsuarioSede",
                column: "CentroSaludOrigenId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioSede_UsuarioId",
                table: "UsuarioSede",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Configuracion");

            migrationBuilder.DropTable(
                name: "ContenidoEstaticoIdioma");

            migrationBuilder.DropTable(
                name: "Correlativo");

            migrationBuilder.DropTable(
                name: "EstadoCivil");

            migrationBuilder.DropTable(
                name: "GalenoSolExaLabDet");

            migrationBuilder.DropTable(
                name: "GeoIp");

            migrationBuilder.DropTable(
                name: "HISEnvioExamen");

            migrationBuilder.DropTable(
                name: "HISEquivPaqueteEquipo");

            migrationBuilder.DropTable(
                name: "HISEquivPaqueteServicio");

            migrationBuilder.DropTable(
                name: "IntEquivPaqueteEquipo");

            migrationBuilder.DropTable(
                name: "LogTransaccion");

            migrationBuilder.DropTable(
                name: "MSSolExaLab");

            migrationBuilder.DropTable(
                name: "MSSolExaLabDet");

            migrationBuilder.DropTable(
                name: "Notificacion");

            migrationBuilder.DropTable(
                name: "OpcionPerfil");

            migrationBuilder.DropTable(
                name: "OpcionUsuario");

            migrationBuilder.DropTable(
                name: "OrdenPaqueteAcceso");

            migrationBuilder.DropTable(
                name: "OrdenPaqueteDetalle");

            migrationBuilder.DropTable(
                name: "OrdenPaqueteImagenes");

            migrationBuilder.DropTable(
                name: "OrdenPaqueteTramas");

            migrationBuilder.DropTable(
                name: "OrdenReporteCorrelativo");

            migrationBuilder.DropTable(
                name: "OrdenServicioCalculado");

            migrationBuilder.DropTable(
                name: "PaqueteConexion");

            migrationBuilder.DropTable(
                name: "PaqueteServicio");

            migrationBuilder.DropTable(
                name: "ParametroCalculado");

            migrationBuilder.DropTable(
                name: "ParametroEquipo");

            migrationBuilder.DropTable(
                name: "ServicioAgrupamiento");

            migrationBuilder.DropTable(
                name: "ServicioInterfaz");

            migrationBuilder.DropTable(
                name: "SGSSSolExaLabCPS");

            migrationBuilder.DropTable(
                name: "TrazabilidadAcceso");

            migrationBuilder.DropTable(
                name: "TrazabilidadServicio");

            migrationBuilder.DropTable(
                name: "UsuarioPerfil");

            migrationBuilder.DropTable(
                name: "UsuarioSede");

            migrationBuilder.DropTable(
                name: "ContenidoEstatico");

            migrationBuilder.DropTable(
                name: "Idioma");

            migrationBuilder.DropTable(
                name: "GalenoSolExaLab");

            migrationBuilder.DropTable(
                name: "Opcion");

            migrationBuilder.DropTable(
                name: "OrdenServicioFormula");

            migrationBuilder.DropTable(
                name: "PaqueteEquipo");

            migrationBuilder.DropTable(
                name: "ParametroInterfaz");

            migrationBuilder.DropTable(
                name: "Agrupamiento");

            migrationBuilder.DropTable(
                name: "OrdenPaquete");

            migrationBuilder.DropTable(
                name: "Perfil");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "SGSSSolExaLab");

            migrationBuilder.DropTable(
                name: "Servicio");

            migrationBuilder.DropTable(
                name: "Equipo");

            migrationBuilder.DropTable(
                name: "Paquete");

            migrationBuilder.DropTable(
                name: "Especialidad");

            migrationBuilder.DropTable(
                name: "Orden");

            migrationBuilder.DropTable(
                name: "Metodo");

            migrationBuilder.DropTable(
                name: "TipoInterfaz");

            migrationBuilder.DropTable(
                name: "AreaEstudio");

            migrationBuilder.DropTable(
                name: "TipoMuestraAnalizador");

            migrationBuilder.DropTable(
                name: "CentroSaludAsistencial");

            migrationBuilder.DropTable(
                name: "Medico");

            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "Procedencia");

            migrationBuilder.DropTable(
                name: "ServicioSalud");

            migrationBuilder.DropTable(
                name: "TipoOrden");

            migrationBuilder.DropTable(
                name: "TipoPaciente");

            migrationBuilder.DropTable(
                name: "CentroSaludOrigen");

            migrationBuilder.DropTable(
                name: "TipoDocumento");

            migrationBuilder.DropTable(
                name: "Ubigeo");
        }
    }
}
