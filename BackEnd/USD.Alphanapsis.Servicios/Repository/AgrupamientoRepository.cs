using System;
using System.Collections.Generic;
using System.Text;
using USD.Alphanapsis.Data;
using USD.Alphanapsis.Entidades;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using USD.Alphanapsis.Entidades.Custom;
using USD.Alphanapsis.Dto;
using USD.Alphanapsis.Dto.Custom;

namespace USD.Alphanapsis.Servicios.Repository
{
    public class AgrupamientoRepository : IAgrupamientoRepository
    {
        private readonly ApplicationDbContext ctx;
        NLog.Logger logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        public AgrupamientoRepository(ApplicationDbContext bd)
        {
            ctx = bd;
        }

        public void EliminaAgrupamiento(int id, string usuario)
        {

            try
            {
                var obj = ctx.Agrupamiento.Find(id);
                obj.ModificadoPor = usuario;
                obj.FlagEliminado = true;
                obj.FlagActivo = false;
                obj.FechaModificacion = DateTime.Now;
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

        }

        public ICollection<Agrupamiento> ListarAgrupamiento(string filtro, bool? estado, int? areaId, int page, int rows, out int nroTotalRegistros)
        {

            try
            {
                //IRepositorio<Agrupamiento> rep = new EfRepositorio<Agrupamiento>(ctx);
                //IRepositorio<AreaEstudio> repAE = new EfRepositorio<AreaEstudio>(ctx);

                var lista = (from a in ctx.Agrupamiento
                             join b in ctx.AreaEstudio on a.AreaEstudioId equals b.AreaEstudioId into p0
                             from q0 in p0.DefaultIfEmpty()
                             where (a.FlagActivo == estado || !estado.HasValue)
                             && (string.IsNullOrEmpty(filtro) || a.Descripcion.Contains(filtro.ToUpper()))
                             && a.FlagEliminado == false &&
                             (areaId == null || a.AreaEstudioId == areaId)
                             orderby a.Descripcion ascending
                             select new
                             {
                                 a.CreadoPor,
                                 a.Descripcion,
                                 a.Codigo,
                                 a.FechaCreacion,
                                 a.FechaModificacion,
                                 a.FlagActivo,
                                 a.FlagEliminado,
                                 a.ModificadoPor,
                                 a.Nombre,
                                 a.AgrupamientoId,
                                 a.AreaEstudioId,
                                 AreaEstudio = q0.Nombre
                             });
                nroTotalRegistros = lista.Count();
                lista = lista.Skip((page - 1) * rows).Take(rows);
                var listaFinal = (from a in lista.ToList()
                                  select new Agrupamiento
                                  {
                                      CreadoPor = a.CreadoPor,
                                      Descripcion = a.Descripcion,
                                      FechaCreacion = a.FechaCreacion,
                                      FechaModificacion = a.FechaModificacion,
                                      Codigo = a.Codigo,
                                      FlagActivo = a.FlagActivo,
                                      FlagEliminado = a.FlagEliminado,
                                      ModificadoPor = a.ModificadoPor,
                                      //Descripcion = a.Descripcion,
                                      AgrupamientoId = a.AgrupamientoId,
                                      AreaEstudioId = a.AreaEstudioId,
                                      AreaEstudio = new AreaEstudio() { AreaEstudioId = a.AreaEstudioId == null ? 0 : a.AreaEstudioId.Value, Nombre = a.AreaEstudio }
                                  }).ToList();
                return listaFinal;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

        }

        public AgrupamientoDto ObtenerAgrupamiento(int Id)
        {
            try
            {
                //  int? dato = null;
                //IRepositorio<Agrupamiento> rep = new EfRepositorio<Agrupamiento>(ctx);
                var agrupa = ctx.Agrupamiento.Find(Id);
                var dto = InitAutoMapper.mapper.Map<AgrupamientoDto>(agrupa);
                //  agrupa.EsCalculadoId = agrupa.EsCalculado == null ? dato : (agrupa.EsCalculado.Value ? (int)ECalculado.Calculado : (int)ECalculado.NoCalculado);

                var serv = (from a in ctx.Set<ServicioAgrupamiento>()
                            where a.AgrupamientoId == agrupa.AgrupamientoId
                            && a.FlagActivo == true
                            select a).Include("Servicio").ToList();

                dto.Servicios = (from x in serv
                                 select new ComboDto()
                                 {
                                     Id = x.Servicio.ServicioId,
                                     Descripcion = x.Servicio.Descripcion
                                 }).ToList();

                return dto;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }
        }

        public int RegistrarAgrupamiento(AgrupamientoDto agrupa)
        {

            try
            {

                if (agrupa.AgrupamientoId == 0)
                {
                    foreach (var item in agrupa.ServiciosIds)
                    {
                        var serv = (from a in ctx.Set<Servicio>()
                                    where a.ServicioId == item
                                    select a).FirstOrDefault();
                        var paqser = new ServicioAgrupamiento()
                        {
                            Agrupamiento = InitAutoMapper.mapper.Map<Agrupamiento>(agrupa),
                            Servicio = serv,
                            CreadoPor = agrupa.CreadoPor,
                            FechaCreacion = DateTime.Now,
                            FlagActivo = true,
                            FlagEliminado = false
                        };
                        ctx.Set<ServicioAgrupamiento>().Add(paqser);
                    }
                    ctx.SaveChanges();

                }
                else
                {


                    var todos = (from a in ctx.Set<ServicioAgrupamiento>()
                                 where a.AgrupamientoId == agrupa.AgrupamientoId
                                 && a.FlagActivo == true
                                 select a).ToList();

                    var dif = (from b in todos
                               where !agrupa.ServiciosIds.Contains(b.ServicioId)
                               select b).ToList();

                    foreach (var item in dif)
                    {
                        var serv = (from a in ctx.Set<ServicioAgrupamiento>()
                                    where a.ServicioId == item.ServicioId
                                    && a.AgrupamientoId == agrupa.AgrupamientoId
                                    && a.FlagActivo == true
                                    select a).FirstOrDefault();

                        serv.FlagActivo = false;
                        serv.FlagEliminado = true;
                        serv.FechaModificacion = DateTime.Now;
                        serv.ModificadoPor = agrupa.ModificadoPor;

                    }

                    foreach (var item in agrupa.ServiciosIds)
                    {
                        var serv = (from a in ctx.Set<ServicioAgrupamiento>()
                                    where a.ServicioId == item
                                    && a.AgrupamientoId == agrupa.AgrupamientoId
                                    && a.FlagActivo == true
                                    select a).FirstOrDefault();
                        if (serv == null)
                        {
                            var oldservicio = (from a in ctx.Set<Servicio>()
                                               where a.ServicioId == item
                                               select a).FirstOrDefault();
                            var oldpaquete = (from a in ctx.Set<Agrupamiento>()
                                              where a.AgrupamientoId == agrupa.AgrupamientoId
                                              select a).FirstOrDefault();


                            var paqser = new ServicioAgrupamiento()
                            {
                                Agrupamiento = oldpaquete,
                                Servicio = oldservicio,
                                CreadoPor = agrupa.ModificadoPor,
                                FechaCreacion = DateTime.Now,
                                FlagActivo = true,
                                FlagEliminado = false
                            };
                            ctx.Set<ServicioAgrupamiento>().Add(paqser);
                        }
                    }
                    ctx.SaveChanges();


                    //IRepositorio<Agrupamiento> rep = new EfRepositorio<Agrupamiento>(ctx);
                    var act = ctx.Agrupamiento.FirstOrDefault(m => m.AgrupamientoId == agrupa.AgrupamientoId);
                    act.Descripcion = agrupa.Descripcion;
                    act.Nombre = agrupa.Nombre;
                    act.FechaModificacion = agrupa.FechaModificacion;
                    act.ModificadoPor = agrupa.ModificadoPor;
                    act.Descripcion = agrupa.Descripcion;
                    act.Codigo = agrupa.Codigo;
                    act.AgrupamientoId = agrupa.AgrupamientoId;
                    act.AreaEstudioId = agrupa.AreaEstudioId;
                    //act.EsCalculado = agrupa.EsCalculadoId == null ? dato : (paquete.EsCalculadoId == 1 ? true : false);
                    //  act.TipoMuestraId = agrupa.TipoMuestraId;
                    ctx.SaveChanges();
                    return act.AgrupamientoId;

                }

            }
            catch (Exception ex)
            {

                logger.Error(ex);
                throw ex;
            }

            return agrupa.AgrupamientoId;
        }
    }
}
