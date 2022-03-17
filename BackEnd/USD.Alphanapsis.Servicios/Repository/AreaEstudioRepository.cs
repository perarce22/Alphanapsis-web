using System;
using System.Collections.Generic;
using System.Text;
using USD.Alphanapsis.Data;
using USD.Alphanapsis.Dto;
using System.Linq;
using USD.Alphanapsis.Entidades;

namespace USD.Alphanapsis.Servicios.Repository
{
    public class AreaEstudioRepository : IAreaEstudioRepository
    {
        private readonly ApplicationDbContext _bd;
        NLog.Logger logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        public AreaEstudioRepository(ApplicationDbContext bd)
        {
            _bd = bd;
        }

        public ICollection<AreaEstudio> ListarAreaEstudio(string filtro, bool? estado, int page, int rows, out int nroTotalRegistros)
        {


            {
                try
                {
                    //IRepositorio<AreaEstudio> rep = new EfRepositorio<AreaEstudio>(ctx);
                    var lista = (from a in _bd.AreaEstudio
                                 where (a.FlagActivo == estado || !estado.HasValue)
                                 && (string.IsNullOrEmpty(filtro) || a.Nombre.Contains(filtro.ToUpper()))
                                 && a.FlagEliminado == false
                                 orderby a.Nombre ascending
                                 select new
                                 {
                                     a.Nombre,
                                     a.Descripcion,
                                     a.Sigla,
                                     a.AreaEstudioId,
                                     a.CodigoInterno,
                                     a.FlagActivo
                                 });
                    nroTotalRegistros = lista.Count();
                    lista = lista.Skip((page - 1) * rows).Take(rows);
                    var listaFinal = (from a in lista.ToList()
                                      select new AreaEstudio
                                      {
                                          Nombre = a.Nombre,
                                          Descripcion = a.Descripcion,
                                          Sigla = a.Sigla,
                                          AreaEstudioId = a.AreaEstudioId,
                                          CodigoInterno = a.CodigoInterno,
                                          FlagActivo = a.FlagActivo
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

        public AreaEstudio ObtenerAreaEstudio(int id)
        {
            try
            {

                {
                    //IRepositorio<AreaEstudio> rep = new EfRepositorio<AreaEstudio>(ctx);
                    return  (_bd.AreaEstudio.Find(id)) ;
                }
            }
             
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }
        }

        public void EliminaAreaEstudio(int id, string usuario)
        {

            {
                try
                {
                    //IRepositorio<AreaEstudio> rep = new EfRepositorio<AreaEstudio>(ctx);
                    var obj = _bd.AreaEstudio.Find(id);
                    obj.ModificadoPor = usuario;
                    obj.FechaModificacion = DateTime.Now;
                    obj.FlagActivo = false;
                    obj.FlagEliminado = true;
                    _bd.SaveChanges();
                }
                 
                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }

        public int RegistrarAreaEstudio(AreaEstudio areaEstudio)
        {

            {
                try
                {
                    //IRepositorio<AreaEstudio> rep = new EfRepositorio<AreaEstudio>(ctx);
                    if (areaEstudio.AreaEstudioId == 0)
                    {
                        //rep.Insert(areaEstudio); 
                       
                        _bd.AreaEstudio.Add(areaEstudio);
                        _bd.SaveChanges();
                        return areaEstudio.AreaEstudioId;
                    }
                    else
                    {
                        var act = _bd.AreaEstudio.FirstOrDefault(m => m.AreaEstudioId == areaEstudio.AreaEstudioId);
                        act.Nombre = areaEstudio.Nombre;
                        act.Descripcion = areaEstudio.Descripcion;
                        act.Sigla = areaEstudio.Sigla;
                        act.AreaEstudioId = areaEstudio.AreaEstudioId;
                        act.CodigoInterno = areaEstudio.CodigoInterno;
                        act.Reporte = areaEstudio.Reporte;
                        _bd.SaveChanges();
                        return act.AreaEstudioId;
                    }
                }
                
                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }

        public ICollection<AreaEstudio> ListarAreaEstudio()
        {


            {
                try
                {
                    //IRepositorio<AreaEstudio> rep = new EfRepositorio<AreaEstudio>(ctx);
                    var lista = (from a in _bd.AreaEstudio
                                 where (a.FlagActivo == true)
                                 && a.FlagEliminado == false
                                 orderby a.Nombre ascending
                                 select new
                                 {
                                     a.Nombre,
                                     a.Sigla,
                                     a.AreaEstudioId,
                                     a.CodigoInterno,
                                     a.Reporte,
                                     a.FlagActivo
                                 });

                    var listaFinal = (from a in lista.ToList()
                                      select new AreaEstudio
                                      {
                                          Nombre = a.Nombre,
                                          Sigla = a.Sigla,
                                          AreaEstudioId = a.AreaEstudioId,
                                          CodigoInterno = a.CodigoInterno,
                                          Reporte = a.Reporte,
                                          FlagActivo = a.FlagActivo
                                      }).ToList();
                    return (listaFinal);
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
