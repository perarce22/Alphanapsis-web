using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using USD.Alphanapsis.Dto;
using USD.Alphanapsis.Entidades;

namespace USD.Alphanapsis.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            InitAutoMapper.Start();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (IMutableEntityType entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.DisplayName());
            }
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Configuracion>().Ignore(a => a.CreadoPor).Ignore(a => a.FechaCreacion).Ignore(a => a.FlagEliminado).Ignore(a => a.FlagActivo);
            modelBuilder.Entity<Equipo>();
            modelBuilder.Entity<Servicio>();
            modelBuilder.Entity<ServicioInterfaz>();
            modelBuilder.Entity<Perfil>();
            modelBuilder.Entity<Usuario>();
            modelBuilder.Entity<UsuarioPerfil>();
            modelBuilder.Entity<TipoDocumento>();
            modelBuilder.Entity<Medico>();
            modelBuilder.Entity<EstadoCivil>();
            modelBuilder.Entity<Ubigeo>().Ignore(a => a.FlagActivo).Ignore(a => a.FlagEliminado).Ignore(a => a.FechaCreacion).Ignore(a => a.CreadoPor);
            modelBuilder.Entity<Orden>();
            modelBuilder.Entity<OrdenPaquete>();
            modelBuilder.Entity<OrdenPaqueteAcceso>().
                 HasOne(s => s.OrdenPaquete)
          .WithMany()
          .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrdenPaqueteDetalle>();
            modelBuilder.Entity<TrazabilidadServicio>();
            modelBuilder.Entity<OrdenPaqueteImagenes>().Ignore(a => a.FlagActivo).Ignore(a => a.FlagEliminado).Ignore(a => a.FechaCreacion).Ignore(a => a.CreadoPor).Ignore(a => a.ModificadoPor).Ignore(a => a.FechaModificacion).
                 HasOne(s => s.OrdenPaquete)
          .WithMany()
          .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrdenPaqueteTramas>().Ignore(a => a.FlagActivo).Ignore(a => a.FlagEliminado).Ignore(a => a.FechaCreacion).Ignore(a => a.CreadoPor).Ignore(a => a.ModificadoPor).Ignore(a => a.FechaModificacion).
                HasOne(s => s.OrdenPaquete)
          .WithMany()
          .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrdenServicioFormula>();
            modelBuilder.Entity<OrdenServicioCalculado>().
                HasOne(s => s.Servicio)
          .WithMany()
          .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TrazabilidadAcceso>();
            modelBuilder.Entity<Paciente>();
            modelBuilder.Entity<Perfil>();
            modelBuilder.Entity<Usuario>();
            modelBuilder.Entity<Opcion>();
            modelBuilder.Entity<OpcionUsuario>();
            modelBuilder.Entity<OpcionPerfil>();
            modelBuilder.Entity<UsuarioPerfil>();
            //modelBuilder.Entity<UsuarioSede>();
            modelBuilder.Entity<UsuarioSede>().ToTable("UsuarioSede")
          .HasOne(s => s.CentroSaludOrigen)
          .WithMany()
          .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TipoOrden>();
            modelBuilder.Entity<TipoDocumento>();
            modelBuilder.Entity<Notificacion>();
            modelBuilder.Entity<Paquete>();
            modelBuilder.Entity<PaqueteEquipo>();
            modelBuilder.Entity<PaqueteServicio>();
            modelBuilder.Entity<PaqueteConexion>();
            modelBuilder.Entity<ParametroEquipo>();
            modelBuilder.Entity<ParametroCalculado>().Ignore(a => a.FlagActivo).Ignore(a => a.FlagEliminado).Ignore(a => a.FechaCreacion).Ignore(a => a.CreadoPor);
            modelBuilder.Entity<ParametroInterfaz>();
            modelBuilder.Entity<TipoInterfaz>();
            modelBuilder.Entity<AreaEstudio>();
            modelBuilder.Entity<Correlativo>();
            modelBuilder.Entity<Especialidad>();
            modelBuilder.Entity<ServicioSalud>();
            modelBuilder.Entity<Procedencia>();
            modelBuilder.Entity<TipoPaciente>();
            modelBuilder.Entity<TipoMuestraAnalizador>();

            modelBuilder.Entity<HISEnvioExamen>().Ignore(a => a.FlagActivo).Ignore(a => a.FlagEliminado).Ignore(a => a.FechaCreacion).Ignore(a => a.CreadoPor).Ignore(a => a.ModificadoPor).Ignore(a => a.FechaModificacion);
            modelBuilder.Entity<HISEquivPaqueteEquipo>().Ignore(a => a.FlagActivo).Ignore(a => a.FlagEliminado).Ignore(a => a.FechaCreacion).Ignore(a => a.CreadoPor).Ignore(a => a.ModificadoPor).Ignore(a => a.FechaModificacion);
            modelBuilder.Entity<HISEquivPaqueteServicio>().Ignore(a => a.FlagActivo).Ignore(a => a.FlagEliminado).Ignore(a => a.FechaCreacion).Ignore(a => a.CreadoPor).Ignore(a => a.ModificadoPor).Ignore(a => a.FechaModificacion);

            modelBuilder.Entity<Idioma>();
            modelBuilder.Entity<ContenidoEstatico>();
            modelBuilder.Entity<ContenidoEstaticoIdioma>();
            modelBuilder.Entity<GeoIp>();

            modelBuilder.Entity<SGSSSolExaLab>().Ignore(a => a.FlagActivo).Ignore(a => a.FlagEliminado).Ignore(a => a.FechaCreacion).Ignore(a => a.CreadoPor).Ignore(a => a.ModificadoPor).Ignore(a => a.FechaModificacion);
            modelBuilder.Entity<SGSSSolExaLab>().Property(x => x.SolEqpExaNum).HasPrecision(10, 0);
            modelBuilder.Entity<SGSSSolExaLab>().Property(x => x.SolEqpPacHisCliNum).HasPrecision(10, 0);
            modelBuilder.Entity<SGSSSolExaLab>().Property(x => x.SolEqpPacEdad).HasPrecision(3, 0);
            modelBuilder.Entity<SGSSSolExaLabCPS>().Ignore(a => a.FlagActivo).Ignore(a => a.FlagEliminado).Ignore(a => a.FechaCreacion).Ignore(a => a.CreadoPor).Ignore(a => a.ModificadoPor).Ignore(a => a.FechaModificacion);
            modelBuilder.Entity<SGSSSolExaLabCPS>().Property(x => x.SolEqpExaNum).HasPrecision(10, 0);
            modelBuilder.Entity<IntEquivPaqueteEquipo>().Ignore(a => a.FlagActivo).Ignore(a => a.FlagEliminado).Ignore(a => a.FechaCreacion).Ignore(a => a.CreadoPor).Ignore(a => a.ModificadoPor).Ignore(a => a.FechaModificacion);

            modelBuilder.Entity<MSSolExaLab>().Ignore(a => a.FlagActivo).Ignore(a => a.FlagEliminado).Ignore(a => a.FechaCreacion).Ignore(a => a.CreadoPor).Ignore(a => a.ModificadoPor).Ignore(a => a.FechaModificacion);
            modelBuilder.Entity<MSSolExaLabDet>().Ignore(a => a.FlagActivo).Ignore(a => a.FlagEliminado).Ignore(a => a.FechaCreacion).Ignore(a => a.CreadoPor).Ignore(a => a.ModificadoPor).Ignore(a => a.FechaModificacion);
            modelBuilder.Entity<OrdenReporteCorrelativo>().Ignore(a => a.FlagActivo).Ignore(a => a.FlagEliminado).Ignore(a => a.FechaCreacion).Ignore(a => a.CreadoPor).Ignore(a => a.ModificadoPor).Ignore(a => a.FechaModificacion);

            modelBuilder.Entity<GalenoSolExaLab>().Ignore(a => a.FlagActivo).Ignore(a => a.FlagEliminado).Ignore(a => a.FechaCreacion).Ignore(a => a.CreadoPor).Ignore(a => a.ModificadoPor).Ignore(a => a.FechaModificacion);
            modelBuilder.Entity<GalenoSolExaLabDet>().Ignore(a => a.FlagActivo).Ignore(a => a.FlagEliminado).Ignore(a => a.FechaCreacion).Ignore(a => a.CreadoPor).Ignore(a => a.ModificadoPor).Ignore(a => a.FechaModificacion);

            modelBuilder.Entity<CentroSaludOrigen>();
            modelBuilder.Entity<CentroSaludAsistencial>();
            modelBuilder.Entity<LogTransaccion>();
            modelBuilder.Entity<Metodo>();
            modelBuilder.Entity<Agrupamiento>();
            modelBuilder.Entity<ServicioAgrupamiento>();

        }
        public DbSet<Configuracion> Configuracion { get; set; }
        public DbSet<Equipo> Equipo { get; set; }
        public DbSet<Servicio> Servicio { get; set; }
        public DbSet<ServicioInterfaz> ServicioInterfaz { get; set; }
        public DbSet<Perfil> Perfil { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<UsuarioPerfil> UsuarioPerfil { get; set; }
        public DbSet<TipoDocumento> TipoDocumento { get; set; }
        public DbSet<Medico> Medico { get; set; }
        public DbSet<EstadoCivil> EstadoCivil { get; set; }
        public DbSet<Ubigeo> Ubigeo { get; set; }
        public DbSet<Orden> Orden { get; set; }
        public DbSet<OrdenPaquete> OrdenPaquete { get; set; }
        public DbSet<OrdenPaqueteAcceso> OrdenPaqueteAcceso { get; set; }
        public DbSet<OrdenPaqueteDetalle> OrdenPaqueteDetalle { get; set; }
        public DbSet<TrazabilidadServicio> TrazabilidadServicio { get; set; }
        public DbSet<OrdenPaqueteImagenes> OrdenPaqueteImagenes { get; set; }
        public DbSet<OrdenPaqueteTramas> OrdenPaqueteTramas { get; set; }
        public DbSet<OrdenServicioFormula> OrdenServicioFormula { get; set; }
        public DbSet<OrdenServicioCalculado> OrdenServicioCalculado { get; set; }
        public DbSet<TrazabilidadAcceso> TrazabilidadAcceso { get; set; }
        public DbSet<Paciente> Paciente { get; set; }  
        public DbSet<Opcion> Opcion { get; set; }
        public DbSet<OpcionUsuario> OpcionUsuario { get; set; }
        public DbSet<OpcionPerfil> OpcionPerfil { get; set; } 
        public DbSet<UsuarioSede> UsuarioSede { get; set; }
        public DbSet<TipoOrden> TipoOrden { get; set; } 
        public DbSet<Notificacion> Notificacion { get; set; }
        public DbSet<Paquete> Paquete { get; set; }
        public DbSet<PaqueteEquipo> PaqueteEquipo { get; set; }
        public DbSet<PaqueteServicio> PaqueteServicio { get; set; }
        public DbSet<PaqueteConexion> PaqueteConexion { get; set; }
        public DbSet<ParametroEquipo> ParametroEquipo { get; set; }
        public DbSet<ParametroCalculado> ParametroCalculado { get; set; }
        public DbSet<ParametroInterfaz> ParametroInterfaz { get; set; }
        public DbSet<TipoInterfaz> TipoInterfaz { get; set; }
        public DbSet<AreaEstudio> AreaEstudio { get; set; }
        public DbSet<Correlativo> Correlativo { get; set; }
        public DbSet<Especialidad> Especialidad { get; set; }
        public DbSet<ServicioSalud> ServicioSalud { get; set; }
        public DbSet<Procedencia> Procedencia { get; set; }
        public DbSet<TipoPaciente> TipoPaciente { get; set; }
        public DbSet<TipoMuestraAnalizador> TipoMuestraAnalizador { get; set; }
        public DbSet<HISEnvioExamen> HISEnvioExamen { get; set; }
        public DbSet<HISEquivPaqueteEquipo> HISEquivPaqueteEquipo { get; set; }
        public DbSet<HISEquivPaqueteServicio> HISEquivPaqueteServicio { get; set; }
        public DbSet<Idioma> Idioma { get; set; }
        public DbSet<ContenidoEstatico> ContenidoEstatico { get; set; }
        public DbSet<ContenidoEstaticoIdioma> ContenidoEstaticoIdioma { get; set; }
        public DbSet<GeoIp> GeoIp { get; set; }
        public DbSet<SGSSSolExaLab> SGSSSolExaLab { get; set; }
        public DbSet<SGSSSolExaLabCPS> SGSSSolExaLabCPS { get; set; }
        public DbSet<IntEquivPaqueteEquipo> IntEquivPaqueteEquipo { get; set; }
        public DbSet<MSSolExaLab> MSSolExaLab { get; set; }
        public DbSet<MSSolExaLabDet> MSSolExaLabDet { get; set; }
        public DbSet<OrdenReporteCorrelativo> OrdenReporteCorrelativo { get; set; }
        public DbSet<GalenoSolExaLab> GalenoSolExaLab { get; set; }
        public DbSet<GalenoSolExaLabDet> GalenoSolExaLabDet { get; set; }
        public DbSet<CentroSaludOrigen> CentroSaludOrigen { get; set; }
        public DbSet<CentroSaludAsistencial> CentroSaludAsistencial { get; set; }
        public DbSet<LogTransaccion> LogTransaccion { get; set; }
        public DbSet<Metodo> Metodo { get; set; }
        public DbSet<Agrupamiento> Agrupamiento { get; set; }
        public DbSet<ServicioAgrupamiento> ServicioAgrupamiento { get; set; }
    }
}
