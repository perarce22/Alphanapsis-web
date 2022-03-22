using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USD.Alphanapsis.Data;
using USD.Alphanapsis.Dto;
using USD.Alphanapsis.Entidades;
using USD.Alphanapsis.Servicios.IRepository;

namespace USD.Alphanapsis.Servicios.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _bd;
        NLog.Logger logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        public UsuarioRepository(ApplicationDbContext bd)
        {
            _bd = bd;
        }

        public ICollection<UsuarioDto> GetUsuarios()
        {
            try
            {
                var rows = _bd.Usuario.OrderBy(c => c.UsuarioId).ToList();
                var dtos = InitAutoMapper.mapper.Map<List<UsuarioDto>>(rows);
                return dtos;
            }
            catch (Exception ex)
            {

                logger.Error(ex);
                throw ex;
            }
        }

        public UsuarioDto AutenticarUsuario(string username, string password)
        {
            try
            {
                var lista = (from a in _bd.Usuario
                             where (a.FlagActivo == true)
                             && a.FlagEliminado == false
                             && (a.Username.ToUpper() == username.Trim().ToUpper())
                             && (a.Password == password)
                             select new
                             {
                                 a.UsuarioId,
                                 a.Nombres,
                                 a.ApellidoPaterno,
                                 a.ApellidoMaterno,
                                 a.CorreoElectronico,
                                 a.TipoAtencionId,
                                 a.FechaIngreso,
                                 a.FechaCese,
                                 a.FlagActivo,
                                 a.Username
                             });

                var usuario = (from a in lista.ToList()
                               group a by new
                               {
                                   a.UsuarioId,
                                   a.Nombres,
                                   a.ApellidoPaterno,
                                   a.ApellidoMaterno,
                                   a.TipoAtencionId,
                                   a.FechaIngreso,
                                   a.FechaCese,
                                   a.Username,
                                   a.FlagActivo,
                                   a.CorreoElectronico
                               } into grp
                               select new Usuario
                               {
                                   UsuarioId = grp.Key.UsuarioId,
                                   Nombres = grp.Key.Nombres,
                                   ApellidoPaterno = grp.Key.ApellidoPaterno,
                                   ApellidoMaterno = grp.Key.ApellidoMaterno,
                                   TipoAtencionId = grp.Key.TipoAtencionId,
                                   FechaIngreso = grp.Key.FechaIngreso,
                                   FechaCese = grp.Key.FechaCese,
                                   FlagActivo = grp.Key.FlagActivo,
                                   CorreoElectronico = grp.Key.CorreoElectronico,
                                   Username = grp.Key.Username
                               }).ToList().FirstOrDefault();

                return InitAutoMapper.mapper.Map<UsuarioDto>(usuario);

            }
            catch (Exception ex)
            {

                logger.Error(ex);
                throw ex;
            }

        }
        public UsuarioSedeDto ExisteUsuarioSede(int userId, int centroSedeId)
        {
            try
            {


                var userSede = _bd.UsuarioSede.FirstOrDefault(o => o.UsuarioId == userId && o.CentroSaludAsistencialId == centroSedeId && o.FlagActivo == true);
                return InitAutoMapper.mapper.Map<UsuarioSedeDto>(userSede);

            }
            catch (Exception ex)
            {

                logger.Error(ex);
                throw ex;
            }

        }

        public ICollection<Usuario> ListarUsuario(string filtro, bool? estado, int page, int rows, out int nroTotalRegistros)
        {

            
            {
                try
                {
                    var lista = (from a in _bd.Usuario
                                 where (a.FlagActivo == estado || !estado.HasValue) &&
                                       (string.IsNullOrEmpty(filtro) || a.ApellidoMaterno.Contains(filtro.ToUpper()) || a.ApellidoPaterno.Contains(filtro.ToUpper()) ||
                                       a.Nombres.Contains(filtro.ToUpper()) || (a.ApellidoPaterno + " " + a.ApellidoMaterno + " " + a.Nombres).Contains(filtro.ToUpper()))
                                 orderby a.Nombres ascending
                                 select new
                                 {
                                     a.ApellidoMaterno,
                                     a.ApellidoPaterno,
                                     a.CorreoElectronico,
                                     a.CreadoPor,
                                     a.FechaCreacion,
                                     a.FechaModificacion,
                                     a.FlagActivo,
                                     a.FlagEliminado,
                                     a.ModificadoPor,
                                     a.Nombres,
                                     a.Password,
                                     a.Username,
                                     a.UsuarioId,
                                 });
                    nroTotalRegistros = lista.Count();
                    lista = lista.Skip((page - 1) * rows).Take(rows);
                    var listaFinal = (from a in lista.ToList()
                                      select new Usuario
                                      {
                                          ApellidoMaterno = a.ApellidoMaterno,
                                          ApellidoPaterno = a.ApellidoPaterno,
                                          CorreoElectronico = a.CorreoElectronico,
                                          CreadoPor = a.CreadoPor,
                                          FechaCreacion = a.FechaCreacion,
                                          FechaModificacion = a.FechaModificacion,
                                          FlagActivo = a.FlagActivo,
                                          FlagEliminado = a.FlagEliminado,
                                          ModificadoPor = a.ModificadoPor,
                                          Nombres = a.Nombres,
                                          Password = a.Password,
                                          Username = a.Username,
                                          UsuarioId = a.UsuarioId,
                                      }).ToList();
                    return listaFinal;
                }
               
                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }

        public Usuario ObtenerUsuario(int id)
        {
            try
            {
                
                {
                    return _bd.Usuario.Find(id);
                }
            }
           
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }
        }

        public void EliminaUsuario(int id, string usuario)
        {
            
            {
                try
                {
                    var obj = _bd.Usuario.Find(id);
                    obj.FlagActivo = false;
                    obj.FlagEliminado = true;
                    obj.ModificadoPor = usuario;
                    obj.FechaModificacion = DateTime.Now;
                    _bd.SaveChanges();
                }
                
                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }

        public int RegistrarUsuario(UsuarioDto usuario)
        {
            
            {
                try
                {
                    //IRepositorio<Usuario> rep = new EfRepositorio<Usuario>(ctx);
                    if (usuario.UsuarioId == 0)
                    {
                        _bd.Usuario.Add(InitAutoMapper.mapper.Map<Usuario>(usuario));
                        //rep.Insert(usuario);
                        _bd.SaveChanges();
                        var sedes = usuario.Sedes;
                        if (sedes != "" && sedes != null)
                        {
                            string[] sedesArr = usuario.Sedes.Split(',');

                            foreach (string sede in sedesArr)
                            {
                                var sedeId = Convert.ToInt32(sede);

                                var dato = ActualizaUsuarioSede(usuario.UsuarioId, sedeId, usuario.CreadoPor);
                            }
                        }

                        return usuario.UsuarioId;
                    }
                    else
                    {
                        var act = _bd.Usuario.FirstOrDefault(m => m.UsuarioId == usuario.UsuarioId);
                        act.ApellidoMaterno = usuario.ApellidoMaterno;
                        act.ApellidoPaterno = usuario.ApellidoPaterno;
                        act.CorreoElectronico = usuario.CorreoElectronico;
                        act.FechaModificacion = usuario.FechaModificacion;
                        act.ModificadoPor = usuario.ModificadoPor;
                        act.Nombres = usuario.Nombres;
                        act.Username = usuario.Username;
                        act.UsuarioId = usuario.UsuarioId;
                        act.EspecialidadId = usuario.EspecialidadId;
                        act.FechaIngreso = usuario.FechaIngreso;
                        act.FechaCese = usuario.FechaCese;
                        act.CodigoInterno = usuario.CodigoInterno;
                        act.TipoDocumentoId = usuario.TipoDocumentoId;
                        act.NumeroDocumento = usuario.NumeroDocumento;
                        act.TipoAtencionId = usuario.TipoAtencionId;
                        _bd.SaveChanges();

                        var sedes = usuario.Sedes;
                        if (sedes != "" && sedes != null)
                        {
                            string[] sedesArr = sedes.Split(',');

                            UpdateEstado(act.UsuarioId);

                            foreach (var sede in sedesArr)
                            {
                                var sedeId = Convert.ToInt32(sede);

                                var dato = ActualizaUsuarioSede(act.UsuarioId, sedeId, usuario.CreadoPor);
                            }

                        }

                        return act.UsuarioId;
                    }
                }
                 
                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }

        

        public void CambiarContrasena(int id, string password, string usuario)
        {
            
            {
                try
                {
                   

                    var obj = _bd.Usuario.Find(id);

                    obj.ModificadoPor = usuario;
                    obj.FechaModificacion = DateTime.Now;
                    obj.Password = password;
                    _bd.SaveChanges();
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }

            }
        }

        public ICollection<Opcion> ListarOpciones(int usuarioId, string prefijo)
        {
            
            {
                try
                {
                    //IRepositorio<Opcion> repOpcion = new EfRepositorio<Opcion>(ctx);
                    //IRepositorio<OpcionUsuario> repOpcionUsuario = new EfRepositorio<OpcionUsuario>(ctx);

                    //IRepositorio<Idioma> rep = new EfRepositorio<Idioma>(ctx);
                    //IRepositorio<ContenidoEstatico> repContenidoEstatico = new EfRepositorio<ContenidoEstatico>(ctx);
                    //IRepositorio<ContenidoEstaticoIdioma> repContenidoEstaticoIdioma = new EfRepositorio<ContenidoEstaticoIdioma>(ctx);

                    var lista = (from a in _bd.Opcion
                                 join b in _bd.OpcionUsuario on a.OpcionId equals b.OpcionId
                                 join c in _bd.ContenidoEstatico on a.Etiqueta equals c.Campo
                                 join d in _bd.ContenidoEstaticoIdioma on c.ContenidoEstaticoId equals d.ContenidoEstaticoId
                                 join e in _bd.Idioma on d.IdiomaId equals e.IdiomaId
                                 where a.FlagActivo == true && a.FlagEliminado == false &&
                                       b.FlagActivo == true && b.FlagEliminado == false &&
                                       c.FlagActivo == true && d.FlagActivo == true && e.FlagActivo == true &&
                                       b.UsuarioId == usuarioId && e.Prefijo.ToUpper() == prefijo.ToUpper()
                                 select new
                                 {
                                     a.OpcionId,
                                     d.Valor,
                                     a.Url,
                                     a.ParentId,
                                     a.Orden,
                                     a.Icono,
                                     a.FlagActivo,
                                     a.FlagEliminado,
                                 });

                    var resultado = (from a in lista.ToList()
                                     select new Opcion()
                                     {
                                         OpcionId = a.OpcionId,
                                         Etiqueta = a.Valor,
                                         Url = a.Url,
                                         ParentId = a.ParentId,
                                         Orden = a.Orden,
                                         Icono = a.Icono,
                                         FlagActivo = a.FlagActivo,
                                         FlagEliminado = a.FlagEliminado
                                     }).ToList();

                    return resultado;
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }

        public void RegistrarOpcionUsuario(List<int> listaOpciones, int usuarioId, string usuarioActual)
        {
            
            {
                try
                {
                    //IRepositorio<OpcionUsuario> repOpcionUsuario = new EfRepositorio<OpcionUsuario>(ctx);

                    var lista = (from a in _bd.Set<OpcionUsuario>()
                                 where a.UsuarioId == usuarioId &&
                                 a.FlagActivo == true &&
                                 a.FlagEliminado == false
                                 select a.OpcionUsuarioId).ToList();

                    foreach (var opcion in lista)
                    {
                        var obj = _bd.Set<OpcionUsuario>().FirstOrDefault(p => p.OpcionUsuarioId == opcion);
                        obj.FlagActivo = false;
                        obj.FlagEliminado = true;
                        obj.FechaModificacion = DateTime.Now;
                        obj.ModificadoPor = usuarioActual;
                    }
                    if (listaOpciones != null)
                    {
                        foreach (var opcion in listaOpciones)
                        {
                            _bd.Set<OpcionUsuario>().Add(
                                new OpcionUsuario()
                                {
                                    UsuarioId = usuarioId,
                                    OpcionId = opcion,
                                    CreadoPor = usuarioActual,
                                    FechaCreacion = DateTime.Now,
                                    FlagActivo = true,
                                    FlagEliminado = false
                                }
                                );
                        }
                    }
                    _bd.SaveChanges();
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }

        public ICollection<OpcionUsuario> ListarOpcionesUsuario(int usuarioId, out int nroTotalRegistros)
        {
            
            {
                try
                {
                    //IRepositorio<Opcion> repOpcion = new EfRepositorio<Opcion>(ctx);
                    //IRepositorio<OpcionUsuario> repOpcionUsuario = new EfRepositorio<OpcionUsuario>(ctx);

                    var lista1 = (from a in _bd.Opcion
                                  join b in _bd.OpcionUsuario on a.OpcionId equals b.OpcionId.Value
                                  where a.FlagActivo == true &&
                                        a.FlagEliminado == false &&
                                        b.FlagActivo == true &&
                                        b.FlagEliminado == false &&
                                        b.UsuarioId == usuarioId
                                  select new
                                  {
                                      a.OpcionId,
                                      a.Etiqueta,
                                      a.Url,
                                      a.ParentId,
                                      a.Orden,
                                      a.FlagActivo,
                                      a.FlagEliminado,
                                      a.CreadoPor,
                                      a.FechaCreacion,
                                      a.ModificadoPor,
                                      a.FechaModificacion,
                                      b.OpcionUsuarioId
                                  }).ToList().Select(m => new OpcionUsuario()
                                  {
                                      Opcion = new Opcion()
                                      {
                                          OpcionId = m.OpcionId,
                                          Etiqueta = m.Etiqueta,
                                          Url = m.Url,
                                          ParentId = m.ParentId,
                                          Orden = m.Orden,
                                          FlagActivo = m.FlagActivo,
                                          FlagEliminado = m.FlagEliminado,
                                          CreadoPor = m.CreadoPor,
                                          FechaCreacion = m.FechaCreacion,
                                          ModificadoPor = m.ModificadoPor,
                                          FechaModificacion = m.FechaModificacion
                                      },
                                      OpcionUsuarioId = m.OpcionUsuarioId
                                  }).ToList();

                    var lista2 = (from a in _bd.Opcion
                                  where a.FlagActivo == true &&
                                        a.FlagEliminado == false
                                  select new
                                  {
                                      a.OpcionId,
                                      a.Etiqueta,
                                      a.Url,
                                      a.ParentId,
                                      a.Orden,
                                      a.FlagActivo,
                                      a.FlagEliminado,
                                      a.CreadoPor,
                                      a.FechaCreacion,
                                      a.ModificadoPor,
                                      a.FechaModificacion,
                                      OpcionUsuarioId = 0
                                  }).ToList().Select(m => new OpcionUsuario()
                                  {
                                      Opcion = new Opcion()
                                      {
                                          OpcionId = m.OpcionId,
                                          Etiqueta = m.Etiqueta,
                                          Url = m.Url,
                                          ParentId = m.ParentId,
                                          Orden = m.Orden,
                                          FlagActivo = m.FlagActivo,
                                          FlagEliminado = m.FlagEliminado,
                                          CreadoPor = m.CreadoPor,
                                          FechaCreacion = m.FechaCreacion,
                                          ModificadoPor = m.ModificadoPor,
                                          FechaModificacion = m.FechaModificacion
                                      },
                                      OpcionUsuarioId = m.OpcionUsuarioId
                                  }).ToList();


                    var lista3 = lista2.Select(m => new OpcionUsuario()
                    {
                        Opcion = new Opcion()
                        {
                            OpcionId = m.Opcion.OpcionId,
                            Etiqueta = m.Opcion.Etiqueta,
                            Url = m.Opcion.Url,
                            ParentId = m.Opcion.ParentId,
                            Orden = m.Opcion.Orden,
                            FlagActivo = m.Opcion.FlagActivo,
                            FlagEliminado = m.Opcion.FlagEliminado,
                            CreadoPor = m.Opcion.CreadoPor,
                            FechaCreacion = m.Opcion.FechaCreacion,
                            ModificadoPor = m.Opcion.ModificadoPor,
                            FechaModificacion = m.Opcion.FechaModificacion
                        },
                        OpcionUsuarioId = (lista1.Count(p => p.Opcion.OpcionId == m.Opcion.OpcionId))
                    }).ToList();

                    nroTotalRegistros = lista3.Count();
                    return lista3;
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }

        public ICollection<UsuarioSede> ObtenerUsuarioSede(int userId, int centroSedeId)
        {
            
            {

                //IRepositorio<UsuarioSede> rep = new EfRepositorio<UsuarioSede>(ctx);

                var result = (from used in _bd.UsuarioSede
                              where used.UsuarioId == userId && used.FlagActivo == true &&
                                    used.CentroSaludAsistencialId == centroSedeId
                              select new
                              {
                                  used.CentroSaludAsistencialId,
                                  used.CentroSaludOrigenId,
                                  used.UsuarioId
                              }).ToList().Select(o => new UsuarioSede()
                              {
                                  CentroSaludOrigenId = o.CentroSaludOrigenId,
                                  CentroSaludAsistencialId = o.CentroSaludAsistencialId,
                                  UsuarioId = o.UsuarioId
                              });

                return result.ToList();

            }
        }

        

        public bool UpdateEstado(int userId)
        {
            var proc = false;

            
            {

                //IRepositorio<UsuarioSede> rep = new EfRepositorio<UsuarioSede>(ctx);

                var userSedes = (from usede in _bd.UsuarioSede
                                 where usede.UsuarioId == userId
                                 select usede).ToList();

                foreach (var userSede in userSedes)
                {
                    userSede.FlagActivo = false;
                     
                    _bd.SaveChanges();
                }

                proc = true;
            }

            return proc;
        }

        public bool ActualizaUsuarioSede(int userId, int centroSedeId, string creadoPor)
        {
            var proc = false;

            
            {
                //IRepositorio<UsuarioSede> rep = new EfRepositorio<UsuarioSede>(ctx);
                //IRepositorio<CentroSaludAsistencial> repSede = new EfRepositorio<CentroSaludAsistencial>(ctx);

                var userSedes = (from used in _bd.UsuarioSede
                                 where used.UsuarioId == userId
                                 select used).ToList();

                if (userSedes.Where(o => o.CentroSaludAsistencialId == centroSedeId).ToList().Count() == 0)
                {
                    var centroOrigen = _bd.CentroSaludAsistencial.Where(o => o.CentroSaludAsistencialId == centroSedeId).FirstOrDefault();

                    var userSede = new UsuarioSede()
                    {
                        CentroSaludOrigenId = centroOrigen.CentroSaludOrigenId,
                        CentroSaludAsistencialId = centroSedeId,
                        UsuarioId = userId,
                        FlagActivo = true,
                        FlagEliminado = false,
                        CreadoPor = creadoPor,
                        FechaCreacion = DateTime.Now
                    };

                    _bd.UsuarioSede.Add(userSede);
                    _bd.SaveChanges();
                }
                else
                {
                    var userSede = userSedes.FirstOrDefault(o => o.CentroSaludAsistencialId == centroSedeId);
                    userSede.FlagActivo = true;
                    userSede.ModificadoPor = creadoPor;
                    userSede.FechaModificacion = DateTime.Now;
                    _bd.SaveChanges();
                    _bd.SaveChanges();
                }

                proc = true;
            }

            return proc;
        }

        public mvBPAccess ValidationBP(string userName, string userPassw)
        {
            
            {
                try
                {

                    //TODO: REVISAR PAP
                    //object[] parameters = { userName, userPassw };
                    //var datosResultado = _bd.Database.SqlQuery<mvBPAccess>("[sp_mv_ValidarUsuario] {0}, {1}", parameters).FirstOrDefault();

                    //return datosResultado;
                    return null;
                }
                catch (Exception ex)
                {

                    logger.Error(ex);
                    throw ex;
                }
            }
        }

        public mvBPPatient GetPatient(int bpId, int ordenId)
        {
            
            {
                try
                {
                    //TODO: REVISAR PAP
                    //object[] parameters = { bpId, ordenId };
                    //var datosResultado = ctx.Database.SqlQuery<mvBPPatient>("[sp_mv_ObtenerDatosPaciente] {0}, {1}", parameters).FirstOrDefault();

                    //return datosResultado;
                    return null;
                }
                catch (Exception ex)
                {

                    logger.Error(ex);
                    throw ex;
                }
            }
        }
    }
}
