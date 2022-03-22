using System;
using System.Collections.Generic;
using System.Text;
using USD.Alphanapsis.Data;
using System.Linq;
using USD.Alphanapsis.Entidades;

namespace USD.Alphanapsis.Servicios.Repository
{
    public class TipoPacienteRepository : ITipoPacienteRepository
    {
        private readonly ApplicationDbContext _bd;
        NLog.Logger logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        public TipoPacienteRepository(ApplicationDbContext bd)
        {
            _bd = bd;
        }
        public ICollection<TipoPaciente> ListarTipoPaciente(string filtro, bool? estado, int page, int rows, out int nroTotalRegistros)
        {
            
            {
                try
                {
                    //IRepositorio<TipoPaciente> rep = new EfRepositorio<TipoPaciente>(ctx);
                    var lista = (from a in _bd.TipoPaciente
                                 where (a.FlagActivo == estado || !estado.HasValue)
                                 && (string.IsNullOrEmpty(filtro) || a.Nombre.Contains(filtro.ToUpper()))
                                 && a.FlagEliminado == false
                                 orderby a.Nombre ascending
                                 select new
                                 {
                                     a.TipoPacienteId,
                                     a.Nombre,
                                     a.CreadoPor,
                                     a.FechaCreacion,
                                     a.ModificadoPor,
                                     a.FechaModificacion,
                                     a.FlagActivo
                                 });
                    nroTotalRegistros = lista.Count();

                    lista = lista.Skip((page - 1) * rows).Take(rows);

                    var listaFinal = (from a in lista.ToList()
                                      select new TipoPaciente
                                      {
                                          TipoPacienteId = a.TipoPacienteId,
                                          Nombre = a.Nombre,
                                          CreadoPor = a.CreadoPor,
                                          FechaCreacion = a.FechaCreacion,
                                          ModificadoPor = a.ModificadoPor,
                                          FechaModificacion = a.FechaModificacion,
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

        public TipoPaciente ObtenerTipoPaciente(int id)
        {
            try
            {
                
                {
                    //IRepositorio<TipoPaciente> rep = new EfRepositorio<TipoPaciente>(ctx);
                    return _bd.TipoPaciente.Find(id);
                }
            }
            
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }
        }

        public void EliminaTipoPaciente(int id, string usuario)
        {
            
            {
                try
                {
                    //IRepositorio<TipoPaciente> rep = new EfRepositorio<TipoPaciente>(ctx);
                    var obj = _bd.TipoPaciente.Find(id);
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

        public int RegistrarTipoPaciente(TipoPaciente entidad)
        {
            
            {
                try
                {
                    //IRepositorio<TipoPaciente> rep = new EfRepositorio<TipoPaciente>(ctx);
                    if (entidad.TipoPacienteId == 0)
                    {
                        _bd.TipoPaciente.Add(entidad);
                        _bd.SaveChanges();
                        return entidad.TipoPacienteId;
                    }
                    else
                    {
                        var act = _bd.TipoPaciente.FirstOrDefault(m => m.TipoPacienteId == entidad.TipoPacienteId);
                        act.Nombre = entidad.Nombre;
                        act.TipoPacienteId = entidad.TipoPacienteId;
                        _bd.SaveChanges();
                        return act.TipoPacienteId;
                    }
                } 
                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }

        public ICollection<TipoPaciente> ListarTipoPaciente()
        {

            
            {
                try
                {
                    //IRepositorio<TipoPaciente> rep = new EfRepositorio<TipoPaciente>(ctx);
                    var lista = (from a in _bd.TipoPaciente
                                 where (a.FlagActivo == true)
                                 && a.FlagEliminado == false
                                 orderby a.Nombre ascending
                                 select new
                                 {
                                     a.Nombre,
                                     a.TipoPacienteId,
                                     a.FlagActivo
                                 });

                    var listaFinal = (from a in lista.ToList()
                                      select new TipoPaciente
                                      {
                                          Nombre = a.Nombre,
                                          TipoPacienteId = a.TipoPacienteId,
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

        public TipoPaciente ObtenerTipoPaciente(string codigoHIS)
        {
            try
            {
                
                {
                    //IRepositorio<TipoPaciente> rep = new EfRepositorio<TipoPaciente>(ctx);
                    return _bd.TipoPaciente.FirstOrDefault(o => o.CodigoHIS == codigoHIS);
                }
            } 
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }
        }
    }
}
