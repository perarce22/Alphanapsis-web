using System;
using System.Collections.Generic;
using System.Text;
using USD.Alphanapsis.Data;
using USD.Alphanapsis.Entidades;
using System.Linq;
using USD.Alphanapsis.Dto;

namespace USD.Alphanapsis.Servicios.Repository
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly ApplicationDbContext _bd;
        NLog.Logger logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        public PacienteRepository(ApplicationDbContext bd)
        {
            _bd = bd;
        }
        public ICollection<Paciente> ListarPaciente(string filtro, bool? estado, int page, int rows, out int nroTotalRegistros)
        {

            
            {
                try
                {
                    //IRepositorio<Paciente> rep = new EfRepositorio<Paciente>(ctx);
                    var lista = (from a in _bd.Paciente
                                 where (a.FlagActivo == estado || !estado.HasValue) &&
                                       (string.IsNullOrEmpty(filtro) || a.ApellidoMaterno.Contains(filtro.ToUpper()) || a.ApellidoPaterno.Contains(filtro.ToUpper()) ||
                                       a.Nombres.Contains(filtro.ToUpper()) || (a.ApellidoPaterno + " " + a.ApellidoMaterno + " " + a.Nombres).Contains(filtro.ToUpper()))
                                 orderby a.Nombres ascending
                                 select new
                                 {
                                     a.ApellidoMaterno,
                                     a.ApellidoPaterno,
                                     a.Celular,
                                     a.CorreoElectronico,
                                     a.CreadoPor,
                                     a.Direccion,
                                     a.FechaCreacion,
                                     a.FechaModificacion,
                                     a.FechaNacimiento,
                                     a.FlagActivo,
                                     a.FlagEliminado,
                                     a.ModificadoPor,
                                     a.Nombres,
                                     a.NumeroDocumento,
                                     a.PacienteId,
                                     a.Sexo,
                                     a.Telefono,
                                     a.TipoDocumentoId,
                                     a.UbigeoId,
                                 });
                    nroTotalRegistros = lista.Count();
                    lista = lista.Skip((page - 1) * rows).Take(rows);
                    var listaFinal = (from a in lista.ToList()
                                      select new Paciente
                                      {
                                          ApellidoMaterno = a.ApellidoMaterno,
                                          ApellidoPaterno = a.ApellidoPaterno,
                                          Celular = a.Celular,
                                          CorreoElectronico = a.CorreoElectronico,
                                          CreadoPor = a.CreadoPor,
                                          Direccion = a.Direccion,
                                          FechaCreacion = a.FechaCreacion,
                                          FechaModificacion = a.FechaModificacion,
                                          FechaNacimiento = a.FechaNacimiento,
                                          FlagActivo = a.FlagActivo,
                                          FlagEliminado = a.FlagEliminado,
                                          ModificadoPor = a.ModificadoPor,
                                          Nombres = a.Nombres,
                                          NumeroDocumento = a.NumeroDocumento,
                                          PacienteId = a.PacienteId,
                                          Sexo = a.Sexo,
                                          Telefono = a.Telefono,
                                          TipoDocumentoId = a.TipoDocumentoId,
                                          UbigeoId = a.UbigeoId,
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

        public ICollection<Paciente> ListarBuscar(string filtro)
        {

            
            {
                try
                {
                    //IRepositorio<Paciente> rep = new EfRepositorio<Paciente>(ctx);
                    var lista = (from a in _bd.Paciente
                                 where (a.FlagActivo == true)
                                 && (a.Nombres.ToUpper().Contains(filtro.ToUpper())
                                 || a.ApellidoPaterno.ToUpper().Contains(filtro.ToUpper())
                                 || a.ApellidoMaterno.ToUpper().Contains(filtro.ToUpper())
                                 || a.NumeroDocumento.ToUpper().Contains(filtro.ToUpper())
                                 || a.NroAsegurado.ToUpper().Contains(filtro.ToUpper()))
                                 orderby a.Nombres ascending
                                 select new
                                 {
                                     a.ApellidoMaterno,
                                     a.ApellidoPaterno,
                                     a.Celular,
                                     a.CorreoElectronico,
                                     a.CreadoPor,
                                     a.Direccion,
                                     a.FechaCreacion,
                                     a.FechaModificacion,
                                     a.FechaNacimiento,
                                     a.Edad,
                                     a.FlagActivo,
                                     a.FlagEliminado,
                                     a.ModificadoPor,
                                     a.Nombres,
                                     a.NumeroDocumento,
                                     a.NroHistoriaClinica,
                                     a.PacienteId,
                                     a.Sexo,
                                     a.Telefono,
                                     a.TipoDocumentoId,
                                     a.UbigeoId,
                                 });
                    var listaFinal = (from a in lista.ToList()
                                      select new Paciente
                                      {
                                          ApellidoMaterno = a.ApellidoMaterno,
                                          ApellidoPaterno = a.ApellidoPaterno,
                                          Celular = a.Celular,
                                          CorreoElectronico = a.CorreoElectronico,
                                          CreadoPor = a.CreadoPor,
                                          Direccion = a.Direccion,
                                          FechaCreacion = a.FechaCreacion,
                                          FechaModificacion = a.FechaModificacion,
                                          FechaNacimiento = a.FechaNacimiento,
                                          Edad = a.Edad,
                                          FlagActivo = a.FlagActivo,
                                          FlagEliminado = a.FlagEliminado,
                                          ModificadoPor = a.ModificadoPor,
                                          Nombres = a.Nombres,
                                          NumeroDocumento = a.NumeroDocumento,
                                          NroHistoriaClinica = a.NroHistoriaClinica,
                                          PacienteId = a.PacienteId,
                                          Sexo = a.Sexo,
                                          Telefono = a.Telefono,
                                          TipoDocumentoId = a.TipoDocumentoId,
                                          UbigeoId = a.UbigeoId,
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
        public Paciente PacienteBuscar(string dni)
        {

            
            {
                try
                {
                    //IRepositorio<Paciente> rep = new EfRepositorio<Paciente>(ctx);
                    var lista = (from a in _bd.Paciente
                                 where (a.FlagActivo == true)
                                 && a.NumeroDocumento == dni
                                 orderby a.Nombres ascending
                                 select new
                                 {
                                     a.ApellidoMaterno,
                                     a.ApellidoPaterno,
                                     a.Celular,
                                     a.CorreoElectronico,
                                     a.CreadoPor,
                                     a.Direccion,
                                     a.FechaCreacion,
                                     a.FechaModificacion,
                                     a.FechaNacimiento,
                                     a.Edad,
                                     a.FlagActivo,
                                     a.FlagEliminado,
                                     a.ModificadoPor,
                                     a.Nombres,
                                     a.NumeroDocumento,
                                     a.PacienteId,
                                     a.Sexo,
                                     a.Telefono,
                                     a.TipoDocumentoId,
                                     a.UbigeoId,
                                 });
                    var listaFinal = (from a in lista.ToList()
                                      select new Paciente
                                      {
                                          ApellidoMaterno = a.ApellidoMaterno,
                                          ApellidoPaterno = a.ApellidoPaterno,
                                          Celular = a.Celular,
                                          CorreoElectronico = a.CorreoElectronico,
                                          CreadoPor = a.CreadoPor,
                                          Direccion = a.Direccion,
                                          FechaCreacion = a.FechaCreacion,
                                          FechaModificacion = a.FechaModificacion,
                                          FechaNacimiento = a.FechaNacimiento,
                                          Edad = a.Edad,
                                          FlagActivo = a.FlagActivo,
                                          FlagEliminado = a.FlagEliminado,
                                          ModificadoPor = a.ModificadoPor,
                                          Nombres = a.Nombres,
                                          NumeroDocumento = a.NumeroDocumento,
                                          PacienteId = a.PacienteId,
                                          Sexo = a.Sexo,
                                          Telefono = a.Telefono,
                                          TipoDocumentoId = a.TipoDocumentoId,
                                          UbigeoId = a.UbigeoId,
                                      }).FirstOrDefault();
                    return listaFinal;
                }
                 
                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }

        public Paciente ObtenerPaciente(int id)
        {
            try
            {
                
                {
                    //IRepositorio<Paciente> rep = new EfRepositorio<Paciente>(ctx);
                    return _bd.Paciente.Find(id);
                }
            }
            
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }
        }

        public void EliminaPaciente(int id, string usuario)
        {
            
            {
                try
                {
                    //IRepositorio<Paciente> rep = new EfRepositorio<Paciente>(ctx); 
                    var obj = _bd.Paciente.Find(id);
                    obj.FlagActivo = false;
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

        public int RegistrarPaciente(Paciente paciente)
        {
            
            {
                try
                {
                    //IRepositorio<Paciente> rep = new EfRepositorio<Paciente>(ctx);
                    if (paciente.PacienteId == 0)
                    {
                        _bd.Paciente.Add(paciente);
                        _bd.SaveChanges();
                        return paciente.PacienteId;
                    }
                    else
                    {
                        var act = _bd.Paciente.FirstOrDefault(m => m.PacienteId == paciente.PacienteId); act.ApellidoMaterno = paciente.ApellidoMaterno;
                        act.ApellidoPaterno = paciente.ApellidoPaterno;
                        act.Celular = paciente.Celular;
                        act.CorreoElectronico = paciente.CorreoElectronico;
                        act.NroHistoriaClinica = paciente.NroHistoriaClinica;
                        //act.CreadoPor = paciente.CreadoPor;
                        act.Direccion = paciente.Direccion;
                        //act.FechaCreacion = paciente.FechaCreacion;
                        act.FechaModificacion = paciente.FechaModificacion;
                        act.FechaNacimiento = paciente.FechaNacimiento;
                        //act.FlagActivo = paciente.FlagActivo;
                        //act.FlagEliminado = paciente.FlagEliminado;
                        act.ModificadoPor = paciente.ModificadoPor;
                        act.Nombres = paciente.Nombres;
                        act.NumeroDocumento = paciente.NumeroDocumento;
                        act.PacienteId = paciente.PacienteId;
                        act.Sexo = paciente.Sexo;
                        act.Telefono = paciente.Telefono;
                        act.TipoDocumentoId = paciente.TipoDocumentoId;
                        act.UbigeoId = paciente.UbigeoId;
                        //rep.Update(act);
                        _bd.SaveChanges();
                        return act.PacienteId;
                    }
                }
                
                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }
        }

        public Paciente ObtenerPaciente(string nroAseg, string nroHistClinica)
        {
            try
            {
                
                {
                    //IRepositorio<Paciente> rep = new EfRepositorio<Paciente>(ctx);
                    return _bd.Paciente.FirstOrDefault(o => o.NroAsegurado == nroAseg && o.NroHistoriaClinica == nroHistClinica);
                }
            }
             
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }
        }

        public PacienteDto obtenerPacientexOrden(int ordenId)
        {
            
            {
                try
                {
                    //IRepositorio<Paciente> rep = new EfRepositorio<Paciente>(ctx);
                    //IRepositorio<Orden> repOr = new EfRepositorio<Orden>(ctx);
                    var lista = (from a in _bd.Paciente
                                 join b in _bd.Orden on a.PacienteId equals b.PacienteId
                                 where (a.FlagActivo == true)
                                 && b.OrdenId == ordenId
                                 //orderby a.Nombres ascending
                                 select new
                                 {
                                     a.ApellidoMaterno,
                                     a.ApellidoPaterno,
                                     b.FechaCreacion,
                                     a.Edad,
                                     a.Nombres,
                                     a.NumeroDocumento,
                                     a.PacienteId,
                                     a.Sexo,
                                     b.TipoAtencionId
                                 });
                    var listaFinal = (from a in lista.ToList()
                                      select new PacienteDto
                                      {
                                          ApellidoMaterno = a.ApellidoMaterno,
                                          ApellidoPaterno = a.ApellidoPaterno,
                                          FechaCreacion = a.FechaCreacion,
                                          Edad = a.Edad,
                                          Nombres = a.Nombres,
                                          NumeroDocumento = a.NumeroDocumento,
                                          PacienteId = a.PacienteId,
                                          Sexo = a.Sexo,
                                          TipoAtencionId = a.TipoAtencionId



                                      }).FirstOrDefault();
                    return listaFinal;
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
