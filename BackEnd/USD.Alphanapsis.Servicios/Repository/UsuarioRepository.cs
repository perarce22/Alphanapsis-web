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
    }
}
