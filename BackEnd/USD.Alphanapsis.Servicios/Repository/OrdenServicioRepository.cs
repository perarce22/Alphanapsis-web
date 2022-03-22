using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USD.Alphanapsis.Data;
using USD.Alphanapsis.Entidades;

namespace USD.Alphanapsis.Servicios.Repository
{
    public class OrdenServicioRepository : IOrdenServicioRepository
    {
        private readonly ApplicationDbContext _bd;
        NLog.Logger logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        public OrdenServicioRepository(ApplicationDbContext bd)
        {
            _bd = bd;
        }

        public ICollection<OrdenPaquete> ListarOrdenServicio(string filtro, bool? estado, int page, int rows, out int nroTotalRegistros)
        {


            {
                try
                {
                    //IRepositorio<OrdenPaquete> rep = new EfRepositorio<OrdenPaquete>(ctx);
                    var lista = (from a in _bd.OrdenPaquete
                                 where (a.FlagActivo == estado || !estado.HasValue)
                                 //&& (string.IsNullOrEmpty(filtro) || a.Nombre.ToUpper().Contains(filtro.ToUpper()))
                                 && a.FlagEliminado == false
                                 orderby a.FechaCreacion ascending
                                 select new
                                 {
                                     a.CreadoPor,
                                     a.FechaCreacion,
                                     a.FechaModificacion,
                                     //FechaResultado = a.FechaResultado,
                                     a.FlagActivo,
                                     a.FlagEliminado,
                                     a.ModificadoPor,
                                     a.OrdenId,
                                     a.OrdenPaqueteId,
                                     //Resultado = a.Resultado,
                                     a.PaqueteId,
                                 });
                    nroTotalRegistros = lista.Count();
                    lista = lista.Skip((page - 1) * rows).Take(rows);
                    var listaFinal = (from a in lista.ToList()
                                      select new OrdenPaquete
                                      {
                                          CreadoPor = a.CreadoPor,
                                          FechaCreacion = a.FechaCreacion,
                                          FechaModificacion = a.FechaModificacion,
                                          //FechaResultado = a.FechaResultado,
                                          FlagActivo = a.FlagActivo,
                                          FlagEliminado = a.FlagEliminado,
                                          ModificadoPor = a.ModificadoPor,
                                          OrdenId = a.OrdenId,
                                          OrdenPaqueteId = a.OrdenPaqueteId,
                                          //Resultado = a.Resultado,
                                          PaqueteId = a.PaqueteId,
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

        public OrdenPaquete ObtenerOrdenServicio(int id)
        {
            try
            {

                {
                    //IRepositorio<OrdenPaquete> rep = new EfRepositorio<OrdenPaquete>(ctx);
                    return _bd.OrdenPaquete.Find(id);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }
        }

        public void EliminaOrdenServicio(int id, bool estado, string usuario)
        {

            {
                try
                {
                    //IRepositorio<OrdenPaquete> rep = new EfRepositorio<OrdenPaquete>(ctx); 
                    var obj = _bd.OrdenPaquete.Find(id);
                    obj.FlagActivo = estado;
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

        public int RegistrarOrdenServicio(OrdenPaquete ordenservicio)
        {

            {
                try
                {
                    //IRepositorio<OrdenPaquete> rep = new EfRepositorio<OrdenPaquete>(ctx);
                    if (ordenservicio.OrdenPaqueteId == 0)
                    {
                        _bd.OrdenPaquete.Add(ordenservicio);
                        _bd.SaveChanges();
                        return ordenservicio.OrdenPaqueteId;
                    }
                    else
                    {
                        var act = _bd.OrdenPaquete.FirstOrDefault(m => m.OrdenPaqueteId == ordenservicio.OrdenPaqueteId); act.CreadoPor = ordenservicio.CreadoPor;
                        act.FechaCreacion = ordenservicio.FechaCreacion;
                        act.FechaModificacion = ordenservicio.FechaModificacion;
                        //act.FechaResultado = ordenservicio.FechaResultado;
                        act.FlagActivo = ordenservicio.FlagActivo;
                        act.FlagEliminado = ordenservicio.FlagEliminado;
                        act.ModificadoPor = ordenservicio.ModificadoPor;
                        act.OrdenId = ordenservicio.OrdenId;
                        act.OrdenPaqueteId = ordenservicio.OrdenPaqueteId;
                        //act.Resultado = ordenservicio.Resultado;
                        act.PaqueteId = ordenservicio.PaqueteId;
                        _bd.SaveChanges();
                        return act.OrdenPaqueteId;
                    }
                }

                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }

        public ICollection<ReportResult> obtenerResultado(int ordenId, int equipoId) //, string nroOrden)
        {

            {
                try
                {

                    object[] parameters = { ordenId, equipoId }; // , nroOrden };
                    //TODO:REVISAR PAP
                    //var datosResultExamen = ctx.Database.SqlQuery<ReportResult>("[sp_Listar_Resultados] {0},{1}", parameters).ToList();
                    //return datosResultExamen;
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
