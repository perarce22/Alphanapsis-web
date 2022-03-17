using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USD.Alphanapsis.Data;
using USD.Alphanapsis.Entidades;

namespace USD.Alphanapsis.Servicios.Repository
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly ApplicationDbContext _bd;
        NLog.Logger logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        public MedicoRepository(ApplicationDbContext bd)
        {
            _bd = bd;
        }

        public ICollection<Medico> ListarMedico(string filtro, bool? estado, int page, int rows, out int nroTotalRegistros)
        {


            {
                try
                {
                    //IRepositorio<Medico> rep = new EfRepositorio<Medico>(ctx);
                    //IRepositorio<TipoDocumento> tip = new EfRepositorio<TipoDocumento>(ctx);
                    var lista = (from a in _bd.Medico
                                 join b in _bd.TipoDocumento on a.TipoDocumentoId equals b.TipoDocumentoId
                                 where (a.FlagActivo == estado || !estado.HasValue) &&
                                       (string.IsNullOrEmpty(filtro) || a.ApellidoMaterno.Contains(filtro.ToUpper()) || a.ApellidoPaterno.Contains(filtro.ToUpper()) ||
                                       a.Nombres.Contains(filtro.ToUpper()) || (a.ApellidoPaterno + " " + a.ApellidoMaterno + " " + a.Nombres).Contains(filtro.ToUpper()))
                                 orderby a.FechaCreacion ascending
                                 select new
                                 {
                                     a.ApellidoMaterno,
                                     a.ApellidoPaterno,
                                     a.Celular,
                                     a.TipoDocumentoId,
                                     a.CodigoInterno,
                                     a.CorreoElectronico,
                                     a.CreadoPor,
                                     a.FechaCreacion,
                                     a.FechaModificacion,
                                     a.FlagActivo,
                                     a.FlagEliminado,
                                     a.MedicoId,
                                     a.ModificadoPor,
                                     a.Nombres,
                                     a.NroColegiatura,
                                     a.Sexo,
                                     a.Telefono,
                                     NombreTipoDocumento = b.Nombre,
                                     a.NumeroDocumento
                                 });
                    nroTotalRegistros = lista.Count();
                    lista = lista.Skip((page - 1) * rows).Take(rows);
                    var listaFinal = (from a in lista.ToList()
                                      select new Medico
                                      {
                                          ApellidoMaterno = a.ApellidoMaterno,
                                          ApellidoPaterno = a.ApellidoPaterno,
                                          Celular = a.Celular,
                                          TipoDocumentoId = a.TipoDocumentoId,
                                          CodigoInterno = a.CodigoInterno,
                                          CorreoElectronico = a.CorreoElectronico,
                                          CreadoPor = a.CreadoPor,
                                          FechaCreacion = a.FechaCreacion,
                                          FechaModificacion = a.FechaModificacion,
                                          FlagActivo = a.FlagActivo,
                                          FlagEliminado = a.FlagEliminado,
                                          MedicoId = a.MedicoId,
                                          ModificadoPor = a.ModificadoPor,
                                          Nombres = a.Nombres,
                                          NroColegiatura = a.NroColegiatura,
                                          NumeroDocumento = a.NumeroDocumento,
                                          Sexo = a.Sexo,
                                          Telefono = a.Telefono,
                                          TipoDocumento = new TipoDocumento()
                                          {
                                              TipoDocumentoId = a.TipoDocumentoId,
                                              Nombre = a.NombreTipoDocumento
                                          }
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
        public ICollection<Medico> BuscarMedico(string filtro)
        {


            {
                try
                {
                    var lista = (from a in _bd.Medico
                                 join b in _bd.TipoDocumento on a.TipoDocumentoId equals b.TipoDocumentoId
                                 where a.FlagActivo == true
                                 && (
                                 a.Nombres.ToUpper().Contains(filtro.ToUpper())
                                 || a.Nombres.ToUpper().Contains(filtro.ToUpper())
                                 || a.ApellidoPaterno.ToUpper().Contains(filtro.ToUpper())
                                 || a.ApellidoMaterno.Contains(filtro)
                                 || a.CodigoInterno.Contains(filtro)
                                 || a.NroColegiatura.Contains(filtro)
                                 || a.NumeroDocumento.Contains(filtro))
                                 orderby a.FechaCreacion ascending
                                 select new
                                 {
                                     a.ApellidoMaterno,
                                     a.ApellidoPaterno,
                                     a.Celular,
                                     a.TipoDocumentoId,
                                     a.CodigoInterno,
                                     a.CorreoElectronico,
                                     a.CreadoPor,
                                     a.FechaCreacion,
                                     a.FechaModificacion,
                                     a.FlagActivo,
                                     a.FlagEliminado,
                                     a.MedicoId,
                                     a.ModificadoPor,
                                     a.Nombres,
                                     a.NroColegiatura,
                                     a.Sexo,
                                     a.Telefono,
                                     NombreTipoDocumento = b.Nombre,
                                     a.NumeroDocumento
                                 });
                    var listaFinal = (from a in lista.ToList()
                                      select new Medico
                                      {
                                          ApellidoMaterno = a.ApellidoMaterno,
                                          ApellidoPaterno = a.ApellidoPaterno,
                                          Celular = a.Celular,
                                          TipoDocumentoId = a.TipoDocumentoId,
                                          CodigoInterno = a.CodigoInterno,
                                          CorreoElectronico = a.CorreoElectronico,
                                          CreadoPor = a.CreadoPor,
                                          FechaCreacion = a.FechaCreacion,
                                          FechaModificacion = a.FechaModificacion,
                                          FlagActivo = a.FlagActivo,
                                          FlagEliminado = a.FlagEliminado,
                                          MedicoId = a.MedicoId,
                                          ModificadoPor = a.ModificadoPor,
                                          Nombres = a.Nombres,
                                          NroColegiatura = a.NroColegiatura,
                                          NumeroDocumento = a.NumeroDocumento,
                                          Sexo = a.Sexo,
                                          Telefono = a.Telefono,
                                          TipoDocumento = new TipoDocumento()
                                          {
                                              TipoDocumentoId = a.TipoDocumentoId,
                                              Nombre = a.NombreTipoDocumento
                                          }
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

        public Medico ObtenerMedico(int id)
        {
            try
            {

                {

                    return _bd.Medico.Find(id);
                }
            }

            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }
        }

        public Medico ObtenerMedico(string nroDocumento)
        {
            try
            {

                {
                    return _bd.Medico.FirstOrDefault(o => o.NumeroDocumento == nroDocumento);

                }
            }

            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }
        }

        public void EliminaMedico(int id, string usuario)
        {

            {
                try
                {

                    var obj = _bd.Medico.Find(id);

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

        public int RegistrarMedico(Medico medico)
        {

            {
                try
                {
                    //IRepositorio<Medico> rep = new EfRepositorio<Medico>(ctx);
                    if (medico.MedicoId == 0)
                    {
                        _bd.Medico.Add(medico);
                        _bd.SaveChanges();
                        return medico.MedicoId;
                    }
                    else
                    {
                        var act = _bd.Medico.FirstOrDefault(m => m.MedicoId == medico.MedicoId); act.ApellidoMaterno = medico.ApellidoMaterno;
                        act.ApellidoPaterno = medico.ApellidoPaterno;
                        act.Celular = medico.Celular;
                        act.TipoDocumentoId = medico.TipoDocumentoId;
                        act.CodigoInterno = medico.CodigoInterno;
                        act.CorreoElectronico = medico.CorreoElectronico;
                        //act.CreadoPor = medico.CreadoPor;
                        //act.FechaCreacion = medico.FechaCreacion;
                        act.FechaModificacion = medico.FechaModificacion;
                        //act.FlagActivo = medico.FlagActivo;
                        //act.FlagEliminado = medico.FlagEliminado;
                        act.MedicoId = medico.MedicoId;
                        act.ModificadoPor = medico.ModificadoPor;
                        act.Nombres = medico.Nombres;
                        act.NroColegiatura = medico.NroColegiatura;
                        act.Sexo = medico.Sexo;
                        act.Telefono = medico.Telefono;
                        _bd.SaveChanges();
                        return act.MedicoId;
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
}
